using System;
using System.Collections.Generic;
using MyGojo.Data.Mongo.Model;
using NLog;


namespace SiteLinks
{
    public class App
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static IDictionary<string, string> CollectedFileEntries { get; private set; }
        public static IDictionary<string, string> SiteCollections { get; private set; }
        public static IDictionary<string, SiteInfo> CollectedSites { get; private set; }
        public static IDictionary<string, UserInfo> CollectedUsers { get; private set; } 

        // Private Constructor
        static App()
        {
            // Static Constructor fires the first time the SiteCollections object is accessed
            // and never again for the lifetime of the application
            // Note:  Be careful using in multithreaded environment where multiple threads
            // might simultaneously access the data in static object(s).  Reading, generally okay,
            // but writing, should have data protected in the proper synchronization code.
            Initialize();
        }


        private static void Initialize()
        {
            logger.Info("SiteLinks.Tests - (c) 2012 . All Rights Reserved.");
            logger.Info("Initializing...");

            //CollectedFileEntries = new Dictionary<string, string>();
            SiteCollections = LoadSiteCollectionsToProcess();
            CollectedSites = new Dictionary<string, SiteInfo>(StringComparer.OrdinalIgnoreCase);
            CollectedUsers = new Dictionary<string, UserInfo>(StringComparer.OrdinalIgnoreCase);

        }

        // Should Refactor at some point to pull values in from app.config
        private static Dictionary<string, string> LoadSiteCollectionsToProcess()
        {
            Dictionary<string, string> siteCollections = new Dictionary<string, string>
                                                             {
                                                                {"myGOJO", "http://akr-spstage1"},
                                                        //         {"MySite Host", "http://akr-spstage1/mysite"},
                                                                 {"Project Workspaces", "http://akr-spstage1/pw"},
                                                                 {"Home - Techknow", "http://akr-spstage1/sites/techknow"},
                                                                 {"Team Workspaces", "http://akr-spstage1/tw"},
                                                         //        {"Home - Collab", "http://akr-spstage1/collab"},
                                                                 {"Home - File Sharing Workspaces", "http://akr-spstage1/fs"},
                                                         //        {"GOJO Ideas", "http://akr-spstage1/ideas"},
                                                                 {"myGOJO - Portal", "http://akr-spstage1/portal"},
                                                                 {"HR Safety and Environmental","http://akr-spstage1/sites/hrsafetyenv"},
                                                                 {"Home - Marketing Services","http://akr-spstage1/sites/MarketingServices"}
                                                             };

            // To Do: Utilize/Create a app.config section for these.

            // _siteCollections.Add("Dispenser Reporting", "http://akr-spstage1/isignol");
            //_siteCollections.Add("Project Workspaces 2", "http://akr-spstage1/sites/pw");
            // _siteCollections.Add("WOW OS", "http://akr-spstage1/wowos");  --Problems with access
            // _siteCollections.Add("Ultimate Hand Hygeine Plan", "http://akr-spstage1/uhhp");
            // _siteCollections.Add("Home - No Name", "http://akr-spstage1/bi");   

            return siteCollections;
        }
        
    }
}
