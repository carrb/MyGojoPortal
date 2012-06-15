using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using DreamSongs.MongoRepository;
using MyGojo.Data.Model;
using Utility.Logging;

namespace MyGojo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly MongoRepository<UserInfo> _repository; 

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

            var currentUserAdLogin = IsolateLogin(User.Identity.Name);

            try
            {
                var foundUser = _repository.GetSingle(u => u.AdLogin == currentUserAdLogin);

                if (foundUser == null || foundUser.Sites.Count == 0)
                {
                    return View(new[] { new SiteInfo { Title = "No Workspace Membership", Url = "#" } });
                }
                
                ViewBag.Message = "Sites found for " + currentUserAdLogin;
                return View(foundUser.Sites.OrderBy(s => s.Title));
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                _logger.Info(ex.GetType().ToString());
                return View(new[] { new SiteInfo { Title = "No Workspace Membership", Url = "#" } });
            }
        }


        private string IsolateLogin(string login)
        {
            try
            {
                Regex regexpr = new Regex(@"GOJO-NET\\(\w+)", RegexOptions.Singleline, TimeSpan.FromMilliseconds(1));

                Match mtch = regexpr.Match(login);

                Console.WriteLine("{0}", mtch.Groups[1]);

                if (mtch.Success)
                    return (@"GOJO-NET\" + mtch.Groups[1].ToString().ToLowerInvariant());
                return login;
            }
            catch (RegexMatchTimeoutException ex)
            {
                //Console.WriteLine("Regex Timeout for {1} after {2} elapsed. Tried pattern {0}", ex.Pattern, ex.Message, ex.MatchTimeout);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Console.WriteLine(ex.ToString());
            }

            return login;
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
