using System.Web.Mvc;
using Utility.Logging;

namespace MyGojo.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger logger)
        {
            logger.Info("HomeController created...this logger was injected!");
        }

        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
