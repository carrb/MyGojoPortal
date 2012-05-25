using System;
using Microsoft.SharePoint.Client;
using MyGojo.Data.Model;
using NLog;

namespace SiteLinks.Processors
{
    public class RecursiveSiteProcessor : IRecursiveSiteProcessor
    {
        private Logger logger = LogManager.GetCurrentClassLogger();


        ///  Constructor
        public RecursiveSiteProcessor(string siteCollectionUrl)
        {
          logger.Info("RecursiveSiteProcessor working...");
          WalkSiteTree(siteCollectionUrl);
          logger.Info(".............processing complete.");
        }
        

        public void WalkSiteTree(string siteUrl)
        {
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

                      var permProcessor = new AccountPermissionsProcessor(currentSiteUrl, currentSite.UserAccounts);
                      currentSite.UserAccounts = permProcessor.GetSitePermissions();
                  }

                  if (subSites.Count < 1) return;
                  
                  foreach (var subsite in subSites)
                  {
                    WalkSiteTree("http://akr-spstage1" + subsite.ServerRelativeUrl);
                  }
              }
            }
            catch (Exception ex)
            {
                logger.Error("Error creating ClientContext and getting SubSites: {0}", ex.Message);
            }
        }


        //private Web GetRootWebForSiteCollection(string url)
        //{
        //    Web rootWeb = null;
        //
        //    try
        //    {
        //        using (ClientContext context = new ClientContext(url))
        //        {
        //            rootWeb = context.Site.RootWeb;
        //            context.Load(context.Site.RootWeb);
        //            context.ExecuteQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Error creating ClientContext and getting RootWeb for Site Collection: {0}", ex.Message);
        //    }
        //
        //    return rootWeb;
        //}
    }
}
