// ----------------------------------------------------------------------
// <copyright file="ClientContextMapper.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    using CoreLinkAdmin.Common.Utility.CommonUtility;
    using Microsoft.HostIntegration.TI;

    /// <summary>
    /// The Object
    /// </summary>
    internal static class ClientContextMapper
    {
        /// <summary>
        /// Meta the data.
        /// </summary>
        /// <param name="regionCode">The region code.</param>
        /// <returns>The result</returns>
        internal static ClientContext MetaData(int regionCode)
        {
            return new ClientContext
            {
                RemoteEnvironment = RemoteEnvironment.GetEnvName(regionCode, 2)
            };
        }
    }
}