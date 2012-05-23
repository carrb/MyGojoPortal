using System.Collections.Generic;

namespace SiteLinks.Processors
{
    public interface IRecursiveSiteProcessor
    {
        void WalkSiteTree(string siteUrl);
    }
}