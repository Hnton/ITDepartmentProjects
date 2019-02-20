using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutoringCenter.DAL;
using TutoringCenter.Models;

namespace TutoringCenter.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // Login Page
        public ActionResult Index()
        {
            return View();
        }

        // CheckedIn Page
        public ActionResult CheckedIn()
        {
            return View();
        }

        // CheckedOut Page
        public ActionResult CheckedOut()
        {
            return View();
        }

        // Login Page Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {
            TempData["TempStudentId"] = login.RealStudentID;
            int inputSID = (int)login.RealStudentID;

            int check = (from l in db.Logins
                         join s in db.Students
                            on l.Student.ID equals s.ID
                         where s.StudentID == inputSID && l.CheckedOut == null
                         select l).Count();

            Student student = db.Students.Where(x => x.StudentID == inputSID).FirstOrDefault();

            //STUDENT IS IN THE SYSTEM 
            if (student != null && check == 1)
            {  
                var students = db.Logins.Where(c => c.Student.StudentID == inputSID).Select(c => new { IDNUM = c.ID }).ToList().LastOrDefault();

                return RedirectToAction("Logout", new { id = students.IDNUM });              
            }
            //STUDENT IS NOT IN THE SYSTEM
            else
            {
                return RedirectToAction("Create");    
            }
        }

        // Create Page
        public ActionResult Create()
        {      
            ViewBag.data = TempData["TempStudentId"].ToString();
           

            var ReasonList = db.Reasons.Where(c => c.Status == false).ToList();
            var SubjectList = db.Subjects.Where(c => c.Status == false).ToList();

            ViewBag.Reasons = new MultiSelectList(ReasonList.ToList(), "R_ID", "Name");
            ViewBag.Subjects = new MultiSelectList(SubjectList.ToList(), "S_ID", "Name");
            return View(new Models.Login());
        }

        // Create Page Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Where(x => x.StudentID == login.RealStudentID).FirstOrDefault();

                if(student != null)
                {
                    login.Student = student;
                    login.RealStudentID = student.ID;
                }
                else
                {
                    
                    student = new Student
                    {
                        StudentID = (int)login.RealStudentID
                    };
                    db.Students.Add(student);
                    login.RealStudentID = student.ID;
                }

                db.Logins.Add(login);
                db.SaveChanges();
                foreach(int ID in login.ReasonIDs)
                {
                    Reason reason = db.Reasons.Find(ID);
                    login.Reasons.Add(reason);
                }
                foreach (int ID in login.SubjectIDs)
                {
                    Subject subject = db.Subjects.Find(ID);
                    login.Subjects.Add(subject);
                   
                }
                db.Entry(login).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("CheckedIn");
            }
            return RedirectToAction("CheckedIn");
        }
    
        // Logout Page
        public ActionResult Logout(int? Id)
        {
          
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Login login = db.Logins.Find(Id);
            
            db.Logins
                .Where(y => y.Student.ID == login.RealStudentID)
                .ToList()
                .ForEach(a => a.CheckedOut = DateTime.Now);
            db.SaveChanges();
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }
    
        // Logout Page Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout(Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;

                
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }    
    }
}
