using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMS2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace LMS2.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Index(int? id, string searchBy, string search, int? page, string sortOrder)
        {
            ViewBag.Filter = "";
            ViewBag.Users = db.Users.Select(x => new StudentList { FullName = x.FullName, CourseId = x.CourseId});
            var today = DateTime.Now.Date;
            if (id == null | id == 0 | id == 1)
            {
                ViewBag.Filter = "Present/Future";
                return View(db.Courses.Where(x => x.EndDate>=today).OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList());
            }
            else if (id == 2)
            {
                ViewBag.Filter = "Past";
                return View(db.Courses.Where(x => x.EndDate < today).OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList());
            }
            else
                ViewBag.Filter = "All";
            return View(db.Courses.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList());

            }

        public class StudentList
        {
            public string FullName { get; set; }
            public int? CourseId { get; set; }
    }

        public ActionResult StudentCourse(string id)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
            if (User.IsInRole(Roles.Student))
            {
                if (user.CourseId != null)
                {
                    var course = db.Courses.FirstOrDefault(c => c.Id == user.CourseId);
                    return View(course);
                }
                else return View();
            }
            if (User.IsInRole(Roles.Teacher))
            {
                if(Int32.TryParse(id,out int idint))
                { 
                    var course2 = db.Courses.FirstOrDefault(c => c.Id == idint);
                    return View(course2);
                }
                else return View();
            }
            else return View();
        }

        public ActionResult Redirect()
        {
            //Det enda den här metoden gör att routa om tillbaks till UserSpecificLogin i Accountcontroller.
            //Men därmed har nu en 'identitytoken' hunnits sättas.
            return RedirectToAction("UserSpecificLogin", "Account");
                
        }

        
        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create

        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = Roles.Teacher)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseName,Description,StartDate,EndDate,UrgentInfo")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = Roles.Teacher)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseName,Description,StartDate,EndDate,UrgentInfo")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [Authorize(Roles = Roles.Teacher)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
