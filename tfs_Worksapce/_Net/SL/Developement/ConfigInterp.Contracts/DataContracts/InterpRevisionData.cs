// ----------------------------------------------------------------------
// <copyright file="InterpRevisionData.cs" company="CoreLink">
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
    public abstract class InterpRevisionData
    {
        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The create by revision.
        /// </value>
        [DataMember]
        public short CreateByRevision { get; set; }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The create by revision.
        /// </value>
        [DataMember]
        public short RevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the Outline.
        /// </summary>
        /// <value>
        /// The Outline.
        /// </value>
        [DataMember]
        public short Status { get; set; }
    }
}