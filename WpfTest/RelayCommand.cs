using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTest
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_executeMethod == null)
                throw new NotImplementedException("Your command action was not implemented");
            _executeMethod(parameter);
        }

        Action<object> _executeMethod;

        Predicate<object> _canExecuteMethod;

        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            _executeMethod = action;
            _canExecuteMethod = canExecute;
        }
    }
}
