using EmploymentSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Data.Context
{
    public class BaseContext : DbContext
    {
        private const string BaseName = "Employment System";

        public BaseContext() : base(BaseName)
        {
            Database.SetInitializer(new EmploymentSystemInitializer());
        }

        public DbSet<User> User { get; set; }
        public DbSet<JobSeeker> JobSeeker { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Recruiter> Recruiter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JobSeeker>().ToTable("JobSeekers");
            modelBuilder.Entity<Recruiter>().ToTable("Recruiters");
            modelBuilder.Entity<Admin>().ToTable("Admins");
        }

    }
}
