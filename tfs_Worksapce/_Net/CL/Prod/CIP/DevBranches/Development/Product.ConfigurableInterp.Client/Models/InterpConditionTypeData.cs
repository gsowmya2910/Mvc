//----------------------------------------------------------------
// <copyright file="InterpConditionTypeData.cs" company="CoreLink">
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
    /// This class will hold Interp Condition Type Data
    /// </summary>
    public class InterpConditionTypeData
    {
        /// <summary>
        /// Gets or sets Condition Type Id
        /// </summary>
        public string ConditionTypeId { get; set; }

        /// <summary>
        /// Gets or sets Condition Type Value
        /// </summary>
        public string ConditionTypeValue { get; set; }
    }
}