// ----------------------------------------------------------------------
// <copyright file="SystemTypeRequest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// the System type request
    /// </summary>
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class SystemTypeRequest : RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public LineOfBusiness LineOfBusiness { get; set; }
    }
}