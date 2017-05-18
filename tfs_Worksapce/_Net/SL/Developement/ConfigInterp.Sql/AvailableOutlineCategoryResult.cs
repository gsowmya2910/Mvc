// ----------------------------------------------------------------------
// <copyright file="AvailableOutlineCategoryResult.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Sql
{
    using System.Collections.Generic;
    using Contracts.DataContracts;

    /// <summary>
    /// Gets or sets Available Outline Results
    /// </summary>
    public class AvailableOutlineCategoryResult : SqlDataResultBase
    {
        /// <summary>
        /// Gets or sets the Available Outline Data
        /// </summary>
        public List<AvailableOutlineCategoryData> Data { get; set; }
    }
}