using System.Web.Mvc;

namespace MyGojo.Web.Infrastructure.ViewGeneration
{
    public class ViewGenerationConfiguration
    {
        public static void Configure()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}