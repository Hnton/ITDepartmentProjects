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

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckedIn()
        {
            return View();
        }

        public ActionResult CheckedOut()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {
            TempData["TempStudentId"] = login.Student.StudentID;


            
            if(db.Students.Where(u => u.StudentID == login.Student.StudentID).Any())
            {

                if(db.Logins.Where(x => x.Student.ID == login.Student.StudentID && x.CheckedOut == null).Any())
              
                {
                    var student = db.Logins.Where(u => u.Student.StudentID == login.Student.StudentID).Select(u => new { IDnum = u.ID }).Single();

                    var i = student.IDnum;
                    return RedirectToAction("Logout", new { id = i });
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }
            else
            { 
                return RedirectToAction("Create");
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            
            ViewBag.data = TempData["TempStudentId"].ToString();
            ViewBag.Reasons = new MultiSelectList(db.Reasons.ToList(), "R_ID", "Name");
            ViewBag.Subjects = new MultiSelectList(db.Subjects.ToList(), "S_ID", "Name");
            return View(new Models.Login());//Brian Added here
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

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

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentID,VisitReason,Subject,CheckedIn,CheckedOut")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

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




        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
