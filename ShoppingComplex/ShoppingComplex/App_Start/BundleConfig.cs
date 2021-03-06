﻿using System.Web;
using System.Web.Optimization;

namespace ShoppingComplex
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Content/js/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
                        "~/Scripts/modalform.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/nn-style.css",
                      "~/Content/site.css"));
            
            //Admin  ///////////////////////////////////////////////////////////////////////////////////////////////
            bundles.Add(new StyleBundle("~/AdminContent/css").Include(
                      "~/Areas/AdminTheme/Content/bootstrap.css",
                      "~/Content/css/jquery-ui.css",
                      "~/Areas/AdminTheme/Content/sb-admin.css"));

            bundles.Add(new ScriptBundle("~/AdminContent/Scripts").Include(
                     "~/Areas/AdminTheme/Scripts/bootstrap.js",
                     "~/Areas/AdminTheme/Scripts/respond.js"));
        }
    }
}
