using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.Data.Entities;
using GalaSoft.MvvmLight.Messaging;
using JobSeeker.Infrastructure.Commands;
using JobSeeker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JobSeeker.ViewModels
{
    class VMSelectJob : VMBase
    {
        private readonly IAuthorizationService authorization;
        private readonly IBaseManager baseManager;
        private LogOutCommand logOutCommand;
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
        public LogOutCommand LogOutCommand => logOutCommand ??
                  (logOutCommand = new LogOutCommand(IoC.IoC.Get<IMainNavigation>(), authorization));
        public SelectJobCommand SelectJobCommand => selectJobCommand ?? (selectJobCommand = new SelectJobCommand(IoC.IoC.Get<IMainNavigation>()));
        public VMSelectJob()
        {
            baseManager = IoC.IoC.Get<IBaseManager>();
            authorization = IoC.IoC.Get<IAuthorizationService>();
            foreach (Test test in baseManager.GetAllTests())
            {
                var answers = baseManager.GetAllUserAnswers().Where(answer => answer.JobSeeker.Id == authorization.GetCurrentUser().Id && answer.Test.Id == test.Id).ToList();
                if (answers.Count == 0) test.Available = true;
            }
        }
    }
}
