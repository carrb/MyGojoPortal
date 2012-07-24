using System;
using Microsoft.SharePoint.Client;
using MyGojo.Data.Model;
using NLog;

namespace SiteLinksCollector.Processors
{
    public class RecursiveSiteProcessor : IRecursiveSiteProcessor
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();



        public void ProcessSiteCollection(string siteCollectionUrl)
        {
            logger.Info("RecursiveSiteProcessor working...");
            WalkSiteTree(siteCollectionUrl);
            logger.Info(".............processing complete.");    
        }
        

        public bool WalkSiteTree(string siteUrl)
        {
            if (String.IsNullOrEmpty(siteUrl)) return false;

            Console.WriteLine("Working on ----------------------> " + siteUrl);

            try
            {
              using (ClientContext context = new ClientContext(siteUrl))
              {
                  Web site = context.Web;
                  WebCollection subSites = context.Web.Webs;

                  context.Load(context.Web);
                  context.Load(context.Web.Webs, web => web.Include(w => w.Title, w => w.ServerRelativeUrl));
                  context.ExecuteQuery();

                  var currentSiteUrl = "http://akr-spstage1" + site.ServerRelativeUrl;

                  if (!App.CollectedSites.ContainsKey(currentSiteUrl))
                  {
                      var currentSite = new SiteInfo(currentSiteUrl) { Title = site.Title };

                      App.CollectedSites.Add(currentSiteUrl, currentSite);

                      var permProcessor = new AccountPermissionsProcessor(currentSiteUrl, currentSite.Users);
                      currentSite.Users = permProcessor.GetSitePermissions();
                  }

                  if (subSites.Count < 1) return false;
                  
                  foreach (var subsite in subSites)
                  {
                    WalkSiteTree("http://akr-spstage1" + subsite.ServerRelativeUrl);
                  }
              }
            }
            catch (Exception ex)
            {
                logger.Error("Error creating ClientContext and getting SubSites: {0}", ex.Message);
                return false;
            }

            return true;
        }

    }
}
