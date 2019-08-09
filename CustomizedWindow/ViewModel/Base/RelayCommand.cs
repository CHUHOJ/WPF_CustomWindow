using System;
using System.Windows.Input;

namespace CustomizedWindow
{
    public class RelayCommand : ICommand
    {

        private Action mAction;
        /// <summary>
        /// The event thats fires when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion

        /// <summary>
        /// RelayCommand can always excuted
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
