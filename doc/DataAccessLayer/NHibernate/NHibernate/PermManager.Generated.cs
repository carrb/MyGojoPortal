using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial interface IPermManager : IManagerBase<MyGojo.Data.NHibernate.Perm, string>
    {
		// Get Methods
		Perm GetById(System.Guid siteId, System.Byte[] delTransId, System.String scopeUrl);
		IList<Perm> GetBySiteIdScopeId(System.Guid siteId, System.Guid scopeId);
    }

    partial class PermManager : ManagerBase<MyGojo.Data.NHibernate.Perm, string>, IPermManager
    {
		#region Constructors
		
		public PermManager() : base()
        {
        }
        public PermManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override Perm GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 3)
				throw new Exception("Invalid Id for PermManager.GetById");
			
			return GetById(new System.Guid(keys[0]), System.Byte[].Parse(keys[1]), keys[2]);
		}
		public Perm GetById(System.Guid siteId, System.Byte[] delTransId, System.String scopeUrl)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Perm));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			criteria.Add(NHibernate.Criterion.Expression.Eq("DelTransId", delTransId));
			criteria.Add(NHibernate.Criterion.Expression.Eq("ScopeUrl", scopeUrl));
			
			Perm result = (Perm)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<Perm> GetBySiteIdScopeId(System.Guid siteId, System.Guid scopeId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Perm));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ScopeId", scopeId));
			
			return criteria.List<Perm>();
        }
		
		#endregion
    }
}