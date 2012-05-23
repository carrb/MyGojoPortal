using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate.Tests
{
	[TestFixture]
    public partial class WebTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetWebManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected MyGojo.Data.NHibernate.IWebManager manager;
		
		protected MyGojo.Data.NHibernate.Web CreateNewWeb()
		{
			MyGojo.Data.NHibernate.Web entity = new MyGojo.Data.NHibernate.Web();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = System.Guid.Empty;
			
			entity.SiteId = System.Guid.Empty;
			entity.FullUrl = "Test Test ";
			entity.ParentWebId = System.Guid.Empty;
			entity.ProductVersion = default(Int16);
			entity.TemplateVersion = default(Int16);
			entity.FirstUniqueAncestorWebId = System.Guid.Empty;
			entity.Author = 9;
			entity.Title = "Test Test ";
			entity.TimeCreated = System.DateTime.Now;
			entity.CachedNavDirty = 6;
			entity.CachedNav = new System.Byte[]{};
			entity.CachedInheritedNav = new System.Byte[]{};
			entity.CachedNavScope = "Test Test ";
			entity.CachedDataVersion = 32;
			entity.Description = "Test Test ";
			entity.ScopeId = System.Guid.Empty;
			entity.SecurityProvider = System.Guid.Empty;
			entity.MetaInfo = new System.Byte[]{};
			entity.MetaInfoVersion = 40;
			entity.LastMetadataChange = System.DateTime.Now;
			entity.NavStructNextEid = 48;
			entity.NavParentWebId = System.Guid.Empty;
			entity.NextWebGroupId = 63;
			entity.DefTheme = "Test";
			entity.AlternateCSSUrl = "Test Test ";
			entity.CustomizedCss = "Test Test ";
			entity.CustomJSUrl = "Test Test ";
			entity.AlternateHeaderUrl = "Test Test ";
			entity.DailyUsageData = new System.Byte[]{};
			entity.DailyUsageDataVersion = 28;
			entity.MonthlyUsageData = new System.Byte[]{};
			entity.MonthlyUsageDataVersion = 78;
			entity.DayLastAccessed = default(Int16);
			entity.WebTemplate = 40;
			entity.Language = 72;
			entity.Locale = 98;
			entity.TimeZone = default(Int16);
			entity.Time24 = true;
			entity.CalendarType = default(Int16);
			entity.AdjustHijriDays = default(Int16);
			entity.MeetingCount = default(Int16);
			entity.ProvisionConfig = default(Int16);
			entity.Flags = 40;
			entity.Collation = default(Int16);
			entity.RequestAccessEmail = "Test Test ";
			entity.MasterUrl = "Test Test ";
			entity.CustomMasterUrl = "Test Test ";
			entity.SiteLogoUrl = "Test Test ";
			entity.SiteLogoDescription = "Test Test ";
			entity.AuditFlags = 90;
			entity.InheritAuditFlags = 79;
			entity.Ancestry = new System.Byte[]{};
			entity.AltCalendarType = default(Byte);
			entity.CalendarViewOptions = default(Byte);
			entity.WorkDays = default(Int16);
			entity.WorkDayStartHour = default(Int16);
			entity.WorkDayEndHour = default(Int16);
			entity.EmailEnabled = true;
			
			return entity;
		}
		protected MyGojo.Data.NHibernate.Web GetFirstWeb()
        {
            IList<MyGojo.Data.NHibernate.Web> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				MyGojo.Data.NHibernate.Web entity = CreateNewWeb();
				
                object result = manager.Save(entity);

                Assert.IsNotNull(result);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Read()
        {
            try
            {
                MyGojo.Data.NHibernate.Web entityA = CreateNewWeb();
				manager.Save(entityA);

                MyGojo.Data.NHibernate.Web entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA, entityB);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
		[Test]
		public void Update()
        {
            try
            {
                MyGojo.Data.NHibernate.Web entityA = GetFirstWeb();
				
				entityA.SiteId = System.Guid.Empty;
				
				manager.Update(entityA);

                MyGojo.Data.NHibernate.Web entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.SiteId, entityB.SiteId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Delete()
        {
            try
            {
                MyGojo.Data.NHibernate.Web entity = GetFirstWeb();
				
                manager.Delete(entity);

                entity = manager.GetById(entity.Id);
                Assert.IsNull(entity);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
	}
}

