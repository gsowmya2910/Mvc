// ----------------------------------------------------------------------
// <copyright file="Interp.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    using System.Diagnostics;
    using Interfaces;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="IInterp" />
    [DebuggerDisplay("{DebugDisplay,nq}")]
    public class Interp : IInterp
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public short Category { get; set; }

        /// <summary>
        /// Gets or sets the interp value.
        /// </summary>
        /// <value>
        /// The interp value.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public short Level { get; set; }

        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        public short Outline { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public short SubCategory { get; set; }

        /// <summary>
        /// Gets the debug display.
        /// </summary>
        /// <value>
        /// The debug display.
        /// </value>
        internal string DebugDisplay
        {
            get
            {
                return string.Format(
                    "{0}-{1}-{2}-{3}-{4}",
                this.Outline.ToString().PadLeft(2, '0'),
                this.Category.ToString().PadLeft(3, '0'),
                this.SubCategory.ToString().PadLeft(3, '0'),
                this.AdmitInterp.ToString().PadLeft(4, '0'),
                this.Level.ToString().PadLeft(2, '0'));
            }
        }
    }
}