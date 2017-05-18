//----------------------------------------------------------------
// <copyright file="AlphaParameters.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using schemas.corelinksolutions.com.product.schema.configinterp;

    /// <summary>
    /// This class will hold Alpha Parameters
    /// </summary>
    public class AlphaParameters
    {
        /// <summary>
        /// Gets or sets Value property
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets ValueThru property
        /// </summary>
        public string ValueThru { get; set; }
    }
}