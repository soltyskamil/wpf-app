using MVVMGym.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVMGym.ViewModels
{
    public class OthersDashboardViewModel : WorkspaceViewModel
    {
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        public ReadOnlyCollection<CommandViewModel> Commands { get { if (_Commands == null) { List<CommandViewModel> cmds = this.CreateCommands(); _Commands = new ReadOnlyCollection<CommandViewModel>(cmds); } return _Commands; } }
        private readonly BranchesViewModel _all = new BranchesViewModel();
        private readonly NewBranchViewModel _add = new NewBranchViewModel();
        private readonly BranchSummaryViewModel _summary = new BranchSummaryViewModel();

        private dynamic _currentPage { get; set; }


        public dynamic CurrentPage
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
                new CommandViewModel("Summary", "TableAccount", new BaseCommand(() => this.ShowAllEquipment())),
                new CommandViewModel("Add branch","Plus" ,new BaseCommand(() => this.ShowAddEquipment())),
                new CommandViewModel("All branches", "TableAccount", new BaseCommand(() => this.ShowAllEquipment())),

            };
        }

        private void ShowSummaryBranches()
        {
            this.CurrentPage = _summary;
            this.SetActiveWorkspace(CurrentPage);
        }


        private void ShowAllEquipment()
        {
            this.CurrentPage = _all;
            this.SetActiveWorkspace(CurrentPage);
        }

        private void ShowAddEquipment()
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
