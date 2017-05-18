//----------------------------------------------------------------
// <copyright file="ConditionTypeData.cs" company="CoreLink">
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
    /// This class will hold Interp Exception JSON structure
    /// </summary>
    public class ConditionTypeData
    {
        /// <summary>
        /// Gets or sets Exception Id data from User
        /// </summary>
        public string ConditionTypeId { get; set; }

        /// <summary>
        /// Gets or sets Exception value from User
        /// </summary>
        public string ExceptionValue { get; set; }
    }
}