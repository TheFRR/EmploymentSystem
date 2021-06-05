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

        private EmploymentSystem.Data.Entities.JobSeeker currentUser;
        private Job selectedJob;
        private Variant variant;
        private List<Question> questions;
        private List<Question> selectedQuestions;
        private List<EmploymentSystem.Data.Entities.Test> tests;
        private List<EmploymentSystem.Data.Entities.Test> selectedTests;
        private int i = 0;
        private UserAnswer firstFalseAnswer;

        public EmploymentSystem.Data.Entities.Test currentTest { get; set; }
        public List<int> currentNumbers { get; set; }
        public Question currentQuestion
        {
            get
            {
                if (currentNumbers[0] == 0) return null;
                else return selectedQuestions[currentNumbers[0] - 1];
            }
        }
        public List<Variant> Variants
        {
            get
            {
                if (currentNumbers[0] == 0) return null;
                return baseManager.GetAllVariants().Where(variant => variant.Question.Id == selectedQuestions[currentNumbers[0] - 1].Id).ToList();
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
            if (i != 0) i = 0;
            baseManager = IoC.IoC.Get<IBaseManager>();
            authorizationService = IoC.IoC.Get<IAuthorizationService>();
            navigation = IoC.IoC.Get<IMainNavigation>();
            currentUser = CurrentUser();
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
                    if (i == 0) baseManager.UpdateAnswer(firstFalseAnswer, SelectedVariant);
                    else baseManager.SetAnswer(new UserAnswer() { JobSeeker = currentUser, Question = currentQuestion, Test = currentTest, Variant = SelectedVariant });
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
                        currentTest.Job.Available = false;
                        navigation.Navigate(new TestResult());
                        Messenger.Default.Send(currentTest);
                    }
                }));
            }
        }

        private EndTestCommand endTestCommand;
        public EndTestCommand EndTestCommand => endTestCommand ??
                  (endTestCommand = new EndTestCommand(IoC.IoC.Get<IMainNavigation>(), baseManager));

        private int SelectRandomValue(int n)
        {
            Random rnd = new Random();
            return rnd.Next(0, n);
        }

        private void SetData(Job job)
        {
            SelectedJob = job;
            //Console.WriteLine(selectedJob.Available);
            SetTestsData();
            SetQuestionsData();
            SetNumbersData();
            if (selectedJob.Available == false) navigation.Navigate(new LackOfTests());
            else
            {
                OnPropertyChanged("currentNumbers");
                OnPropertyChanged("currentQuestion");
                OnPropertyChanged("Variants");
                firstFalseAnswer = new UserAnswer() { JobSeeker = currentUser, Test = currentTest, Question = currentQuestion, Variant = Variants.Where(variant => variant.Correctness == false).First() };
                baseManager.SetAnswer(firstFalseAnswer);
            }
        }

        private bool SetTestsData()
        {
            tests = new List<EmploymentSystem.Data.Entities.Test>();
            tests = baseManager.GetAllTests();
            selectedTests = new List<EmploymentSystem.Data.Entities.Test>();
            selectedTests = tests.FindAll(test => test.Job.Id == SelectedJob.Id).ToList();
            currentTest = selectedTests[SelectRandomValue(selectedTests.Count)];
            OnPropertyChanged("currentTest");
            return true;
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

        private EmploymentSystem.Data.Entities.JobSeeker CurrentUser()
        {
            User user = authorizationService.GetCurrentUser();
            if (!(user is EmploymentSystem.Data.Entities.JobSeeker)) throw new Exception("Invalid user type");
            return user as EmploymentSystem.Data.Entities.JobSeeker;
        }
    }
}
