using System;
using System.Collections.Generic;
using MyGojo.Data.Model;

using NLog;

namespace SiteLinks.Persisters
{
    public class SiteInfoPersister
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();


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
    }
}
