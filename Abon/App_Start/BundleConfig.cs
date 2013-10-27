using System.Web;
using System.Web.Optimization;

namespace Abon
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/common").Include(
            //            "~/Scripts/underscore.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                "~/Scripts/jquery-1.8.2.js",
                "~/Scripts/spin.js",
                "~/Scripts/jquery.menu-aim.js",
                "~/Scripts/bootstrap.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angularjs/angular.js",
                "~/Scripts/angularjs/angular-cache-0.9.1.js",
                "~/Scripts/angularjs/ui-bootstrap-tpls-0.6.0.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/portalApp").Include(
                "~/Scripts/app/helpers/scopeHelper.js",
                "~/Scripts/app/common/commonModule.js",
                "~/Scripts/app/common/spinner.js",
                "~/Scripts/app/validators/validatorModule.js",
                "~/Scripts/app/validators/numberValidator.js",
                "~/Scripts/app/validators/emailValidator.js",
                "~/Scripts/app/Portal/services/serviceModule.js",
                "~/Scripts/app/Portal/services/offersService.js",
                "~/Scripts/app/Portal/controllers/controllerModule.js",
                "~/Scripts/app/Portal/controllers/menuController.js",
                "~/Scripts/app/Portal/controllers/categoryController.js",
                "~/Scripts/app/Portal/controllers/filterController.js",
                "~/Scripts/app/Portal/controllers/offersController.js",
                "~/Scripts/app/Portal/controllers/pagerController.js",
                "~/Scripts/app/Portal/main.js"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-responsive.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
