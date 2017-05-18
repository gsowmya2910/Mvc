// ----------------------------------------------------------------------
// <copyright file="DecimalValueWithThru.cs" company="CoreLink">
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
    public class DecimalValueWithThru
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember]
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the value thru.
        /// </summary>
        /// <value>
        /// The value thru.
        /// </value>
        [DataMember]
        public decimal ValueThru { get; set; }
    }
}