using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.Data.Entities;
using GalaSoft.MvvmLight.Messaging;
using JobSeeker.Infrastructure.Commands;
using JobSeeker.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.ViewModels
{
    class VMCreateTest : VMBase
    {
        private readonly IBaseManager baseManager;
        public Job currentJob;
        public Test currentTest;

        public string Question { get; set; }
        public ObservableCollection<Variant> Variants { get; set; }
        public int currentQuestion { get; set; }
        public bool? flag { get; set; }

        private AddVariantCommand addVariantCommand;
        public AddVariantCommand AddVariantCommand
        {
            get
            {
                return addVariantCommand ?? (addVariantCommand = new AddVariantCommand(obj =>
                {
                    Variants.Add(new Variant() { Text = "" });
                }));
            }
        }

        private DeleteVariantCommand deleteVariantCommand;
        public DeleteVariantCommand DeleteVariantCommand
        {
            get
            {
                return deleteVariantCommand ?? (deleteVariantCommand = new DeleteVariantCommand(obj =>
                {
                    Variants.RemoveAt(Variants.Count - 1);
                }));
            }
        }

        private SaveQuestionCommand nextQuestion;
        public SaveQuestionCommand NextQuestion
        {
            get
            {
                return nextQuestion ?? (nextQuestion = new SaveQuestionCommand(obj =>
                {
                    Question currentQuestion = new Question() { Test = currentTest, Text = Question };
                    if (this.currentQuestion == 1) baseManager.CreateTest(currentTest);
                    baseManager.CreateQuestion(currentQuestion);
                    foreach (Variant variant in Variants)
                        baseManager.CreateVariant(new Variant() { Question = currentQuestion, Text = variant.Text, Correctness = variant.Correctness });
                    flag = true;
                    OnPropertyChanged("flag");
                }));
            }
        }

        private EndTestCreationCommand endTestCreationCommand;
        public EndTestCreationCommand EndTestCreationCommand => endTestCreationCommand ??
            (endTestCreationCommand = new EndTestCreationCommand(IoC.IoC.Get<IMainNavigation>()));

        public VMCreateTest()
        {
            Messenger.Default.Register<Job>(this, SetJob);
            baseManager = IoC.IoC.Get<IBaseManager>();
            currentQuestion = 1;
            SetVariants();
        }

        private AddQuestionCommand addQuestionCommand;
        public AddQuestionCommand AddQuestionCommand
        {
            get
            {
                return addQuestionCommand ?? (addQuestionCommand = new AddQuestionCommand(obj =>
                {
                    flag = false;
                    this.currentQuestion++;
                    SetVariants();
                    Question = "";
                    OnPropertyChanged("Question");
                    OnPropertyChanged("Variants");
                    OnPropertyChanged("currentQuestion");
                }));
            }
        }

        private void SetJob(Job job)
        {
            currentJob = job;
            currentTest = new Test() { Job = currentJob };
        }
        private void SetVariants()
        {
            Variants = new ObservableCollection<Variant>();
            Variants.Add(new Variant() { Text = "" });
            Variants.Add(new Variant() { Text = "" });
        }
    }
}
