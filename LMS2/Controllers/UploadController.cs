using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS2.Models;
using System.Configuration;
using System.Data;



namespace LMS2.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(ApplicationUser applicationUser, HttpPostedFileBase file)
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

            try
            {
              
                    if (file != null && file.ContentLength > 0)
                    {
                        var upload = new Models.File
                        {
                            FileName = Path.GetFileName(file.FileName),
                            FileType = FileType.File,
                            ContentType = file.ContentType
                        };
                        using (var reader = new BinaryReader(file.InputStream))
                        {
                            upload.Content = reader.ReadBytes(file.ContentLength);
                        }
                        applicationUser.Files = new List<Models.File> { upload };
                    }
                    db.Users.Add(applicationUser);
                    db.SaveChanges();
                    ViewBag.Message = "File Upload Successfully!";
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