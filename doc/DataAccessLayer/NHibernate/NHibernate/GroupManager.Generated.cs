using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial interface IGroupManager : IManagerBase<MyGojo.Data.NHibernate.Group, string>
    {
		// Get Methods
		Group GetById(System.Guid siteId, System.Int32 id);
		IList<Group> GetBySiteIdDLAlias(System.Guid siteId, System.String dLAlias);
		IList<Group> GetBySiteIdTitle(System.Guid siteId, System.String title);
    }

    partial class GroupManager : ManagerBase<MyGojo.Data.NHibernate.Group, string>, IGroupManager
    {
		#region Constructors
		
		public GroupManager() : base()
        {
        }
        public GroupManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override Group GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for GroupManager.GetById");
			
			return GetById(new System.Guid(keys[0]), System.Int32.Parse(keys[1]));
		}
		public Group GetById(System.Guid siteId, System.Int32 id)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Group));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Id", id));
			
			Group result = (Group)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<Group> GetBySiteIdDLAlias(System.Guid siteId, System.String dLAlias)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Group));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("DLAlias", dLAlias));
			
			return criteria.List<Group>();
        }
		
		public IList<Group> GetBySiteIdTitle(System.Guid siteId, System.String title)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Group));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Title", title));
			
			return criteria.List<Group>();
        }
		
		#endregion
    }
}