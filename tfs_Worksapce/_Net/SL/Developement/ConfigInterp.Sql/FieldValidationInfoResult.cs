// <copyright file="FieldValidationInfoResult.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------using System;

namespace ConfigInterp.Sql
{
    using System.Collections.Generic;
    using Contracts.DataContracts;

    /// <summary>
    /// Gets or sets the Field validation result
    /// </summary>
    public class FieldValidationInfoResult : SqlDataResultBase
    {
        /// <summary>
        /// Gets or sets the Field Validation information
        /// </summary>
        public List<FieldValidationInfoData> Data { get; set; }
    }
}