// ----------------------------------------------------------------------
// <copyright file="OperationResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    /// <summary>
    /// The enum
    /// </summary>
    public enum OperationResult
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The success
        /// </summary>
        Success = 1,

        /// <summary>
        /// The failed
        /// </summary>
        Failed = 2,

        /// <summary>
        /// The not found
        /// </summary>
        NotFound = 4,

        /// <summary>
        /// The interp not configurable
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        InterpNotConfigurable = 8,

        /// <summary>
        /// The already exists
        /// </summary>
        AlreadyExists = 16,

        /// <summary>
        /// The zero level doesn't exist
        /// </summary>
        ZeroLevelDoesNotExist = 32
    }
}