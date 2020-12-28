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
    class EndTestCreationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly IMainNavigation navigation;

        public EndTestCreationCommand(IMainNavigation navigation)
        {
            this.navigation = navigation;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            navigation.Navigate(new AdminSelection());
        }
    }
}
