using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using DreamSongs.MongoRepository;

using MyGojo.Data.Model;
using Utility.Logging;

namespace MyGojo.Web.Controllers
{
    // See: http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
    // See: http://weblogs.asp.net/fredriknormen/archive/2012/06/11/asp-net-web-api-exception-handling.aspx
    public class SiteLinksController : ApiController
    {
        private readonly ILogger _logger;
        private readonly MongoRepository<UserInfo> _repository; 

        public SiteLinksController(MongoRepository<UserInfo> repository, ILogger logger)
        {
            _logger = logger;
            _repository = repository;
            _logger.Info("UserSitesController created...this logger was injected!");    
        }

        
        // GET /api/UserSites
        // 

        public IEnumerable<SiteInfo> Get()
        {
            _logger.Info("Entering Get method...");
            var currentUserAdLogin = IsolateLogin(User.Identity.Name);

            try
            {
                var foundUser = _repository.GetSingle(u => u.AdLogin == currentUserAdLogin);

                if (foundUser == null || foundUser.Sites.Count == 0)
                {
                    return new[] { new SiteInfo { Title = "No Workspace Membership", Url = "#" } };
                }

                return foundUser.Sites.OrderBy(s => s.Title);
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                _logger.Info(ex.GetType().ToString());
                return new[] { new SiteInfo { Title = "No Workspace Membership", Url = "#" } };
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

    }
}
