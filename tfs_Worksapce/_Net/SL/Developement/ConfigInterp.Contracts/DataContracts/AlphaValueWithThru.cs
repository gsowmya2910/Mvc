// ----------------------------------------------------------------------
// <copyright file="AlphaValueWithThru.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.AlphaValue" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class AlphaValueWithThru
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the value thru.
        /// </summary>
        /// <value>
        /// The value thru.
        /// </value>
        [DataMember]
        public string ValueThru { get; set; }
    }
}