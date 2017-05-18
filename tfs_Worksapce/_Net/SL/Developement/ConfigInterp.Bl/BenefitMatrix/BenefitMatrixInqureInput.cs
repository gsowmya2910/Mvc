// ----------------------------------------------------------------------
// <copyright file="BenefitMatrixInqureInput.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.BenefitMatrixInput" />
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixNarrativeInquireable" />
    public class BenefitMatrixInqureInput : BenefitMatrixInput, IBenefitMatrixNarrativeInquireable
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }
    }
}