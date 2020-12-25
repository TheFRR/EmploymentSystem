using EmploymentSystem.BLL.Infrastructure;
using EmploymentSystem.BLL.Interfaces;
using EmploymentSystem.Data.Entities;
using EmploymentSystem.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.BLL
{
    public class BaseManager : IBaseManager
    {
        private LiveData<User> user;
        private LiveData<Admin> admin;
        private LiveData<JobSeeker> jobSeeker;

        public LiveData<User> User => user ?? (user = new LiveData<User>(ctx.User));
        public LiveData<Admin> Admin => admin ?? (admin = new LiveData<Admin>(ctx.Admin));
        public LiveData<JobSeeker> JobSeeker => jobSeeker ?? (jobSeeker = new LiveData<JobSeeker>(ctx.JobSeeker));

        private BaseContext ctx;
        public BaseManager()
        {
            ctx = new BaseContext();
        }

        public List<Job> GetAllJobs()
        {
            return ctx.Job.ToList();
        }

        public Test GetTest(int Id)
        {
            return ctx.Test.Find(Id);
        }

        public Question GetQuestion(int Id)
        {
            return ctx.Question.Find(Id);
        }

        public List<Question> GetAllQuestions()
        {
            return ctx.Question.ToList();
        }

        public Variant GetVariant(int Id)
        {
            return ctx.Variant.Find(Id);
        }

        public List<Variant> GetAllVariants()
        {
            return ctx.Variant.ToList();
        }

        public List<Test> GetAllTests()
        {
            return ctx.Test.ToList();
        }

        public void SetAnswer(UserAnswer userAnswer)
        {
            ctx.UserAnswer.Add(userAnswer);
            Save();
        }

        public List<UserAnswer> GetAllAnswers()
        {
            return ctx.UserAnswer.ToList();
        }

        public void UpdateTest(Test test)
        {
            Test updatedTest = ctx.Test.Find(test.Id);
            updatedTest.Available = test.Available;
            Save();
        }

        public List<UserAnswer> GetAllUserAnswers()
        {
            return ctx.UserAnswer.ToList();
        }

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
