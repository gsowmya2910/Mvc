// ----------------------------------------------------------------------
// <copyright file="InquireNarrativeOutputData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.InterpDataBase" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class InquireNarrativeOutputData : InterpDataStatusBase
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        [DataMember]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        [DataMember]
        public int EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or sets the maintenance date.
        /// </summary>
        /// <value>
        /// The maintenance date.
        /// </value>
        [DataMember]
        public DateTime? MaintenanceDate { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        [DataMember]
        public short SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        /// <value>
        /// The status date.
        /// </value>
        [DataMember]
        public DateTime? StatusDate { get; set; }
    }
}