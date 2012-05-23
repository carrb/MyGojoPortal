using System;
using System.Collections;
using System.Collections.Generic;

using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial class UserInfo : BusinessBase<string>
    {
        #region Declarations

		private System.Guid _tpSiteID = Guid.Empty;
		private int _tpID = default(Int32);
		private bool _tpDomainGroup = default(Boolean);
		private System.Guid _tpGUID = Guid.Empty;
		private byte[] _tpSystemID = null;
		private int _tpDeleted = default(Int32);
		private bool _tpSiteAdmin = default(Boolean);
		private bool _tpIsActive = default(Boolean);
		private string _tpLogin = String.Empty;
		private string _tpTitle = String.Empty;
		private string _tpEmail = String.Empty;
		private string _tpNotes = String.Empty;
		private byte[] _tpToken = null;
		private byte[] _tpExternalToken = null;
		private System.DateTime? _tpExternalTokenLastUpdated = null;
		private int? _tpLocale = null;
		private short? _tpCalendarType = null;
		private short? _tpAdjustHijriDays = null;
		private short? _tpTimeZone = null;
		private bool? _tpTime24 = null;
		private byte? _tpAltCalendarType = null;
		private byte? _tpCalendarViewOptions = null;
		private short? _tpWorkDays = null;
		private short? _tpWorkDayStartHour = null;
		private short? _tpWorkDayEndHour = null;
		
		
		
		#endregion

        #region Constructors

        public UserInfo() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_tpSiteID);
			sb.Append(_tpID);
			sb.Append(_tpDomainGroup);
			sb.Append(_tpGUID);
			sb.Append(_tpSystemID);
			sb.Append(_tpDeleted);
			sb.Append(_tpSiteAdmin);
			sb.Append(_tpIsActive);
			sb.Append(_tpLogin);
			sb.Append(_tpTitle);
			sb.Append(_tpEmail);
			sb.Append(_tpNotes);
			sb.Append(_tpToken);
			sb.Append(_tpExternalToken);
			sb.Append(_tpExternalTokenLastUpdated);
			sb.Append(_tpLocale);
			sb.Append(_tpCalendarType);
			sb.Append(_tpAdjustHijriDays);
			sb.Append(_tpTimeZone);
			sb.Append(_tpTime24);
			sb.Append(_tpAltCalendarType);
			sb.Append(_tpCalendarViewOptions);
			sb.Append(_tpWorkDays);
			sb.Append(_tpWorkDayStartHour);
			sb.Append(_tpWorkDayEndHour);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public override string Id
		{
			get
			{
				System.Text.StringBuilder uniqueId = new System.Text.StringBuilder();
				uniqueId.Append(_tpSiteID.ToString());
				uniqueId.Append("^");
				uniqueId.Append(_tpID.ToString());
				return uniqueId.ToString();
			}
		}
		
		public virtual System.Guid TpSiteID
        {
            get { return _tpSiteID; }
			set
			{
				OnTpSiteIDChanging();
				_tpSiteID = value;
				OnTpSiteIDChanged();
			}
        }
		partial void OnTpSiteIDChanging();
		partial void OnTpSiteIDChanged();
		
		public virtual int TpID
        {
            get { return _tpID; }
			set
			{
				OnTpIDChanging();
				_tpID = value;
				OnTpIDChanged();
			}
        }
		partial void OnTpIDChanging();
		partial void OnTpIDChanged();
		
		public virtual bool TpDomainGroup
        {
            get { return _tpDomainGroup; }
			set
			{
				OnTpDomainGroupChanging();
				_tpDomainGroup = value;
				OnTpDomainGroupChanged();
			}
        }
		partial void OnTpDomainGroupChanging();
		partial void OnTpDomainGroupChanged();
		
		public virtual System.Guid TpGUID
        {
            get { return _tpGUID; }
			set
			{
				OnTpGUIDChanging();
				_tpGUID = value;
				OnTpGUIDChanged();
			}
        }
		partial void OnTpGUIDChanging();
		partial void OnTpGUIDChanged();
		
		public virtual byte[] TpSystemID
        {
            get { return _tpSystemID; }
			set
			{
				OnTpSystemIDChanging();
				_tpSystemID = value;
				OnTpSystemIDChanged();
			}
        }
		partial void OnTpSystemIDChanging();
		partial void OnTpSystemIDChanged();
		
		public virtual int TpDeleted
        {
            get { return _tpDeleted; }
			set
			{
				OnTpDeletedChanging();
				_tpDeleted = value;
				OnTpDeletedChanged();
			}
        }
		partial void OnTpDeletedChanging();
		partial void OnTpDeletedChanged();
		
		public virtual bool TpSiteAdmin
        {
            get { return _tpSiteAdmin; }
			set
			{
				OnTpSiteAdminChanging();
				_tpSiteAdmin = value;
				OnTpSiteAdminChanged();
			}
        }
		partial void OnTpSiteAdminChanging();
		partial void OnTpSiteAdminChanged();
		
		public virtual bool TpIsActive
        {
            get { return _tpIsActive; }
			set
			{
				OnTpIsActiveChanging();
				_tpIsActive = value;
				OnTpIsActiveChanged();
			}
        }
		partial void OnTpIsActiveChanging();
		partial void OnTpIsActiveChanged();
		
		public virtual string TpLogin
        {
            get { return _tpLogin; }
			set
			{
				OnTpLoginChanging();
				_tpLogin = value;
				OnTpLoginChanged();
			}
        }
		partial void OnTpLoginChanging();
		partial void OnTpLoginChanged();
		
		public virtual string TpTitle
        {
            get { return _tpTitle; }
			set
			{
				OnTpTitleChanging();
				_tpTitle = value;
				OnTpTitleChanged();
			}
        }
		partial void OnTpTitleChanging();
		partial void OnTpTitleChanged();
		
		public virtual string TpEmail
        {
            get { return _tpEmail; }
			set
			{
				OnTpEmailChanging();
				_tpEmail = value;
				OnTpEmailChanged();
			}
        }
		partial void OnTpEmailChanging();
		partial void OnTpEmailChanged();
		
		public virtual string TpNotes
        {
            get { return _tpNotes; }
			set
			{
				OnTpNotesChanging();
				_tpNotes = value;
				OnTpNotesChanged();
			}
        }
		partial void OnTpNotesChanging();
		partial void OnTpNotesChanged();
		
		public virtual byte[] TpToken
        {
            get { return _tpToken; }
			set
			{
				OnTpTokenChanging();
				_tpToken = value;
				OnTpTokenChanged();
			}
        }
		partial void OnTpTokenChanging();
		partial void OnTpTokenChanged();
		
		public virtual byte[] TpExternalToken
        {
            get { return _tpExternalToken; }
			set
			{
				OnTpExternalTokenChanging();
				_tpExternalToken = value;
				OnTpExternalTokenChanged();
			}
        }
		partial void OnTpExternalTokenChanging();
		partial void OnTpExternalTokenChanged();
		
		public virtual System.DateTime? TpExternalTokenLastUpdated
        {
            get { return _tpExternalTokenLastUpdated; }
			set
			{
				OnTpExternalTokenLastUpdatedChanging();
				_tpExternalTokenLastUpdated = value;
				OnTpExternalTokenLastUpdatedChanged();
			}
        }
		partial void OnTpExternalTokenLastUpdatedChanging();
		partial void OnTpExternalTokenLastUpdatedChanged();
		
		public virtual int? TpLocale
        {
            get { return _tpLocale; }
			set
			{
				OnTpLocaleChanging();
				_tpLocale = value;
				OnTpLocaleChanged();
			}
        }
		partial void OnTpLocaleChanging();
		partial void OnTpLocaleChanged();
		
		public virtual short? TpCalendarType
        {
            get { return _tpCalendarType; }
			set
			{
				OnTpCalendarTypeChanging();
				_tpCalendarType = value;
				OnTpCalendarTypeChanged();
			}
        }
		partial void OnTpCalendarTypeChanging();
		partial void OnTpCalendarTypeChanged();
		
		public virtual short? TpAdjustHijriDays
        {
            get { return _tpAdjustHijriDays; }
			set
			{
				OnTpAdjustHijriDaysChanging();
				_tpAdjustHijriDays = value;
				OnTpAdjustHijriDaysChanged();
			}
        }
		partial void OnTpAdjustHijriDaysChanging();
		partial void OnTpAdjustHijriDaysChanged();
		
		public virtual short? TpTimeZone
        {
            get { return _tpTimeZone; }
			set
			{
				OnTpTimeZoneChanging();
				_tpTimeZone = value;
				OnTpTimeZoneChanged();
			}
        }
		partial void OnTpTimeZoneChanging();
		partial void OnTpTimeZoneChanged();
		
		public virtual bool? TpTime24
        {
            get { return _tpTime24; }
			set
			{
				OnTpTime24Changing();
				_tpTime24 = value;
				OnTpTime24Changed();
			}
        }
		partial void OnTpTime24Changing();
		partial void OnTpTime24Changed();
		
		public virtual byte? TpAltCalendarType
        {
            get { return _tpAltCalendarType; }
			set
			{
				OnTpAltCalendarTypeChanging();
				_tpAltCalendarType = value;
				OnTpAltCalendarTypeChanged();
			}
        }
		partial void OnTpAltCalendarTypeChanging();
		partial void OnTpAltCalendarTypeChanged();
		
		public virtual byte? TpCalendarViewOptions
        {
            get { return _tpCalendarViewOptions; }
			set
			{
				OnTpCalendarViewOptionsChanging();
				_tpCalendarViewOptions = value;
				OnTpCalendarViewOptionsChanged();
			}
        }
		partial void OnTpCalendarViewOptionsChanging();
		partial void OnTpCalendarViewOptionsChanged();
		
		public virtual short? TpWorkDays
        {
            get { return _tpWorkDays; }
			set
			{
				OnTpWorkDaysChanging();
				_tpWorkDays = value;
				OnTpWorkDaysChanged();
			}
        }
		partial void OnTpWorkDaysChanging();
		partial void OnTpWorkDaysChanged();
		
		public virtual short? TpWorkDayStartHour
        {
            get { return _tpWorkDayStartHour; }
			set
			{
				OnTpWorkDayStartHourChanging();
				_tpWorkDayStartHour = value;
				OnTpWorkDayStartHourChanged();
			}
        }
		partial void OnTpWorkDayStartHourChanging();
		partial void OnTpWorkDayStartHourChanged();
		
		public virtual short? TpWorkDayEndHour
        {
            get { return _tpWorkDayEndHour; }
			set
			{
				OnTpWorkDayEndHourChanging();
				_tpWorkDayEndHour = value;
				OnTpWorkDayEndHourChanged();
			}
        }
		partial void OnTpWorkDayEndHourChanging();
		partial void OnTpWorkDayEndHourChanged();
		
        #endregion
    }
}
