using EmploymentSystem.BLL.Interfaces;
using JobSeeker.Infrastructure.Commands;
using JobSeeker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.ViewModels
{
    class VMAdminSelection : VMBase
    {
        private LogOutCommand logOutCommand;
        public LogOutCommand LogOutCommand => logOutCommand ??
                  (logOutCommand = new LogOutCommand(IoC.IoC.Get<IMainNavigation>(), IoC.IoC.Get<IAuthorizationService>()));
    }
}
