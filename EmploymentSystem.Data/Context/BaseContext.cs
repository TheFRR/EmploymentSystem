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
        private const string BaseName = "EmploymentSystem";

        public BaseContext() : base(BaseName)
        {
            Database.SetInitializer(new EmploymentSystemInitializer());
        }

        public DbSet<User> User { get; set; }
        public DbSet<JobSeeker> JobSeeker { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Variant> Variant { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JobSeeker>().ToTable("JobSeekers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
        }

    }
}
