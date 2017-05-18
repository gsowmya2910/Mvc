// ----------------------------------------------------------------------
// <copyright file="IBenefitMatrixChangeable.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixNarrativeInputBase" />
    public interface IBenefitMatrixChangeable : IBenefitMatrixNarrativeInputBase, IHasStatus
    {
        /// <summary>
        /// Gets or sets the narrative.
        /// </summary>
        /// <value>
        /// The narrative.
        /// </value>
        string[] Narrative { get; set; }
    }
}