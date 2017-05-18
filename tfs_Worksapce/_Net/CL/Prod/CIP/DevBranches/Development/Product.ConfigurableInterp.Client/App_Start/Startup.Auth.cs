//----------------------------------------------------------------
// <copyright file="Startup.Auth.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//----------------------------------------------------------------

namespace Product.ConfigurableInterp.Client
{
    #region references
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.DataProtection;
    using Microsoft.Owin.Security.Google;
    using Owin;    
    using Product.ConfigurableInterp.Client.Models;
    #endregion

    /// <summary>
    /// Startup class
    /// </summary>
    public static partial class Startup
    {
       /// <summary>
       /// Configure Authentications
       /// </summary>
       /// <param name="app">Application builder</param>
        public static void ConfigureAuth(IAppBuilder app)
        {            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}