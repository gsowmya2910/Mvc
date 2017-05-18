// ----------------------------------------------------------------------
// <copyright file="IWorkFlowManager.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    using BenefitMatrix;
    using Update;

    /// <summary>
    /// the class
    /// </summary>
    public interface IWorkflowManager
    {
        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the value</returns>
        CloneInterpResult CloneInterp(ICloneInterpData value);

        /// <summary>
        /// Deletes the Interp
        /// </summary>
        /// <param name="input">Delete Request</param>
        /// <returns>The result</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        UpdateResult DeleteInterp(IDeleteInterpIntialData input);

        /// <summary>
        /// Updates the narrative.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the value</returns>
        CompletionResult UpdateNarrative(IBenefitMatrixChangeable value);

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the value</returns>
        StatusChangeResult UpdateStatus(IStatusChangeData value);
    }
}