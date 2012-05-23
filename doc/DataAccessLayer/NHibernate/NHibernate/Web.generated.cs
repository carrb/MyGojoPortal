using System;
using System.Collections;
using System.Collections.Generic;

using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public partial class Web : BusinessBase<System.Guid>
    {
        #region Declarations

		private System.Guid _siteId = Guid.Empty;
		private string _fullUrl = String.Empty;
		private System.Guid? _parentWebId = null;
		private short _productVersion = default(Int16);
		private short _templateVersion = default(Int16);
		private System.Guid _firstUniqueAncestorWebId = Guid.Empty;
		private int _author = default(Int32);
		private string _title = null;
		private System.DateTime _timeCreated = new DateTime();
		private int _cachedNavDirty = default(Int32);
		private byte[] _cachedNav = null;
		private byte[] _cachedInheritedNav = null;
		private string _cachedNavScope = null;
		private int _cachedDataVersion = default(Int32);
		private string _description = null;
		private System.Guid _scopeId = Guid.Empty;
		private System.Guid? _securityProvider = null;
		private byte[] _metaInfo = null;
		private int _metaInfoVersion = default(Int32);
		private System.DateTime _lastMetadataChange = new DateTime();
		private int _navStructNextEid = default(Int32);
		private System.Guid? _navParentWebId = null;
		private int _nextWebGroupId = default(Int32);
		private string _defTheme = null;
		private string _alternateCSSUrl = null;
		private string _customizedCss = null;
		private string _customJSUrl = null;
		private string _alternateHeaderUrl = null;
		private byte[] _dailyUsageData = null;
		private int _dailyUsageDataVersion = default(Int32);
		private byte[] _monthlyUsageData = null;
		private int _monthlyUsageDataVersion = default(Int32);
		private short _dayLastAccessed = default(Int16);
		private int _webTemplate = default(Int32);
		private int _language = default(Int32);
		private int _locale = default(Int32);
		private short _timeZone = default(Int16);
		private bool? _time24 = null;
		private short? _calendarType = null;
		private short? _adjustHijriDays = null;
		private short _meetingCount = default(Int16);
		private short _provisionConfig = default(Int16);
		private int _flags = default(Int32);
		private short _collation = default(Int16);
		private string _requestAccessEmail = null;
		private string _masterUrl = null;
		private string _customMasterUrl = null;
		private string _siteLogoUrl = null;
		private string _siteLogoDescription = null;
		private int? _auditFlags = null;
		private int? _inheritAuditFlags = null;
		private byte[] _ancestry = null;
		private byte? _altCalendarType = null;
		private byte? _calendarViewOptions = null;
		private short? _workDays = null;
		private short? _workDayStartHour = null;
		private short? _workDayEndHour = null;
		private bool _emailEnabled = default(Boolean);
		
		
		
		#endregion

        #region Constructors

        public Web() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_siteId);
			sb.Append(_fullUrl);
			sb.Append(_parentWebId);
			sb.Append(_productVersion);
			sb.Append(_templateVersion);
			sb.Append(_firstUniqueAncestorWebId);
			sb.Append(_author);
			sb.Append(_title);
			sb.Append(_timeCreated);
			sb.Append(_cachedNavDirty);
			sb.Append(_cachedNav);
			sb.Append(_cachedInheritedNav);
			sb.Append(_cachedNavScope);
			sb.Append(_cachedDataVersion);
			sb.Append(_description);
			sb.Append(_scopeId);
			sb.Append(_securityProvider);
			sb.Append(_metaInfo);
			sb.Append(_metaInfoVersion);
			sb.Append(_lastMetadataChange);
			sb.Append(_navStructNextEid);
			sb.Append(_navParentWebId);
			sb.Append(_nextWebGroupId);
			sb.Append(_defTheme);
			sb.Append(_alternateCSSUrl);
			sb.Append(_customizedCss);
			sb.Append(_customJSUrl);
			sb.Append(_alternateHeaderUrl);
			sb.Append(_dailyUsageData);
			sb.Append(_dailyUsageDataVersion);
			sb.Append(_monthlyUsageData);
			sb.Append(_monthlyUsageDataVersion);
			sb.Append(_dayLastAccessed);
			sb.Append(_webTemplate);
			sb.Append(_language);
			sb.Append(_locale);
			sb.Append(_timeZone);
			sb.Append(_time24);
			sb.Append(_calendarType);
			sb.Append(_adjustHijriDays);
			sb.Append(_meetingCount);
			sb.Append(_provisionConfig);
			sb.Append(_flags);
			sb.Append(_collation);
			sb.Append(_requestAccessEmail);
			sb.Append(_masterUrl);
			sb.Append(_customMasterUrl);
			sb.Append(_siteLogoUrl);
			sb.Append(_siteLogoDescription);
			sb.Append(_auditFlags);
			sb.Append(_inheritAuditFlags);
			sb.Append(_ancestry);
			sb.Append(_altCalendarType);
			sb.Append(_calendarViewOptions);
			sb.Append(_workDays);
			sb.Append(_workDayStartHour);
			sb.Append(_workDayEndHour);
			sb.Append(_emailEnabled);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

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
		
		public virtual string FullUrl
        {
            get { return _fullUrl; }
			set
			{
				OnFullUrlChanging();
				_fullUrl = value;
				OnFullUrlChanged();
			}
        }
		partial void OnFullUrlChanging();
		partial void OnFullUrlChanged();
		
		public virtual System.Guid? ParentWebId
        {
            get { return _parentWebId; }
			set
			{
				OnParentWebIdChanging();
				_parentWebId = value;
				OnParentWebIdChanged();
			}
        }
		partial void OnParentWebIdChanging();
		partial void OnParentWebIdChanged();
		
		public virtual short ProductVersion
        {
            get { return _productVersion; }
			set
			{
				OnProductVersionChanging();
				_productVersion = value;
				OnProductVersionChanged();
			}
        }
		partial void OnProductVersionChanging();
		partial void OnProductVersionChanged();
		
		public virtual short TemplateVersion
        {
            get { return _templateVersion; }
			set
			{
				OnTemplateVersionChanging();
				_templateVersion = value;
				OnTemplateVersionChanged();
			}
        }
		partial void OnTemplateVersionChanging();
		partial void OnTemplateVersionChanged();
		
		public virtual System.Guid FirstUniqueAncestorWebId
        {
            get { return _firstUniqueAncestorWebId; }
			set
			{
				OnFirstUniqueAncestorWebIdChanging();
				_firstUniqueAncestorWebId = value;
				OnFirstUniqueAncestorWebIdChanged();
			}
        }
		partial void OnFirstUniqueAncestorWebIdChanging();
		partial void OnFirstUniqueAncestorWebIdChanged();
		
		public virtual int Author
        {
            get { return _author; }
			set
			{
				OnAuthorChanging();
				_author = value;
				OnAuthorChanged();
			}
        }
		partial void OnAuthorChanging();
		partial void OnAuthorChanged();
		
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
		
		public virtual System.DateTime TimeCreated
        {
            get { return _timeCreated; }
			set
			{
				OnTimeCreatedChanging();
				_timeCreated = value;
				OnTimeCreatedChanged();
			}
        }
		partial void OnTimeCreatedChanging();
		partial void OnTimeCreatedChanged();
		
		public virtual int CachedNavDirty
        {
            get { return _cachedNavDirty; }
			set
			{
				OnCachedNavDirtyChanging();
				_cachedNavDirty = value;
				OnCachedNavDirtyChanged();
			}
        }
		partial void OnCachedNavDirtyChanging();
		partial void OnCachedNavDirtyChanged();
		
		public virtual byte[] CachedNav
        {
            get { return _cachedNav; }
			set
			{
				OnCachedNavChanging();
				_cachedNav = value;
				OnCachedNavChanged();
			}
        }
		partial void OnCachedNavChanging();
		partial void OnCachedNavChanged();
		
		public virtual byte[] CachedInheritedNav
        {
            get { return _cachedInheritedNav; }
			set
			{
				OnCachedInheritedNavChanging();
				_cachedInheritedNav = value;
				OnCachedInheritedNavChanged();
			}
        }
		partial void OnCachedInheritedNavChanging();
		partial void OnCachedInheritedNavChanged();
		
		public virtual string CachedNavScope
        {
            get { return _cachedNavScope; }
			set
			{
				OnCachedNavScopeChanging();
				_cachedNavScope = value;
				OnCachedNavScopeChanged();
			}
        }
		partial void OnCachedNavScopeChanging();
		partial void OnCachedNavScopeChanged();
		
		public virtual int CachedDataVersion
        {
            get { return _cachedDataVersion; }
			set
			{
				OnCachedDataVersionChanging();
				_cachedDataVersion = value;
				OnCachedDataVersionChanged();
			}
        }
		partial void OnCachedDataVersionChanging();
		partial void OnCachedDataVersionChanged();
		
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
		
		public virtual System.Guid? SecurityProvider
        {
            get { return _securityProvider; }
			set
			{
				OnSecurityProviderChanging();
				_securityProvider = value;
				OnSecurityProviderChanged();
			}
        }
		partial void OnSecurityProviderChanging();
		partial void OnSecurityProviderChanged();
		
		public virtual byte[] MetaInfo
        {
            get { return _metaInfo; }
			set
			{
				OnMetaInfoChanging();
				_metaInfo = value;
				OnMetaInfoChanged();
			}
        }
		partial void OnMetaInfoChanging();
		partial void OnMetaInfoChanged();
		
		public virtual int MetaInfoVersion
        {
            get { return _metaInfoVersion; }
			set
			{
				OnMetaInfoVersionChanging();
				_metaInfoVersion = value;
				OnMetaInfoVersionChanged();
			}
        }
		partial void OnMetaInfoVersionChanging();
		partial void OnMetaInfoVersionChanged();
		
		public virtual System.DateTime LastMetadataChange
        {
            get { return _lastMetadataChange; }
			set
			{
				OnLastMetadataChangeChanging();
				_lastMetadataChange = value;
				OnLastMetadataChangeChanged();
			}
        }
		partial void OnLastMetadataChangeChanging();
		partial void OnLastMetadataChangeChanged();
		
		public virtual int NavStructNextEid
        {
            get { return _navStructNextEid; }
			set
			{
				OnNavStructNextEidChanging();
				_navStructNextEid = value;
				OnNavStructNextEidChanged();
			}
        }
		partial void OnNavStructNextEidChanging();
		partial void OnNavStructNextEidChanged();
		
		public virtual System.Guid? NavParentWebId
        {
            get { return _navParentWebId; }
			set
			{
				OnNavParentWebIdChanging();
				_navParentWebId = value;
				OnNavParentWebIdChanged();
			}
        }
		partial void OnNavParentWebIdChanging();
		partial void OnNavParentWebIdChanged();
		
		public virtual int NextWebGroupId
        {
            get { return _nextWebGroupId; }
			set
			{
				OnNextWebGroupIdChanging();
				_nextWebGroupId = value;
				OnNextWebGroupIdChanged();
			}
        }
		partial void OnNextWebGroupIdChanging();
		partial void OnNextWebGroupIdChanged();
		
		public virtual string DefTheme
        {
            get { return _defTheme; }
			set
			{
				OnDefThemeChanging();
				_defTheme = value;
				OnDefThemeChanged();
			}
        }
		partial void OnDefThemeChanging();
		partial void OnDefThemeChanged();
		
		public virtual string AlternateCSSUrl
        {
            get { return _alternateCSSUrl; }
			set
			{
				OnAlternateCSSUrlChanging();
				_alternateCSSUrl = value;
				OnAlternateCSSUrlChanged();
			}
        }
		partial void OnAlternateCSSUrlChanging();
		partial void OnAlternateCSSUrlChanged();
		
		public virtual string CustomizedCss
        {
            get { return _customizedCss; }
			set
			{
				OnCustomizedCssChanging();
				_customizedCss = value;
				OnCustomizedCssChanged();
			}
        }
		partial void OnCustomizedCssChanging();
		partial void OnCustomizedCssChanged();
		
		public virtual string CustomJSUrl
        {
            get { return _customJSUrl; }
			set
			{
				OnCustomJSUrlChanging();
				_customJSUrl = value;
				OnCustomJSUrlChanged();
			}
        }
		partial void OnCustomJSUrlChanging();
		partial void OnCustomJSUrlChanged();
		
		public virtual string AlternateHeaderUrl
        {
            get { return _alternateHeaderUrl; }
			set
			{
				OnAlternateHeaderUrlChanging();
				_alternateHeaderUrl = value;
				OnAlternateHeaderUrlChanged();
			}
        }
		partial void OnAlternateHeaderUrlChanging();
		partial void OnAlternateHeaderUrlChanged();
		
		public virtual byte[] DailyUsageData
        {
            get { return _dailyUsageData; }
			set
			{
				OnDailyUsageDataChanging();
				_dailyUsageData = value;
				OnDailyUsageDataChanged();
			}
        }
		partial void OnDailyUsageDataChanging();
		partial void OnDailyUsageDataChanged();
		
		public virtual int DailyUsageDataVersion
        {
            get { return _dailyUsageDataVersion; }
			set
			{
				OnDailyUsageDataVersionChanging();
				_dailyUsageDataVersion = value;
				OnDailyUsageDataVersionChanged();
			}
        }
		partial void OnDailyUsageDataVersionChanging();
		partial void OnDailyUsageDataVersionChanged();
		
		public virtual byte[] MonthlyUsageData
        {
            get { return _monthlyUsageData; }
			set
			{
				OnMonthlyUsageDataChanging();
				_monthlyUsageData = value;
				OnMonthlyUsageDataChanged();
			}
        }
		partial void OnMonthlyUsageDataChanging();
		partial void OnMonthlyUsageDataChanged();
		
		public virtual int MonthlyUsageDataVersion
        {
            get { return _monthlyUsageDataVersion; }
			set
			{
				OnMonthlyUsageDataVersionChanging();
				_monthlyUsageDataVersion = value;
				OnMonthlyUsageDataVersionChanged();
			}
        }
		partial void OnMonthlyUsageDataVersionChanging();
		partial void OnMonthlyUsageDataVersionChanged();
		
		public virtual short DayLastAccessed
        {
            get { return _dayLastAccessed; }
			set
			{
				OnDayLastAccessedChanging();
				_dayLastAccessed = value;
				OnDayLastAccessedChanged();
			}
        }
		partial void OnDayLastAccessedChanging();
		partial void OnDayLastAccessedChanged();
		
		public virtual int WebTemplate
        {
            get { return _webTemplate; }
			set
			{
				OnWebTemplateChanging();
				_webTemplate = value;
				OnWebTemplateChanged();
			}
        }
		partial void OnWebTemplateChanging();
		partial void OnWebTemplateChanged();
		
		public virtual int Language
        {
            get { return _language; }
			set
			{
				OnLanguageChanging();
				_language = value;
				OnLanguageChanged();
			}
        }
		partial void OnLanguageChanging();
		partial void OnLanguageChanged();
		
		public virtual int Locale
        {
            get { return _locale; }
			set
			{
				OnLocaleChanging();
				_locale = value;
				OnLocaleChanged();
			}
        }
		partial void OnLocaleChanging();
		partial void OnLocaleChanged();
		
		public virtual short TimeZone
        {
            get { return _timeZone; }
			set
			{
				OnTimeZoneChanging();
				_timeZone = value;
				OnTimeZoneChanged();
			}
        }
		partial void OnTimeZoneChanging();
		partial void OnTimeZoneChanged();
		
		public virtual bool? Time24
        {
            get { return _time24; }
			set
			{
				OnTime24Changing();
				_time24 = value;
				OnTime24Changed();
			}
        }
		partial void OnTime24Changing();
		partial void OnTime24Changed();
		
		public virtual short? CalendarType
        {
            get { return _calendarType; }
			set
			{
				OnCalendarTypeChanging();
				_calendarType = value;
				OnCalendarTypeChanged();
			}
        }
		partial void OnCalendarTypeChanging();
		partial void OnCalendarTypeChanged();
		
		public virtual short? AdjustHijriDays
        {
            get { return _adjustHijriDays; }
			set
			{
				OnAdjustHijriDaysChanging();
				_adjustHijriDays = value;
				OnAdjustHijriDaysChanged();
			}
        }
		partial void OnAdjustHijriDaysChanging();
		partial void OnAdjustHijriDaysChanged();
		
		public virtual short MeetingCount
        {
            get { return _meetingCount; }
			set
			{
				OnMeetingCountChanging();
				_meetingCount = value;
				OnMeetingCountChanged();
			}
        }
		partial void OnMeetingCountChanging();
		partial void OnMeetingCountChanged();
		
		public virtual short ProvisionConfig
        {
            get { return _provisionConfig; }
			set
			{
				OnProvisionConfigChanging();
				_provisionConfig = value;
				OnProvisionConfigChanged();
			}
        }
		partial void OnProvisionConfigChanging();
		partial void OnProvisionConfigChanged();
		
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
		
		public virtual short Collation
        {
            get { return _collation; }
			set
			{
				OnCollationChanging();
				_collation = value;
				OnCollationChanged();
			}
        }
		partial void OnCollationChanging();
		partial void OnCollationChanged();
		
		public virtual string RequestAccessEmail
        {
            get { return _requestAccessEmail; }
			set
			{
				OnRequestAccessEmailChanging();
				_requestAccessEmail = value;
				OnRequestAccessEmailChanged();
			}
        }
		partial void OnRequestAccessEmailChanging();
		partial void OnRequestAccessEmailChanged();
		
		public virtual string MasterUrl
        {
            get { return _masterUrl; }
			set
			{
				OnMasterUrlChanging();
				_masterUrl = value;
				OnMasterUrlChanged();
			}
        }
		partial void OnMasterUrlChanging();
		partial void OnMasterUrlChanged();
		
		public virtual string CustomMasterUrl
        {
            get { return _customMasterUrl; }
			set
			{
				OnCustomMasterUrlChanging();
				_customMasterUrl = value;
				OnCustomMasterUrlChanged();
			}
        }
		partial void OnCustomMasterUrlChanging();
		partial void OnCustomMasterUrlChanged();
		
		public virtual string SiteLogoUrl
        {
            get { return _siteLogoUrl; }
			set
			{
				OnSiteLogoUrlChanging();
				_siteLogoUrl = value;
				OnSiteLogoUrlChanged();
			}
        }
		partial void OnSiteLogoUrlChanging();
		partial void OnSiteLogoUrlChanged();
		
		public virtual string SiteLogoDescription
        {
            get { return _siteLogoDescription; }
			set
			{
				OnSiteLogoDescriptionChanging();
				_siteLogoDescription = value;
				OnSiteLogoDescriptionChanged();
			}
        }
		partial void OnSiteLogoDescriptionChanging();
		partial void OnSiteLogoDescriptionChanged();
		
		public virtual int? AuditFlags
        {
            get { return _auditFlags; }
			set
			{
				OnAuditFlagsChanging();
				_auditFlags = value;
				OnAuditFlagsChanged();
			}
        }
		partial void OnAuditFlagsChanging();
		partial void OnAuditFlagsChanged();
		
		public virtual int? InheritAuditFlags
        {
            get { return _inheritAuditFlags; }
			set
			{
				OnInheritAuditFlagsChanging();
				_inheritAuditFlags = value;
				OnInheritAuditFlagsChanged();
			}
        }
		partial void OnInheritAuditFlagsChanging();
		partial void OnInheritAuditFlagsChanged();
		
		public virtual byte[] Ancestry
        {
            get { return _ancestry; }
			set
			{
				OnAncestryChanging();
				_ancestry = value;
				OnAncestryChanged();
			}
        }
		partial void OnAncestryChanging();
		partial void OnAncestryChanged();
		
		public virtual byte? AltCalendarType
        {
            get { return _altCalendarType; }
			set
			{
				OnAltCalendarTypeChanging();
				_altCalendarType = value;
				OnAltCalendarTypeChanged();
			}
        }
		partial void OnAltCalendarTypeChanging();
		partial void OnAltCalendarTypeChanged();
		
		public virtual byte? CalendarViewOptions
        {
            get { return _calendarViewOptions; }
			set
			{
				OnCalendarViewOptionsChanging();
				_calendarViewOptions = value;
				OnCalendarViewOptionsChanged();
			}
        }
		partial void OnCalendarViewOptionsChanging();
		partial void OnCalendarViewOptionsChanged();
		
		public virtual short? WorkDays
        {
            get { return _workDays; }
			set
			{
				OnWorkDaysChanging();
				_workDays = value;
				OnWorkDaysChanged();
			}
        }
		partial void OnWorkDaysChanging();
		partial void OnWorkDaysChanged();
		
		public virtual short? WorkDayStartHour
        {
            get { return _workDayStartHour; }
			set
			{
				OnWorkDayStartHourChanging();
				_workDayStartHour = value;
				OnWorkDayStartHourChanged();
			}
        }
		partial void OnWorkDayStartHourChanging();
		partial void OnWorkDayStartHourChanged();
		
		public virtual short? WorkDayEndHour
        {
            get { return _workDayEndHour; }
			set
			{
				OnWorkDayEndHourChanging();
				_workDayEndHour = value;
				OnWorkDayEndHourChanged();
			}
        }
		partial void OnWorkDayEndHourChanging();
		partial void OnWorkDayEndHourChanged();
		
		public virtual bool EmailEnabled
        {
            get { return _emailEnabled; }
			set
			{
				OnEmailEnabledChanging();
				_emailEnabled = value;
				OnEmailEnabledChanged();
			}
        }
		partial void OnEmailEnabledChanging();
		partial void OnEmailEnabledChanged();
		
        #endregion
    }
}
