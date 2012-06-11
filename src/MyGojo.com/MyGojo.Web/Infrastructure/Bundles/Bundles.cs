using System.Web.Optimization;
using Utility.Logging;
using MyGojo.Web.Infrastructure.Optimization;

namespace MyGojo.Web.Infrastructure.Bundles
{
    public class Bundles
    {

        public static void ConfigureAndRegister()
        {
            BundleCollection bundles = BundleTable.Bundles;

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/CSS/bootstrap.min.css",
                        "~/Content/CSS/bootstrap-responsive.min.css",
                        "~/Content/CSS/overrides.css",
                        "~/Content/CSS/jquery.jgrowl.css",
                        "~/Content/CSS/prettify.css",
                        "~/Content/CSS/font-awesome.css"));

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



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-1.7.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.8.20.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.5.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/extra").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/backbone.js",
                        "~/Scripts/sequence.jquery.js",
                        "~/Scripts/prettify.js",
                        "~/Scripts/jquery.jgrowl.min.js",
                        "~/Scripts/epiceditor.js",
                        "~/Scripts/plugins.js",
                        "~/Scripts/app.js"));
        }
    }
}