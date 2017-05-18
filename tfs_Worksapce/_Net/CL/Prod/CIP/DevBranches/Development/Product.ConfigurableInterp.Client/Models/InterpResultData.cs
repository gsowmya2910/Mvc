//----------------------------------------------------------------
// <copyright file="InterpResultData.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//----------------------------------------------------------------

namespace Product.ConfigurableInterp.Client.Models
{
    #region references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    #endregion

    /// <summary>
    /// This class will hold Interp Result Data
    /// </summary>
    public class InterpResultData
    {
        /// <summary>
        /// Gets or sets Result Id
        /// </summary>
        public string ResultId { get; set; }

        /// <summary>
        /// Gets or sets Result Value
        /// </summary>
        public string ResultValue { get; set; }
    }
}