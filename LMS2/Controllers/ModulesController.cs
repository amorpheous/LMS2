using System;
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

        // GET: Modules
        public ActionResult Index(string searchBy, string search, int? page, string sortOrder)
        {

            //ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "ParkingSlot_desc" : "ParkingSlot";
            ViewBag.StartDateSortParm = sortOrder == "StartDate" ? "StartDate_desc" : "StartDate";
            ViewBag.ModuleNameSortParm = sortOrder == "ModuleName" ? "ModuleName_desc" : "ModuleName";
            ViewBag.DurationSortParm = sortOrder == "Duration" ? "Duration_desc" : "Duration";
            ViewBag.ModuleInfoSortParm = sortOrder == "ModuleInfo" ? "ModuleInfo_desc" : "ModuleInfo";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "Description_desc" : "Description";

            var modules = db.Modules.OrderBy(s => s.Course.StartDate).ThenBy(s => s.Course.CourseName).ThenBy(s => s.StartDate).ThenBy(s => s.ModuleName).AsQueryable();


            if (searchBy == "ModuleName")
            {
                // listsearch
                return View(modules.OrderBy(v => v.ModuleName).Where(v => v.ModuleName.ToString().Contains(search)
                || search == null).ToList().ToPagedList(page ?? 1, 25));
            }
            else if (searchBy == "StartYear")
            {
                return View(modules.OrderBy(v => v.StartDate.Year).Where(v => v.StartDate.Year.ToString().Contains(search)
                || search == null).ToList().ToPagedList(page ?? 1, 25));
            }
            else if (searchBy == "CourseName")
            {
                return View(modules.OrderBy(v => v.Course.CourseName).Where(v => v.Course.CourseName.ToString().Contains(search)
                || search == null).ToList().ToPagedList(page ?? 1, 25));
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

        // GET: Modules/Details/5
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

        // GET: Modules/Create
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Create(string CourseId)
        {




            var ViewModel = new Module { Courses = db.Courses.ToList() };
            if (CourseId == null)
            {
                CourseId = "0";
            }
            ViewBag.CourseId = CourseId;
            ViewModel.CourseId = int.Parse(CourseId);
            ViewBag.Course = db.Courses.Where(x => x.Id == Int32.Parse(CourseId));
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

            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                db.SaveChanges();
                
                return RedirectToAction("Index","Courses");
            }
            module.Courses = db.Courses.ToList();

            return View(module);
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
            module.Courses = db.Courses.ToList();

            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Edit([Bind(Include = "Id,ModuleName,Description,StartDate,EndDate,ModuleInfo,Course,CourseId")] Module module)
        {


            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Courses");
            }
           
            module.Courses = db.Courses.ToList();

            return View(module);
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
