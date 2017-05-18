// ----------------------------------------------------------------------
// <copyright file="ICipUpdateHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    /// <summary>
    /// the interface
    /// </summary>
    public interface ICipUpdateHandler
    {
        /// <summary>
        /// Updates the interp.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        UpdateResult UpdateInterp(IUpdateInterp input);

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        UpdateResult UpdateStatus(IStatusChange input);

        /// <summary>
        /// Deletes the Interp
        /// </summary>
        /// <param name="input">Delete Request</param>
        /// <returns>The result</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        UpdateResult DeleteInterp(IDeleteInterp input);
    }
}