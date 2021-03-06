﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMS2.Models;
using PagedList;

namespace LMS2.Controllers
{
    public class ModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /*       // GET: Modules
               [Authorize(Roles = "Teacher, Student")]
               public ActionResult Index(string searchBy, string search, int? page, string sortOrder)
               {

                   ViewBag.CourseNameSortParm = sortOrder == "CourseName" ? "CourseName_desc" : "CourseName";
                   ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
                   ViewBag.LastNameSortParm = sortOrder == "LastName" ? "LastName_desc" : "LastName";
                   ViewBag.FullNameSortParm = sortOrder == "FullName" ? "FullName_desc" : "FullName";
                   ViewBag.AvatarSortParm = sortOrder == "Avatar" ? "Avatar_desc" : "Avatar";

                   var modules = db.Modules.OrderBy(s => s.Course.StartDate).ThenBy(s => s.Course.CourseName).ThenBy(s => s.StartDate).ThenBy(s => s.ModuleName).AsQueryable();


                   if (searchBy == "ModuleName")
                   {
                       // listsearch
                       return View(modules.OrderBy(v => v.ModuleName).Where(v => v.ModuleName.ToString().Contains(search)
                       || search == null).ToList());
                   }
                   else if (searchBy == "StartYear")
                   {
                       return View(modules.OrderBy(v => v.StartDate.Year).Where(v => v.StartDate.Year.ToString().Contains(search)
                       || search == null).ToList());
                   }
                   else if (searchBy == "CourseName")
                   {
                       return View(modules.OrderBy(v => v.Course.CourseName).Where(v => v.Course.CourseName.ToString().Contains(search)
                       || search == null).ToList());
                   }
                   else
                   {
                       switch (sortOrder)
                       {
                           case "StartDate_desc":
                               modules = modules.OrderByDescending(s => s.StartDate);
                               break;
                           case "StartDate":
                               modules = modules.OrderBy(s => s.StartDate);
                               break;
                           case "ModuleName_desc":
                               modules = modules.OrderByDescending(s => s.ModuleName);
                               break;
                           case "ModuleName":
                               modules = modules.OrderBy(s => s.ModuleName);
                               break;

                           case "Description_desc":
                               modules = modules.OrderByDescending(s => s.Description);
                               break;
                           case "Description":
                               modules = modules.OrderBy(s => s.Description);
                               break;
                           case "ModuleInfo_desc":
                               modules = modules.OrderByDescending(s => s.ModuleInfo);
                               break;
                           case "ModuleInfo":
                               modules = modules.OrderBy(s => s.ModuleInfo);
                               break;
                           case "CourseName_desc":
                               modules = modules.OrderByDescending(s => s.Course.CourseName);
                               break;
                           case "CourseName":
                               modules = modules.OrderBy(s => s.Course.CourseName);
                               break;
                           default:
                               modules = modules.OrderBy(s => s.Course.StartDate).ThenBy(s => s.Course.CourseName).ThenBy(s => s.StartDate).ThenBy(s => s.ModuleName);
                               break;
                       }

                       return View(modules.ToList().ToPagedList(page ?? 1, 25));
                   }
       }
       */
        /*        // GET: Modules/Details/5
                public ActionResult Details(int? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Module module = db.Modules.Find(id);
                    if (module == null)
                    {
                        return HttpNotFound();
                    }
                    return View(module);
                }
        */
        // GET: Modules/Create
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Create(string CourseId)
        {


            if (CourseId == null | Int32.TryParse(CourseId, out int intCourseId)==false)
            {
                return RedirectToAction("Index", "Courses");
            }
            var Course = db.Courses.Where(x => x.Id == intCourseId).FirstOrDefault();
            var ViewModel = new Module { Course = db.Courses.Where(x=>x.Id==intCourseId).FirstOrDefault() };
            ViewModel.CourseId = intCourseId;

            var courseStartDate = Course.StartDate;
            var courseEndDate = Course.EndDate;


            var firstFreeStartDate = courseStartDate;
            var previousEndDate = courseStartDate.AddDays(-1);
            var firstFreeEndDate = courseEndDate;
            int loop = 0;
            List<string> moduleDates = new List<string>();
            foreach (var item in Course.Modules.OrderBy(x=>x.StartDate).ThenBy(x=>x.EndDate))
            {
                loop++;
                if (item.StartDate > firstFreeStartDate)
                {
                    moduleDates.Add(item.StartDate.ToShortDateString() + " - " + item.EndDate.ToShortDateString() + " " + item.ModuleName);
                    break;
                }
                else {
                    firstFreeStartDate = item.EndDate.AddDays(1);
                }
            }
            ViewBag.moduleDates = moduleDates;
            int loop2 = 0;
            foreach (var item in Course.Modules.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate))
            {
                loop2++;
                if (loop2==loop+1)
                {
                    firstFreeEndDate= item.StartDate.AddDays(-1);
                    break;
                }
            }

