// ----------------------------------------------------------------------
// <copyright file="ITBenefitMatrix.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    using BMNARR01;

    /// <summary>
    /// the interface
    /// </summary>
    internal interface ITBenefitMatrix
    {
        /// <summary>
        /// Creates the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        void Create(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords);

        /// <summary>
        /// Deletes the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        void Delete(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords);

        /// <summary>
        /// Inquires the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        void Inquire(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords);

        /// <summary>
        /// Updates the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        void Update(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords);
    }
}