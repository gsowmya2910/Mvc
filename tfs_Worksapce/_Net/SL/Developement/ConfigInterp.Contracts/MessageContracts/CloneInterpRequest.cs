// ----------------------------------------------------------------------
// <copyright file="CloneInterpRequest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// gets or sets the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.RequestHeaderBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class CloneInterpRequest : RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public CloneInterpNarrativeData Source { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public InterpStatus CurrentStatus { get; set; }

        /// <summary>
        /// Gets or sets the data
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public CloneInterpNarrativeData Target { get; set; }

        /// <summary>
        /// Gets or sets the line of business.
        /// </summary>
        /// <value>
        /// The line of business.
        /// </value>
        [MessageBodyMember]
        public LineOfBusiness LineOfBusiness { get; set; }
    }
}