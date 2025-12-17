using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMGym.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties

        public ICommand Command { get; private set; }



        #endregion

        #region Constructor


        public CommandViewModel(string displayName,string icon, ICommand command)
        {
            if(command == null) throw new ArgumentNullException("command");
            this.DisplayName = displayName;
            this.Command = command;
            this.Icon = icon;
        }

        #endregion


    }
}
