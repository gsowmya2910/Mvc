// ----------------------------------------------------------------------
// <copyright file="Narrative.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.BenefitMatrix
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.INarrative" />
    public class Narrative : INarrative
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public short Category { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }

        /// <summary>
        /// Gets or sets the interp.
        /// </summary>
        /// <value>
        /// The interp.
        /// </value>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the lines.
        /// </summary>
        /// <value>
        /// The lines.
        /// </value>
        public string[] Lines { get; set; }

        /// <summary>
        /// Gets or sets the maintenance date.
        /// </summary>
        /// <value>
        /// The maintenance date.
        /// </value>
        public DateTime? MaintenanceDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the narrative.
        /// </summary>
        /// <value>
        /// The type of the narrative.
        /// </value>
        public short NarrativeType { get; set; }

        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        public short Outline { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        public short SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        /// <value>
        /// The status date.
        /// </value>
        public DateTime? StatusDate { get; set; }

        /// <summary>
        /// Gets or sets the subcategory.
        /// </summary>
        /// <value>
        /// The subcategory.
        /// </value>
        public short Subcategory { get; set; }
    }
}