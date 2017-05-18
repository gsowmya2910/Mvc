// ----------------------------------------------------------------------
// <copyright file="MockBenefitMatrix.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Mocks
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.BenefitMatrix;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixHandler" />
    [ExcludeFromCodeCoverage]
    public class MockBenefitMatrix : IBenefitMatrixHandler
    {
        /// <summary>
        /// Gets or sets the completion result.
        /// </summary>
        /// <value>
        /// The completion result.
        /// </value>
        public CompletionResult CompletionResult { get; set; }

        /// <summary>
        /// Gets or sets the creation completion result.
        /// </summary>
        /// <value>
        /// The creation completion result.
        /// </value>
        public CreationCompletionResult CreationCompletionResult { get; set; }

        /// <summary>
        /// Gets or sets the narrative result.
        /// </summary>
        /// <value>
        /// The narrative result.
        /// </value>
        public NarrativeResult NarrativeResult { get; set; }

        /// <summary>
        /// Creates the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        public CreationCompletionResult CreateNarrative(IBenefitMatrixCreateInput input)
        {
            return this.CreationCompletionResult;
        }

        /// <summary>
        /// Deletes the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        public CompletionResult DeleteNarrative(IBenefitMatrixNarrativeDeleteable input)
        {
            return this.CompletionResult;
        }

        /// <summary>
        /// Inquires the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        public NarrativeResult InquireNarrative(IBenefitMatrixNarrativeInquireable input)
        {
            return this.NarrativeResult;
        }

        /// <summary>
        /// Updates the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        public CompletionResult UpdateNarrative(IBenefitMatrixChangeable input)
        {
            return this.CompletionResult;
        }
    }
}