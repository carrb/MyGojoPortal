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

        private static MongoRepository<UserInfo> userRepository = new MongoRepository<UserInfo>();

        [SetUp]
        public void SetUp()
        {
            // Only if needed.
        }


        [Test]
        public void Can_Utilize_Many_MongoRepository_Features_Against_Running_Mongo_Instance()
        {
            // See: http://mongorepository.codeplex.com/documentation



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


            //userRepository.Add(new[] { userOne, userTwo, userThree });

            // Show contents of DB
            //DumpData();


            // Update Users
            //userOne.FirstName = "ScottySmithAndStein";
            //userRepository.Update(userOne);

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
