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
    class VMAuthorization : VMBase
    {
        private LogInCommand logInCommand;
        public LogInCommand LogInCommand => logInCommand ??
                  (logInCommand = new LogInCommand(IoC.IoC.Get<IMainNavigation>(), IoC.IoC.Get<IAuthorizationService>()));
    }
}
