using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGym.ViewModels
{
    public class VendorOverviewData
    {
        public string name { get; set; }

        public int count { get; set; }
        public int totalValue { get; set; }
        public double? average { get; set; }
    }


    public class VendorSummaryRow
    {
        public string name { get; set; }
        public string lastName { get; set; }

        public int ID { get; set; }

        public ObservableCollection<VendorOverviewData> overviews { get; set; }
    }
    public class VendorsSummaryViewModel : WszystkieViewModel<Vendors>
    {
        public ObservableCollection<VendorSummaryRow> _vendorsOverview;
        public ObservableCollection<VendorSummaryRow> VendorsOverview
        {
            get
            {
                if (_vendorsOverview == null) load();

                return _vendorsOverview;
            }

            set { _vendorsOverview = value; OnPropertyChanged(() => VendorsOverview); }
        }


        public VendorsSummaryViewModel() : base()
        {
            base.DisplayName = "Vendors summary";
        }

        public override void load()
        {
            VendorsOverview = new ObservableCollection<VendorSummaryRow>(
                base.gymEntities.Vendors
                .AsNoTracking()
                .Select(v => new VendorSummaryRow
                {
                    ID = v.vendor_id,
                    name = v.first_name,
                    lastName = v.last_name,
                    overviews = new ObservableCollection<VendorOverviewData> {
                        new VendorOverviewData { name = "Invoices", count = v.Invoices.Count(), average = (double)v.Invoices.Average(x => x.total_amount), totalValue = (int)v.Invoices.Sum(x => x.total_amount) },
                        new VendorOverviewData { name = "Equipment", count = v.Equipment.Count(), average = (double)v.Equipment.Average(x => x.price), totalValue = (int)v.Equipment.Sum(x => x.price) }

                    }
                })
         );
        }
    }
}
