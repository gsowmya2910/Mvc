// ----------------------------------------------------------------------
// <copyright file="BenefitMatrixInput.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.BenefitMatrix
{
    using Interfaces;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixNarrativeInputBase" />
    public class BenefitMatrixInput : IBenefitMatrixNarrativeInputBase
    {
        /// <summary>
        /// Gets or sets the blue user.
        /// </summary>
        /// <value>
        /// The blue user.
        /// </value>
        public string BlueUser { get; set; }

        /// <summary>
        /// Gets or sets the interp.
        /// </summary>
        /// <value>
        /// The interp.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public IInterp Interp { get; set; }

        /// <summary>
        /// Gets or sets the mainframe usercode.
        /// </summary>
        /// <value>
        /// The mainframe usercode.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public string MainframeUsercode { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public short Region { get; set; }
    }
}