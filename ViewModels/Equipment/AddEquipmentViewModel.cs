using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVVMGym.ViewModels
{
    public class AddEquipmentViewModel : FormViewModel<Equipment>
    {
        public IReadOnlyList<Vendors> Vendors { get; set; }
        public IReadOnlyList<Branches> Branches { get; set; }

        public AddEquipmentViewModel() : base()
        {
            base.DisplayName = "New equipment";
            item = new Equipment();
            item.created_at = DateTime.Now;
            item.updated_at = DateTime.Now;
            Vendors = base.gymEntites.Vendors.ToList();
            Branches = base.gymEntites.Branches.ToList();
        }


        public override void Save()
        {
            gymEntites.Equipment.Add(item);
            gymEntites.SaveChanges();
        }

        public string Name
        {
            get
            {
                return item.name;
            }
            set
            {
                if (item.name != value)
                {
                    item.name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }
        public string Model
        {
            get
            {
                return item.model;
            }
            set
            {
                if (item.model != value)
                {
                    item.model = value;
                    OnPropertyChanged(() => Model);
                }
            }
        }

        public string SerialNumber
        {
            get
            {
                return item.serial_number;
            }
            set
            {
                if (item.serial_number != value)
                {
                    item.serial_number = value;
                    OnPropertyChanged(() => SerialNumber);
                }
            }
        }

        public int Price
        {
            get
            {
                return item.price;
            }
            set
            {
                if (item.price != value)
                {
                    item.price = value;
                    OnPropertyChanged(() => Price);
                }
            }
        }

        public int SelectedVendorId
        {
            get
            {
                return item.vendor_id;
            }
            set
            {
                if (item.vendor_id != value)
                {
                    item.vendor_id = value;
                    OnPropertyChanged(() => SelectedVendorId);
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
