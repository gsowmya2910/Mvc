// ----------------------------------------------------------------------
// <copyright file="CreationCompletionResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.CompletionResult" />
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IHasStatus" />
    public class CreationCompletionResult : CompletionResult, IHasStatus
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