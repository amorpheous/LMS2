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
        [Authorize(Roles = "Teacher, Student")]
        public ActionResult Index(int? id, string searchBy, string search, int? page, string sortOrder)
        {
            var today = DateTime.Now.Date;
            var tomorrow = DateTime.Now.Date.AddDays(1);
            int todayDay = ((int)DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek; ;
            var lastDayThisWeek = today.AddDays(7 - todayDay);
            var firstDayNextWeek = lastDayThisWeek.AddDays(1);
            var lastDayNextWeekPlusOneDay = lastDayThisWeek.AddDays(8);

            ViewBag.Filter = "";
            var user = db.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
            if (User.IsInRole(LMS2.Models.Roles.Student))
            {
                if (user.CourseId != null)
                {
                    var course= db.Courses.Where(c => c.Id == user.CourseId).FirstOrDefault();
                    var editedCourse = (Course)course.CleanClone();
                    ViewBag.Filter = "";
                    List<Course> courseList = new List<Course>()  
                    {
                        editedCourse
                    };

                    List<Activity> SchedulePast = db.Activities.OrderBy(x=>x.StartDate).ThenBy(x=>x.EndDate).Where(c => c.StartDate < today).Where(c => c.Module.Course.Id == user.CourseId).ToList();
                    List<Activity> ScheduleToday = db.Activities.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).Where(c => c.StartDate >= today).Where(c => c.StartDate <= tomorrow).Where(c => c.Module.Course.Id == user.CourseId).ToList();
                    List<Activity> ScheduleThisWeekFromTomorrow = db.Activities.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).Where(c=>c.StartDate >= tomorrow).Where(c => c.StartDate <= firstDayNextWeek).Where(c=>c.Module.Course.Id==user.CourseId).ToList();
                    List<Activity> ScheduleNextWeek = db.Activities.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).Where(c => c.StartDate >= firstDayNextWeek).Where(c => c.StartDate <= lastDayNextWeekPlusOneDay).Where(c => c.Module.Course.Id == user.CourseId).ToList();
                    List<Activity> ScheduleAfterNextWeek = db.Activities.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).Where(c => c.StartDate >= lastDayNextWeekPlusOneDay).Where(c => c.Module.Course.Id == user.CourseId).ToList();

                    ViewBag.SchedulePast = SchedulePast;
                    ViewBag.ScheduleToday = ScheduleToday;
                    ViewBag.ScheduleThisWeekFromTomorrow = ScheduleThisWeekFromTomorrow;
                    ViewBag.ScheduleNextWeek = ScheduleNextWeek;
                    ViewBag.ScheduleAfterNextWeek = ScheduleAfterNextWeek;


                    return View(courseList);
                }
                else
                {
                    ViewBag.Filter = "Something went wrong, talk to your teacher";
                    View();
                }



            }

            ICollection<Course> courses = db.Courses.Where(x => x.EndDate >= today).Where(x => x.StartDate <= today).OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList();

            if (id == null | id == 0 )
            {
                ViewBag.Filter = "Current courses";
                courses = db.Courses.Where(x => x.EndDate >= today).Where(x => x.StartDate <= today).OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList();
                foreach (var course in courses)
                {
                    course.AttendingStudents = db.Users.Where(x => x.CourseId == course.Id).Where(x=>x.IsActive==true).ToList();
                    foreach (var student in course.AttendingStudents)
                    {
                        student.SpecialInfo = null;
                    }
                }


                return View(courses);
            }
            if (id == null |id == 1)
            {
                ViewBag.Filter = "Upcoming courses";
                courses = db.Courses.Where(x => x.EndDate >= today).Where(x => x.StartDate > today).OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList();
                return View(courses);
            }
            else if (id == 2)
            {
                ViewBag.Filter = "Past courses";
                courses = db.Courses.Where(x => x.EndDate < today).OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList();
                return View(courses);
            }
            else
                ViewBag.Filter = "All courses";
            courses = db.Courses.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.CourseName).ToList();
            return View(courses);

            }

        /*       public ActionResult StudentCourse(string id)
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
               */

        public ActionResult Redirect()
        {
            //Det enda den här metoden gör att routa om tillbaks till UserSpecificLogin i Accountcontroller.
            //Men därmed har nu en 'identitytoken' hunnits sättas.
            return RedirectToAction("UserSpecificLogin", "Account");
                
        }

        
        // GET: Courses/Details/5
/*        public ActionResult Details(int? id)
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
*/
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

        [Authorize(Roles = Roles.Teacher)]
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
