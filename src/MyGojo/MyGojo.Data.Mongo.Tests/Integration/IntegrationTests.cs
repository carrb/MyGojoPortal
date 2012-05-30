using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamSongs.MongoRepository;
using MongoDB.Driver;
using MyGojo.Data.Mongo.Model;
using NUnit.Framework;
using Should;

namespace MyGojo.Data.Mongo.Tests.Integration
{
    [TestFixture]
    public class IntegrationTests
    {

        private static readonly MongoRepository<UserInfo> userRepository = new MongoRepository<UserInfo>();

        [SetUp]
        public void SetUp()
        {
            // Only if needed.
        }


        [Test]
        public void Can_Utilize_Many_MongoRepository_Features_Against_Running_Mongo_Instance()
        {
            // See: http://mongorepository.codeplex.com/documentation

            /*

            // Creat some UserInfo objects
            var userOne = new UserInfo
                              {
                                  AdLogin = "GOJO-NET\\wades",
                                  FirstName = "Scott",
                                  LastName = "Wade",
                                  Email = "wades@gojo.com"
                              };

            var userTwo = new UserInfo
            {
                AdLogin = "GOJO-NET\\admsw",
                FirstName = "Admin",
                LastName = "Wade"
            };

            var userThree = new UserInfo
            {
                AdLogin = "GOJO-NET\\BlueChipMike",
                FirstName = "Mike",
                LastName = "BlueChip",
                Email = "someother@outside.com"
            };


            var siteOne = new SiteInfo
                              {
                                  Title = "Site One",
                                  Url = "http://akr-spstage1/pw/2012/Site One/",
                                  IsEditable = true,
                                  IsVisible = true,
                                  Priority = 1
                              };

            var siteTwo = new SiteInfo
            {
                Title = "Site Two",
                Url = "http://akr-spstage1/tw/Site Two/",
                IsEditable = true,
                IsVisible = true,
                Priority = 2
            };

            var siteThree = new SiteInfo
            {
                Title = "Site Two",
                Url = "http://akr-spstage1/fs/Site Three/",
                IsEditable = true,
                IsVisible = true,
                Priority = 3
            };

            List<SiteInfo> sites = new List<SiteInfo>();
            sites.Add(siteOne);
            sites.Add(siteTwo);

            userOne.Sites = sites;
            userTwo.Sites = sites;

            sites.Add(siteThree);

            userThree.Sites = sites;



            userRepository.Add(new[] { userOne, userTwo, userThree });

            // Show contents of DB
            DumpData();


            // Update Users
            //userOne.FirstName = "ScottySmithAndStein";
            //userRepository.Update(userOne);
             * 
             */

            // Delete user
            userRepository.DeleteAll();

            
            DumpData();


        }


        private static void DumpData()
        {
            Console.WriteLine("Currently in the MongoDB: ");

            foreach (var userInfo in userRepository.All())
            {
                Console.WriteLine("User: {0}", userInfo.AdLogin);
            }
            Console.WriteLine(new string('=', 50));
        }




        /*
        [Test]
        public void Can_Initialize_And_Raw_Connect_to_Running_Mongo_Instance()
        {
            // See http://www.mongodb.org/display/DOCS/Connections
            const string ConnectionString = "mongodb://127.0.0.1:27017/?safe=true";
            var server = MongoServer.Create(ConnectionString);
            var db = server.GetDatabase("MyGojoWeb");

            var users = db.GetCollection<UserInfo>("users");
            var userOne = new UserInfo("GOJO-NET\\wades");

            users.Save(userOne);
        }
         */
    }
}
