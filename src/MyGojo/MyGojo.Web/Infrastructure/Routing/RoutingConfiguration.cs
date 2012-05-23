using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;



namespace MyGojo.Web.Infrastructure.Routing
{
	public class RoutingConfiguration
	{
		public static void Configure()
		{
			RegisterAreas();

			RouteTable.Routes.RouteExistingFiles = true;
			RegisterRoutes(RouteTable.Routes);
		}
		
		public static void RegisterAreas()
		{
			AreaRegistration.RegisterAllAreas();
		}
				   
        
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Clear();

			routes.IgnoreRoute("Content/{*catchall}");
			routes.IgnoreRoute("Scripts/{*catchall}");
            routes.IgnoreRoute("Images/{*catchall}");
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{resource}.gif/{*pathInfo}");
			routes.IgnoreRoute("{resource}.jpg/{*pathInfo}");
			routes.IgnoreRoute("{resource}.png/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });								// favicon
			routes.IgnoreRoute("{resource}.ico/{*pathInfo}");
			routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");															// allow ASP.NET classic to utilize WebForms
			routes.IgnoreRoute("{*allsvc}", new { allsvc = @".*\.svc(/.*)?" });											// Allow WCF RIA Services EF 4.0? 


            // Web APIs
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


			/* Custom Static Route */
			routes.MapRoute(
				"XmlSiteMap",																							// Route name 
				"sitemap.xml",																							// URL with parameters
				new { controller = "Home", action = "SiteMapXml" }														// Parameter defaults
			);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            /* ASP.NET MVC 3 Default Route */
			//routes.MapRoute(
			//	"Default",																								// Route name
			//	"{controller}/{action}/{id}",																			// URL with parameters
			//	new { controller = "Home", action = "Index", id = UrlParameter.Optional },								// Parameter defaults
			//	new[] { "MyGojo.Web.Controllers" }																		// constraints on namespaces to search and avoid collisions.
			//);

			routes.MapRoute(																							// Baseline ROOT 
			  "Root",
			  "",
			  new { controller = "Home", action = "Index", id = "" }
			);

			routes.MapRoute(																							// Catch all as last resort.
				"Catch-All",
				"{*catchall}",
				new { controller = "Error", action = "NotFound404"}
			);    

		}

		
	}
}