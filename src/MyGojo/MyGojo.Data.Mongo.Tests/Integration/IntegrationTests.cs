using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MyGojo.Data.Model;
using NUnit.Framework;
using Should;

namespace MyGojo.Data.Mongo.Tests.Integration
{
    [TestFixture]
    public class IntegrationTests
    {
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
    }
}
