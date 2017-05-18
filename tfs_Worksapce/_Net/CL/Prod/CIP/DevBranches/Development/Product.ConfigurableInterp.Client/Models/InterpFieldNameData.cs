//----------------------------------------------------------------
// <copyright file="InterpFieldnameData.cs" company="CoreLink">
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
    /// This class will hold Interp Field Name Data
    /// </summary>
    public class InterpFieldnameData
    {
        /// <summary>
        /// Gets or sets Field Name Id
        /// </summary>
        public string FieldnameId { get; set; }

        /// <summary>
        /// Gets or sets Field Name Value
        /// </summary>
        public string FieldnameValue { get; set; }
    }
}