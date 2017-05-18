// ----------------------------------------------------------------------
// <copyright file="ICloneInterp.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    using ConfigInterp.Contracts.DataContracts;

    /// <summary>
    /// the interface
    /// </summary>
    public interface ICloneInterp
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// the source.
        /// </value>
        IInterpBaseType Source { get; }

        /// <summary>
        /// Gets the target
        /// </summary>
        /// <value>
        /// the target
        /// </value>
        IInterpBaseType Target { get; }

        /// <summary>
        /// Gets the type of the system.
        /// </summary>
        /// <value>
        /// The type of the system.
        /// </value>
        LineOfBusiness SystemType { get; }
    }
}