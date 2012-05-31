using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var currentUserAdLogin = User.Identity.Name;

            try
            {
                var foundUser = repository.GetSingle(u => u.AdLogin == currentUserAdLogin);

                if (foundUser.Sites == null || foundUser.Sites.Count == 0)
                {
                    return View(new[] {new SiteInfo {Title = "No Workspace Membership", Url = "#"}});
                }

                logger.Info(foundUser);

                return View(foundUser.Sites);    
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
