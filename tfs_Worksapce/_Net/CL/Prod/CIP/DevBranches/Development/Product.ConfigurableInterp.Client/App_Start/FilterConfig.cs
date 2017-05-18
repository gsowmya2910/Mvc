//----------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client
{
    #region references
    using System.Web;
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Filter Configurations
    /// </summary>
    public sealed class FilterConfig
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="FilterConfig" /> class from being created.
        /// </summary>
        private FilterConfig()
        {
        }

        /// <summary>
        /// Register Global Filters
        /// </summary>
        /// <param name="filters">Filters Collections</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
