using EmploymentSystem.BLL.Infrastructure;
using EmploymentSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.BLL.Interfaces
{
    public interface IBaseManager
    {
        LiveData<User> User { get; }
        LiveData<Admin> Admin { get; }
        LiveData<JobSeeker> JobSeeker { get; }

        List<Job> GetAllJobs();
        Test GetTest(int Id);
        Question GetQuestion(int Id);
        Variant GetVariant(int Id);

        void CreateTest(Test test);
        void CreateQuestion(Question question);
        void CreateVariant(Variant variant);
        void CreateUserLine(UserLine userLine);

        List<Question> GetAllQuestions();
        List<Variant> GetAllVariants();
        List<Test> GetAllTests();
        List<UserLine> GetAllUserLines();
        List<UserAnswer> GetAllUserAnswers();
        List<UserAnswer> GetAllAnswers();

        void SetAnswer(UserAnswer userAnswer);
        void UpdateJob(Job job, bool flag);
        void UpdateAnswer(UserAnswer userAnswer, Variant variant);
        
        void Save();

    }
}
