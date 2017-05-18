// ----------------------------------------------------------------------
// <copyright file="ExceptionStep.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.ConfiguredStep" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class ExceptionStep : ConfiguredStep
    {
        /// <summary>
        /// Gets or sets the exception identifier.
        /// </summary>
        /// <value>
        /// The exception identifier.
        /// </value>
        [DataMember]
        public short ExceptionId { get; set; }
    }
}