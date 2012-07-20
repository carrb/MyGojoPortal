using System;
using System.Collections.Generic;
using System.Linq;
using DreamSongs.MongoRepository;
using Gojo.Core.TextTools;
using MyGojo.Data.Model;
using Utility.Logging;

namespace MyGojo.Web.Orchestrators
{
    public class HomeOrchestrator : IHomeOrchestrator
    {
        private readonly ILogger _logger;
        private readonly MongoRepository<UserInfo> _repository;

        public HomeOrchestrator(MongoRepository<UserInfo> repository, ILogger logger)
        {
            _logger = logger;
            _repository = repository;    
        }

        public IEnumerable<SiteInfo> GetUserSiteLinks(string userLogin)
        {
            var currentUserAdLogin = UserLoginDomainStripper.RemoveDomain(userLogin);

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