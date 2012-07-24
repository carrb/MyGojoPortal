namespace SiteLinksCollector.Processors
{
    public interface IRecursiveSiteProcessor
    {
        bool WalkSiteTree(string siteUrl);
    }
}