using MVVMGym.Helper;
using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMGym.ViewModels
{
    public class BranchesViewModel : WszystkieViewModel<Branches>
    {
        private BaseCommand _LoadCommand;
        private ObservableCollection<Branches> _branchesList;


        public ObservableCollection<Branches> BranchesList
        {
            get
            {
                if (_branchesList == null) load();

                return _branchesList;
            }

            set { _branchesList = value; OnPropertyChanged(() => BranchesList); }
        }

        public BranchesViewModel() : base()
        {

            base.DisplayName = "Wszystkie siłownie";
        }

        public override void load()
        {
            BranchesList = new ObservableCollection<Branches>(
                base.gymEntities.Branches.ToList()
                );
        }

       


    }
}
