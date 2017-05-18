//----------------------------------------------------------------
// <copyright file="Global.asax.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//----------------------------------------------------------------

namespace Product.ConfigurableInterp.Client
{
    using System;
    using System.Configuration;
    using System.Data.OleDb;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using CoreLink.Core.BusinessEntities;
    using CoreLink.Core.DataAccess;
    using CoreLink.Infrastructure.Security;
    using CoreLink.Infrastructure.Security.Client;
 
    /// <summary>
    /// MVC Application class
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Application error handling
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">Event arguments</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            LogRecord log = new LogRecord(
                     HttpContext.Current.User.Identity.Name,
                     Session["RegionCode"].ToInt32(),
                     ConfigurationManager.AppSettings["ApplicationId"],
                     "Global",
                     "UnhandledException",
                     "UI",
                     "Application_Error");

            log.ErrorData = exc.ToString().SerializeAscii();
            log.LogType = "Error";
            TransLogger.CreateLog(log);
            Server.ClearError();
            Response.Redirect("~/Interp/Error");
        }

        /// <summary>
        /// Application start
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "ASP.Net Framework Method")]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Session startup
        /// </summary>
        protected void Session_Start()
        {
            int regionValue;
            if (this.Request["Region"] != null)
            {
                regionValue = int.Parse(this.Request["Region"], CultureInfo.CurrentCulture);
                if (regionValue.Equals(0))
                {
                    regionValue = GetRegionValue();
                }
            }
            else
            {
                regionValue = GetRegionValue();
            }

            try
            {
                BlueBridgeRegion region = BlueBridge.GetRegion(regionValue);
                this.Session["Region"] = region;
                this.Session["RegionCode"] = region.Code;
            }
            catch (OleDbException)
            {
                // default not set
                this.Session["Region"] = -1;
                this.Session["RegionCode"] = -1;
            }

            this.Session["Color"] = "jquery-ui-1.8.11.blue.css";
            this.Session["ieCache"] = new Random().Next(0, 99999);
        }

        /// <summary>
        /// Get region Value
        /// </summary>
        /// <returns> return the region value </returns>
        private static int GetRegionValue()
        {
            // TO Do Change this whatever correct default is
            int defaultReturnRegionValue = -1;
            try
            {
                if (BlueBridge.GetUsersHomeRegion() != null)
                {
                    return BlueBridge.GetUsersHomeRegion().CodeLastDigit;
                }
                else
                {
                    // TO DO  what should be returned if HomeRegion is NULL?
                    return defaultReturnRegionValue;
                }
            }
            catch (OleDbException)
            {
                return defaultReturnRegionValue;
            }
        }
    }
}