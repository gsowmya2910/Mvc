// ----------------------------------------------------------------------
// <copyright file="DefaultRequest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;

    /// <summary>
    /// The default request
    /// </summary>[MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class DefaultRequest : RequestHeaderBase
    {
    }
}