// ----------------------------------------------------------------------
// <copyright file="InquireOutputDataBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The class
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public abstract class InquireOutputDataBase : InterpConfigBase
    {
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