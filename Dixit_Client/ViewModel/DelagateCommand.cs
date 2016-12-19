using System;
using System.Windows.Input;

namespace Dixit_Client.ViewModel
{
    /// <summary>
    /// Common command type
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Lambda expression to execute action
        /// </summary>
        private readonly Action<Object> _Execute; 
        /// <summary>
        /// Lambda expression to check action's condition
        /// </summary>
        private readonly Func<Object, Boolean> _CanExecute;

        /// <summary>
        /// Create command
        /// </summary>
        /// <param name="execute">Action to be executed</param>
        public DelegateCommand(Action<Object> execute) : this(null, execute) { }

        /// <summary>
        /// Create command
        /// </summary>
        /// <param name="canExecute">Condition for executability</param>
        /// <param name="execute">Action to be executed</param>
        public DelegateCommand(Func<Object, Boolean> canExecute, Action<Object> execute)
        {
            if (execute == null) {
                throw new ArgumentNullException("execute");
            }

            _Execute = execute;
            _CanExecute = canExecute;
        }

        /// <summary>
        /// Executability state change
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Check for executability
        /// </summary>
        /// <param name="parameter">Action's parameter</param>
        /// <returns>True if the action is executable</returns>
        public Boolean CanExecute(Object parameter)
        {
            return _CanExecute == null ? true : _CanExecute(parameter);
        }

        /// <summary>
        /// Execute action
        /// </summary>
        /// <param name="parameter">Action's parameter</param>
        public void Execute(Object parameter)
        {
            _Execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null) {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)(() => { CanExecuteChanged(this, EventArgs.Empty); }));
            }
        }
    }
}
