using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.Data.Entities;
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
    class VMUserAdministration : VMBase
    {
        private readonly IBaseManager baseManager;
        private readonly IMainNavigation navigation;
        public List<UserLine> UserLines { get; set; }

        public VMUserAdministration()
        {
            baseManager = IoC.IoC.Get<IBaseManager>();
            navigation = IoC.IoC.Get<IMainNavigation>();
            UserLines = baseManager.GetAllUserLines();
        }

        private RelayCommand backToAdminSelection;
        public RelayCommand BackToAdminSelection
        {
            get
            {
                return backToAdminSelection ?? (backToAdminSelection = new RelayCommand(obj =>
                {
                    navigation.Navigate(new RecruiterSelection());  
                }));
            }
        }

        private RelayCommand saveChanges;
        public RelayCommand SaveChanges
        {
            get
            {
                return saveChanges ?? (saveChanges = new RelayCommand(obj =>
                {
                    baseManager.Save();
                }));
            }
        }

    }
}
