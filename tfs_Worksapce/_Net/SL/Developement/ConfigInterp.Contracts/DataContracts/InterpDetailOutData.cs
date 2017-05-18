// ----------------------------------------------------------------------
// <copyright file="InterpDetailOutData.cs" company="CoreLink">
//        Copyright � CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.InquireOutputDataBase" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class InterpDetailOutData : InterpConfigBase
    {
        /// <summary>
        /// Gets or sets the configured steps.
        /// </summary>
        /// <value>
        /// The configured steps.
        /// </value>
        [DataMember]
        public ConfiguredSteps ConfiguredSteps { get; set; }

        /// <summary>
        /// Gets or sets the last edited.
        /// </summary>
        /// <value>
        /// The last edited.
        /// </value>
        [DataMember]
        public DateTime? LastEdited { get; set; }
    }
}