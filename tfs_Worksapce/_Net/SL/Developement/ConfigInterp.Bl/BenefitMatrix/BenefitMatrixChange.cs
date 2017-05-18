// ----------------------------------------------------------------------
// <copyright file="BenefitMatrixChange.cs" company="CoreLink">
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
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixChangeable" />
    public class BenefitMatrixChange : BenefitMatrixInput, IBenefitMatrixChangeable
    {
        /// <summary>
        /// Gets or sets the narrative.
        /// </summary>
        /// <value>
        /// The narrative.
        /// </value>
        public string[] Narrative { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }
    }
}