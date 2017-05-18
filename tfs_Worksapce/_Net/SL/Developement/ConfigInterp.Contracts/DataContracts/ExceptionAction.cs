// ----------------------------------------------------------------------
// <copyright file="ExceptionAction.cs" company="CoreLink">
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
    public class ExceptionAction
    {
        /// <summary>
        /// Gets or sets the action identifier.
        /// </summary>
        /// <value>
        /// The action identifier.
        /// </value>
        [DataMember]
        public short ActionId { get; set; }
    }
}