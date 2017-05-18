// <copyright file="SqlDataResultBase.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Sql
{
    using System;
    using Contracts.DataContracts;

    /// <summary>
    /// The basic results of the query
    /// </summary>
    public abstract class SqlDataResultBase
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public OperationResult Result { get; set; }

        /// <summary>
        /// Gets or sets the ti exception.
        /// </summary>
        /// <value>
        /// The ti exception.
        /// </value>
        public Exception Exception { get; set; }
    }
}