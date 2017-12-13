using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calendar.ViewModel
{
    class RelayCommand : ICommand
    {
        readonly Action<Object> _execute;
        public RelayCommand(Action<Object> execute)
        {
            if(execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public Boolean CanExecute(Object parameter)
        {
            return true;
        }

        public void Execute(Object parameter)
        {
            _execute(parameter);
        }
    }
}
