// ----------------------------------------------------------------------
// <copyright file="IBenefitMatrixNarrativeInputBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    using Interfaces;

    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixCommonInput" />
    /// <seealso cref="IRegion" />
    public interface IBenefitMatrixNarrativeInputBase : IBenefitMatrixCommonInput, IRegion
    {
        /// <summary>
        /// Gets or sets the blue user.
        /// </summary>
        /// <value>
        /// The blue user.
        /// </value>
        string BlueUser { get; set; }

        /// <summary>
        /// Gets or sets the interp.
        /// </summary>
        /// <value>
        /// The interp.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        IInterp Interp { get; set; }
    }
}