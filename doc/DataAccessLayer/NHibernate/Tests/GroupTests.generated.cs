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
    public partial class GroupTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetGroupManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected MyGojo.Data.NHibernate.IGroupManager manager;
		
		protected MyGojo.Data.NHibernate.Group CreateNewGroup()
		{
			MyGojo.Data.NHibernate.Group entity = new MyGojo.Data.NHibernate.Group();
			
			
			entity.SiteId = System.Guid.Empty;
			entity.Id = 13;
			entity.Title = "Test Test ";
			entity.Description = "Test Test ";
			entity.Owner = 71;
			entity.OwnerIsUser = true;
			entity.DLAlias = "Test Test ";
			entity.DLErrorMessage = "Test Test ";
			entity.DLFlags = 53;
			entity.DLJobId = 36;
			entity.DLArchives = "Test Test ";
			entity.RequestEmail = "Test Test ";
			entity.Flags = 71;
			
			return entity;
		}
		protected MyGojo.Data.NHibernate.Group GetFirstGroup()
        {
            IList<MyGojo.Data.NHibernate.Group> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				MyGojo.Data.NHibernate.Group entity = CreateNewGroup();
				
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
                MyGojo.Data.NHibernate.Group entityA = CreateNewGroup();
				manager.Save(entityA);

                MyGojo.Data.NHibernate.Group entityB = manager.GetById(entityA.Id);

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
                MyGojo.Data.NHibernate.Group entityA = GetFirstGroup();
				
				entityA.Title = "Test Test ";
				
				manager.Update(entityA);

                MyGojo.Data.NHibernate.Group entityB = manager.GetById(entityA.Id);

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
                MyGojo.Data.NHibernate.Group entity = GetFirstGroup();
				
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

