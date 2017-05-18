// ----------------------------------------------------------------------
// <copyright file="OutlineData.cs" company="CoreLink">
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
    public class OutlineData
    {
        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        [DataMember]
        public short Outline { get; set; }
    }
}