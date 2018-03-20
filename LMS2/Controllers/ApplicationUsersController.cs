using System;
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

            if (id == null | id == 0)
                return View(db.Users.OrderBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x=>x.CourseId==null).ToList());

            else
                return View(db.Users.OrderBy(x => x.LastName).ThenBy(x => x.NickName).ThenBy(x => x.FirstName).ThenBy(x => x.Email).Where(x => x.CourseId != null).ToList());

        }

        // GET: ApplicationUsers/Details/5
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
        public ActionResult Edit(string id)
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
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
