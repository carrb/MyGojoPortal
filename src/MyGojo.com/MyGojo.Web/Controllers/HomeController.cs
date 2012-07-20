using System.Web.Mvc;
using MyGojo.Web.Orchestrators;
using Utility.Logging;

namespace MyGojo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeOrchestrator _homeOrchestrator;
        private readonly ILogger _logger;
        

        public HomeController(IHomeOrchestrator homeOrchestrator, ILogger logger)
        {
            _homeOrchestrator = homeOrchestrator;
            _logger = logger;
        }


        public ActionResult Index()
        {
            var model = _homeOrchestrator.GetUserSiteLinks(User.Identity.Name);
            return View(model);
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


        /// GET: /Tests/StyleTest

        public ActionResult StyleTest()
        {
            return View();
        }

        /// GET: /Tests/StyleTestII

        public ActionResult StyleTestII()
        {
            return View();
        }

        /// GET: /Tests/JavascriptTest

        public ActionResult JavascriptTest()
        {
            return View();
        }





    }
}
