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

namespace JobSeeker.ViewModels
{
    class VMTestResult : VMBase
    {
        private readonly IBaseManager baseManager;
        private readonly IAuthorizationService authorizationService;
        private readonly IMainNavigation navigation;

        private List<UserAnswer> selectedAnswers;
        public int correctAnswers { get; set; }
        public int allAnswers { get; set; }

        private Test currentTest;
        private User currentUser;
        private bool flag = false;

        private BackToTestsCommand backToTestsCommand;
        public BackToTestsCommand BackToTestsCommand => backToTestsCommand ??
                  (backToTestsCommand = new BackToTestsCommand(navigation));

        public VMTestResult()
        {
            Messenger.Default.Register<Test>(this, SetData);
            baseManager = IoC.IoC.Get<IBaseManager>();
            authorizationService = IoC.IoC.Get<IAuthorizationService>();
            navigation = IoC.IoC.Get<IMainNavigation>();
        }

        private void SetData(Test test)
        {
            currentUser = authorizationService.GetCurrentUser();
            currentTest = test;
            selectedAnswers = baseManager.GetAllAnswers().Where(answer => answer.JobSeeker.Id == currentUser.Id && answer.Test.Id == currentTest.Id).ToList();
            allAnswers = baseManager.GetAllQuestions().Where(question => question.Test.Id == currentTest.Id).ToList().Count;
            correctAnswers = selectedAnswers.Where(answer => answer.Variant.Correctness == true).ToList().Count;
            if (flag == false)
            {
                baseManager.CreateUserLine(new UserLine() { Test = currentTest, AllAnswers = allAnswers, CorrectAnswers = correctAnswers, JobSeeker = currentUser, Hired = false });
                flag = true;
            }
            OnPropertyChanged("allAnswers");
            OnPropertyChanged("correctAnswers");
        }
    }
}
