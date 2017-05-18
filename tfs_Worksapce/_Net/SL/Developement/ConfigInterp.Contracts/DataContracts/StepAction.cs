// ----------------------------------------------------------------------
// <copyright file="StepAction.cs" company="CoreLink">
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
    public class StepAction
    {
        /// <summary>
        /// Gets or sets the action identifier.
        /// </summary>
        /// <value>
        /// The action identifier.
        /// </value>
        [DataMember]
        public short ActionId { get; set; }

        /// <summary>
        /// Gets or sets the numeric parameters.
        /// </summary>
        /// <value>
        /// The numeric parameters.
        /// </value>
        [DataMember]
        public List<NumericValue> NumericParameters { get; set; }

        /// <summary>
        /// Gets or sets the decimal parameters.
        /// </summary>
        /// <value>
        /// The decimal parameters.
        /// </value>
        [DataMember]
        public List<DecimalValue> DecimalParameters { get; set; }

        /// <summary>
        /// Gets or sets the alpha parameters.
        /// </summary>
        /// <value>
        /// The alpha parameters.
        /// </value>
        [DataMember]
        public List<AlphaValue> AlphaParameters { get; set; }
    }
}