// ----------------------------------------------------------------------
// <copyright file="InquireInput.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Inquire
{
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="IInquireInput" />
    public class InquireInput : IInquireInput
    {
        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public short Region { get; set; }

        /// <summary>
        /// Gets or sets the main frame user code.
        /// </summary>
        /// <value>
        /// The main frame user code.
        /// </value>
        public string MainFrameUsercode { get; set; }

        /// <summary>
        /// Gets or sets the admit interp.
        /// </summary>
        /// <value>
        /// The admit interp.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public short Category { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public LineOfBusiness SystemType { get; set; }

        /// <summary>
        /// Gets or sets the out line.
        /// </summary>
        /// <value>
        /// The out line.
        /// </value>
        public short Outline { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public InterpStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public short SubCategory { get; set; }
    }
}