// ----------------------------------------------------------------------
// <copyright file="SubCategoryRequest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.RequestHeaderBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class SubCategoryRequest : RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public SubCategoryData Data { get; set; }
    }
}