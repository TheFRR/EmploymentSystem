using EmploymentSystem.BLL;
using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.BLL.Services;
using JobSeeker.Infrastructure.Navigation;
using JobSeeker.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.IoC
{
    class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IBaseManager>().To<BaseManager>().InSingletonScope();
            Bind<IAuthorizationService>().To<AuthorizationService>().InSingletonScope();
            Bind<IMainNavigation>().To<MainNavigation>().InSingletonScope();
        }
    }
}
