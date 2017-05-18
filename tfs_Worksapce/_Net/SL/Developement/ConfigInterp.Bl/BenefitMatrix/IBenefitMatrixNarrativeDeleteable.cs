// ----------------------------------------------------------------------
// <copyright file="IBenefitMatrixNarrativeDeleteable.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IHasStatus" />
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixNarrativeInputBase" />
    public interface IBenefitMatrixNarrativeDeleteable : IBenefitMatrixNarrativeInputBase, IHasStatus
    {
        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        short SequenceNumber { get; set; }
    }
}