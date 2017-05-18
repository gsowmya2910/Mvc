// <copyright file="DescriptionCommonSqlDataResult.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Sql
{
    using System.Collections.Generic;
    using Contracts.DataContracts;

    /// <summary>
    /// Gets or sets theAction Parameter Results
    /// </summary>
    public class DescriptionCommonSqlDataResult : SqlDataResultBase
    {
        /// <summary>
        /// Gets or sets the Action Parameter data
        /// </summary>
        public List<DescriptionCommon> Data { get; set; }
    }
}