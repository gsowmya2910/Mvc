// ----------------------------------------------------------------------
// <copyright file="InquireSimpleOutputData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.InquireOutputDataBase" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class InquireSimpleOutputData : InquireOutputDataBase
    {
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        [DataMember]
        public short Level { get; set; }
    }
}