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
    public class ClassesDashboardViewModel : WorkspaceViewModel
    {
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;

        public ReadOnlyCollection<CommandViewModel> Commands { get { if (_Commands == null) { List<CommandViewModel> cmds = this.CreateCommands(); _Commands = new ReadOnlyCollection<CommandViewModel>(cmds); } return _Commands; } }
        private readonly AllClassesViewModel _summary = new AllClassesViewModel();
        private readonly AddNewClassViewModel _add = new AddNewClassViewModel();


        public dynamic _currentPage { get; set; }

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
                new CommandViewModel("Add class","Plus" ,new BaseCommand(() => this.ShowAddEquipment())),
                new CommandViewModel("All classess", "TableAccount", new BaseCommand(() => this.ShowAllEquipment())),
            };
        }

        private void ShowAllEquipment()
        {
            this.CurrentPage = _add;
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
