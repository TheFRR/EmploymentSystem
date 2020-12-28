using EmploymentSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JobSeeker.Infrastructure.Commands
{
    class AddVariantCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public AddVariantCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            ObservableCollection<Variant> data = (ObservableCollection<Variant>)parameter;
            if (data == null || data.Count < 4) return true;
            else return false;
        }
        
        public void Execute(object parameter) => execute(parameter);
    }
}
