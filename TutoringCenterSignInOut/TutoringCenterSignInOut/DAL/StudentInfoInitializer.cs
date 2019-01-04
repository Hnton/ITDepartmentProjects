using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TutoringCenterSignInOut.Models;


namespace TutoringCenterSignInOut.DAL
{
    public class StudentInfoInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var Student = new List<StudentInfo>
            {
                new StudentInfo
                {
                    StudentID = 91743103, Subject = "Computer Science", TutoringUse = "Tutoring",
                },
                new StudentInfo
                {
                    StudentID = 917431111, Subject = "Computer Science", TutoringUse = "Tutoring",
                }
            };
            Student.ForEach(s => context.StudentInfos.Add(s));
            context.SaveChanges();
     
        }
    }
}