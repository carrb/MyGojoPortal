using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamSongs.MongoRepository;
using MyGojo.Data.Model;
using NLog;
using SiteLinksCollector.Persisters;
using SiteLinksCollector.Processors;

namespace SiteLinksCollector
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info("Attempting to connect to MongoDB and initialize a repository...");

            try
            {
                MongoRepository<UserInfo> userRepository = new MongoRepository<UserInfo>();
                //var connectTest = userRepository.GetSingle(u => string.IsNullOrEmpty(u.AdLogin));

                logger.Info("Success.");
            }
            catch (Exception ex)
            {
                logger.Error("Error creatint userRepository or getting a single entry", ex.Message);
            }

            var siteCollectionsToProcess = App.SiteCollections;

            foreach (var siteColl in siteCollectionsToProcess)
            {
                Console.WriteLine("Creating processor to collect sites in site collection {0} at: {1}", siteColl.Key, siteColl.Value);
                var siteProcessor = new RecursiveSiteProcessor();
                siteProcessor.ProcessSiteCollection(siteColl.Value);

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


        static Dictionary<string, string> GetSiteCollectionsFromConfig()
        {
            var siteCollections = new Dictionary<string, string>
                {
                    {"siteCollection01", ConfigurationManager.AppSettings["siteCollection01"]},
                    {"siteCollection02", ConfigurationManager.AppSettings["siteCollection02"]}
                };

            return siteCollections;
        }
    }
}
