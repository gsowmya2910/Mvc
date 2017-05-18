//----------------------------------------------------------------
// <copyright file="InterpFieldTypeData.cs" company="CoreLink">
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
    /// This class will hold Interp Field Type Data
    /// </summary>
    public class InterpFieldTypeData
    {
        /// <summary>
        /// Gets or sets Field Type Id
        /// </summary>
        public string FieldTypeId { get; set; }

        /// <summary>
        /// Gets or sets Field Type Value
        /// </summary>
        public string FieldTypeValue { get; set; }
    }
}