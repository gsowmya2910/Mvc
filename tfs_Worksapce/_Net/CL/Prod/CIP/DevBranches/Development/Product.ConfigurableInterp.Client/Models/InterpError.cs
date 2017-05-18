//----------------------------------------------------------------
// <copyright file="InterpError.cs" company="CoreLink">
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
    /// This class will hold Interp Exception structure
    /// </summary>
    public class InterpError
    {
        /// <summary>
        /// Gets or sets Step Number of the Exception
        /// </summary>
        public int StepNumber { get; set; }

        /// <summary>
        /// Gets or sets Exception Order Number within the step
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets Id property
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Name Property
        /// </summary>
        public string Name { get; set; }
    }    
}