// ----------------------------------------------------------------------
// <copyright file="IInterp.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    /// <summary>
    /// the interface
    /// </summary>
    public interface IInterp : IInterpBase
    {
        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        short Level { get; }
    }
}