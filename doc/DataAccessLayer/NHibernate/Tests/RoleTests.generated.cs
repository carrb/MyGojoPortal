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
    public partial class RoleTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetRoleManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected MyGojo.Data.NHibernate.IRoleManager manager;
		
		protected MyGojo.Data.NHibernate.Role CreateNewRole()
		{
			MyGojo.Data.NHibernate.Role entity = new MyGojo.Data.NHibernate.Role();
			
			
			entity.SiteId = System.Guid.Empty;
			entity.WebId = System.Guid.Empty;
			entity.RoleId = 10;
			entity.Title = "Test Test ";
			entity.Description = "Test Test ";
			entity.PermMask = default(Int64);
			entity.PermMaskDeny = default(Int64);
			entity.Hidden = true;
			entity.Type = default(Byte);
			entity.WebGroupId = 31;
			entity.RoleOrder = 74;
			
			return entity;
		}
		protected MyGojo.Data.NHibernate.Role GetFirstRole()
        {
            IList<MyGojo.Data.NHibernate.Role> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				MyGojo.Data.NHibernate.Role entity = CreateNewRole();
				
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
                MyGojo.Data.NHibernate.Role entityA = CreateNewRole();
				manager.Save(entityA);

                MyGojo.Data.NHibernate.Role entityB = manager.GetById(entityA.Id);

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
                MyGojo.Data.NHibernate.Role entityA = GetFirstRole();
				
				entityA.Title = "Test Test ";
				
				manager.Update(entityA);

                MyGojo.Data.NHibernate.Role entityB = manager.GetById(entityA.Id);

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
                MyGojo.Data.NHibernate.Role entity = GetFirstRole();
				
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

