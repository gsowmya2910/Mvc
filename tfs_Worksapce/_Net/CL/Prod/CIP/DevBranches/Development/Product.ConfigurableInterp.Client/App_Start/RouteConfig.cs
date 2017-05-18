//----------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client
{
    #region references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    #endregion

    /// <summary>
    /// Route Configurations
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Register Routes
        /// </summary>
        /// <param name="routes">Routes collections</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{InterpQueryId}",
                defaults: new { controller = "Interp", action = "Index", InterpQueryId = UrlParameter.Optional });

            routes.MapRoute(
                "Error", //// Route name
                "{controller}/{action}/{id}", //// URL with parameters
                new { controller = "Interp", action = "Error", id = UrlParameter.Optional }); ////Default Parameters
        }
    }
}
