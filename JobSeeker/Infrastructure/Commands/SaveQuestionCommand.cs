using EmploymentSystem.Data.Entities;
using JobSeeker.Infrastructure.Structures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JobSeeker.Infrastructure.Commands
{
    class SaveQuestionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public SaveQuestionCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            var data = parameter as CreateTestData;
            if (data == null) return false;
            else
            {
                ObservableCollection<Variant> variants = (ObservableCollection<Variant>)data.VariantsItems.ItemsSource;
                foreach (Variant variant in variants)
                    if (string.IsNullOrEmpty(variant.Text)) return false;
                if (string.IsNullOrEmpty(data.QuestionText)) return false;
                else return true;
            }
        }

        public void Execute(object parameter) => execute(parameter);
    }
}
