using System.Collections.Generic;

namespace SiteLinks.Processors
{
    interface IAccountPermissionsProcessor
    {
        void GetSitePermissions(string url, List<string> userList);
    }
}
