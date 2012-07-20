using System.Collections.Generic;
using MyGojo.Data.Model;

namespace MyGojo.Web.Orchestrators
{
    public interface IHomeOrchestrator
    {
        IEnumerable<SiteInfo> GetUserSiteLinks(string userLogin);
    }
}