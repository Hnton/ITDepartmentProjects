using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutoringCenterSignInOut.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TutoringCenterSignInOut.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContext")
        {

        }

        public DbSet<StudentInfo> StudentInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}