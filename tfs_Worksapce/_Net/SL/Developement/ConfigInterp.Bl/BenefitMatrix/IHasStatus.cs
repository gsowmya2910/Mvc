// ----------------------------------------------------------------------
// <copyright file="IHasStatus.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.BenefitMatrix
{
    using Contracts.DataContracts;

    /// <summary>
    /// the interface
    /// </summary>
    public interface IHasStatus
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        Status Status { get; set; }
    }
}