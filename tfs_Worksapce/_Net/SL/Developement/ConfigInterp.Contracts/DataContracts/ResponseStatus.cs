// ----------------------------------------------------------------------
// <copyright file="ResponseStatus.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    /// <summary>
    /// ResponseStatus enum
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The failure
        /// </summary>
        Failure = 4,

        /// <summary>
        /// The success
        /// </summary>
        Success = 1,

        /// <summary>
        /// The rejected
        /// </summary>
        Rejected = 2
    }
}