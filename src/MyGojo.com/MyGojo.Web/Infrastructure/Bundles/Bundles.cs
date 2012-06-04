using System.Web.Optimization;
using MyGojo.Web.Infrastructure.Optimization;

namespace MyGojo.Web.Infrastructure.Bundles
{
    public class Bundles
    {
        public static void ConfigureAndRegister()
        {
            BundleCollection bundles = BundleTable.Bundles;

            //var lessBundle = new Bundle("~/Content/less").IncludeDirectory("~/Content/less", "*.less");
            //
            //lessBundle.Transforms.Add(new LessTransform());
            //lessBundle.Transforms.Add(new CssMinify());
            //bundles.Add(lessBundle);



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/CSS/bootstrap.css",
                        "~/Content/CSS/bootstrap-responsive.css",
                        "~/Content/CSS/custom.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/extra").Include(
                "~/Scripts/underscore-min.js",
                "~/Scripts/backbone-min.js",
                "~/Scripts/plugins.js"));

        }
    }
}