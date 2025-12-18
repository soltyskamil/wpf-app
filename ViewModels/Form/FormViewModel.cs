using MVVMGym.Helper;
using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMGym.ViewModels
{
    public abstract class FormViewModel<T> : WorkspaceViewModel
    {

        protected MVVMGymEntities gymEntites;
        protected T item;

        public FormViewModel()
        {
            gymEntites = new MVVMGymEntities();
        }


        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null) _SaveAndCloseCommand = new BaseCommand(saveAndClose);
                return _SaveAndCloseCommand;
            }
        }


        public abstract void Save();

        private void saveAndClose()
        {
            Save();

            OnRequestClose();
        }


    }
}
