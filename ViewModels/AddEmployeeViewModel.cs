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
            item.dob = DateTime.Today;
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
                return item.firstName;
            }
            set
            {
                if (item.firstName != value)
                {
                    item.firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }
        public string LastName
        {
            get
            {
                return item.lastName;
            }
            set
            {
                if (item.lastName != value)
                {
                    item.lastName = value;
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
                return item.dob;
            }
            set
            {
                if (item.dob != value)
                {
                    item.dob = value;
                    OnPropertyChanged(() => Dob);
                }
            }
        }
        public int SelectedRoleId
        {
            get
            {


                return item.roleId;
            }
            set
            {
                if (item.roleId != value)
                {
                    item.roleId = value;
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
