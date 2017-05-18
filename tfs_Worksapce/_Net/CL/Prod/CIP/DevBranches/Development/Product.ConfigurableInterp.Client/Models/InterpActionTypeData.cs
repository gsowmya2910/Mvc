//----------------------------------------------------------------
// <copyright file="InterpActionTypeData.cs" company="CoreLink">
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
    /// This class will hold Interp Action Type Data
    /// </summary>
    public class InterpActionTypeData
    {
        /// <summary>
        /// Gets or sets Action Type Id
        /// </summary>
        public string ActionTypeId { get; set; }

        /// <summary>
        /// Gets or sets Action Type Value
        /// </summary>
        public string ActionTypeValue { get; set; }
    }
}