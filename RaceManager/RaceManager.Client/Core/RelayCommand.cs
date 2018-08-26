using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RaceManager.Client.Core
{
    class RelayCommand : ICommand
    {
        private Action _executeMethod;
        private Func<bool> _canExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }

            if (_executeMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            _executeMethod?.Invoke();
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
