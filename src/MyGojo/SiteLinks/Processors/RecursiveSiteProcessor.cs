using System;
using System.Collections.Generic;
using Gojo.Core;
using Microsoft.SharePoint.Client;
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
            Console.WriteLine("Walking: " + siteUrl);

            try
            {
              using (ClientContext context = new ClientContext(siteUrl))
             {
                  Web site = context.Web;
                  WebCollection subSites = context.Web.Webs;
                  context.Load(context.Web);
                  context.Load(context.Web.Webs, web => web.Include(w => w.Title, w => w.ServerRelativeUrl));
                  context.ExecuteQuery();

                  if (!App.CollectedSites.ContainsKey("http://akr-spstage1" + site.ServerRelativeUrl))
                  {
                      App.CollectedSites.Add("http://akr-spstage1" + site.ServerRelativeUrl, site.Title);
                      var permProcessor = new AccountPermissionsProcessor("http://akr-spstage1" + site.ServerRelativeUrl);
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
