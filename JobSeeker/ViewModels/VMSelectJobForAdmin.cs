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
    class VMSelectJobForAdmin : VMBase
    {
        private readonly IAuthorizationService authorization;
        private readonly IBaseManager baseManager;
        private readonly IMainNavigation navigation;
        private RelayCommand backToAdminSelection;
        private SelectJobCommand selectJobCommand;
        private Job selectedJob;
        public IEnumerable<Job> Jobs
        {
            get
            {
                var jobList = baseManager.GetAllJobs();
                return jobList;
            }
        }
        public Job SelectedJob
        {
            get { return selectedJob; }
            set
            {
                selectedJob = value;
                OnPropertyChanged("SelectedJob");
            }
        }
        public SelectJobCommand SelectJobCommand => selectJobCommand ?? (selectJobCommand = new SelectJobCommand(IoC.IoC.Get<IMainNavigation>(), authorization));
        public RelayCommand BackToAdminSelection
        { 
            get
            {
                return backToAdminSelection ?? (backToAdminSelection = new RelayCommand(obj =>
                {
                    navigation.Navigate(new AdminSelection());
                }));
            }
        }
        public VMSelectJobForAdmin()
        {
            baseManager = IoC.IoC.Get<IBaseManager>();
            authorization = IoC.IoC.Get<IAuthorizationService>();
            navigation = IoC.IoC.Get<IMainNavigation>();
        }
    }
}
