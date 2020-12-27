using EmploymentSystem.BLL.Interfaces;
using JobSeeker.Infrastructure.Commands;
using JobSeeker.Interfaces;
using JobSeeker.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.ViewModels
{
    class VMRecruiterSelection : VMBase
    {
        private readonly IMainNavigation navigation;
        private LogOutCommand logOutCommand;
        public LogOutCommand LogOutCommand => logOutCommand ??
                  (logOutCommand = new LogOutCommand(IoC.IoC.Get<IMainNavigation>(), IoC.IoC.Get<IAuthorizationService>()));

        public VMRecruiterSelection()
        {
            navigation = IoC.IoC.Get<IMainNavigation>();
        }

        private RelayCommand startAdministration;
        public RelayCommand StartAdministration
        {
            get
            {
                return startAdministration ?? (startAdministration = new RelayCommand(obj =>
                {
                    navigation.Navigate(new UserAdministration());
                }));
            }
        }
    }
}
