// ----------------------------------------------------------------------
// <copyright file="DescriptionCommon.cs" company="CoreLink">
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
    public class DescriptionCommon
    {
        /// <summary>
        /// Gets or sets the Type ID.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        [DataMember]
        public short TypeId { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the PseudoDescription.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string PseudoDescription { get; set; }
    }
}