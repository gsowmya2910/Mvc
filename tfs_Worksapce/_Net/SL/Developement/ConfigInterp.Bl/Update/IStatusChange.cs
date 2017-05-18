// ----------------------------------------------------------------------
// <copyright file="IStatusChange.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using System;
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IRegion" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IMainFrameUsercode" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IInterpAsType" />
    public interface IStatusChange : IRegion, IMainFrameUsercode, IInterpAsType
    {
        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        int EmployeeNumber { get; set; }

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
        InterpStatus TargetStatus { get; }

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

        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        /// <value>
        /// The revision number.
        /// </value>
        short RevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the revision sequence.
        /// </summary>
        /// <value>
        /// The revision sequence.
        /// </value>
        short RevisionSequence { get; set; }
    }
}