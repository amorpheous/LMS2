﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LMS2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LMS2.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        public ActionResult Index(int? id)
        {
            ViewBag.Filter = "";

            if (User.IsInRole(LMS2.Models.Roles.Teacher))
            {

                if (id == null | id == 0)
                {
                    ViewBag.Filter = "Teachers (active)";
                    return View(db.Users.OrderBy(x => x.Course.StartDate).ThenBy(x => x.Course.EndDate).ThenBy(x => x.Course.CourseName).ThenBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x => x.CourseId == null).Where(x => x.IsActive == true).ToList());
                }
                if (id == null | id == 1)
                {
                    ViewBag.Filter = "Teachers (inactive)";
                    return View(db.Users.OrderBy(x => x.Course.StartDate).ThenBy(x => x.Course.EndDate).ThenBy(x => x.Course.CourseName).ThenBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x => x.CourseId == null).Where(x => x.IsActive == false).ToList());
                }
                if (id == null | id == 2)
                {
                    ViewBag.Filter = "Teachers (all)";
                    return View(db.Users.OrderBy(x => x.Course.StartDate).ThenBy(x => x.Course.EndDate).ThenBy(x => x.Course.CourseName).ThenBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x => x.CourseId == null).ToList());
                }
                if (id == null | id == 3)
                {
                    ViewBag.Filter = "Students (active)";
                    return View(db.Users.OrderBy(x => x.Course.StartDate).ThenBy(x => x.Course.EndDate).ThenBy(x => x.Course.CourseName).ThenBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x => x.CourseId != null).Where(x => x.IsActive == true).ToList());
                }
                if (id == null | id == 4)
                {
                    ViewBag.Filter = "Students (inactive)";
                    return View(db.Users.OrderBy(x => x.Course.StartDate).ThenBy(x => x.Course.EndDate).ThenBy(x => x.Course.CourseName).ThenBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x => x.CourseId != null).Where(x => x.IsActive == false).ToList());
                }
                else
                {
                    ViewBag.Filter = "Students (all)";
                    return View(db.Users.OrderBy(x => x.Course.StartDate).ThenBy(x => x.Course.EndDate).ThenBy(x => x.Course.CourseName).ThenBy(x => x.LastName).ThenBy(x => x.FirstName).ThenBy(x => x.NickName).ThenBy(x => x.Email).Where(x => x.CourseId != null).ToList());
                }
            }

            else
            {
                ViewBag.Filter = "Teachers";
                return View(db.Users.OrderBy(x => x.Course.StartDate).ThenBy(x => x.Course.EndDate).ThenBy(x => x.Course.CourseName).ThenBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x => x.CourseId == null).Where(x => x.IsActive == true).ToList());
            }
        }

        // GET: ApplicationUsers/Details/5


        /*
                public ActionResult Details(string id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ApplicationUser applicationUser = db.Users.Find(id);





                    if (applicationUser == null)
                    {
                        return HttpNotFound();
                    }
                    return View(applicationUser);
                }

                //public ActionResult OtherUserHomePage()
                //{

                //    return Red
                //}


        */

        [Authorize(Roles = "Teacher, Student")]
        public ActionResult UserHomePage(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserId);
            int picId;
            if (id != currentUserId)
            {
                ApplicationUser otherUser = context.Users.FirstOrDefault(x => x.Id == id);
                if (otherUser.Files != null)
                {
                    ViewBag.Id = otherUser.Id;
                    picId = otherUser.Files.Where(x => x.FileType == "avatar").Select(x => x.Id).LastOrDefault();
                    ViewBag.pic = otherUser.Files.Where(x => x.FileType == "avatar").LastOrDefault();
                }
                return View(otherUser);
            }
            ViewBag.Id = currentUserId;
            if (currentUser.Files != null) { 
            picId = currentUser.Files.Where(x => x.FileType == "avatar").Select(x => x.Id).LastOrDefault();
            ViewBag.pic = currentUser.Files.Where(x => x.FileType == "avatar").LastOrDefault();
            }
            return View(currentUser);
        }

        [Authorize(Roles = "Teacher, Student")]
        public ActionResult EditUserHomePage(string id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser applicationUser = db.Users.Find(id);
            applicationUser = db.Users.Include(s => s.Files).SingleOrDefault(s => s.Id == id);

                if (applicationUser == null)
            {
                return HttpNotFound();
            }
            string UserId = "";
            if (id == null | id.Length == 0)
            { UserId = User.Identity.GetUserId(); }
            else UserId = id;

            ApplicationDbContext context = new ApplicationDbContext();
            ApplicationUser user = context.Users.FirstOrDefault(x => x.Id == UserId);



            ViewBag.Id = id;
            return View(user);
        }




        [HttpPost]
        [Authorize(Roles = "Teacher, Student")]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserHomePage([Bind(Include = "FirstName,LastName,NickName,IsActive,AdditionalInfo,SpecialInfo,Email")] ApplicationUser applicationUser)
        {


            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                ApplicationUser user = context.Users.AsNoTracking().FirstOrDefault(x => x.Email == applicationUser.Email);

                user.FirstName = applicationUser.FirstName;
                user.LastName = applicationUser.LastName;
                if (User.IsInRole(LMS2.Models.Roles.Teacher))
                {
                    user.IsActive = applicationUser.IsActive;
                }
                if (User.Identity.GetUserId()==user.Id)
                {
                    user.NickName = applicationUser.NickName;
                    user.AdditionalInfo = applicationUser.AdditionalInfo;
                    user.SpecialInfo = applicationUser.SpecialInfo;
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserHomePage","ApplicationUsers",new { id = user.Id }); 
            }
            else
            return View(applicationUser);


        }

        //public ActionResult CheckIfUserIsActiveOnLogin()
        //{
          
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    string currentUserId = User.Identity.GetUserId();
        //    ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserId);


        //    if (currentUser.IsActive == false) {

        //        return View("InactiveUser");

        //            }

        //    else return RedirectToAction("Login", "Account");


        //}

        // GET: ApplicationUsers/Create
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Create()
        {
            var ViewModel = new ApplicationUser { Courses = db.Courses.ToList() };
            

            return View(ViewModel);
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = Roles.Teacher)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,NickName,IsActive,AdditionalInfo,SpecialInfo,Email, CourseId, Password")] ApplicationUser applicationUser)
        {
            //var ViewModel = new ApplicationUser { Courses = db.Courses.ToList() };

            if (ModelState.IsValid)
            {
                applicationUser.UserName = applicationUser.Email;

                db.Users.Add(applicationUser);
                db.SaveChanges();

                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var roleNames = new[] { Roles.Teacher, Roles.Student };
                foreach (var roleName in roleNames)
                {
                    if (db.Roles.Any(r => r.Name == roleName)) continue;

                    // Create role
                    var role = new IdentityRole { Name = roleName };
                    var result = roleManager.Create(role);
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }

                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var User2giveRole = userManager.FindByName(applicationUser.Email);


                if (applicationUser.CourseId != null)
                {
                    var result = await userManager.CreateAsync(applicationUser, "Samarkand1945%");
                    userManager.AddToRole(User2giveRole.Id, Roles.Student);

                }
                else
                {
                    var result = await userManager.CreateAsync(applicationUser, "Samarkand1945%");
                    userManager.AddToRole(User2giveRole.Id, Roles.Teacher);
                }

                db.SaveChanges();








                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }



        // GET: ApplicationUsers/Edit/5
/*        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,NickName,IsActive,AdditionalInfo,SpecialInfo,Email")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                applicationUser.UserName = applicationUser.Email;
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }
*/
        // GET: ApplicationUsers/Delete/5
        [Authorize(Roles = Roles.Teacher)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = Roles.Teacher)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();

            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            if(applicationUser.Id!=currentUserId)
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
