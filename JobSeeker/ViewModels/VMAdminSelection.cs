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
    class VMAdminSelection : VMBase
    {
        private readonly IMainNavigation navigation;
        private LogOutCommand logOutCommand;
        public LogOutCommand LogOutCommand => logOutCommand ??
                  (logOutCommand = new LogOutCommand(IoC.IoC.Get<IMainNavigation>(), IoC.IoC.Get<IAuthorizationService>()));

        private StartTestCreationCommand startTestCreationCommand;
        public StartTestCreationCommand StartTestCreationCommand => startTestCreationCommand ??
            (startTestCreationCommand = new StartTestCreationCommand((IoC.IoC.Get<IMainNavigation>())));

        public VMAdminSelection()
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

        private RelayCommand checkReport;
        public RelayCommand CheckReport
        {
            get
            {
                return checkReport ?? (checkReport = new RelayCommand(obj =>
                {
                    navigation.Navigate(new Report());
                }));
            }
        }

        private RelayCommand createNewUser;
        public RelayCommand CreateNewUser
        {
            get
            {
                return createNewUser ?? (createNewUser = new RelayCommand(obj =>
                {
                    navigation.Navigate(new Register());
                }));
            }
        }
    }
}
