using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGym.ViewModels
{
    public class AddEmployeeViewModel : FormViewModel<Employees>
    {
        public IReadOnlyList<Roles> Roles { get; set; }
        public IReadOnlyList<Branches> Branches { get; set; }
        public IReadOnlyList<string> Sexes { get; } = new List<string>() { "male", "female" };

        public AddEmployeeViewModel() : base()
        {
            base.DisplayName = "New employee";
            item = new Employees();
            item.date_of_birth = DateTime.Today;
            item.created_at = DateTime.Today;
            item.updated_at = DateTime.Today;
            Roles = base.gymEntites.Roles.ToList();
            Branches = base.gymEntites.Branches.ToList();

        }

        public override void Save()
        {
            gymEntites.Employees.Add(item);
            gymEntites.SaveChanges();
        }

        

        public string FirstName
        {
            get
            {
                return item.first_name;
            }
            set
            {
                if (item.first_name != value)
                {
                    item.first_name = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }
        public string LastName
        {
            get
            {
                return item.last_name;
            }
            set
            {
                if (item.last_name != value)
                {
                    item.last_name = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public string Sex
        {
            get
            {
                return item.sex;
            }
            set
            {
                if (item.sex != value)
                {
                    item.sex = value;
                    OnPropertyChanged(() => Sex);

                }
            }
        }
        public DateTime Dob
        {
            get
            {
                return item.date_of_birth;
            }
            set
            {
                if (item.date_of_birth != value)
                {
                    item.date_of_birth = value;
                    OnPropertyChanged(() => Dob);
                }
            }
        }
        public int SelectedRoleId
        {
            get
            {


                return item.role_id;
            }
            set
            {
                if (item.role_id != value)
                {
                    item.role_id = value;
                    OnPropertyChanged(() => SelectedRoleId);
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
    }
}
