// ----------------------------------------------------------------------
// <copyright file="IInquireDataResultBase.cs" company="CoreLink">
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
    public interface IInquireDataResultBase : IDataResultBase, IInterp
    {
        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        string Comment { get; }

        /// <summary>
        /// Gets the create by revision.
        /// </summary>
        /// <value>
        /// The create by revision.
        /// </value>
        short CreateByRevision { get; }

        /// <summary>
        /// Gets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        InterpStatus CurrentStatus { get; }

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        short EmployeeNumber { get; }

        /// <summary>
        /// Gets the employee region.
        /// </summary>
        /// <value>
        /// The employee region.
        /// </value>
        Plan EmployeeRegion { get; }
       
        /// <summary>
        /// Gets the revision number.
        /// </summary>
        /// <value>
        /// The revision number.
        /// </value>
        short RevisionNumber { get; }

        /// <summary>
        /// Gets the revision sequence.
        /// </summary>
        /// <value>
        /// The revision sequence.
        /// </value>
        short RevisionSequence { get; }

        /// <summary>
        /// Gets the status date.
        /// </summary>
        /// <value>
        /// The status date.
        /// </value>
        DateTime StatusDateTime { get; }

        /// <summary>
        /// Gets the step count.
        /// </summary>
        /// <value>
        /// The step count.
        /// </value>
        short StepCount { get; }

        /// <summary>
        /// Gets the type of the system.
        /// </summary>
        /// <value>
        /// The type of the system.
        /// </value>
        LineOfBusiness SystemType { get; }
    }
}