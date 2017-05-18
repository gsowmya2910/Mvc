// ----------------------------------------------------------------------
// <copyright file="ICipUpdateTiWrapper.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    using CIPUPD01;

    /// <summary>
    /// the interface
    /// </summary>
    internal interface ICipUpdateTiWrapper
    {
        /// <summary>
        /// Deletes the interp.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="keyInfo">The key information.</param>
        /// <param name="response">The response.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        void DeleteInterp(InputHeader inputHeader, KeyInfo keyInfo, out OutputHeader response);

        /// <summary>
        /// Updates the interp.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="keyInfo">The key information.</param>
        /// <param name="inTableOccurs">The in table occurs.</param>
        /// <param name="inRecTable">The in record table.</param>
        /// <param name="response">The response.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        void UpdateInterp(InputHeader inputHeader, KeyInfo keyInfo, short inTableOccurs, RecordTable[] inRecTable, out OutputHeader response);

        /// <summary>
        /// Updates the interp status.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="keyInfo">The key information.</param>
        /// <param name="response">The response.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        void UpdateInterpStatus(InputHeader inputHeader, KeyInfo keyInfo, out OutputHeader response);
    }
}