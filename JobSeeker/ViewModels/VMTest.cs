using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.Data.Entities;
using GalaSoft.MvvmLight.Messaging;
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
    class VMTest : VMBase
    {
        private readonly IBaseManager baseManager;
        private readonly IAuthorizationService authorizationService;
        private readonly IMainNavigation navigation;

        private User currentUser;
        private Job selectedJob;
        private Variant variant;
        private List<Question> questions;
        private List<Question> selectedQuestions;
        private List<EmploymentSystem.Data.Entities.Test> tests;
        private List<EmploymentSystem.Data.Entities.Test> selectedTests;
        public EmploymentSystem.Data.Entities.Test currentTest { get; set; }
        private int i = 0;

        public List<int> currentNumbers { get; set; }
        public Question currentQuestion
        {
            get
            {
                return selectedQuestions[i];
            }
        }
        public List<Variant> Variants
        {
            get
            {
                return baseManager.GetAllVariants().Where(variant => variant.Question.Id == selectedQuestions[i].Id).ToList();
            }
        }
        public Variant SelectedVariant
        {
            get 
            {
                return variant; 
            }
            set
            {
                variant = value;
                OnPropertyChanged("SelectedVariant");
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

        public VMTest()
        {
            Messenger.Default.Register<Job>(this, SetData);

            baseManager = IoC.IoC.Get<IBaseManager>();
            authorizationService = IoC.IoC.Get<IAuthorizationService>();
            navigation = IoC.IoC.Get<IMainNavigation>();
            currentUser = authorizationService.GetCurrentUser();
            selectedQuestions = new List<Question>();
            selectedQuestions.Add(new Question() { Text = "" });
            currentNumbers = new List<int>();
            currentNumbers.Add(0);
            currentNumbers.Add(1);
        }

        private NextQuestionCommand nextQuestion;
        public NextQuestionCommand NextQuestion
        {
            get
            {
                return nextQuestion ?? (nextQuestion = new NextQuestionCommand(obj =>
                {
                    if (i != selectedQuestions.Count - 1)
                    {
                        currentNumbers[0]++;
                        i++;
                        OnPropertyChanged("currentQuestion");
                        OnPropertyChanged("currentNumbers");
                        OnPropertyChanged("Variants");
                    }
                }));
            }
        }

        private PreviousQuestionCommand previousQuestion;
        public PreviousQuestionCommand PreviousQuestion
        {

            get
            {
                return previousQuestion ?? (previousQuestion = new PreviousQuestionCommand(obj =>
                {
                    
                    if (i != 0)
                    {
                        currentNumbers[0]--;
                        i--;
                        OnPropertyChanged("currentQuestion");
                        OnPropertyChanged("currentNumbers");
                        OnPropertyChanged("Variants");
                    }
                }));
            }
        }

        private ConfirmAnswerCommand confirmAnswerCommand;
        public ConfirmAnswerCommand ConfirmAnswerCommand
        {
            get 
            {
                return confirmAnswerCommand ?? (confirmAnswerCommand = new ConfirmAnswerCommand(obj =>
                {
                    baseManager.SetAnswer(new UserAnswer() { JobSeeker = currentUser, Question = currentQuestion, Test = currentTest, Variant = SelectedVariant });
                    if (currentNumbers[0] != currentNumbers[1])
                    {
                        currentNumbers[0]++;
                        i++;
                        OnPropertyChanged("currentQuestion");
                        OnPropertyChanged("currentNumbers");
                        OnPropertyChanged("Variants");
                        OnPropertyChanged("SelectedVariant");

                    }
                    else
                    {
                        currentTest.Available = false;
                        baseManager.UpdateTest(currentTest);
                        navigation.Navigate(new TestResult());
                        Messenger.Default.Send(currentTest);
                    }
                }));
            }
        }

        private EndTestCommand endTestCommand;
        public EndTestCommand EndTestCommand => endTestCommand ??
                  (endTestCommand = new EndTestCommand(IoC.IoC.Get<IMainNavigation>()));

        private int SelectRandomValue(int n)
        {
            Random rnd = new Random();
            return rnd.Next(0, n);
        }

        private void SetData(Job job)
        {
            SelectedJob = job;
            SetTestsData();
            SetQuestionsData();
            SetNumbersData();
            OnPropertyChanged("currentNumbers");
            OnPropertyChanged("currentQuestion");
            OnPropertyChanged("Variants");
            bool flag = false;
            foreach (EmploymentSystem.Data.Entities.Test test in selectedTests)
                if (test.Available == true) flag = true;
            if (flag == false) navigation.Navigate(new LackOfTests());
        }

        private void SetTestsData()
        {
            tests = new List<EmploymentSystem.Data.Entities.Test>();
            tests = baseManager.GetAllTests();
            selectedTests = new List<EmploymentSystem.Data.Entities.Test>();
            selectedTests = tests.FindAll(test => test.Job.Id == SelectedJob.Id).ToList();
            currentTest = selectedTests[SelectRandomValue(selectedTests.Count)];
            OnPropertyChanged("currentTest");
        }
        private void SetQuestionsData()
        {
            questions = new List<Question>();
            selectedQuestions = new List<Question>();
            questions = baseManager.GetAllQuestions();
            selectedQuestions = questions.FindAll(question => question.Test.Id == currentTest.Id).ToList();
        }
        private void SetNumbersData()
        {
            currentNumbers[0] = 1;
            currentNumbers[1] = selectedQuestions.Count;
        }
    }
}
