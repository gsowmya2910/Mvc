// ----------------------------------------------------------------------
// <copyright file="IBenefitMatrixHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    /// <summary>
    /// the interface
    /// </summary>
    public interface IBenefitMatrixHandler
    {
        /// <summary>
        /// Creates the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        CreationCompletionResult CreateNarrative(IBenefitMatrixCreateInput input);

        /// <summary>
        /// Deletes the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        CompletionResult DeleteNarrative(IBenefitMatrixNarrativeDeleteable input);

        /// <summary>
        /// Inquires the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        NarrativeResult InquireNarrative(IBenefitMatrixNarrativeInquireable input);

        /// <summary>
        /// Updates the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        CompletionResult UpdateNarrative(IBenefitMatrixChangeable input);
    }
}