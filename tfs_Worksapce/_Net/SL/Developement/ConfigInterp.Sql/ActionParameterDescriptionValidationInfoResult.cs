// <copyright file="ActionParameterDescriptionValidationInfoResult.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Sql
{
    using System.Collections.Generic;
    using Contracts.DataContracts;

    /// <summary>
    /// Gets or sets the common results
    /// </summary>
    public class ActionParameterDescriptionValidationInfoResult : SqlDataResultBase
    {
        /// <summary>
        /// Gets or sets the common list
        /// </summary>
        public List<ActionParameterDescriptionValidationInfoData> Data { get; set; }
    }
}