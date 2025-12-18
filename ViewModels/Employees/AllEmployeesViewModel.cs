using MVVMGym.Helper;
using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.Entity;
namespace MVVMGym.ViewModels
{
    public class EmployeeRow
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string sex { get; set; }

        public DateTime dob { get; set; }

        public string Role { get; set; }

        public string Branch { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }


    public class AllEmployeesViewModel : WszystkieViewModel<Employees>
    {

        private BaseCommand _LoadCommand;

        private ObservableCollection<EmployeeRow> _employeesList;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) { _LoadCommand = new BaseCommand(() => load()); }
                return _LoadCommand;
            }
        }
        public ObservableCollection<EmployeeRow> EmployeesList
        {
            get
            {
                if (_employeesList == null) load();

                return _employeesList;
            }

            set
            {
                _employeesList = value; OnPropertyChanged(() => EmployeesList);
            }
        }

        public AllEmployeesViewModel() : base()
        {
            base.DisplayName = "All employees";
        }

        public override void load()
        {
            EmployeesList = new ObservableCollection<EmployeeRow>(
                base.gymEntities.Employees.Include(e => e.Branches)
                .Include(e => e.Roles)
                .Select(i => new EmployeeRow
                {
                    ID = i.employee_id,
                    firstName = i.first_name,
                    lastName = i.last_name,
                    sex = i.sex,
                    dob = i.date_of_birth,
                    Role = i.Roles.code,
                    Branch = i.Branches.name,
                    createdAt = i.created_at,
                    updatedAt = i.updated_at,
                }
                )
               );
        }

    }
}
