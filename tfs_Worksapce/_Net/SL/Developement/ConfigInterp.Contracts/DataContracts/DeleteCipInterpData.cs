// ----------------------------------------------------------------------
// <copyright file="DeleteCipInterpDAta.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// class for delete
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class DeleteCipInterpData : InterpDataBase
    { 
        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        [DataMember]
        public InterpStatus Status { get; set; }
    }
}