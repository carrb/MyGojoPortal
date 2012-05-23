using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Should;

namespace SiteLinks.Tests
{
    [TestFixture]
    public class AppTests
    {
        [Test]
        public void Application_Can_Initialize_and_Configure()
        {
            // Arrange

            // Act
            var siteCollectionsToProcess = App.SiteCollections;

            // Assert
            siteCollectionsToProcess.ShouldNotBeNull();
            siteCollectionsToProcess.Count.ShouldNotEqual(0);
            siteCollectionsToProcess.Count.ShouldEqual(11);
        }
    }
}
