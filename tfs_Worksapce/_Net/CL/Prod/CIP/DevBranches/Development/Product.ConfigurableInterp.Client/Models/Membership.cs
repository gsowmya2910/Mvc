//----------------------------------------------------------------
// <copyright file="Membership.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    using System;
    using System.Configuration;
    using CoreLink.Infrastructure.Security;
    using CoreLink.Infrastructure.Security.Client;

    /// <summary>
    /// This Class represents the user membership properties
    /// </summary>
    public class Membership
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Membership" /> class.
        /// </summary>
        public Membership()
        {
            BlueBridgeUser user = BlueBridge.GetUser();

            if (user != null)
            {
                this.UserId = user.UserId;
                this.UnisysUsercode = user.MFUsercode;
                this.UserFirstName = user.FirstName;
                this.UserLastName = user.LastName;
            }
            else
            {
                Helpers.Utility.ConsoleLogger("#### Did not receive a user object back from BlueBridge, using temporary ID. ####");
                this.UserId = "id11120";
                this.UnisysUsercode = "CL111206773";
                this.UserFirstName = "Test";
                this.UserLastName = "User";
            }

            BlueBridgeRegion region = (BlueBridgeRegion)System.Web.HttpContext.Current.Session["Region"];
            if (region != null)
            {
                this.RegionCode = region.CodeLastDigit;
                this.RegionAbbrev = region.Abbreviation;
            }
            else
            {
                this.RegionCode = 1;
                this.RegionAbbrev = "Test";
            }

            this.ApplicationId = ConfigurationManager.AppSettings["ApplicationId"];
            this.ApplicationName = BlueBridge.GetBlueBridgeApplicationName();
        }

        /// <summary>
        /// Gets or sets The UserID from the BlueBridgeUser object.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets The MFUserCode from the BlueBridgeUser object.
        /// </summary>
        public string UnisysUsercode { get; set; }

        /// <summary>
        /// Gets or sets The FirstName from the BlueBridgeUser object.
        /// </summary>
        public string UserFirstName { get; set; }

        /// <summary>
        /// Gets or sets The LastName from the BlueBridgeUser object.
        /// </summary>
        public string UserLastName { get; set; }

        /// <summary>
        /// Gets or sets The RegionCode from the BlueBridge Region object.
        /// </summary>
        public int RegionCode { get; set; }

        /// <summary>
        /// Gets or sets The Abbreviation from the BlueBridge Region object.
        /// </summary>
        public string RegionAbbrev { get; set; }

        /// <summary>
        /// Gets or sets The ApplicationId from the Configuration AppSettings.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets The Application Name from BlueBridge.
        /// </summary>
        public string ApplicationName { get; set; }
    }
}