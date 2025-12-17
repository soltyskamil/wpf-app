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
            base.DisplayName = "New branch";
            item = new Branches();
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
                return item.openTime;
            }
            set
            {
                if (item.openTime != value)
                {
                    
                    item.openTime = value;
                    OnPropertyChanged(() => OpenTime);
                }
            }
        }
        public TimeSpan CloseTime
        {
            get
            {
                return item.closeTime;
            }
            set
            {
                if (item.closeTime != value)
                {
                    item.closeTime = value;
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
