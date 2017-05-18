// ----------------------------------------------------------------------
// <copyright file="InterpConfigBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The class
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public abstract class InterpConfigBase : InterpDataBase
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
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        [DataMember]
        public short EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee region.
        /// </summary>
        /// <value>
        /// The employee region.
        /// </value>
        [DataMember]
        public Plan EmployeeRegion { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        [DataMember]
        public string Comment { get; set; }
    }
}