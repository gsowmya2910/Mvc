// ----------------------------------------------------------------------
// <copyright file="UpdateInterpRequest.cs" company="CoreLink">
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
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.RequestHeaderBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class UpdateInterpRequest : RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]

        public UpdateInterpNarrativeData Data { get; set; }
    }
}