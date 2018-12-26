using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakaryaBufe
{
    public class LanguageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = filterContext.RouteData.Values["lang"] != null ? filterContext.RouteData.Values["lang"].ToString() : "en";

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);

            filterContext.HttpContext.Response.Cookies.Add(new HttpCookie("dil")
            {
                Value = lang,
                Expires = DateTime.Now.AddYears(1)
            });

            base.OnActionExecuting(filterContext);
        }
    }
}