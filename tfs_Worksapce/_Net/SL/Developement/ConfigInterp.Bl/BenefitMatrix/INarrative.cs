// ----------------------------------------------------------------------
// <copyright file="INarrative.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    using System;

    /// <summary>
    /// the interface
    /// </summary>
    public interface INarrative
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        short Category { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }

        /// <summary>
        /// Gets or sets the interp.
        /// </summary>
        /// <value>
        /// The interp.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the lines.
        /// </summary>
        /// <value>
        /// The lines.
        /// </value>
        string[] Lines { get; set; }

        /// <summary>
        /// Gets or sets the maintenance date.
        /// </summary>
        /// <value>
        /// The maintenance date.
        /// </value>
        DateTime? MaintenanceDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the narrative.
        /// </summary>
        /// <value>
        /// The type of the narrative.
        /// </value>
        short NarrativeType { get; set; }

        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        short Outline { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        short SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        string Status { get; set; }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        /// <value>
        /// The status date.
        /// </value>
        DateTime? StatusDate { get; set; }

        /// <summary>
        /// Gets or sets the subcategory.
        /// </summary>
        /// <value>
        /// The subcategory.
        /// </value>
        short Subcategory { get; set; }
    }
}