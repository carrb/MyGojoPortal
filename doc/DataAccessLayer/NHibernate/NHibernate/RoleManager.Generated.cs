using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial interface IRoleManager : IManagerBase<MyGojo.Data.NHibernate.Role, string>
    {
		// Get Methods
		Role GetById(System.Guid siteId, System.Guid webId, System.Int32 roleId);
		IList<Role> GetBySiteIdWebIdTitle(System.Guid siteId, System.Guid webId, System.String title);
    }

    partial class RoleManager : ManagerBase<MyGojo.Data.NHibernate.Role, string>, IRoleManager
    {
		#region Constructors
		
		public RoleManager() : base()
        {
        }
        public RoleManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override Role GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 3)
				throw new Exception("Invalid Id for RoleManager.GetById");
			
			return GetById(new System.Guid(keys[0]), new System.Guid(keys[1]), System.Int32.Parse(keys[2]));
		}
		public Role GetById(System.Guid siteId, System.Guid webId, System.Int32 roleId)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Role));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			criteria.Add(NHibernate.Criterion.Expression.Eq("WebId", webId));
			criteria.Add(NHibernate.Criterion.Expression.Eq("RoleId", roleId));
			
			Role result = (Role)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<Role> GetBySiteIdWebIdTitle(System.Guid siteId, System.Guid webId, System.String title)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Role));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("WebId", webId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Title", title));
			
			return criteria.List<Role>();
        }
		
		#endregion
    }
}