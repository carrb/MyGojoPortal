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
    public partial class PermTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetPermManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected MyGojo.Data.NHibernate.IPermManager manager;
		
		protected MyGojo.Data.NHibernate.Perm CreateNewPerm()
		{
			MyGojo.Data.NHibernate.Perm entity = new MyGojo.Data.NHibernate.Perm();
			
			
			entity.SiteId = System.Guid.Empty;
			entity.DelTransId = new System.Byte[]{};
			entity.ScopeUrl = "Test Test ";
			entity.ScopeId = System.Guid.Empty;
			entity.RoleDefWebId = System.Guid.Empty;
			entity.WebId = System.Guid.Empty;
			entity.AnonymousPermMask = default(Int64);
			entity.Acl = new System.Byte[]{};
			
			return entity;
		}
		protected MyGojo.Data.NHibernate.Perm GetFirstPerm()
        {
            IList<MyGojo.Data.NHibernate.Perm> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				MyGojo.Data.NHibernate.Perm entity = CreateNewPerm();
				
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
                MyGojo.Data.NHibernate.Perm entityA = CreateNewPerm();
				manager.Save(entityA);

                MyGojo.Data.NHibernate.Perm entityB = manager.GetById(entityA.Id);

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
                MyGojo.Data.NHibernate.Perm entityA = GetFirstPerm();
				
				entityA.ScopeId = System.Guid.Empty;
				
				manager.Update(entityA);

                MyGojo.Data.NHibernate.Perm entityB = manager.GetById(entityA.Id);

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
                MyGojo.Data.NHibernate.Perm entity = GetFirstPerm();
				
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

