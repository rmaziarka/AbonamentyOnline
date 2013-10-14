using System.Web.Mvc;

namespace Abon.Areas.Portal
{
    public class PortalAreaAreaRegistration : AreaRegistration 
	{
        public override string AreaName 
		{
            get 
			{
                return "Portal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "Portal_with_controller",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );

            context.MapRoute(
                "Portal_without_controller",
                "{action}",
                new { controller = "Home", action = "Index" }
            );
        }
    }
}