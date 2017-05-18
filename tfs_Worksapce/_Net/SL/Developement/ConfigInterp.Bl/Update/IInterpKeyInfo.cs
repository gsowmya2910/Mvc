// ----------------------------------------------------------------------
// <copyright file="IInterpKeyInfo.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using System;
    using Contracts.DataContracts;

    /// <summary>
    /// the interface
    /// </summary>
    public interface IInterpKeyInfo
    {
        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; }

        /// <summary>
        /// Gets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        InterpStatus CurrentStatus { get; }

        /// <summary>
        /// Gets the employee region.
        /// </summary>
        /// <value>
        /// The employee region.
        /// </value>
        Plan EmployeeRegion { get; }

        /// <summary>
        /// Gets the status date time.
        /// </summary>
        /// <value>
        /// The status date time.
        /// </value>
        DateTime StatusDateTime { get; }
    }
}