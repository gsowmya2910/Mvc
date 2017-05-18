// ----------------------------------------------------------------------
// <copyright file="ActionParameterDescriptionValidationInfoData.cs" company="CoreLink">
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
    public class ActionParameterDescriptionValidationInfoData
    {
        /// <summary>
        /// Gets or sets the parameter Description.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        [DataMember]
        public string ParameterDescription { get; set; }

        /// <summary>
        /// Gets or sets the ValueTypeID.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short ValueTypeId { get; set; }

        /// <summary>
        /// Gets or sets the OrderSequence.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short OrderSequence { get; set; }

        /// <summary>
        /// Gets or sets the FormatInputPattern.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string FormatInputPattern { get; set; }

        /// <summary>
        /// Gets or sets the FormatInputPattern.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string FormatInputHintDescription { get; set; }

        /// <summary>
        /// Gets or sets the FormatTypeID.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public short FormatTypeId { get; set; }

        /// <summary>
        /// Gets or sets the FormatDescription.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [DataMember]
        public string FormatDescription { get; set; }

        /// <summary>
        /// Gets or sets the Minimum Size.
        /// </summary>
        /// <value>
        /// The Minimum size.
        /// </value>
        [DataMember]
        public short MinimumSize { get; set; }

        /// <summary>
        /// Gets or sets the Maximum Size.
        /// </summary>
        /// <value>
        /// the Maximum size.
        /// </value>
        [DataMember]
        public short MaximumSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is optional.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is optional; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsOptional { get; set; }

        /// <summary>
        /// Gets or sets the parameter pseudo code description.
        /// </summary>
        /// <value>
        /// Pseudo Code.
        /// </value>
        [DataMember]
        public string ParameterPseudoDescription { get; set; }
    }
}