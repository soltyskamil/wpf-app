using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGym.ViewModels
{
    public class NewBranchViewModel : FormViewModel<Branches>
    {
        public IReadOnlyList<TimeSpan> AvaiableHours { get; } = Enumerable.Range(0, 24).Select(h => TimeSpan.FromHours(h)).ToList();


        public NewBranchViewModel() : base()
        {
            base.DisplayName = "Add branch";
            item = new Branches();
            item.created_at = DateTime.Now;
            item.updated_at = DateTime.Now;
        }

        public string Phone
        {
            get
            {
                return item.phone;
            }
            set
            {
                if (item.phone != value)
                {
                    item.phone = value;
                    OnPropertyChanged(() => Phone);
                }
            }
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
        public TimeSpan OpenTime
        { 
            get
            {
                return item.open_time;
            }
            set
            {
                if (item.open_time != value)
                {
                    
                    item.open_time = value;
                    OnPropertyChanged(() => OpenTime);
                }
            }
        }
        public TimeSpan CloseTime
        {
            get
            {
                return item.close_time;
            }
            set
            {
                if (item.close_time != value)
                {
                    item.close_time = value;
                    OnPropertyChanged(() => CloseTime);
                }
            }
        }

        public string Address
        {
            get
            {
                return item.address;
            }
            set
            {
                if (item.address != value)
                {
                    item.address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }




        public override void Save()
        {
            gymEntites.Branches.Add(item);//to jest dodanie towaru do kolekcji towarow
            gymEntites.SaveChanges();  //to jest zapisanie danych do bazy danych
        }
    }
}
