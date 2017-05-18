// ----------------------------------------------------------------------
// <copyright file="CipUpdateTiWrapper.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using System.Diagnostics.CodeAnalysis;
    using CIPUPD01;
    using Interfaces;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.ICipUpdateTiWrapper" />
    [ExcludeFromCodeCoverage]
    internal class CipUpdateTiWrapper : ICipUpdateTiWrapper
    {
        /// <summary>
        /// The region
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly short _region;

        /// <summary>
        /// Initializes a new instance of the <see cref="CipUpdateTiWrapper"/> class.
        /// </summary>
        /// <param name="region">The region.</param>
        public CipUpdateTiWrapper(short region)
        {
            this._region = region;
            this.Implementation = new CIPUPD();
        }

        /// <summary>
        /// Gets or sets the implementation.
        /// </summary>
        /// <value>
        /// The implementation.
        /// </value>
        private ICIPUPD Implementation { get; set; }

        /// <summary>
        /// Deletes the interp.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="keyInfo">The key information.</param>
        /// <param name="response">The response.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void DeleteInterp(InputHeader inputHeader, KeyInfo keyInfo, out OutputHeader response)
        {
            var context = ClientContextMapper.MetaData(this._region);

            this.Implementation.DeleteInterp(inputHeader, keyInfo, out response, ref context);
        }

        /// <summary>
        /// Updates the interp.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="keyInfo">The key information.</param>
        /// <param name="inTableOccurs">The in table occurs.</param>
        /// <param name="inRecTable">The in record table.</param>
        /// <param name="response">The response.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterp(InputHeader inputHeader, KeyInfo keyInfo, short inTableOccurs, RecordTable[] inRecTable, out OutputHeader response)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.UpdateInterpConfig(inputHeader, keyInfo, inTableOccurs, inRecTable, out response, ref context);
        }

        /// <summary>
        /// Updates the interp status.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="keyInfo">The key information.</param>
        /// <param name="response">The response.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpStatus(InputHeader inputHeader, KeyInfo keyInfo, out OutputHeader response)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.UpdateInterpStatus(inputHeader, keyInfo, out response, ref context);
        }
    }
}