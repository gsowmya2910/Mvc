// ----------------------------------------------------------------------
// <copyright file="InterpStatus.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    /// <summary>
    /// The Enum
    /// </summary>
    public enum InterpStatus : short
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The draft
        /// </summary>
        Draft = 1,

        /// <summary>
        /// The draft revision
        /// </summary>
        DraftRevision = 3,

        /// <summary>
        /// The test
        /// </summary>
        Test = 5,

        /// <summary>
        /// The active
        /// </summary>
        Active = 10,

        /// <summary>
        /// The deactivated
        /// </summary>
        Deactivated = 20
    }
}