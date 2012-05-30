using System;
using System.Collections.Generic;
using DreamSongs.MongoRepository;
using MyGojo.Data.Mongo.Model;
using NLog;

namespace SiteLinks.Persisters
{
    public class SiteInfoPersister
    {
        private Logger logger = LogManager.GetCurrentClassLogger();


        // Constructor
        public SiteInfoPersister(IDictionary<string, SiteInfo> collectedSites)
        {
            PersistSiteInfo(collectedSites);
        }



        public void PersistSiteInfo(IDictionary<string, SiteInfo> sites)
        {
            try
            {
     
            }
            catch (Exception ex)
            {
                logger.Error("Error persisting sites: {0}", ex.Message);
            }
        }



        // Needs to check for existing UserInfo objects alredy persisted in database...see code snippet below commented out!
        /*
        public void PersistSiteInfo(IDictionary<string, SiteInfo> sites)
        {
            try
            {
                using (var context = new MyGojoContext())
                {
                    var repository = new SiteInfoRepository(context);

                    foreach (var site in sites)
                    {
                        repository.InsertOrUpdate(site.Value);
                    }

                    repository.Save();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error using MyGojoContext: {0}", ex.Message);
            }
        }
        */



        /*
        using (var context = new MyGojoWebContext())
            {
                var repository = new UserRepository(context);
                var storedUsers = repository.All.ToList();

                foreach (var currentUser in debugAllUsers.Select(userEntry => userEntry.Value))
                {
                    var result = storedUsers.SingleOrDefault(u => u.AdLogin == currentUser.AdLogin);
             
                    if (result == null || result.Workspaces == null)
                    {
                        repository.InsertOrUpdate(currentUser);
                        continue;
                    }
                    
                    if (result.Workspaces.Equals(currentUser.Workspaces)) continue;
                    repository.InsertOrUpdate(currentUser);
                }
                repository.Save();
            }
            Console.WriteLine("\nDone.");
        }
        */

    }
}
