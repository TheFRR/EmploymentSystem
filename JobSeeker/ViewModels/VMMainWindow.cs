using EmploymentSystem.BLL.Interfaces;
using JobSeeker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JobSeeker.ViewModels
{
    class VMMainWindow : VMBase
    {
        private readonly IMainNavigation navigation;
        private readonly IAuthorizationService authorization;

        public Page CurrentPage => navigation.CurrentPage;

        public VMMainWindow()
        {
            navigation = IoC.IoC.Get<IMainNavigation>();
            authorization = IoC.IoC.Get<IAuthorizationService>();

            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.Navigate(authorization.GetCurrentUser());
        }
    }
}
