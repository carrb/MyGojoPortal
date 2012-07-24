using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;
using Xunit;

namespace SiteLinksCollector.Tests
{
    public class AppTests
    {
        [Fact]
        public void App_Can_Initialize_And_Configure()
        {
            // Arrange 

            // Act
            var siteCollectionsToProcess = App.SiteCollections;

            // Assert
            siteCollectionsToProcess.ShouldNotBeNull();
            siteCollectionsToProcess.Count.ShouldNotEqual(0);
        }
    }
}
