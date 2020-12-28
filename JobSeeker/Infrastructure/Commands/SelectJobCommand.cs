using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.Data.Entities;
using GalaSoft.MvvmLight.Messaging;
using JobSeeker.Interfaces;
using JobSeeker.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test = JobSeeker.Views.Pages.Test;

namespace JobSeeker.Infrastructure.Commands
{
    class SelectJobCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly INavigation navigation;
        private readonly IAuthorizationService authorization;

        public SelectJobCommand(INavigation navigation, IAuthorizationService authorization)
        {
            this.navigation = navigation;
            this.authorization = authorization;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var data = parameter as Job;
            var currentUser = authorization.GetCurrentUser();
            if (currentUser is EmploymentSystem.Data.Entities.JobSeeker) navigation.Navigate(new Test());
            else if (currentUser is Admin) navigation.Navigate(new CreateTest());
            Messenger.Default.Send(data);
        }
    }
}
