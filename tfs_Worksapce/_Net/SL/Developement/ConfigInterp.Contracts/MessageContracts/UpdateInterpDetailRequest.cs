// ----------------------------------------------------------------------
// <copyright file="UpdateInterpDetailRequest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.ResponseBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class UpdateInterpDetailRequest : RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public InterpDetailData Data { get; set; }
    }
}