// ----------------------------------------------------------------------
// <copyright file="Status.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.DataContracts
{
    using System.ComponentModel;

    /// <summary>
    /// The enum
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The active
        /// </summary>
        [Description("A")]
        Active = 1,

        /// <summary>
        /// The maintenance
        /// </summary>
        [Description("M")]
        Maintenance = 2,

        /// <summary>
        /// The revision
        /// </summary>
        [Description("R")]
        Revision = 4,

        /// <summary>
        /// The prior
        /// </summary>
        [Description("P")]
        Prior = 8
    }
}