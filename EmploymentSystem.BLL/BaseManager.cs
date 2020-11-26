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
        private LiveData<Recruiter> recruiter;
        private LiveData<JobSeeker> jobSeeker;

        public LiveData<User> User => user ?? (user = new LiveData<User>(ctx.User));
        public LiveData<Admin> Admin => admin ?? (admin = new LiveData<Admin>(ctx.Admin));
        public LiveData<Recruiter> Recruiter => recruiter ?? (recruiter = new LiveData<Recruiter>(ctx.Recruiter));
        public LiveData<JobSeeker> JobSeeker => jobSeeker ?? (jobSeeker = new LiveData<JobSeeker>(ctx.JobSeeker));

        private BaseContext ctx;
        public BaseManager()
        {
            this.ctx = new BaseContext();
        }

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
