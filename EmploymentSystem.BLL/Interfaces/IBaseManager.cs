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
        List<Question> GetAllQuestions();
        List<Variant> GetAllVariants();
        List<Test> GetAllTests();
        void SetAnswer(UserAnswer userAnswer);
        List<UserAnswer> GetAllAnswers();
        void UpdateTest(Test test);
        List<UserAnswer> GetAllUserAnswers();

        void Save();

    }
}
