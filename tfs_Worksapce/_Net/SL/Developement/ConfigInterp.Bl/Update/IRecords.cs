// ----------------------------------------------------------------------
// <copyright file="IRecords.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using Interfaces;

    /// <summary>
    /// the interface
    /// </summary>
    public interface IRecords
    {
        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        /// <value>
        /// The steps.
        /// </value>
        IStepDataMap[] Steps { get; set; }
    }
}