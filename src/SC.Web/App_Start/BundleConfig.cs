using System.Web.Optimization;

namespace SC.Web
{
    public static class BundleConfig
    {
        /// <summary>
        /// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/styles").Include("~/Assets/css/bootstrap.css", "~/Assets/font-awesome/css/font-awesome.css", "~/Assets/css/sb-admin.css"));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include("~/Assets/js/jquery.js", "~/Assets/js/bootstrap.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
