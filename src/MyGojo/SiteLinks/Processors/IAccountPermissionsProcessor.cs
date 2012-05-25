using System.Collections.Generic;
using MyGojo.Data.Model;

namespace SiteLinks.Processors
{
    interface IAccountPermissionsProcessor
    {
        void GetSitePermissions(string url, List<UserInfo> userList);
    }
}
