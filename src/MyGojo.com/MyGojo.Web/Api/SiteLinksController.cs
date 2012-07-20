using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using DreamSongs.MongoRepository;
using Gojo.Core.TextTools;
using MyGojo.Data.Model;
using Utility.Logging;

namespace MyGojo.Web.Api
{
    // See: http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
    // See: http://weblogs.asp.net/fredriknormen/archive/2012/06/11/asp-net-web-api-exception-handling.aspx
    //      http://blogs.msdn.com/b/youssefm/archive/2012/06/28/error-handling-in-asp-net-webapi.aspx
    //      http://weblogs.asp.net/fredriknormen/archive/2012/06/28/using-razor-together-with-asp-net-web-api.aspx
    //      http://weblogs.asp.net/fredriknormen/archive/2012/06/09/log-message-request-and-response-in-asp-net-webapi.aspx
    //
    //

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
            var currentUserAdLogin = UserLoginDomainStripper.RemoveDomain(User.Identity.Name);

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



    }
}
