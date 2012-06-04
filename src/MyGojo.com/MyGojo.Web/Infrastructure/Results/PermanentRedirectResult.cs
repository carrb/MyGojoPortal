using System;
using System.Web.Mvc;

using Gojo.Core;

namespace MyGojo.Web.Infrastructure.Results
{
    /*
     * ASP.NET MVC 3 supplies a RedirectResult class with a Boolean property to make the redirect permanent via a HTTP 301 status code.
     * Could use that, but this custom class provides greater control if needed!
     * 
     * Usage:
     * 
     *      public ActionResult Old()
     *      {
     *           string newUrl = "/Home/Index";
     *           return new PermanentRedirectResult(newUrl);
     *      }
     *      
     * More info:  http://www.simple-talk.com/dotnet/asp.net/asp.net-mvc-action-results-and-pdf-content/
     */
    public class PermanentRedirectResult : ActionResult
    {
        public string Url { get; set; }
        public bool ShouldEndResponse { get; set; }

        public PermanentRedirectResult(string url)
        {
            Guard.Against<ArgumentNullException>(url == null, "Can not permanently redirect withou a Url!");

            Url = url;
            ShouldEndResponse = false;
        }


        public override void ExecuteResult(ControllerContext context)
        {
            // Preconditions
            Guard.Against<ArgumentNullException>(context == null, "Can not execute the ActionResult without valid ControllerContext!");

            // Mark all keys in the TempData dictionary for retention
            context.Controller.TempData.Keep();

            // Prepare the response
            var url = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
            var response = context.HttpContext.Response;

            response.Clear();
            response.StatusCode = 301;
            response.AddHeader("Location", url);

            // Optionally end the request
            if (ShouldEndResponse) response.End();
        }


    }
}