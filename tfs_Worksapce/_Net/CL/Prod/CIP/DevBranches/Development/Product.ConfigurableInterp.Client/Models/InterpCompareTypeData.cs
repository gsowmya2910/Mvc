//----------------------------------------------------------------
// <copyright file="InterpCompareTypeData.cs" company="CoreLink">
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
    /// This class will hold Interp Compare Type Data
    /// </summary>
    public class InterpCompareTypeData
    {
        /// <summary>
        /// Gets or sets Compare Type Id
        /// </summary>
        public string CompareTypeId { get; set; }

        /// <summary>
        /// Gets or sets Compare Type Value
        /// </summary>
        public string CompareTypeValue { get; set; }
    }
}