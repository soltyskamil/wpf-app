using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGym.ViewModels
{
    public class EmployeePayrollOverviewData
    {
        public decimal? maxPayNet { get; set; }
        public decimal? minPayNet { get; set; }
        public decimal? maxPayGross { get; set; }
        public decimal? minPayGross { get; set; }


        public decimal? totalValuePayNet { get; set; }
        public decimal? totalValuePayGross { get; set; }

        public decimal? averagePayNet { get; set; }
        public decimal? averagePayGross { get; set; }


    }
    public class EmployeeSummaryRow
    {
        public string name { get; set; }
        public string lastName { get; set; }

        public int ID { get; set; }

        public ObservableCollection<EmployeePayrollOverviewData> overviews { get; set; }
    }

    public class EmployeesSummaryViewModel : WszystkieViewModel<Employees>
    {
        public ObservableCollection<EmployeeSummaryRow> _employeesOverview;
        public ObservableCollection<EmployeeSummaryRow> EmployeesOverview
        {
            get
            {
                if (_employeesOverview == null) load();

                return _employeesOverview;
            }

            set { _employeesOverview = value; OnPropertyChanged(() => EmployeesOverview); }
        }

        public EmployeesSummaryViewModel() : base()
        {
            base.DisplayName = "Employees summary";
        }


        public override void load()
        {
            EmployeesOverview = new ObservableCollection<EmployeeSummaryRow>(
                base.gymEntities.Employees
                .AsNoTracking()
                .Select(e => new EmployeeSummaryRow
                {
                    ID = e.employee_id,
                    lastName = e.last_name,
                    name = e.first_name,
                    overviews = new ObservableCollection<EmployeePayrollOverviewData>
                    {
                        new EmployeePayrollOverviewData
                        {
                        maxPayGross = e.Payrolls.Max(p => p.gross),
                        maxPayNet = e.Payrolls.Max(p => p.net),
                        minPayGross = e.Payrolls.Min(p => p.gross),
                        minPayNet = e.Payrolls.Min(p => p.net),
                        averagePayGross = e.Payrolls.Average(p => p.gross),
                        averagePayNet = e.Payrolls.Average(p => p.net),
                        totalValuePayGross = e.Payrolls.Sum(p => p.gross),
                        totalValuePayNet = e.Payrolls.Sum(p => p.net),
                        }
                    }
                })
            );
        }
    }
}
