using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LMS2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //     "TeacherLogin",                           // Route name
           //     "Home/{Index}",                            // URL with parameters
           //     new { controller = "Courses", action = "Index" }  // Parameter defaults
           // );

           // routes.MapRoute(
           //    "StudentLogin",                           // Route name
           //    "Home/{Index}",                            // URL with parameters
           //    new { controller = "Courses", action = "StudentCourse" }  // Parameter defaults
           //);



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "account", action = "login", id = UrlParameter.Optional }
            );
        }


    }
}
