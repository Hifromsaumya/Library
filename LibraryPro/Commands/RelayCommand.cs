using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace LibraryPro.Commands
{
    public class RelayCommand : ICommand
    {
        private Action Del; //----this delegate will hold reference to a method in VM
        //----Action doesn't take any parameter and returns nothing, stores ref of method w rtrn type void and no pm

        public RelayCommand(Action del)
        {
            this.Del = del;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) //----whenever bind controls with Class RC, this methode will make sure if it's enabled or disabled
        {
            return true;
        }

        public void Execute(object parameter) //----if button could be used, this method will perform logic
        {
            //----will execute method pointed by delegate
            Del();
        }
    }
}
