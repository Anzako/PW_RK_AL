using System;
using System.Windows.Input;

namespace ViewModel
{
    internal class RelayCommand : ICommand
    {
        private readonly Action _m_Execute;
        private readonly Func<bool> _m_CanExecute;

        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _m_CanExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_m_CanExecute == null)
            {
                return true;
            }

            if (parameter == null)
            {
                return _m_CanExecute();
            }

            return _m_CanExecute();
        }

        public void Execute(object parameter)
        {
            _m_Execute();
        }
    }
}
