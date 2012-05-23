using System;
using System.Collections;
using System.Collections.Generic;

using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial class Perm : BusinessBase<string>
    {
        #region Declarations

		private System.Guid _siteId = Guid.Empty;
		private byte[] _delTransId = null;
		private string _scopeUrl = String.Empty;
		private System.Guid _scopeId = Guid.Empty;
		private System.Guid _roleDefWebId = Guid.Empty;
		private System.Guid _webId = Guid.Empty;
		private long _anonymousPermMask = default(Int64);
		private byte[] _acl = null;
		
		
		
		#endregion

        #region Constructors

        public Perm() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_siteId);
			sb.Append(_delTransId);
			sb.Append(_scopeUrl);
			sb.Append(_scopeId);
			sb.Append(_roleDefWebId);
			sb.Append(_webId);
			sb.Append(_anonymousPermMask);
			sb.Append(_acl);

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
				uniqueId.Append(_delTransId.ToString());
				uniqueId.Append("^");
				uniqueId.Append(_scopeUrl.ToString());
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
		
		public virtual byte[] DelTransId
        {
            get { return _delTransId; }
			set
			{
				OnDelTransIdChanging();
				_delTransId = value;
				OnDelTransIdChanged();
			}
        }
		partial void OnDelTransIdChanging();
		partial void OnDelTransIdChanged();
		
		public virtual string ScopeUrl
        {
            get { return _scopeUrl; }
			set
			{
				OnScopeUrlChanging();
				_scopeUrl = value;
				OnScopeUrlChanged();
			}
        }
		partial void OnScopeUrlChanging();
		partial void OnScopeUrlChanged();
		
		public virtual System.Guid ScopeId
        {
            get { return _scopeId; }
			set
			{
				OnScopeIdChanging();
				_scopeId = value;
				OnScopeIdChanged();
			}
        }
		partial void OnScopeIdChanging();
		partial void OnScopeIdChanged();
		
		public virtual System.Guid RoleDefWebId
        {
            get { return _roleDefWebId; }
			set
			{
				OnRoleDefWebIdChanging();
				_roleDefWebId = value;
				OnRoleDefWebIdChanged();
			}
        }
		partial void OnRoleDefWebIdChanging();
		partial void OnRoleDefWebIdChanged();
		
		public virtual System.Guid WebId
        {
            get { return _webId; }
			set
			{
				OnWebIdChanging();
				_webId = value;
				OnWebIdChanged();
			}
        }
		partial void OnWebIdChanging();
		partial void OnWebIdChanged();
		
		public virtual long AnonymousPermMask
        {
            get { return _anonymousPermMask; }
			set
			{
				OnAnonymousPermMaskChanging();
				_anonymousPermMask = value;
				OnAnonymousPermMaskChanged();
			}
        }
		partial void OnAnonymousPermMaskChanging();
		partial void OnAnonymousPermMaskChanged();
		
		public virtual byte[] Acl
        {
            get { return _acl; }
			set
			{
				OnAclChanging();
				_acl = value;
				OnAclChanged();
			}
        }
		partial void OnAclChanging();
		partial void OnAclChanged();
		
        #endregion
    }
}
