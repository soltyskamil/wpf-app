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
    public class EquipmentRow
    {
        public int ID { get; set; }
        public string branchName { get; set; }
        public string name { get; set; }

        public string model { get; set; }

        public string serialNumber { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
        public int price { get; set; }

        public string vendorName { get; set; }
    }

    public class EquipmentViewModel : WszystkieViewModel<Equipment>
    {
        private ObservableCollection<EquipmentRow> _equipmentList;

        public ObservableCollection<EquipmentRow> EquipmentList
        {
            get
            {
                if (_equipmentList == null) load();
                return _equipmentList;
            }
            set
            {
                _equipmentList = value;
                OnPropertyChanged(() => EquipmentList);
            }
        }



        public EquipmentViewModel():base()
        {
            base.DisplayName = "Equipment";
        }

        public override void load()
        {
            EquipmentList = new ObservableCollection<EquipmentRow>(
             base.gymEntities.Equipment
             .Include(r => r.Vendors)
             .Include(r => r.Branches)
             .Select(e => new EquipmentRow
             {
                 ID = e.equipment_id,
                 branchName = e.Branches.name,
                 name = e.name,
                 model = e.model,
                 serialNumber = e.serial_number,
                 createdAt = e.created_at,
                 updatedAt = e.updated_at,
                 price = e.price,
                 vendorName = e.Vendors.first_name
             })
            );
        }

    }
}
