//----------------------------------------------------------------
// <copyright file="ConditionType.cs" company="CoreLink">
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
    /// This class will hold Condition Type
    /// </summary>
    public class ConditionType
    {
        /// <summary>
        /// Gets or sets Id property
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Name Property
        /// </summary>
        public string Name { get; set; }

        public static implicit operator string(ConditionType v)
        {
            throw new NotImplementedException();
        }
    }
}