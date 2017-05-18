// ----------------------------------------------------------------------
// <copyright file="ConditionOperation.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    /// <summary>
    /// the enum
    /// </summary>
    public enum ConditionOperation : short
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// the If
        /// </summary>
        If = 1,

        /// <summary>
        /// The and if
        /// </summary>
        AndIf = 2,

        /// <summary>
        /// The or if
        /// </summary>
        OrIf = 3
    }
}