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
        LiveData<Recruiter> Recruiter { get; }
        LiveData<JobSeeker> JobSeeker { get; }
        void Save();
    }
}
