using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGym.ViewModels
{
    public class AllVendorsViewModel : WszystkieViewModel<Vendors>
    {
        private ObservableCollection<Vendors> _vendorsList;


        public ObservableCollection<Vendors> VendorsList
        {
            get
            {
                if (_vendorsList == null) load();
                return _vendorsList;

            }

            set
            {
                _vendorsList = value; OnPropertyChanged(() => VendorsList);
            }
        }

        public AllVendorsViewModel() : base()
        {
            base.DisplayName = "All vendors";
        }

        public override void load()
        {
            VendorsList = new ObservableCollection<Vendors>(
                base.gymEntities.Vendors
                );
        }

    }
}
