// ----------------------------------------------------------------------
// <copyright file="DeleteInterpNarrativeData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.InterpDataBase" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class DeleteInterpNarrativeData : InterpDataStatusBase
    {
    }
}