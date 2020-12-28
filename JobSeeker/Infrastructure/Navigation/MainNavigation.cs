using EmploymentSystem.Data.Entities;
using JobSeeker.Interfaces;
using JobSeeker.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Infrastructure.Navigation
{
    class MainNavigation : BaseNavigation, IMainNavigation
    {
        public void Navigate(User user)
        {
            if (user == null)
            {
                Navigate(new Authorization());
            }
            else if (user is EmploymentSystem.Data.Entities.JobSeeker)
            {
                Navigate(new SelectJob());
            }
            else if (user is Admin)
            {
                Navigate(new AdminSelection());
            }
        }

    }
}
