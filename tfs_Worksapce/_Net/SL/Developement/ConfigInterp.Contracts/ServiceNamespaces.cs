//------------------------------------------------------------------------------
// <copyright file="ServiceNamespaces.cs" company="CoreLinkAdmin">
//     Copyright © CoreLinkAdmin 2011. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
namespace ConfigInterp.Contracts
{
    /// <summary>
    /// uri namespaces
    /// </summary>
    public static class ServiceNamespaces
    {
        /// <summary>
        /// The core messages
        /// </summary>
        public const string CoreMessages = "http://schemas.corelinksolutions.com/infrastructure/schema/coremessages/v1";

        /// <summary>
        /// Sets the schema url for version one of grace period
        /// </summary>
        public const string DataContracts = "http://schemas.corelinksolutions.com/product/schema/configinterp";

        /// <summary>
        /// The profile transport
        /// </summary>
        public const string ProfileTransport = "http://corelink.com/v1.0.0/profiletransport";

        /// <summary>
        /// Sets the schema url for version one of the grace period service
        /// </summary>
        public const string ServiceContracts = "http://schemas.corelinksolutions.com/product/contract/configinterp/service";

        /// <summary>
        /// Sets the schema url for version one of grace period messages
        /// </summary>
        public const string ServiceMessages = "http://schemas.corelinksolutions.com/infrastructure/schema/coremessages/v1";
    }
}