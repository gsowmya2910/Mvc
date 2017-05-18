// ----------------------------------------------------------------------
// <copyright file="InterpNarrativeResponseBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.ResponseBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public abstract class InterpNarrativeResponseBase : ResponseBase
    {
        /// <summary>
        /// Gets or sets the message number.
        /// </summary>
        /// <value> The message number.
        /// </value>
        [MessageBodyMember]

        public string MessageNumber { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        [MessageBodyMember]
        public string MessageText { get; set; }
    }
}