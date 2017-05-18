// ----------------------------------------------------------------------
// <copyright file="MockSimpleInquireResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Mocks
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Bl.Interfaces;
    using Contracts.DataContracts;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.ISimpleInquire" />
    [ExcludeFromCodeCoverage]
    internal class MockSimpleInquireResult : ISimpleInquire
    {
        /// <summary>
        /// Gets or sets the admit interp.
        /// </summary>
        /// <value>
        /// The admit interp.
        /// </value>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public short Category { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the create by revision.
        /// </summary>
        /// <value>
        /// The create by revision.
        /// </value>
        public short CreateByRevision { get; set; }

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        public InterpStatus CurrentStatus { get; set; }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        public short EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee region.
        /// </summary>
        /// <value>
        /// The employee region.
        /// </value>
        public Plan EmployeeRegion { get; set; }

        /// <summary>
        /// Gets or sets the ti exception.
        /// </summary>
        /// <value>
        /// The ti exception.
        /// </value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public short Level { get; set; }

        /// <summary>
        /// Gets or sets the message number.
        /// </summary>
        /// <value>
        /// The message number.
        /// </value>
        public short MessageNumber { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        public string MessageText { get; set; }

        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        public short Outline { get; set; }
      
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public OperationResult Result { get; set; }

        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        /// <value>
        /// The revision number.
        /// </value>
        public short RevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the revision sequence.
        /// </summary>
        /// <value>
        /// The revision sequence.
        /// </value>
        public short RevisionSequence { get; set; }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        /// <value>
        /// The status date.
        /// </value>
        public DateTime StatusDateTime { get; set; }

        /// <summary>
        /// Gets or sets the step count.
        /// </summary>
        /// <value>
        /// The step count.
        /// </value>
        public short StepCount { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public short SubCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MockSimpleInquireResult" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the type of the system.
        /// </summary>
        /// <value>
        /// The type of the system.
        /// </value>
        public LineOfBusiness SystemType { get; set; }
    }
}