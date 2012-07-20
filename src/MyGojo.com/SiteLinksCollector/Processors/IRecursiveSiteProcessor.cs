namespace SiteLinksCollector.Processors
{
    public interface IRecursiveSiteProcessor
    {
        void WalkSiteTree(string siteUrl);
    }
}