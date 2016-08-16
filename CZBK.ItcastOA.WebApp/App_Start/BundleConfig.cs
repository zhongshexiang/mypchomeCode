using System;
using System.Web;
using System.Web.Optimization;

namespace CZBK.ItcastOA.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ResetIgnorePatterns(bundles.IgnoreList);

            //脚本
            bundles.Add(new ScriptBundle("~/Content/js/library").Include(
                "~/Content/js/core/json2.min.js",
                "~/Content/js/core/utils.js",
                "~/Content/js/core/common.js",
                "~/Content/js/core/knockout-2.2.1.js",
                "~/Content/js/core/knockout.mapping-2.4.1.js",
                "~/Content/js/core/knockout.bindings.js",
                "~/Content/js/jquery-plugin/showloading/jquery.showLoading.min.js",
                "~/Content/js/core/jquery.easyui.fix.js"));

            bundles.Add(new ScriptBundle("~/Content/js/home").Include(
                "~/Content/js/jquery/jquery-{version}.min.js",
                "~/Content/js/core/json2.min.js",
                "~/Content/js/jquery-extend/jquery.cookie.js",
                "~/Content/js/core/utils.js",
                "~/Content/js/core/common.js",
                "~/Content/js/core/jquery.easyui.fix.js",
                "~/Content/js/jquery-plugin/jnotify/jquery.jnotify.js",
                "~/Content/js/jquery-plugin/showloading/jquery.showLoading.min.js",
                "~/Content/js/jquery-plugin/ztree/jquery.ztree.all-3.2.min.js",
                "~/Content/viewModel/homeViewModel.js"));
        }

        public static void ResetIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");
            ignoreList.Clear();
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}