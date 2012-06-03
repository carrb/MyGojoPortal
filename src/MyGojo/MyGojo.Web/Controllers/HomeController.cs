using System;
using System.Linq;
using System.Web.Mvc;
using DreamSongs.MongoRepository;
using MyGojo.Data.Mongo.Model;
using NLog;

namespace MyGojo.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly MongoRepository<UserInfo> repository; 


        // See:  http://www.ihatetermsandconditions.com/
        // 
        // for generating Terms and Conditions!

        public HomeController(MongoRepository<UserInfo> repository)
        {
            this.repository = repository;
            logger.Info("Mongo Repository injected!");   
        }



        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "";

            var currentUserAdLogin = "GOJO-NET\\carrb";//User.Identity.Name;

            try
            {
                var foundUser = repository.GetSingle(u => u.AdLogin == currentUserAdLogin);

                if (foundUser.Sites == null || foundUser.Sites.Count == 0)
                {
                    ViewBag.Message = currentUserAdLogin + " has no matching AdLogin record in Users table of DB";
                    return View(new[] {new SiteInfo {Title = "No Workspace Membership", Url = "#"}});
                }

                return View(foundUser.Sites.OrderBy(s => s.Title));    
            }
            catch (Exception ex)
            {
                ViewBag.Message = currentUserAdLogin + " has no matching AdLogin record in Users table of DB";
                logger.ErrorException(ViewBag.Message, ex);

                return View(new[] { new SiteInfo { Title = "No Workspace Membership", Url = "#" } });
            }

        }

        //
        // GET: /Home/

        public ActionResult Terms()
        {
            return View();
        }

    }
}
