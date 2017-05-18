// ----------------------------------------------------------------------
// <copyright file="DeleteInterpIntialData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Update.IDeleteInterpIntialData" />
    public class DeleteInterpIntialData : IDeleteInterpIntialData
    {
        /// <summary>
        /// Gets or sets the interp value.
        /// </summary>
        /// <value>
        /// The interp value.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the blue user.
        /// </summary>
        /// <value>
        /// The blue user.
        /// </value>
        public string BlueUser { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public short Category { get; set; }

        /// <summary>
        /// Gets or sets the mainframe user code.
        /// </summary>
        /// <value>
        /// The mainframe user code.
        /// </value>
        public string MainFrameUsercode { get; set; }

        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        public short Outline { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public short Region { get; set; }

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        public InterpStatus Status { get; set; }

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
    }
}