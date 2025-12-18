using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace MVVMGym.ViewModels
{
    public class ClassesRow
    {
        public int class_id { get; set; }
        public string name { get; set; }
        public int durationMinutes { get; set; }
        public string difficulty { get; set; }
        public string status { get; set; }
        public string branchName { get; set; }

        public string trainerName { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }


    public class AllClassesViewModel : WszystkieViewModel<Classes>
    {
        private ObservableCollection<ClassesRow> _classesList;

        public ObservableCollection<ClassesRow> ClassesList
        {
            get
            {
                if (_classesList == null) load();
                return _classesList;
            }
            set
            {
                _classesList = value;
                OnPropertyChanged(() =>  ClassesList);
            }
        }
        public AllClassesViewModel() : base() {
            base.DisplayName = "All classes";
        }

        public override void load()
        {
            ClassesList = new ObservableCollection<ClassesRow>(
                base.gymEntities.Classes
                .Include(r => r.Branches)
                .Include(r => r.Trainers)
                .Select(c => new ClassesRow
                {
                    class_id = c.class_id,
                    name = c.name,
                    durationMinutes = c.duration_minutes,
                    difficulty = c.difficulty,
                    status = c.status,
                    branchName = c.Branches.name,
                    trainerName = c.Trainers.first_name,
                    createdAt = c.created_at,
                    updatedAt = c.updated_at,
                })
               );
        }

    }
}
