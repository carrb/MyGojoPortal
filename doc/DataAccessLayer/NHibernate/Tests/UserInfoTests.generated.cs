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
    public partial class UserInfoTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetUserInfoManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected MyGojo.Data.NHibernate.IUserInfoManager manager;
		
		protected MyGojo.Data.NHibernate.UserInfo CreateNewUserInfo()
		{
			MyGojo.Data.NHibernate.UserInfo entity = new MyGojo.Data.NHibernate.UserInfo();
			
			
			entity.TpSiteID = System.Guid.Empty;
			entity.TpID = 25;
			entity.TpDomainGroup = true;
			entity.TpGUID = System.Guid.Empty;
			entity.TpSystemID = new System.Byte[]{};
			entity.TpDeleted = 31;
			entity.TpSiteAdmin = true;
			entity.TpIsActive = true;
			entity.TpLogin = "Test Test ";
			entity.TpTitle = "Test Test ";
			entity.TpEmail = "Test Test ";
			entity.TpNotes = "Test Test ";
			entity.TpToken = new System.Byte[]{};
			entity.TpExternalToken = new System.Byte[]{};
			entity.TpExternalTokenLastUpdated = System.DateTime.Now;
			entity.TpLocale = 6;
			entity.TpCalendarType = default(Int16);
			entity.TpAdjustHijriDays = default(Int16);
			entity.TpTimeZone = default(Int16);
			entity.TpTime24 = true;
			entity.TpAltCalendarType = default(Byte);
			entity.TpCalendarViewOptions = default(Byte);
			entity.TpWorkDays = default(Int16);
			entity.TpWorkDayStartHour = default(Int16);
			entity.TpWorkDayEndHour = default(Int16);
			
			return entity;
		}
		protected MyGojo.Data.NHibernate.UserInfo GetFirstUserInfo()
        {
            IList<MyGojo.Data.NHibernate.UserInfo> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				MyGojo.Data.NHibernate.UserInfo entity = CreateNewUserInfo();
				
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
                MyGojo.Data.NHibernate.UserInfo entityA = CreateNewUserInfo();
				manager.Save(entityA);

                MyGojo.Data.NHibernate.UserInfo entityB = manager.GetById(entityA.Id);

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
                MyGojo.Data.NHibernate.UserInfo entityA = GetFirstUserInfo();
				
				entityA.TpDomainGroup = true;
				
				manager.Update(entityA);

                MyGojo.Data.NHibernate.UserInfo entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.TpSiteID, entityB.TpSiteID);
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
                MyGojo.Data.NHibernate.UserInfo entity = GetFirstUserInfo();
				
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

