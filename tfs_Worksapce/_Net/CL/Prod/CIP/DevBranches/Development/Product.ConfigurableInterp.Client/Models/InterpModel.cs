//----------------------------------------------------------------
// <copyright file="InterpModel.cs" company="CoreLink">
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
    /// This class will hold Interp Model object
    /// </summary>
    public class InterpModel
    {
        /// <summary>
        /// Gets or sets Interp model object
        /// </summary>
        public IEnumerable<string> InterpId { get; set; }
    }
}