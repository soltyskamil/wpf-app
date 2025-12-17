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
using System.Windows;
using System.Windows.Data;

namespace MVVMGym.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields

        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        private Boolean _SidebarExpanded = true;
        public GridLength SidebarWidth => SidebarExpanded ? GridLength.Auto : new GridLength(100);
        public Boolean SidebarExpanded { get => _SidebarExpanded; set { _SidebarExpanded = value; OnPropertyChanged(() => SidebarWidth); } }

        #endregion

        public ReadOnlyCollection<CommandViewModel> Commands { get { if (_Commands == null) { List<CommandViewModel> cmds = this.CreateCommands(); _Commands = new ReadOnlyCollection<CommandViewModel>(cmds); } return _Commands; } }


        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel> {
                new CommandViewModel("Employees","AccountGroup" ,new BaseCommand(() => this.ShowAllEmployees())),
                new CommandViewModel("Add employee","AccountGroup" ,new BaseCommand(() => this.ShowAddNewEmployee())),
                new CommandViewModel("Promotions", "PercentCircle",new BaseCommand(() => this.ShowAllPromotions())),
                new CommandViewModel("Membership plans","WeightLifter", new BaseCommand(() => this.ShowAllMembershipPlans())),
                new CommandViewModel("Branches", "SourceBranch", new BaseCommand(() => this.ShowAllBranches())),
                new CommandViewModel("NewBranch", "SourceBranchPlus", new BaseCommand(() => this.ShowNewBranch())),
                new CommandViewModel("All vendors", "SourceBranchPlus", new BaseCommand(() => this.ShowAllVendors())),
                new CommandViewModel("New vendor", "AccountGroup", new BaseCommand(() => this.ShowAddVendor())),
            };
        }



        #region Helpers
        private void ShowAllVendors()
        {
            AllVendorsViewModel workspace = this.Workspaces.FirstOrDefault(
                vm => vm is AllVendorsViewModel
                ) as AllVendorsViewModel;

            if (workspace == null)
            {
                workspace = new AllVendorsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAddVendor()
        {
            AddVendorViewModel workspace = this.Workspaces.FirstOrDefault(
                vm => vm is AddVendorViewModel
                ) as AddVendorViewModel;

            if (workspace == null)
            {
                workspace = new AddVendorViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }


        private void ShowAllEmployees()
        {

            AllEmployeesViewModel workspace =
                this.Workspaces.FirstOrDefault(
                    wm => wm is AllEmployeesViewModel
            ) as AllEmployeesViewModel;


            if (workspace == null)
            {
                workspace = new AllEmployeesViewModel();
                this.Workspaces.Add(workspace);

            }

            this.SetActiveWorkspace(workspace);

        }

        private void ShowAddNewEmployee()
        {

            AddEmployeeViewModel workspace =
                this.Workspaces.FirstOrDefault(
                    wm => wm is AddEmployeeViewModel
            ) as AddEmployeeViewModel;


            if (workspace == null)
            {
                workspace = new AddEmployeeViewModel();
                this.Workspaces.Add(workspace);

            }

            this.SetActiveWorkspace(workspace);

        }

        private void ShowAllMembershipPlans()
        {

            MembershipPlansViewModel workspace =
                this.Workspaces.FirstOrDefault(
                    wm => wm is MembershipPlansViewModel
            ) as MembershipPlansViewModel;


            if (workspace == null)
            {
                workspace = new MembershipPlansViewModel();
                this.Workspaces.Add(workspace);

            }

            this.SetActiveWorkspace(workspace);

        }

        private void ShowAllBranches()
        {

            BranchesViewModel workspace =
                this.Workspaces.FirstOrDefault(
                    wm => wm is BranchesViewModel
            ) as BranchesViewModel;


            if (workspace == null)
            {
                workspace = new BranchesViewModel();
                this.Workspaces.Add(workspace);

            }

            this.SetActiveWorkspace(workspace);

        }

        private void ShowNewBranch()
        {

            NewBranchViewModel workspace =
                this.Workspaces.FirstOrDefault(
                    wm => wm is NewBranchViewModel
            ) as NewBranchViewModel;


            if (workspace == null)
            {
                workspace = new NewBranchViewModel();
                this.Workspaces.Add(workspace);

            }

            this.SetActiveWorkspace(workspace);

        }


        private void ShowAllPromotions()
        {

            PromotionsViewModel workspace =
                this.Workspaces.FirstOrDefault(
                    wm => wm is PromotionsViewModel
            ) as PromotionsViewModel;


            if (workspace == null)
            {
                workspace = new PromotionsViewModel();
                this.Workspaces.Add(workspace);

            }





            this.SetActiveWorkspace(workspace);

        }


        #endregion

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }

        #region Workspaces

        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
    }



}
