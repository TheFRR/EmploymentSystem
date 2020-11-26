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
            var jobSeekerList = new List<JobSeeker>()
            {
                new JobSeeker()
                {
                    FirstName = "Михаил",
                    LastName = "Зубков",
                    Login = "test_1",
                    Password = "test_1",
                }
            };
            var recruiterList = new List<Recruiter>();
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

            jobSeekerList.ForEach(e => context.JobSeeker.Add(e));
            recruiterList.ForEach(e => context.Recruiter.Add(e));
            adminList.ForEach(e => context.Admin.Add(e));

            context.SaveChanges();
        }
    }
}
