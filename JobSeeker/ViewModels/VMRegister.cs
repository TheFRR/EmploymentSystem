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
    class VMRegister : VMBase
    {
        private readonly IMainNavigation navigation;

        public VMRegister()
        {
            navigation = IoC.IoC.Get<IMainNavigation>();
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return backCommand ?? (backCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new AdminSelection());
                }));
            }
        }

        private CreateNewUserCommand createNewUserCommand;
        public CreateNewUserCommand CreateNewUserCommand => createNewUserCommand ??
            (createNewUserCommand = new CreateNewUserCommand(IoC.IoC.Get<IBaseManager>(), IoC.IoC.Get<IMainNavigation>()));
    }
}
