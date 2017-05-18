// ----------------------------------------------------------------------
// <copyright file="InterpDataBase.cs" company="CoreLink">
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
    public abstract class InterpDataBase
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
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
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
        /// Gets or sets the admit.
        /// </summary>
        /// <value>
        /// The interp.
        /// </value>
        [DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp { get; set; }

        /// <summary>
        /// Gets or sets the line of business.
        /// </summary>
        /// <value>
        /// The line of business.
        /// </value>
        [DataMember]
        public LineOfBusiness LineOfBusiness { get; set; }
    }
}