using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace MyGojo.Web.Infrastructure.Filters
{
    public class RequestTimingFilter : IActionFilter, IResultFilter
    {
        private readonly Stopwatch actionTimer = new Stopwatch();
        private readonly Stopwatch renderTimer = new Stopwatch();


        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            actionTimer.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            actionTimer.Stop();
        }


        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            renderTimer.Start();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            renderTimer.Stop();

            var response = filterContext.HttpContext.Response;

            if (response.ContentType == "text/html")
            {
                response.Write(String.Format("<div id='request-timing-data' class='container_16'>{0}Controller.{1} took {2}ms to execute and {3}ms to render.</div>",
                                    filterContext.RouteData.Values["controller"],
                                    filterContext.RouteData.Values["action"],
                                    actionTimer.ElapsedMilliseconds,
                                    renderTimer.ElapsedMilliseconds));
            }
        }
    }
}