using System;
using System.Linq;
using System.Web.Mvc;
using DreamSongs.MongoRepository;
using MyGojo.Data.Model;
using Utility.Logging;

namespace MyGojo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private MongoRepository<UserInfo> _repository; 

        public HomeController(MongoRepository<UserInfo> repository, ILogger logger)
        {
            _logger = logger;
            _repository = repository;
            _logger.Info("HomeController created...this logger was injected!");
        }

        public ActionResult Index()
        {
            _logger.Info("Entering Index ActionMethod...");
            ViewBag.Message = "";

            var currentUserAdLogin = "GOJO-NET\\carrb";//User.Identity.Name;

            try
            {
                var foundUser = _repository.GetSingle(u => u.AdLogin == currentUserAdLogin);

                if (foundUser.Sites == null || foundUser.Sites.Count == 0)
                {
                    ViewBag.Message = currentUserAdLogin + " has no matching AdLogin record in Users table of DB";
                    return View(new[] { new SiteInfo { Title = "No Workspace Membership", Url = "#" } });
                }

                return View(foundUser.Sites.OrderBy(s => s.Title));
            }
            catch (Exception ex)
            {
                ViewBag.Message = currentUserAdLogin + " has no matching AdLogin record in Users table of DB";
                _logger.Info(ViewBag.Message, ex);

                return View(new[] { new SiteInfo { Title = "No Workspace Membership", Url = "#" } });
            }
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
