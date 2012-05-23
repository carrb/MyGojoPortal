using System.Web.Optimization;

namespace MyGojo.Web.Infrastructure.Bundles
{
    public class BundlesConfiguration
    {
        public static void Configure()
        {
            // Can Create Custom:  http://codebetter.com/johnpetersen/2012/03/06/asp-net-mvc-4-beta-bundling-and-minification-dymystified/
            BundleTable.Bundles.RegisterTemplateBundles();
        }
    }
}