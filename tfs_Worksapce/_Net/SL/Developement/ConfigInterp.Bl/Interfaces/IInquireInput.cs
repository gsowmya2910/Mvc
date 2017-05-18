// ----------------------------------------------------------------------
// <copyright file="IInquireInput.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Interfaces
{
    using Contracts.DataContracts;

    /// <summary>
    /// The Interface
    /// </summary>
    public interface IInquireInput : IMainFrameUsercode
    {
        /// <summary>
        /// Gets or sets the admit interp.
        /// </summary>
        /// <value>
        /// The admit interp.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        short Category { get; set; }

        /// <summary>
        /// Gets or sets the out line.
        /// </summary>
        /// <value>
        /// The out line.
        /// </value>
        short Outline { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        short Region { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        InterpStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        short SubCategory { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        LineOfBusiness SystemType { get; set; }
    }
}