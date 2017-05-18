// ----------------------------------------------------------------------
// <copyright file="RecordValueType.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    /// <summary>
    /// the enum
    /// </summary>
    public enum RecordValueType : short
    {
        /// <summary>
        /// The not applicable
        /// </summary>
        NotApplicable = 0,

        /// <summary>
        /// The alpha
        /// </summary>
        Alpha = 1,

        /// <summary>
        /// The numeric
        /// </summary>
        Numeric = 2,

        /// <summary>
        /// The decimal
        /// </summary>
        Decimal = 3
    }
}