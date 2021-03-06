﻿using System;
using SiteLinks.Persisters;
using SiteLinks.Processors;

namespace SiteLinks
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Recursive Directory/File Processor Testing
            //var fileProcessor = new RecursiveDirectoryProcessor("C:\\users\\wades\\Pictures");
            //Console.WriteLine("Number of files collected: {0}", App.CollectedFileEntries.Count);
            //
            //Console.WriteLine("Enter any key to exit.");
            //Console.ReadLine();
            #endregion

            var siteCollectionsToProcess = App.SiteCollections;

            foreach (var siteColl in siteCollectionsToProcess)
            {
                Console.WriteLine("Creating processor to collect sites in site collection {0} at: {1}", siteColl.Key, siteColl.Value);
                var siteProcessor = new RecursiveSiteProcessor(siteColl.Value);
                
                Console.WriteLine("Collected " + App.CollectedSites.Count + " sites in the SharePoint site collections given.");
            }
           
            var siteAccessProcessor = new AccountSiteAccessProcessor(App.CollectedSites, App.CollectedUsers);

            var testPointSites = App.CollectedSites;
            var testPointUsers = App.CollectedUsers;

            //var sitePersister = new SiteInfoPersister(App.CollectedSites);
            var userPersister = new UserInfoPersister(App.CollectedUsers);


            Console.WriteLine("Enter any key to exit.");
            Console.ReadLine();
        }

    }
}
