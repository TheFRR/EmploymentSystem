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

namespace JobSeeker.Infrastructure.Commands
{
    class EndTestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly IMainNavigation navigation;
        private readonly IBaseManager baseManager;

        public EndTestCommand(IMainNavigation navigation, IBaseManager baseManager)
        {
            this.navigation = navigation;
            this.baseManager = baseManager;
        }

        public bool CanExecute(object parameter)
        {
            var data = parameter as EmploymentSystem.Data.Entities.Test;
            return data != null;
        }

        public void Execute(object parameter)
        {
            var data = parameter as EmploymentSystem.Data.Entities.Test;
            baseManager.UpdateJob(data.Job, false);
            navigation.Navigate(new TestResult());
            Messenger.Default.Send(data);
        }
    }
}
