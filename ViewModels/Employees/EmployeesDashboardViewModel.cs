using MVVMGym.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMGym.ViewModels
{
    public class EmployeesDashboardViewModel : WorkspaceViewModel
    {
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        public ReadOnlyCollection<CommandViewModel> Commands { get { if (_Commands == null) { List<CommandViewModel> cmds = this.CreateCommands(); _Commands = new ReadOnlyCollection<CommandViewModel>(cmds); } return _Commands; } }
        private readonly EmployeesSummaryViewModel _summary = new EmployeesSummaryViewModel();
        private readonly AddEmployeeViewModel _add = new AddEmployeeViewModel();
        private readonly AllEmployeesViewModel _all = new AllEmployeesViewModel();
        private object _currentPage { get; set; }


        public object CurrentPage
        {
            get
            {
                return _currentPage;
            }
            private set
            {
                _currentPage = value;
                OnPropertyChanged(() => CurrentPage);
            }
        }



        public List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel> {
                //employees
                new CommandViewModel("All employees","AccountGroup" ,new BaseCommand(() => this.ShowAllEmployees())),
                new CommandViewModel("Add employee","AccountPlus" ,new BaseCommand(() => this.ShowAddEmployee())),
                new CommandViewModel("Employees summary", "TableAccount", new BaseCommand(() => this.ShowEmployeesSummary())),
            };
        }
        private void ShowEmployeesSummary()
        {
            this.CurrentPage = _summary;
            this.SetActiveWorkspace(CurrentPage);
        }

        private void ShowAllEmployees()
        {
            this.CurrentPage = _all;
            this.SetActiveWorkspace(CurrentPage);

        }

        private void ShowAddEmployee()
        {
            this.CurrentPage = _add;
            this.SetActiveWorkspace(CurrentPage);

        }

        private void SetActiveWorkspace(dynamic workspace)
        {

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.CurrentPage);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

    }
}
