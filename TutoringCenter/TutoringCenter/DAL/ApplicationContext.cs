// Application Context that connects the Database to the Application
// (LocalDb)\MsSQLLocalDb which is in Web.config

using System.Data.Entity;
using TutoringCenter.Models;

namespace TutoringCenter.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContext")
        {
            //NULL
        }

        // Where each database table is created
        public DbSet<Login> Logins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);     
        }
    }
}