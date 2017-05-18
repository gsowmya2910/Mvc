// ----------------------------------------------------------------------
// <copyright file="ChangeInterpResultResponse.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.ResponseBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class ChangeInterpResultResponse : ResponseBase
    {
    }
}