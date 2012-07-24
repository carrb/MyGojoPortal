using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;
using SiteLinksCollector.Processors;
using Xunit;

namespace SiteLinksCollector.Tests.Processors
{
    public class RecursiveSiteProcessorTests
    {
        // Integration Tests Sample Site
        public const string siteUrl = "http://akr-spstage1/pw/2012/E2 Bulk Soap";

        
        [Fact]
        public void SiteProcessor__Returns_False__When_SiteCollection_Url_Is_Null_Or_Empty()
        {
            // Arrange
            var processor = new RecursiveSiteProcessor();

            // Act
            var success = processor.WalkSiteTree("");

            // Assert
            success.ShouldBeFalse();
        }



        [Fact]
        public void Verify_That_ShouldAssertionLibrary_IsWorking()
        {
            object obj = null;
            obj.ShouldBeNull();

            obj = new object();
            obj.ShouldBeType(typeof(object));
            obj.ShouldEqual(obj);
            obj.ShouldNotBeNull();
            obj.ShouldNotBeSameAs(new object());
            obj.ShouldNotBeType(typeof(string));
            obj.ShouldNotEqual("foo");

            obj = "x";
            obj.ShouldNotBeInRange("y", "z");
            obj.ShouldBeInRange("a", "z");
            obj.ShouldBeSameAs("x");

            "This String".ShouldContain("This");
            "This String".ShouldNotBeEmpty();
            "This String".ShouldNotContain("foobar");

            false.ShouldBeFalse();
            true.ShouldBeTrue();

            var list = new List<object>();
            list.ShouldBeEmpty();
            list.ShouldNotContain(new object());

            var item = new object();
            list.Add(item);
            list.ShouldNotBeEmpty();
            list.ShouldContain(item);
        }
    }
}
