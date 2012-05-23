using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial interface IUserInfoManager : IManagerBase<MyGojo.Data.NHibernate.UserInfo, string>
    {
		// Get Methods
		UserInfo GetById(System.Guid tpSiteID, System.Int32 tpID);
		IList<UserInfo> GetBytp_SiteIDtp_Email(System.Guid tpSiteID, System.String tpEmail);
		IList<UserInfo> GetBytp_SiteIDtp_Logintp_Deleted(System.Guid tpSiteID, System.String tpLogin, System.Int32 tpDeleted);
		IList<UserInfo> GetBytp_SiteIDtp_SystemID(System.Guid tpSiteID, System.Byte[] tpSystemID);
		IList<UserInfo> GetBytp_SiteIDtp_SiteAdmin(System.Guid tpSiteID, System.Boolean tpSiteAdmin);
		IList<UserInfo> GetBytp_SiteIDtp_Deletedtp_Title(System.Guid tpSiteID, System.Int32 tpDeleted, System.String tpTitle);
    }

    partial class UserInfoManager : ManagerBase<MyGojo.Data.NHibernate.UserInfo, string>, IUserInfoManager
    {
		#region Constructors
		
		public UserInfoManager() : base()
        {
        }
        public UserInfoManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override UserInfo GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for UserInfoManager.GetById");
			
			return GetById(new System.Guid(keys[0]), System.Int32.Parse(keys[1]));
		}
		public UserInfo GetById(System.Guid tpSiteID, System.Int32 tpID)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserInfo));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSiteID", tpSiteID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpID", tpID));
			
			UserInfo result = (UserInfo)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<UserInfo> GetBytp_SiteIDtp_Email(System.Guid tpSiteID, System.String tpEmail)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserInfo));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSiteID", tpSiteID));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpEmail", tpEmail));
			
			return criteria.List<UserInfo>();
        }
		
		public IList<UserInfo> GetBytp_SiteIDtp_Logintp_Deleted(System.Guid tpSiteID, System.String tpLogin, System.Int32 tpDeleted)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserInfo));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSiteID", tpSiteID));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpLogin", tpLogin));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpDeleted", tpDeleted));
			
			return criteria.List<UserInfo>();
        }
		
		public IList<UserInfo> GetBytp_SiteIDtp_SystemID(System.Guid tpSiteID, System.Byte[] tpSystemID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserInfo));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSiteID", tpSiteID));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSystemID", tpSystemID));
			
			return criteria.List<UserInfo>();
        }
		
		public IList<UserInfo> GetBytp_SiteIDtp_SiteAdmin(System.Guid tpSiteID, System.Boolean tpSiteAdmin)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserInfo));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSiteID", tpSiteID));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSiteAdmin", tpSiteAdmin));
			
			return criteria.List<UserInfo>();
        }
		
		public IList<UserInfo> GetBytp_SiteIDtp_Deletedtp_Title(System.Guid tpSiteID, System.Int32 tpDeleted, System.String tpTitle)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserInfo));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpSiteID", tpSiteID));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpDeleted", tpDeleted));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("TpTitle", tpTitle));
			
			return criteria.List<UserInfo>();
        }
		
		#endregion
    }
}