using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JobSeeker.Infrastructure.Commands
{
    class NextQuestionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public NextQuestionCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                if (parameter != null) Console.WriteLine(parameter);
                return false;
            }
            else
            {
                List<int> nums;
                nums = (List<int>)parameter;
                if (nums[0] == nums[1]) return false;
                else return true;
            }
        }

        public void Execute(object parameter) => execute(parameter);
    }
}
