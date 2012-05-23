using System;
using System.Collections.Generic;
using Microsoft.SharePoint.Client;
using NUnit.Framework;
using Should;
using SiteLinks.Processors;
using SiteLinks.Tests.Fakes;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace SiteLinks.Tests.Processors
{
    [TestFixture]
    public class RecursiveSiteProcessorTests
    {
        public const string siteUrl = "http://akr-spstage1/pw/2012/E2 Bulk Soap";


        [SetUp]
        public void Setup()
        {
            // var siteCollectionsToProcess = App.SiteCollections;
        }

        /*
               [Test]
               public void SiteProcessor__Returns_Null__When_Accessing_RootWeb_Or_SubSites_Before_Calling_ProcessSite()
               {
                   // Arrange
                   var processor = new RecursiveSiteProcessor();

                   // Act and Assert
                   processor.RootWeb.ShouldBeNull();
                   processor.RootSubSites.ShouldBeNull();
               }

        
      
               [Test]
               public void SiteProcessor__Given_Valid_Web_Site_Url__Can_Get__RootSite()
               {
                   // Not working trying mock out ObjectPath or ClientRuntimeContext abstract with internal constructors!
                   //JustMock docs: http://www.telerik.com/help/justmock/basic-usage-mock.html

                   // Arrange
                   Web RootWeb = null;
                   var processor = Mock.Create<IRecursiveSiteProcessor>();
                   var oPath = Mock.Create<ObjectPath>();
                   var fakeContext = new FakeClientContext();

                   //Mock.Arrange(() => processor.ProcessSite(siteUrl)).Returns(web);

                   Mock.ArrangeSet(() => processor.ProcessSite(siteUrl)).DoInstead(() => RootWeb = new Web(fakeContext, oPath));

                   //Act
                   processor.ProcessSite(siteUrl);

                   //Assert
                   //processor.RootWeb.ShouldNotBeNull();
                   processor.RootWeb.ShouldBeType<Web>();
                   processor.RootWeb.Id.ShouldBeType<Guid>();
                   processor.RootWeb.ServerRelativeUrl.ShouldNotBeNull();
                   processor.RootWeb.Title.ShouldNotBeNull();
               }

       
             [Test]
             public void SiteProcessor__Given_Valid_Web_Site_Url__Can_Get__RootSite_And_Subsites()
             {
                     // Arrange
                 var processor = new RecursiveSiteProcessor();

                 //Act
                 processor.ProcessSite(siteUrl);

                 // Assert
                 processor.SubSites.ShouldNotBeNull();
                 processor.SubSites.ShouldBeType<WebCollection>();
             }

             [Test]
             public void SiteProcessor__Given_Valid_Web_Site_Url__Can_Get__SubSite_Webs_Title_And_Url()
             {
                 // Arrange
                 var processor = new RecursiveSiteProcessor();

                 //Act
                 processor.ProcessSite(siteUrl);

                 // Assert
                 foreach (var site in processor.SubSites)
                 {
                     site.ServerRelativeUrl.ShouldNotBeNull();
                     site.ServerRelativeUrl.ShouldBeType<string>();

                     if (!string.IsNullOrEmpty(site.Title)) site.Title.ShouldBeType<string>();
                 }
             }

             [Test]
             public void SiteProcessor__Throws_Exception__When_ProcessSite_Is_Called_More_Than_Once()
             {
                 // Arrange
                 var processor = new RecursiveSiteProcessor();

                 // Act
                 processor.ProcessSite(siteUrl);

                 // Assert
                 Assert.Throws<ArgumentException>(() => processor.ProcessSite(siteUrl));
             }

      


      
             [Test]
             public void Processor_Can_Get__RootWeb_Site_Or_Subsite_RoleAssignmentCollection()
             {
                 // Arrange
                 var processor = new RecursiveSiteProcessor(siteUrl);
                 RoleAssignmentCollection roles = null;

                 // Act
                 using (ClientContext context = new ClientContext(processor.CurrentSiteUrl.Url))
                 {
                     roles = context.Site.RootWeb.RoleAssignments;
                     context.Load(roles);
                     context.ExecuteQuery();
                 }

                 // Assert
                 roles.ShouldNotBeNull();
                 roles.ShouldNotBeEmpty();
                 roles.ShouldBeType<RoleAssignmentCollection>();
             }

             [Test]
             public void Processor_Can_Get__RootWeb_Site_Or_Subsite_SiteGroups_GroupCollection()
             {
                 var processor = new RecursiveSiteProcessor(siteUrl);
                 GroupCollection groupCollection = null;

                 using (ClientContext context = new ClientContext(processor.CurrentSiteUrl.Url))
                 {
                     groupCollection = context.Site.RootWeb.SiteGroups;
                     context.Load(groupCollection,groups => groups.Include(group => group.Users));
                     context.ExecuteQuery();
                 }

                 groupCollection.ShouldNotBeNull();
                 groupCollection.ShouldNotBeEmpty();
                 groupCollection.ShouldBeType<GroupCollection>();
             }

             [Test]
             public void Processor_Can_Get__Specific_Groups_And_UserCollection_From_GroupCollection()
             {
                 var processor = new RecursiveSiteProcessor(siteUrl);
                 GroupCollection groupCollection = null;
                 UserCollection userCollection = null;

                 using (ClientContext context = new ClientContext(processor.CurrentSiteUrl.Url))
                 {
                     groupCollection = context.Site.RootWeb.SiteGroups;
                     context.Load(groupCollection, groups => groups.Include(group => group.Users));
                     context.ExecuteQuery();

                     foreach (Group group in groupCollection)
                     {
                         userCollection = group.Users;

                         group.ShouldNotBeNull();
                         group.ShouldBeType<Group>();

                         userCollection.ShouldNotBeNull();
                         userCollection.ShouldBeType<UserCollection>();
                     }
                 }
             }

             [Test]
             public void Processor_Can_Get__Specific_Users_From_Specific_Groups_And_UserCollection()
             {
                 var processor = new RecursiveSiteProcessor(siteUrl);


                 using (ClientContext context = new ClientContext(processor.CurrentSiteUrl.Url))
                 {
                     GroupCollection groupCollection = context.Site.RootWeb.SiteGroups;
                     context.Load(groupCollection, groups => groups.Include(group => group.Users));
                     context.ExecuteQuery();

                     foreach (Group group in groupCollection)
                     {
                         UserCollection userCollection = @group.Users;

                         foreach (User user in userCollection)
                         {
                             user.ShouldNotBeNull();
                             user.ShouldBeType<User>();
                             user.Title.ShouldNotBeEmpty();
                             user.LoginName.ShouldNotBeEmpty();
                             //user.Email.ShouldNotBeEmpty();   -- some ARE empty!
                             //Console.WriteLine("User name: {0}, LoginName: {1}, Email: {2}", user.Title, user.LoginName, user.Email);
                         }
                     }
                 }
             }

             */

        [Test]
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
