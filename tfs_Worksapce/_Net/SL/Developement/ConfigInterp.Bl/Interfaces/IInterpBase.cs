// ----------------------------------------------------------------------
// <copyright file="IInterpBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    /// <summary>
    /// the interface
    /// </summary>
    public interface IInterpBase
    {
        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        short Category { get; }

        /// <summary>
        /// Gets the interp value.
        /// </summary>
        /// <value>
        /// The interp value.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        short AdmitInterp { get; }

        /// <summary>
        /// Gets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        short Outline { get; }

        /// <summary>
        /// Gets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        short SubCategory { get; }
    }
}