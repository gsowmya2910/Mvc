// ----------------------------------------------------------------------
// <copyright file="SubCategoryData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The Object
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class SubCategoryData
    {
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
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        [DataMember]
        public short SubCategory { get; set; }
    }
}