using MVVMGym.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGym.ViewModels
{
    public class AddNewClassViewModel : FormViewModel<Classes>
    {
        public IReadOnlyList<Branches> Branches { get; set; }
        public IReadOnlyList<string> DifficultyList { get; } = new List<string>() { "easy", "mid", "hard"};
        public IReadOnlyList<Rooms> Rooms { get; set; }

        public IReadOnlyList<Trainers> Trainers { get; set; }

        public AddNewClassViewModel():base() {
            base.DisplayName = "Add class";
            item = new Classes();
            item.created_at = DateTime.Now;
            item.updated_at = DateTime.Now;
            this.Trainers = base.gymEntites.Trainers.ToList();
            this.Branches = base.gymEntites.Branches.ToList();
            this.Rooms = base.gymEntites.Rooms.ToList();
            item.difficulty = "easy";
            item.status = "Aktywne";
            
        }

        public override void Save()
        {
            gymEntites.Classes.Add(item);
            gymEntites.SaveChanges();
        }

        public string Name
        {
            get {
                return item.name;


            }
            set
            {
                if(item.name != value)
                {
                    item.name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        
        }
        public int DurationMinutes
        {
            get
            {
                return item.duration_minutes;


            }
            set
            {
                if (item.duration_minutes != value)
                {
                    item.duration_minutes = value;
                    OnPropertyChanged(() => DurationMinutes);
                }
            }

        }
        public string Difficulty
        {
            get
            {
                return item.difficulty;


            }
            set
            {
                if (item.difficulty != value)
                {
                    item.difficulty = value;
                    OnPropertyChanged(() => Difficulty);
                }
            }

        }
        public string Status
        {
            get
            {
                return item.status;


            }
            set
            {
                if (item.status != value)
                {
                    item.status = value;
                    OnPropertyChanged(() => Status);
                }
            }

        }
        public int SelectedBranchId
        {
            get
            {
                return item.branch_id;


            }
            set
            {
                if (item.branch_id != value)
                {
                    item.branch_id = value;
                    OnPropertyChanged(() => SelectedBranchId);
                }
            }

        }

        public int SelectedTrainerId
        {
            get
            {
                return item.trainer_id;
            }

            set
            {
                if(item.trainer_id != value)
                {
                    item.trainer_id = value;
                    OnPropertyChanged(() => SelectedTrainerId);
                }
            }
        }
        
        public int SelectedRoomId
        {
            get
            {
                return item.room_id;
            }

            set
            {
                if(item.room_id != value)
                {
                    item.room_id = value;
                    OnPropertyChanged(() => SelectedRoomId);
                }
            }
        }

    }
}
