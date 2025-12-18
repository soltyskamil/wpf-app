using MVVMGym.Helper;
using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMGym.ViewModels
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        protected readonly MVVMGymEntities gymEntities;

        private BaseCommand _LoadCommand;

        public WszystkieViewModel()
        {
            this.gymEntities = new MVVMGymEntities();
        }

        private ObservableCollection<T> _List;
        public ICommand LoadCommand
        {
            get { return GetCommand(_LoadCommand, load); }
        }


        public ObservableCollection<T> List
        {
            get { 
                
            if (_List == null) load();
            
            return _List;
            }

            set { _List = value; OnPropertyChanged(() => List); }

        }

        #region Constructor


        #region helpers

        public abstract void load();
        #endregion

        #endregion
    }
}
