// ----------------------------------------------------------------------
// <copyright file="FieldNameData.cs" company="CoreLink">
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
    public class FieldNameData
    {
        /// <summary>
        /// Gets or sets the field identifier.
        /// </summary>
        /// <value>
        /// The field identifier.
        /// </value>
        [DataMember]
        public string FieldId { get; set; }

        /// <summary>
        /// Gets or sets the field description.
        /// </summary>
        /// <value>
        /// The field description.
        /// </value>
        [DataMember]
        public string FieldDescription { get; set; }

        /// <summary>
        /// Gets or sets the field pseudo description.
        /// </summary>
        /// <value>
        /// The field pseudo description.
        /// </value>
        [DataMember]
        public string FieldPseudoDescription { get; set; }

        /// <summary>
        /// Gets or sets the qualifier pseudo description.
        /// </summary>
        /// <value>
        /// The qualifier pseudo description.
        /// </value>
        [DataMember]
        public string QualifierPseudoDescription { get; set; }
    }
}