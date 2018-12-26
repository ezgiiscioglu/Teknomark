using System.Web.Mvc;

namespace SakaryaBufe.Areas.Yonetim
{
    public class YonetimAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Yonetim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Yonetim_default",
                "Yonetim/{controller}/{action}/{id}",
                new { action = "YonetimGiris", controller="Panel", id = UrlParameter.Optional }
            );
        }
    }
}