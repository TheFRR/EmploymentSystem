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

        public SelectJobCommand(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var data = parameter as Job;
            navigation.Navigate(new Test());
            Messenger.Default.Send(data);
        }
    }
}
