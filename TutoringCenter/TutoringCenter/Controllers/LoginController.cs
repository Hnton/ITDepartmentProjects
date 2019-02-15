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
            TempData["TempStudentId"] = login.Student.StudentID;
            int inputSID = login.Student.StudentID;

            int query = (from o in db.Students
                         where o.StudentID == inputSID
                         select o).Count();

            int check = (from l in db.Logins
                         join s in db.Students
                            on l.Student.ID equals s.ID
                         where s.StudentID == inputSID && l.CheckedOut == null
                         orderby l.ID descending
                         select l).Count();

            //STUDENT IS IN THE SYSTEM 
            if (query != 0 )
            {
                //STUDENT IS LOGGED IN & NEEDS TO BE CHECKED OUT
                if (check != 0)
                {
                    var student = db.Logins.Where(c => c.Student.StudentID == inputSID).Select(c => new { IDNUM = c.ID }).ToList().LastOrDefault();

                    return RedirectToAction("Logout", new { id = student.IDNUM });
                }
                //STUDENT IS IN SYSTEM AND CHECKED OUT
                else
                {
                    //CREATE NEW LOGIN WITH NEW ID AND NEW CHECKIN BUT SAME STUDENT ID        
                    return RedirectToAction("Create");
                }
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
            return View(new Models.Login());//Brian Added here
        }

        // Create Page Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            if (ModelState.IsValid)
            {     
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
            return View(login);
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
                .Where(y => y.Student.ID == login.ID)
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
        public ActionResult Logout([Bind(Include = "ID,CheckedIn,CheckedOut")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
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
