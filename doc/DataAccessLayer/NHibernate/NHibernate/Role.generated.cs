using System;
using System.Collections;
using System.Collections.Generic;

using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial class Role : BusinessBase<string>
    {
        #region Declarations

		private System.Guid _siteId = Guid.Empty;
		private System.Guid _webId = Guid.Empty;
		private int _roleId = default(Int32);
		private string _title = String.Empty;
		private string _description = null;
		private long? _permMask = null;
		private long? _permMaskDeny = null;
		private bool _hidden = default(Boolean);
		private byte _type = default(Byte);
		private int _webGroupId = default(Int32);
		private int _roleOrder = default(Int32);
		
		
		
		#endregion

        #region Constructors

        public Role() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_siteId);
			sb.Append(_webId);
			sb.Append(_roleId);
			sb.Append(_title);
			sb.Append(_description);
			sb.Append(_permMask);
			sb.Append(_permMaskDeny);
			sb.Append(_hidden);
			sb.Append(_type);
			sb.Append(_webGroupId);
			sb.Append(_roleOrder);

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
				uniqueId.Append(_webId.ToString());
				uniqueId.Append("^");
				uniqueId.Append(_roleId.ToString());
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
		
		public virtual int RoleId
        {
            get { return _roleId; }
			set
			{
				OnRoleIdChanging();
				_roleId = value;
				OnRoleIdChanged();
			}
        }
		partial void OnRoleIdChanging();
		partial void OnRoleIdChanged();
		
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
		
		public virtual long? PermMask
        {
            get { return _permMask; }
			set
			{
				OnPermMaskChanging();
				_permMask = value;
				OnPermMaskChanged();
			}
        }
		partial void OnPermMaskChanging();
		partial void OnPermMaskChanged();
		
		public virtual long? PermMaskDeny
        {
            get { return _permMaskDeny; }
			set
			{
				OnPermMaskDenyChanging();
				_permMaskDeny = value;
				OnPermMaskDenyChanged();
			}
        }
		partial void OnPermMaskDenyChanging();
		partial void OnPermMaskDenyChanged();
		
		public virtual bool Hidden
        {
            get { return _hidden; }
			set
			{
				OnHiddenChanging();
				_hidden = value;
				OnHiddenChanged();
			}
        }
		partial void OnHiddenChanging();
		partial void OnHiddenChanged();
		
		public virtual byte Type
        {
            get { return _type; }
			set
			{
				OnTypeChanging();
				_type = value;
				OnTypeChanged();
			}
        }
		partial void OnTypeChanging();
		partial void OnTypeChanged();
		
		public virtual int WebGroupId
        {
            get { return _webGroupId; }
			set
			{
				OnWebGroupIdChanging();
				_webGroupId = value;
				OnWebGroupIdChanged();
			}
        }
		partial void OnWebGroupIdChanging();
		partial void OnWebGroupIdChanged();
		
		public virtual int RoleOrder
        {
            get { return _roleOrder; }
			set
			{
				OnRoleOrderChanging();
				_roleOrder = value;
				OnRoleOrderChanged();
			}
        }
		partial void OnRoleOrderChanging();
		partial void OnRoleOrderChanged();
		
        #endregion
    }
}
