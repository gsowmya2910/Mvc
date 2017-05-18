// ----------------------------------------------------------------------
// <copyright file="InterpBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class InterpBase
    {
        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        [DataMember]
        public short SubCategory { get; set; }

        /// <summary>
        /// Gets or sets the outline.
        /// </summary>
        /// <value>
        /// The outline.
        /// </value>
        [DataMember]
        public short Outline { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short Category { get; set; }

        /// <summary>
        /// Gets or sets the interp value.
        /// </summary>
        /// <value>
        /// The interp value.
        /// </value>
        [DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }
    }
}