using EmploymentSystem.BLL.Interfaces;
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
    class LogOutCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly IMainNavigation navigation;
        private readonly IAuthorizationService authorization;

        public LogOutCommand(IMainNavigation navigation, IAuthorizationService authorization)
        {
            this.navigation = navigation;
            this.authorization = authorization;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            authorization.LogOut();
            navigation.Navigate(new Authorization());
        }
    }
}
