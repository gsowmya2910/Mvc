// ----------------------------------------------------------------------
// <copyright file="Condition.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class Condition
    {
        /// <summary>
        /// Gets or sets the alpha parameters.
        /// </summary>
        /// <value>
        /// The alpha parameters.
        /// </value>
        [DataMember]
        public List<AlphaValueWithThru> AlphaParameters { get; set; }

        /// <summary>
        /// Gets or sets the type of the compare.
        /// </summary>
        /// <value>
        /// The type of the compare.
        /// </value>
        [DataMember]
        public CompareType CompareType { get; set; }

        /// <summary>
        /// Gets or sets the decimal parameters.
        /// </summary>
        /// <value>
        /// The decimal parameters.
        /// </value>
        [DataMember]
        public List<DecimalValueWithThru> DecimalParameters { get; set; }

        /// <summary>
        /// Gets or sets the field number.
        /// </summary>
        /// <value>
        /// The field number.
        /// </value>
        [DataMember]
        public int FieldNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the field.
        /// </summary>
        /// <value>
        /// The type of the field.
        /// </value>
        [DataMember]
        public FieldType FieldType { get; set; }

        /// <summary>
        /// Gets or sets the numeric parameters.
        /// </summary>
        /// <value>
        /// The numeric parameters.
        /// </value>
        [DataMember]
        public List<NumericValueWithThru> NumericParameters { get; set; }

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        /// <value>
        /// The operation.
        /// </value>
        [DataMember]
        public ConditionOperation Operation { get; set; }

        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        /// <value>
        /// The type of the parameter.
        /// </value>
        [DataMember]
        public RecordValueType ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the qualifier.
        /// </summary>
        /// <value>
        /// The qualifier.
        /// </value>
        [DataMember]
        public short Qualifier { get; set; }
    }
}