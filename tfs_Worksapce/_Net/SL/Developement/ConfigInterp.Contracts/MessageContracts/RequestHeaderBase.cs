// <copyright file="RequestHeaderBase.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;

    /// <summary>
    /// Base Request Class
    /// </summary>
    [MessageContract]
    public abstract class RequestHeaderBase
    {
        /// <summary>
        /// Gets or sets the UserId MessageHeader
        /// </summary>
        [MessageHeader(Namespace = ServiceNamespaces.ProfileTransport)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationId MessageHeader
        /// </summary>
        [MessageHeader(Namespace = ServiceNamespaces.ProfileTransport)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the Region MessageHeader
        /// </summary>
        [MessageHeader(Namespace = ServiceNamespaces.ProfileTransport)]
        public int Region { get; set; }

        /// <summary>
        /// Gets or sets the Unisys user code.
        /// </summary>
        /// <value>
        /// The Unisys user code.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Dev", MessageId = "Usercode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [MessageHeader(Namespace = ServiceNamespaces.ProfileTransport)]
        public string UnisysUsercode { get; set; }

        /// <summary>
        /// Gets or sets the correspondence location.
        /// </summary>
        /// <value>
        /// The correspondence location.
        /// </value>
        [MessageHeader(Namespace = ServiceNamespaces.ProfileTransport)]
        public string CorrespondenceLocation { get; set; }
    }
}