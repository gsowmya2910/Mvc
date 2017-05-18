﻿// ----------------------------------------------------------------------
// <copyright file="SimpleInterpResponse.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.MessageContracts
{
    using System.ServiceModel;
    using DataContracts;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.MessageContracts.ResponseBase" />
    [MessageContract(WrapperNamespace = ServiceNamespaces.ServiceContracts)]
    public class SimpleInterpResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [MessageBodyMember]
        public InquireSimpleOutputData Data { get; set; }
    }
}