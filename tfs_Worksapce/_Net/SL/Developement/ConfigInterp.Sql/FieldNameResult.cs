// <copyright file="FieldNameResult.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------using System;

namespace ConfigInterp.Sql
{
    using System.Collections.Generic;
    using Contracts.DataContracts;

    /// <summary>
    /// Gets or sets the Results of the field name query
    /// </summary>
    public class FieldNameResult : SqlDataResultBase
    {
        /// <summary>
        /// Gets or sets a list of field names
        /// </summary>
        public List<FieldNameData> Data { get; set; }
    }
}