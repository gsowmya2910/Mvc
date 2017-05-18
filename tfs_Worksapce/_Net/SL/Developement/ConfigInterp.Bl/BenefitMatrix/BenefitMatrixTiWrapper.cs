// ----------------------------------------------------------------------
// <copyright file="BenefitMatrixTiWrapper.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    using System.Diagnostics.CodeAnalysis;
    using BMNARR01;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.ITBenefitMatrix" />
    [ExcludeFromCodeCoverage]
    internal class BenefitMatrixTiWrapper : ITBenefitMatrix
    {
        /// <summary>
        /// The region
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly short _region;

        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitMatrixTiWrapper"/> class.
        /// </summary>
        /// <param name="region">The region.</param>
        public BenefitMatrixTiWrapper(short region)
        {
            this._region = region;

            this.Implementation = new BMNARR();
        }

        /// <summary>
        /// Gets or sets the implementation.
        /// </summary>
        /// <value>
        /// The implementation.
        /// </value>
        private IBMNARR Implementation { get; set; }

        /// <summary>
        /// Creates the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        public void Create(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.CREATE_BMNARR(commonInput, narrativeInput, out commonOutput, out narrativeOutput, out recordCount, out narrativeLineRecords, ref context);
        }

        /// <summary>
        /// Deletes the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        public void Delete(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.DELETE_BMNARR(commonInput, narrativeInput, out commonOutput, out narrativeOutput, out recordCount, out narrativeLineRecords, ref context);
        }

        /// <summary>
        /// Inquires the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        public void Inquire(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.INQUIRE_ON_BMNARR(commonInput, narrativeInput, out commonOutput, out narrativeOutput, out recordCount, out narrativeLineRecords, ref context);
        }

        /// <summary>
        /// Updates the specified common input.
        /// </summary>
        /// <param name="commonInput">The common input.</param>
        /// <param name="narrativeInput">The narrative input.</param>
        /// <param name="commonOutput">The common output.</param>
        /// <param name="narrativeOutput">The narrative output.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="narrativeLineRecords">The narrative line records.</param>
        public void Update(CommonInput commonInput, NarrativeInput narrativeInput, out CommonOutput commonOutput, out NarrativeOutput narrativeOutput, out short recordCount, out NarrativeLineRecord[] narrativeLineRecords)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.UPDATE_BMNARR(commonInput, narrativeInput, out commonOutput, out narrativeOutput, out recordCount, out narrativeLineRecords, ref context);
        }
    }
}