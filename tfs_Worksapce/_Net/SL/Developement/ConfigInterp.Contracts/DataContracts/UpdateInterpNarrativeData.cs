// ----------------------------------------------------------------------
// <copyright file="UpdateInterpNarrativeData.cs" company="CoreLink">
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
    public class UpdateInterpNarrativeData : InterpDataStatusBase
    {
        /// <summary>
        /// Gets or sets the narrative lines.
        /// </summary>
        /// <value>
        /// The narrative lines.
        /// </value>
        [DataMember]
        public string[] NarrativeLines { get; set; }
    }
}