            if (firstFreeEndDate < firstFreeStartDate)
                return RedirectToAction("Index", "Courses", null);



            ViewModel.StartDate = firstFreeStartDate;
            ViewModel.EndDate = firstFreeEndDate;


            return View(ViewModel);
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Create([Bind(Include = "Id,ModuleName,Description,StartDate,EndDate,ModuleInfo,Course,CourseId")] Module module)
        {

            var ViewModel = new Module { Course = db.Courses.Where(x => x.Id == module.CourseId ).FirstOrDefault() };

            if (module.StartDate < ViewModel.Course.StartDate | module.StartDate > ViewModel.Course.EndDate)
                ModelState.AddModelError("StartDate", "Start date must be within the course");
            if (module.EndDate < ViewModel.Course.StartDate | module.EndDate > ViewModel.Course.EndDate)
                ModelState.AddModelError("EndDate", "End date must be within the course");
            if (module.EndDate < module.StartDate)
                ModelState.AddModelError("EndDate", "End date cannot occur before start date");


 var conflictingModulesTest1 = db.Modules.Where(x=>x.Id!=module.Id).Where(x => x.CourseId==module.CourseId).Where(x=>x.StartDate<=module.StartDate).Where(x => x.EndDate >= module.StartDate).Count();
            if(conflictingModulesTest1>0)
                ModelState.AddModelError("StartDate", "Conflicts with " +conflictingModulesTest1+ " other module/s");

                var conflictingModulesTest2 = db.Modules.Where(x => x.Id != module.Id).Where(x => x.CourseId == module.CourseId).Where(x => x.StartDate <= module.EndDate).Where(x => x.EndDate >= module.EndDate).Count();
            if (conflictingModulesTest2 > 0)
                ModelState.AddModelError("EndDate", "Conflicts with " + conflictingModulesTest2 + " other module/s");


            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                db.SaveChanges();
                
                return RedirectToAction("Index","Courses");
            }
  
            return View(ViewModel);
        }

        // GET: Modules/Edit/5
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Module module = db.Modules.Find(id);

            if (module == null)
            {
                return HttpNotFound();
            }

            module.Courses = db.Courses.Where(x=>x.Id==module.CourseId).ToList();

            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Edit([Bind(Include = "Id,ModuleName,Description,StartDate,EndDate,ModuleInfo,CourseId,Course")] Module module)
        {
            var ViewModel = new Module { Course = db.Courses.Where(x => x.Id == module.CourseId).FirstOrDefault() };

            if (module.StartDate < ViewModel.Course.StartDate | module.StartDate > ViewModel.Course.EndDate)
                ModelState.AddModelError("StartDate", "Start date must be within the course");
            if (module.EndDate < ViewModel.Course.StartDate | module.EndDate > ViewModel.Course.EndDate)
                ModelState.AddModelError("EndDate", "End date must be within the course");
            if (module.EndDate < module.StartDate)
                ModelState.AddModelError("EndDate", "End date cannot occur before start date");


            var conflictingModulesTest1 = db.Modules.Where(x => x.Id != module.Id).Where(x => x.CourseId == module.CourseId).Where(x => x.StartDate <= module.StartDate).Where(x => x.EndDate >= module.StartDate).Count();
            if (conflictingModulesTest1 > 0)
                ModelState.AddModelError("StartDate", "Conflicts with " + conflictingModulesTest1 + " other module/s");

            var conflictingModulesTest2 = db.Modules.Where(x => x.Id != module.Id).Where(x => x.CourseId == module.CourseId).Where(x => x.StartDate <= module.EndDate).Where(x => x.EndDate >= module.EndDate).Count();
            if (conflictingModulesTest2 > 0)
                ModelState.AddModelError("EndDate", "Conflicts with " + conflictingModulesTest2 + " other module/s");



            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Courses");
            }
           

            return View(ViewModel);
        }

        // GET: Modules/Delete/5
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [Authorize(Roles = Roles.Teacher)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();
            return RedirectToAction("Index","Courses");
        }

        [Authorize(Roles = "Teacher")]
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
