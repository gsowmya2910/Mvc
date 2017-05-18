// ----------------------------------------------------------------------
// <copyright file="AvailableOutlineCategoryData.cs" company="CoreLink">
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
    public class AvailableOutlineCategoryData
    {
        /// <summary>
        /// Gets or sets the OutlineId.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        [DataMember]
        public short OutlineId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryID.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        [DataMember]
        public short CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the StatusID.
        /// </summary>
        /// <value>
        /// The status id.
        /// </value>
        [DataMember]
        public short StatusId { get; set; }

        /// <summary>
        /// Gets or sets the PseudoCategoryLiteralDescription.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember]
        public string PseudoCategoryLiteralDescription { get; set; }
    }
}