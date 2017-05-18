// ----------------------------------------------------------------------
// <copyright file="UpdateStatusData.cs" company="CoreLink">
//        Copyright � CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using System;
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Update.IStatusChange" />
    public class UpdateStatusData : IStatusChange
    {
        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public short Region { get; set; }

        /// <summary>
        /// Gets or sets the mainframe user code.
        /// </summary>
        /// <value>
        /// The mainframe user code.
        /// </value>
        public string MainFrameUsercode { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public short Category { get; set; }

        /// <summary>
        /// Gets or sets the interp value.
        /// </summary>
        /// <value>
        /// The interp value.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        public short Outline { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public short SubCategory { get; set; }

        /// <summary>
        /// Gets or sets the type of the system.
        /// </summary>
        /// <value>
        /// The type of the system.
        /// </value>
        public LineOfBusiness SystemType { get; set; }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        public int EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        public InterpStatus TargetStatus { get; set; }

        /// <summary>
        /// Gets or sets the employee region.
        /// </summary>
        /// <value>
        /// The employee region.
        /// </value>
        public Plan EmployeeRegion { get; set; }

        /// <summary>
        /// Gets or sets the status date time.
        /// </summary>
        /// <value>
        /// The status date time.
        /// </value>
        public DateTime StatusDateTime { get; set; }

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
    }
}