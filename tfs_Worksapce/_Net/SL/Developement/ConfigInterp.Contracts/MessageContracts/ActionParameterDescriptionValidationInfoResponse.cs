// ----------------------------------------------------------------------
// <copyright file="ActionParameterDescriptionValidationInfoResponse.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.MessageContracts
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// The Object
    /// </summary>
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class ActionParameterDescriptionValidationInfoResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public List<ActionParameterDescriptionValidationInfoData> Data { get; set; }
    }
}