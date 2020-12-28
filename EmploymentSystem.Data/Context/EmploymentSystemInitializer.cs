using EmploymentSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Context
{
    class EmploymentSystemInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BaseContext>
    {
        protected override void Seed(BaseContext context)
        {
            var jobList = new List<Job>()
            {
                new Job(){Name = "Программист", Available = true},
                new Job(){Name = "Тестировщик", Available = true}
            };
            var testList = new List<Test>()
            {
                new Test(){Job = jobList[0]},
                new Test(){Job = jobList[0]},
                new Test(){Job = jobList[1]}
            };
            var questionList = new List<Question>()
            {
                new Question(){Test = testList[0], Text = "Лягушка или жаба?"},
                new Question(){Test = testList[0], Text = "Да или нет?"},
                new Question(){Test = testList[1], Text = "C++, C# или С?"},
                new Question(){Test = testList[2], Text = "Буйлов Павел ...?"}
            };
            var variantList = new List<Variant>()
            {
                new Variant(){Question = questionList[0], Text = "Лягушка", Correctness = false},
                new Variant(){Question = questionList[0], Text = "Жаба", Correctness = true},
                new Variant(){Question = questionList[1], Text = "Да", Correctness = true},
                new Variant(){Question = questionList[1], Text = "Нет", Correctness = false},
                new Variant(){Question = questionList[2], Text = "C++", Correctness = false},
                new Variant(){Question = questionList[2], Text = "C#", Correctness = true},
                new Variant(){Question = questionList[2], Text = "С", Correctness = false},
                new Variant(){Question = questionList[3], Text = "Витальевич", Correctness = true},
                new Variant(){Question = questionList[3], Text = "Евгеньевич", Correctness = false}
            };
            var jobSeekerList = new List<JobSeeker>()
            {
                new JobSeeker()
                {
                    FirstName = "Михаил",
                    LastName = "Зубков",
                    Login = "test_1",
                    Password = "test_1",
                },
                new JobSeeker()
                {
                    FirstName = "Алексей",
                    LastName = "Зубенко",
                    Login = "test_2",
                    Password = "test_2",
                }
            };
            var adminList = new List<Admin>()
            {
                new Admin()
                {
                    FirstName = "admin",
                    LastName = "",
                    Login = "admin",
                    Password = "admin",
                }
            };
            var recruiterList = new List<Recruiter>()
            {
                new Recruiter()
                {
                    FirstName = "recruiter",
                    LastName = "",
                    Login = "recrut",
                    Password = "recrut",
                }
            };

            jobList.ForEach(e => context.Job.Add(e));
            testList.ForEach(e => context.Test.Add(e));
            questionList.ForEach(e => context.Question.Add(e));
            variantList.ForEach(e => context.Variant.Add(e));
            jobSeekerList.ForEach(e => context.JobSeeker.Add(e));
            adminList.ForEach(e => context.Admin.Add(e));
            recruiterList.ForEach(e => context.Recruiter.Add(e));

            context.SaveChanges();
        }
    }
}
