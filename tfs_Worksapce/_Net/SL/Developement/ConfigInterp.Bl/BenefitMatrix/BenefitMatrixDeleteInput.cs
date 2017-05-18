// ----------------------------------------------------------------------
// <copyright file="BenefitMatrixDeleteInput.cs" company="CoreLink">
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
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixNarrativeDeleteable" />
    public class BenefitMatrixDeleteInput : BenefitMatrixInput, IBenefitMatrixNarrativeDeleteable
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        public short SequenceNumber { get; set; }
    }
}