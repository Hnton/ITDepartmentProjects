using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutoringCenter.Models;

namespace TutoringCenter.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var Student = new List<Login>
            {
                new Login
                {
                    StudentID = 91743103, Subject = "Computer Science", VisitReason = "Tutoring",
                },
                new Login
                {
                    StudentID = 3333333, Subject = "Computer Science", VisitReason = "Tutoring",
                },
                new Login
                {
                    StudentID = 4444444, Subject = "Computer Science", VisitReason = "Tutoring",
                },
                new Login
                {
                    StudentID = 555555, Subject = "Computer Science", VisitReason = "Tutoring",
                },
                new Login
                {
                    StudentID = 666666, Subject = "Computer Science", VisitReason = "Tutoring",
                },
                new Login
                {
                    StudentID = 777777, Subject = "Computer Science", VisitReason = "Tutoring",
                },
                new Login
                {
                    StudentID = 88888, Subject = "Computer Science", VisitReason = "Tutoring",
                },
                new Login
                {
                    StudentID = 9999999, Subject = "Computer Science", VisitReason = "Tutoring",
                },
            };
            Student.ForEach(s => context.Logins.Add(s));
            context.SaveChanges();

        }
    }
}