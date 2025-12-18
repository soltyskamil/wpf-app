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

    public class OverviewData
    {
        public string name { get; set; }
        public int count { get; set; }

        public int? totalValue { get; set; }

        public double? average { get; set; }
    }



    public class BranchesSummaryRow
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public TimeSpan openTime { get; set; }
        public TimeSpan closeTime { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public ObservableCollection<OverviewData> overviews { get; set; }

    }


    public class BranchSummaryViewModel : WszystkieViewModel<Branches>
    {
        public ObservableCollection<BranchesSummaryRow> _branchesOverview;
      
        public ObservableCollection<BranchesSummaryRow> BranchesOverview
        {
            get
            {
                if (_branchesOverview == null) load();

                return _branchesOverview;
            }

            set { _branchesOverview = value; OnPropertyChanged(() => BranchesOverview); }
        }

     

        public BranchSummaryViewModel() : base()
        {
            base.DisplayName = "Branches summary";
        }






        public override void load()
        {
            BranchesOverview = new ObservableCollection<BranchesSummaryRow>(
             base.gymEntities.Branches
             .AsNoTracking()
             .Select(i => new BranchesSummaryRow
             {
                 name = i.name,
                 address = i.address,
                 phone = i.phone,
                 openTime = i.open_time,
                 closeTime = i.close_time,
                 createdAt = i.created_at,
                 updatedAt = i.updated_at,
                 overviews = new ObservableCollection<OverviewData>
                 {
                    new OverviewData {name = "Classes", count = i.Classes.Count(), average = null, totalValue = null},
                    new OverviewData {name = "Employees", count = i.Employees.Count(), average = null, totalValue = null},
                    new OverviewData {name = "Equipment", count = i.Equipment.Count(), average = i.Equipment.Average(x => x.price), totalValue = i.Equipment.Sum(x => x.price)},
                    new OverviewData {name = "Rooms", count = i.Rooms.Count(), average = null, totalValue = null},
                    new OverviewData {name = "Trainers", count = i.Trainers.Count(), average = null, totalValue = null},
                    new OverviewData {name = "Members", count = i.Members.Count(), average = null, totalValue = null},
                    new OverviewData {name = "MemberInvoices", count = i.MemberInvoices.Count(), average = i.MemberInvoices.Average(x => x.total_amount), totalValue = i.MemberInvoices.Sum(x => x.total_amount)},
                 }
             }
             )
            );

            
        }

    }
}
