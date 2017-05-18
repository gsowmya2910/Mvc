// ----------------------------------------------------------------------
// <copyright file="FieldType.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    /// <summary>
    /// the enum
    /// </summary>
    public enum FieldType : short
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The fixed
        /// </summary>
        Fixed = 1,

        /// <summary>
        /// The line
        /// </summary>
        Line = 2,

        /// <summary>
        /// The other
        /// </summary>
        Other = 3,

        /// <summary>
        /// The calculated
        /// </summary>
        Calculated = 4,

        /// <summary>
        /// The key word
        /// </summary>
        KeyWord = 5,

        /// <summary>
        /// The limit
        /// </summary>
        Limit = 6,

        /// <summary>
        /// The current line accumulator
        /// </summary>
        CurrentLineAccumulator = 7,

        /// <summary>
        /// The accumulator
        /// </summary>
        Accumulator = 8
    }
}