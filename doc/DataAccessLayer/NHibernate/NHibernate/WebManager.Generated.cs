using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial interface IWebManager : IManagerBase<MyGojo.Data.NHibernate.Web, System.Guid>
    {
		// Get Methods
		IList<Web> GetBySiteIdCustomMasterUrl(System.Guid siteId, System.String customMasterUrl);
		IList<Web> GetByFirstUniqueAncestorWebId(System.Guid firstUniqueAncestorWebId);
		IList<Web> GetBySiteIdMasterUrl(System.Guid siteId, System.String masterUrl);
		IList<Web> GetByNavParentWebId(System.Guid navParentWebId);
		IList<Web> GetBySiteIdParentWebIdFullUrl(System.Guid siteId, System.Guid parentWebId, System.String fullUrl);
    }

    partial class WebManager : ManagerBase<MyGojo.Data.NHibernate.Web, System.Guid>, IWebManager
    {
		#region Constructors
		
		public WebManager() : base()
        {
        }
        public WebManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Web> GetBySiteIdCustomMasterUrl(System.Guid siteId, System.String customMasterUrl)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Web));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("CustomMasterUrl", customMasterUrl));
			
			return criteria.List<Web>();
        }
		
		public IList<Web> GetByFirstUniqueAncestorWebId(System.Guid firstUniqueAncestorWebId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Web));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("FirstUniqueAncestorWebId", firstUniqueAncestorWebId));
			
			return criteria.List<Web>();
        }
		
		public IList<Web> GetBySiteIdMasterUrl(System.Guid siteId, System.String masterUrl)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Web));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("MasterUrl", masterUrl));
			
			return criteria.List<Web>();
        }
		
		public IList<Web> GetByNavParentWebId(System.Guid navParentWebId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Web));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("NavParentWebId", navParentWebId));
			
			return criteria.List<Web>();
        }
		
		public IList<Web> GetBySiteIdParentWebIdFullUrl(System.Guid siteId, System.Guid parentWebId, System.String fullUrl)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Web));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SiteId", siteId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ParentWebId", parentWebId));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("FullUrl", fullUrl));
			
			return criteria.List<Web>();
        }
		
		#endregion
    }
}