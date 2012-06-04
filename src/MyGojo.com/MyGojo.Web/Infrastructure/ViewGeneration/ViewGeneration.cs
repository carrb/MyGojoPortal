using System.Web.Mvc;

namespace MyGojo.Web.Infrastructure.ViewGeneration
{
    public class ViewGeneration
    {
        public static void ConfigureAndRegister()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}