//----------------------------------------------------------------
// <copyright file="Startup.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

#region references
using Microsoft.Owin;
using Owin;
#endregion

[assembly: OwinStartupAttribute(typeof(Product.ConfigurableInterp.Client.Startup))]

namespace Product.ConfigurableInterp.Client
{
    /// <summary>
    /// Startup class
    /// </summary>
    public partial class Startup
    {       
        /// <summary>
        /// Configuration method
        /// </summary>
        /// <param name="app">Application builder</param>
        public static void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
