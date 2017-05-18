// ----------------------------------------------------------------------
// <copyright file="IDataResultBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Interfaces
{
    using System;
    using Contracts.DataContracts;

    /// <summary>
    /// The Interface
    /// </summary>
    public interface IDataResultBase
    {
        /// <summary>
        /// Gets the message number.
        /// </summary>
        /// <value>
        /// The message number.
        /// </value>
        short MessageNumber { get; }

        /// <summary>
        /// Gets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        string MessageText { get; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        OperationResult Result { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="DataResultBase"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        bool Success { get; }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        Exception Exception { get; }
    }
}