using System;
using SiteLinks.Processors;

namespace SiteLinks
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var fileProcessor = new RecursiveDirectoryProcessor("C:\\users\\wades\\Pictures");
            //Console.WriteLine("Number of files collected: {0}", App.CollectedFileEntries.Count);
            //
            //Console.WriteLine("Enter any key to exit.");
            //Console.ReadLine();
 
            var siteCollectionsToProcess = App.SiteCollections;

            foreach (var siteColl in siteCollectionsToProcess)
            {
                Console.WriteLine("Creating processor to collect sites in site collection {0} at: {1}", siteColl.Key, siteColl.Value);
                var siteProcessor = new RecursiveSiteProcessor(siteColl.Value);
                
                Console.WriteLine("Collected " + App.CollectedSites.Count + " sites in the SharePoint site collections given.");

            }

            var testPointSites = App.CollectedSites;
            var testPointUsers = App.CollectedUsers;


            Console.WriteLine("Enter any key to exit.");
            Console.ReadLine();
        }

    }
}
