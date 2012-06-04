using System;
using System.Web.Mvc;


namespace MyGojo.Web.Infrastructure.Filters
{
	public class Filters
	{
		public static void ConfigureAndRegister()
		{
			GlobalFilterCollection filters = GlobalFilters.Filters;

			#region Conditional Filters Provider --- See: http://haacked.com/archive/2011/04/25/conditional-filters.aspx
	
			//IEnumerable<Func<ControllerContext, ActionDescriptor, object>> conditions = new Func<ControllerContext, ActionDescriptor, object>[]
			//                                                                                    {
			//                                                                                        (c, a) => c.Controller.GetType() != typeof (HomeController)
			//                                                                                            ? new RequestTimingFilter()
			//                                                                                            : null,
			//                                                                                        (c, a) =>
			//                                                                                        a.ActionName.StartsWith("About")
			//                                                                                            ? new RequestTimingFilter()
			//                                                                                            : null
			//                                                                                    };
			//var provider = new ConditionalFilterProvider(conditions);
			//FilterProviders.Providers.Add(provider);

			#endregion


			filters.Add(new HandleErrorAttribute());
		}


	}
}