// ----------------------------------------------------------------------
// <copyright file="FieldValidationInfoData.cs" company="CoreLink">
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
    public class FieldValidationInfoData
    {
        /// <summary>
        /// Gets or sets the ValueTypeID.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        [DataMember]
        public short ValueTypeId { get; set; }

        /// <summary>
        /// Gets or sets the FormatTypeID.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short FormatTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Format Description.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string FormatDescription { get; set; }

        /// <summary>
        /// Gets or sets the FormatInputPattern.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string FormatInputPattern { get; set; }

        /// <summary>
        /// Gets or sets the Format Input Hint Description.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string FormatInputHintDescription { get; set; }

        /// <summary>
        /// Gets or sets the MinSize.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short MinSize { get; set; }

        /// <summary>
        /// Gets or sets the MaxSize.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short MaxSize { get; set; }

        /// <summary>
        /// Gets or sets the QualifierTypeNumber.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short QualifierTypeNumber { get; set; }
    }
}