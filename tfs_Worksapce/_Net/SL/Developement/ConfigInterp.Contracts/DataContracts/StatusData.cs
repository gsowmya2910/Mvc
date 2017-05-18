// ----------------------------------------------------------------------
// <copyright file="StatusData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.InterpDataBase" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class StatusData : InterpDataBase
    {
        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        [DataMember]
        public InterpStatus CurrentStatus { get; set; }

        /// <summary>
        /// Gets or sets the target status.
        /// </summary>
        /// <value>
        /// The target status.
        /// </value>
        [DataMember]
        public InterpStatus TargetStatus { get; set; }
    }
}