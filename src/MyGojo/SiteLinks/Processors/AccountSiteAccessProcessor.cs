using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGojo.Data.Mongo.Model;
using NLog;

namespace SiteLinks.Processors
{
    public class AccountSiteAccessProcessor
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private readonly string thisAccount;



        ///  Constructor
        public AccountSiteAccessProcessor()
        {
            // not really needed
        }

        public AccountSiteAccessProcessor(IDictionary<string, SiteInfo> collectedSites, IDictionary<string, UserInfo> collectedUsers)
        {
            CollectAccountSitesAccessible(collectedSites, collectedUsers);
        }

        public void CollectAccountSitesAccessible(IDictionary<string, SiteInfo> sites, IDictionary<string, UserInfo> users)
        {
            foreach (var user in users)
            {
                foreach (var site in sites)
                {
                    foreach (var u in site.Value.Users.Where(u => user.Key == u.AdLogin))
                    {
                        user.Value.Sites.Add(site.Value);
                    }
                }
            }
        }
    }
}
