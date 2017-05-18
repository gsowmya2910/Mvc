// ----------------------------------------------------------------------
// <copyright file="ResponseBase.cs" company="CoreLink">
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
    public abstract class ResponseBase
    {
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        [MessageBodyMember]
        public List<ErrorItem> Errors { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [MessageBodyMember]
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the failure reason.
        /// </summary>
        /// <value>
        /// The failure reason.
        /// </value>
        [MessageBodyMember]
        public OperationResult FailureReason { get; set; }
    }
}