using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMS2.Models;

namespace LMS2.Controllers
{
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activities
        public ActionResult Index()
        {
            return View(db.Activities.OrderBy(x => x.StartDate).ThenBy(x => x.EndDate).ThenBy(x => x.ActivityName).ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create

        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Create(string ModuleId)
        {

            var ViewModel = new Activity { Modules = db.Modules.ToList(), ActivityTypes = db.ActivityTypes.ToList()};

            if (ModuleId == null)
            {
                return View(ViewModel);
            }
            var mId = Int32.Parse(ModuleId);
            ViewModel = new Activity { Modules = db.Modules.ToList(), ActivityTypes = db.ActivityTypes.ToList(), Module=db.Modules.Where(x=>x.Id==mId).FirstOrDefault() };
            ViewModel.ModuleId = mId;
            ViewModel.StartDate = db.Modules.Where(x => x.Id == mId).FirstOrDefault().StartDate;
            ViewModel.EndDate = db.Modules.Where(x => x.Id == mId).FirstOrDefault().StartDate;


            return View(ViewModel);
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Roles.Teacher)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,ActivityName,StartDate,EndDate,ActivityInfo,Module,ModuleId,ActivityType,ActivityTypeId")] Activity activity)
        {
           var ViewModel = new Activity { Modules = db.Modules.ToList(), ActivityTypes = db.ActivityTypes.ToList(), Module = db.Modules.Where(x => x.Id == activity.ModuleId).FirstOrDefault() };

            if (activity.StartDate < ViewModel.Module.StartDate | activity.StartDate > ViewModel.Module.EndDate)
                ModelState.AddModelError("StartDate", "Start date must be within the module");
            if (activity.EndDate < ViewModel.Module.StartDate | activity.EndDate > ViewModel.Module.EndDate)
                ModelState.AddModelError("EndDate", "End date must be within the module");
            if (activity.EndDate < activity.StartDate)
                ModelState.AddModelError("EndDate", "End date cannot occur before start date");


            var conflictingActivitiesTest1 = db.Activities.Where(x => x.ModuleId== activity.ModuleId).Where(x => x.StartDate <= activity.StartDate).Where(x => x.EndDate >= activity.StartDate).Count();
            if (conflictingActivitiesTest1 > 0)
                ModelState.AddModelError("StartDate", "Conflicts with " + conflictingActivitiesTest1 + " other activit/y/ies");

            var conflictingActivitiesTest2 = db.Activities.Where(x => x.ModuleId == activity.ModuleId).Where(x => x.StartDate <= activity.EndDate).Where(x => x.EndDate >= activity.EndDate).Count();
            if (conflictingActivitiesTest2 > 0)
                ModelState.AddModelError("EndDate", "Conflicts with " + conflictingActivitiesTest2 + " other activit/y/ies");

            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index","Courses");
            }

            return View(ViewModel);
        }

        // GET: Activities/Edit/5
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Edit(int? id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            activity.Modules = db.Modules.ToList();
            activity.ActivityTypes = db.ActivityTypes.ToList();

            
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Edit([Bind(Include = "Id,Description,ActivityName,StartDate,EndDate,ActivityInfo,ActivityType,ActivityTypeId,Module,ModuleId")] Activity activity)
        {

            var ViewModel = new Activity { Modules = db.Modules.ToList(), ActivityTypes = db.ActivityTypes.ToList(), Module = db.Modules.Where(x => x.Id == activity.ModuleId).FirstOrDefault() };

            if (activity.StartDate < ViewModel.Module.StartDate | activity.StartDate > ViewModel.Module.EndDate)
                ModelState.AddModelError("StartDate", "Start date must be within the module");
            if (activity.EndDate < ViewModel.Module.StartDate | activity.EndDate > ViewModel.Module.EndDate)
                ModelState.AddModelError("EndDate", "End date must be within the module");
            if (activity.EndDate < activity.StartDate)
                ModelState.AddModelError("EndDate", "End date cannot occur before start date");


            var conflictingActivitiesTest1 = db.Activities.Where(x => x.ModuleId == activity.ModuleId).Where(x => x.StartDate <= activity.StartDate).Where(x => x.EndDate >= activity.StartDate).Count();
            if (conflictingActivitiesTest1 > 0)
                ModelState.AddModelError("StartDate", "Conflicts with " + conflictingActivitiesTest1 + " other activit/y/ies");

            var conflictingActivitiesTest2 = db.Activities.Where(x => x.ModuleId == activity.ModuleId).Where(x => x.StartDate <= activity.EndDate).Where(x => x.EndDate >= activity.EndDate).Count();
            if (conflictingActivitiesTest2 > 0)
                ModelState.AddModelError("EndDate", "Conflicts with " + conflictingActivitiesTest2 + " other activit/y/ies");





            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Courses");
            }

            return View(ViewModel);
        }

        // GET: Activities/Delete/5
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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
