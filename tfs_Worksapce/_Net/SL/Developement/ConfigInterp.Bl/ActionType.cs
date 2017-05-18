// ----------------------------------------------------------------------
// <copyright file="ActionType.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    /// <summary>
    /// the enum
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// The not applicable
        /// </summary>
        NotApplicable = -1,

        /// <summary>
        /// The unconditional
        /// </summary>
        Unconditional = 0,

        /// <summary>
        /// The conditional
        /// </summary>
        ConditionalTrue = 1,

        /// <summary>
        /// The conditional
        /// </summary>
        ConditionalFalse = 2
    }
}