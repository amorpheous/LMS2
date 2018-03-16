using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LMS2.Extensions
{
    public static class HtmlExtensions
    {
        public static StringBuilder ExtantBreadcrumb { get; set; }

        public static string BuildBreadcrumbNavigation(this HtmlHelper helper)
        {
            // optional condition: I didn't wanted it to show on home and account controller
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return string.Empty;
            }

            if (ExtantBreadcrumb != null)
            {
                return AppendBreadcrumbNavigation(helper);
            }

            StringBuilder breadcrumb = new StringBuilder("<ol class='breadcrumb'><li>").Append(helper.ActionLink("Home", "Index", "Home").ToHtmlString()).Append("</li>");

            breadcrumb.Append("<li>");
            breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["controller"].ToString().Titleize(),
                                               "Index",
                                               helper.ViewContext.RouteData.Values["controller"].ToString()));
            breadcrumb.Append("</li>");

            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                breadcrumb.Append("<li>");
                breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["action"].ToString().Titleize(),
                                                    helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["controller"].ToString()));
                breadcrumb.Append("</li>");
            }

            ExtantBreadcrumb = breadcrumb;
            //return breadcrumb.Append("</ol>").ToString();
            return ExtantBreadcrumb.Append("</ol>").ToString();

        }

        public static string AppendBreadcrumbNavigation(this HtmlHelper helper)
        {
            ExtantBreadcrumb.Replace("</ol>", "<li>");
            //ExtantBreadcrumb.Append("<li>");
                ExtantBreadcrumb.Append(helper.ActionLink((helper.ViewContext.RouteData.Values["controller"].ToString()+ helper.ViewContext.RouteData.Values["action"].ToString()).Titleize(),
                                                    helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["controller"].ToString()));
                ExtantBreadcrumb.Append("</li>");

            //return breadcrumb.Append("</ol>").ToString();
            return ExtantBreadcrumb.Append("</ol>").ToString();
        }
    }
}