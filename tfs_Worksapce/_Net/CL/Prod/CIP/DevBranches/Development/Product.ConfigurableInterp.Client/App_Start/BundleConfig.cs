//----------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//----------------------------------------------------------------

namespace Product.ConfigurableInterp.Client
{
    #region references

    using System.Web.Optimization;

    #endregion references

    /// <summary>
    /// Class to hold bundle configurations
    /// </summary>
    public sealed class BundleConfig
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="BundleConfig" /> class from being created.
        /// </summary>
        private BundleConfig()
        {
        }

        /// <summary>
        /// Register script bundles
        /// </summary>
        /// <param name="bundles">Bundle collection object</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery-migrate-1.4.1.min.js",
                        "~/Scripts/jquery.searchabledropdown-1.0.8.min.js",
                        "~/Scripts/jquery.maskedinput.min.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.toaster.js",
                        "~/Scripts/NewInterp.js",
                        "~/Scripts/EditInterp.js",
                        "~/Scripts/Interp.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryscripts").Include(
                         "~/Scripts/jqueryUI/jquery-ui.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.widget.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.tooltip.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.tabs.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.spinner.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.sortable.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.slider.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.selectable.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.resizable.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.progressbar.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.position.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.mouse.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.menu.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-transfer.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-slide.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-shake.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-scale.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-pulsate.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-highlight.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-fold.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-fade.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-explode.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-drop.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-clip.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-bounce.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect-blind.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.effect.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.droppable.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.draggable.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.dialog.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.datepicker.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.core.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.button.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.autocomplete.min.js",
                         "~/Scripts/jqueryUI/jquery.ui.accordion.min.js"));

            bundles.Add(new StyleBundle("~/Content/jquerycss").Include(
                      "~/Content/jqueryUI/jquery-ui.min.css",
                      "~/Content/jqueryUI/jquery.ui.accordion.min.css",
                      "~/Content/jqueryUI/jquery.ui.autocomplete.min.css",
                      "~/Content/jqueryUI/jquery.ui.button.min.css",
                      "~/Content/jqueryUI/jquery.ui.core.min.css",
                      "~/Content/jqueryUI/jquery.ui.datepicker.min.css",
                      "~/Content/jqueryUI/jquery.ui.dialog.min.css",
                      "~/Content/jqueryUI/jquery.ui.menu.min.css",
                      "~/Content/jqueryUI/jquery.ui.progressbar.min.css",
                      "~/Content/jqueryUI/jquery.ui.resizable.min.css",
                      "~/Content/jqueryUI/jquery.ui.selectable.min.css",
                      "~/Content/jqueryUI/jquery.ui.slider.min.css",
                      "~/Content/jqueryUI/jquery.ui.spinner.min.css",
                      "~/Content/jqueryUI/jquery.ui.tabs.min.css",
                      "~/Content/jqueryUI/jquery.ui.theme.min.css",
                      "~/Content/jqueryUI/jquery.ui.tooltip.min.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Interp.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}