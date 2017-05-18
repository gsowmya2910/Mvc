// ----------------------------------------------------------------------
// <copyright file="ListRequest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// The  List request
    /// </summary>
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class ListRequest : RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the system type identifier.
        /// </summary>
        /// <value>
        /// The system type identifier.
        /// </value>
        [MessageBodyMember]
        public LineOfBusiness LineOfBusiness { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [MessageBodyMember]
        public int Id { get; set; }
    }
}