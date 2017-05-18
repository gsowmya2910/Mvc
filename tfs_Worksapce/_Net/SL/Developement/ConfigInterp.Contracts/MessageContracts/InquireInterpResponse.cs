// ----------------------------------------------------------------------
// <copyright file="InquireInterpResponse.cs" company="CoreLink">
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
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.ResponseBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class InquireInterpResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public InquireNarrativeOutputData Data { get; set; }
    }
}