using System.Collections.Generic;
using MyGojo.Data.Mongo.Model;

namespace SiteLinks.Processors
{
    interface IAccountPermissionsProcessor
    {
        void GetSitePermissions(string url, List<UserInfo> userList);
    }
}
