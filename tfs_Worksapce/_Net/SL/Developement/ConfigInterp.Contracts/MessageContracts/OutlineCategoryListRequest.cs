// ----------------------------------------------------------------------
// <copyright file="OutlineCategoryListRequest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class OutlineCategoryListRequest : RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public LineOfBusiness LineOfBusiness { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public int OutlineId { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public int CategoryId { get; set; }
    }
}