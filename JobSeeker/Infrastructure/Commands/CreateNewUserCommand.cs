using EmploymentSystem.BLL.Interfaces;
using JobSeeker.Infrastructure.Structures;
using JobSeeker.Interfaces;
using JobSeeker.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JobSeeker.Infrastructure.Commands
{
    class CreateNewUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly IBaseManager baseManager;
        private readonly INavigation navigation;

        public CreateNewUserCommand(IBaseManager baseManager, INavigation navigation)
        {
            this.baseManager = baseManager;
            this.navigation = navigation;
        }

        public bool CanExecute(object parameter)
        {
            var data = parameter as RegistrationData;
            return data != null && !string.IsNullOrEmpty(data.Login) 
                && !string.IsNullOrEmpty(data.Name) && !string.IsNullOrEmpty(data.Surname);
        }

        public void Execute(object parameter)
        {
            var data = parameter as RegistrationData;
            baseManager.CreateJobSeeker(new EmploymentSystem.Data.Entities.JobSeeker { FirstName = data.Name, LastName = data.Surname, Login = data.Login, Password = data.PasswordBox.Password });
            navigation.Navigate(new AdminSelection());
        }
    }
}
