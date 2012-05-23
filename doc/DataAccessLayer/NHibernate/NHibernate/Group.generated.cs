using System;
using System.Collections;
using System.Collections.Generic;

using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial class Group : BusinessBase<string>
    {
        #region Declarations

		private System.Guid _siteId = Guid.Empty;
		private int _id = default(Int32);
		private string _title = String.Empty;
		private string _description = null;
		private int _owner = default(Int32);
		private bool _ownerIsUser = default(Boolean);
		private string _dLAlias = null;
		private string _dLErrorMessage = null;
		private int? _dLFlags = null;
		private int? _dLJobId = null;
		private string _dLArchives = null;
		private string _requestEmail = null;
		private int _flags = default(Int32);
		
		
		
		#endregion

        #region Constructors

        public Group() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_siteId);
			sb.Append(_id);
			sb.Append(_title);
			sb.Append(_description);
			sb.Append(_owner);
			sb.Append(_ownerIsUser);
			sb.Append(_dLAlias);
			sb.Append(_dLErrorMessage);
			sb.Append(_dLFlags);
			sb.Append(_dLJobId);
			sb.Append(_dLArchives);
			sb.Append(_requestEmail);
			sb.Append(_flags);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public override string Id
		{
			get
			{
				System.Text.StringBuilder uniqueId = new System.Text.StringBuilder();
				uniqueId.Append(_siteId.ToString());
				uniqueId.Append("^");
				uniqueId.Append(_id.ToString());
				return uniqueId.ToString();
			}
		}
		
		public virtual System.Guid SiteId
        {
            get { return _siteId; }
			set
			{
				OnSiteIdChanging();
				_siteId = value;
				OnSiteIdChanged();
			}
        }
		partial void OnSiteIdChanging();
		partial void OnSiteIdChanged();
		
		public virtual int Id
        {
            get { return _id; }
			set
			{
				OnIdChanging();
				_id = value;
				OnIdChanged();
			}
        }
		partial void OnIdChanging();
		partial void OnIdChanged();
		
		public virtual string Title
        {
            get { return _title; }
			set
			{
				OnTitleChanging();
				_title = value;
				OnTitleChanged();
			}
        }
		partial void OnTitleChanging();
		partial void OnTitleChanged();
		
		public virtual string Description
        {
            get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				OnDescriptionChanged();
			}
        }
		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		
		public virtual int Owner
        {
            get { return _owner; }
			set
			{
				OnOwnerChanging();
				_owner = value;
				OnOwnerChanged();
			}
        }
		partial void OnOwnerChanging();
		partial void OnOwnerChanged();
		
		public virtual bool OwnerIsUser
        {
            get { return _ownerIsUser; }
			set
			{
				OnOwnerIsUserChanging();
				_ownerIsUser = value;
				OnOwnerIsUserChanged();
			}
        }
		partial void OnOwnerIsUserChanging();
		partial void OnOwnerIsUserChanged();
		
		public virtual string DLAlias
        {
            get { return _dLAlias; }
			set
			{
				OnDLAliasChanging();
				_dLAlias = value;
				OnDLAliasChanged();
			}
        }
		partial void OnDLAliasChanging();
		partial void OnDLAliasChanged();
		
		public virtual string DLErrorMessage
        {
            get { return _dLErrorMessage; }
			set
			{
				OnDLErrorMessageChanging();
				_dLErrorMessage = value;
				OnDLErrorMessageChanged();
			}
        }
		partial void OnDLErrorMessageChanging();
		partial void OnDLErrorMessageChanged();
		
		public virtual int? DLFlags
        {
            get { return _dLFlags; }
			set
			{
				OnDLFlagsChanging();
				_dLFlags = value;
				OnDLFlagsChanged();
			}
        }
		partial void OnDLFlagsChanging();
		partial void OnDLFlagsChanged();
		
		public virtual int? DLJobId
        {
            get { return _dLJobId; }
			set
			{
				OnDLJobIdChanging();
				_dLJobId = value;
				OnDLJobIdChanged();
			}
        }
		partial void OnDLJobIdChanging();
		partial void OnDLJobIdChanged();
		
		public virtual string DLArchives
        {
            get { return _dLArchives; }
			set
			{
				OnDLArchivesChanging();
				_dLArchives = value;
				OnDLArchivesChanged();
			}
        }
		partial void OnDLArchivesChanging();
		partial void OnDLArchivesChanged();
		
		public virtual string RequestEmail
        {
            get { return _requestEmail; }
			set
			{
				OnRequestEmailChanging();
				_requestEmail = value;
				OnRequestEmailChanged();
			}
        }
		partial void OnRequestEmailChanging();
		partial void OnRequestEmailChanged();
		
		public virtual int Flags
        {
            get { return _flags; }
			set
			{
				OnFlagsChanging();
				_flags = value;
				OnFlagsChanged();
			}
        }
		partial void OnFlagsChanging();
		partial void OnFlagsChanged();
		
        #endregion
    }
}
