﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS2.Models;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace LMS2.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        [HttpGet]
        public ActionResult UploadFile()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var UserManager = new UserManager<ApplicationUser>(userStore);

            var ViewModel = new Models.File();
            

            ViewModel = new Models.File();

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult UploadFile(string Id, Models.File fileModel, HttpPostedFileBase file)
        {
            //try
            //{
            //    if (file.ContentLength > 0)
            //    {
            //        string Filename = Path.GetFileName(file.FileName);
            //        string path = Path.Combine(Server.MapPath("/UploadedFiles"), Filename);
            //        file.SaveAs(path);
            //    }
            //    ViewBag.Message = "File Uploaded Successfully!";
            //    return View();
            //}
            //catch
            //{
            //    ViewBag.Message = "File Upload Failed!";
            //    return View();
            //}


            var upload = new Models.File();

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    upload = new Models.File
                    {
                        FileName = Path.GetFileName(file.FileName),
                        ContentType = file.ContentType,
                        Description = fileModel.Description,
                        TimeStamp = DateTime.Now,
                        ApplicationUserId = db.Users.Find(User.Identity.GetUserId())
                    };

                    string[] entityId = Id.Split(' ');

                    if (entityId[1] == "Course")
                    {
                        upload.CourseId = entityId[0];
                    }
                    else if (entityId[1] == "Module")
                    {
                        upload.ModuleId = entityId[0];
                    }
                    else
                    {
                        upload.ActivityId = entityId[0];
                    }
                    

                    using (var reader = new BinaryReader(file.InputStream))
                    {
                        upload.Content = reader.ReadBytes(file.ContentLength);
                    }
                    

                }
                db.Files.Add(upload);
                db.SaveChanges();
                ViewBag.Message = "File Uploaded Successfully!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File Upload Failed!";
                return View();
            }

        }

       
    }
}