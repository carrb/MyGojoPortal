using System;
using System.Collections.Generic;
using System.Text;

using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public interface IManagerFactory
    {
		// Get Methods
		IPermManager GetPermManager();
		IPermManager GetPermManager(INHibernateSession session);
		IRoleManager GetRoleManager();
		IRoleManager GetRoleManager(INHibernateSession session);
		IUserInfoManager GetUserInfoManager();
		IUserInfoManager GetUserInfoManager(INHibernateSession session);
		IWebManager GetWebManager();
		IWebManager GetWebManager(INHibernateSession session);
    }

    public class ManagerFactory : IManagerFactory
    {
        #region Constructors

        public ManagerFactory()
        {
        }

        #endregion

        #region Get Methods

		public IPermManager GetPermManager()
        {
            return new PermManager();
        }
		public IPermManager GetPermManager(INHibernateSession session)
        {
            return new PermManager(session);
        }
		public IRoleManager GetRoleManager()
        {
            return new RoleManager();
        }
		public IRoleManager GetRoleManager(INHibernateSession session)
        {
            return new RoleManager(session);
        }
		public IUserInfoManager GetUserInfoManager()
        {
            return new UserInfoManager();
        }
		public IUserInfoManager GetUserInfoManager(INHibernateSession session)
        {
            return new UserInfoManager(session);
        }
		public IWebManager GetWebManager()
        {
            return new WebManager();
        }
		public IWebManager GetWebManager(INHibernateSession session)
        {
            return new WebManager(session);
        }
        
        #endregion
    }
}
