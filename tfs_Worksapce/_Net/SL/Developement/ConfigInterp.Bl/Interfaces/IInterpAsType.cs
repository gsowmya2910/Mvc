// ----------------------------------------------------------------------
// <copyright file="IInterpAsType.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    using Contracts.DataContracts;

    /// <summary>
    /// the interface
    /// </summary>
    public interface IInterpAsType : IInterpBase
    {
        /// <summary>
        /// Gets the type of the system.
        /// </summary>
        /// <value>
        /// The type of the system.
        /// </value>
        LineOfBusiness SystemType { get; }
    }
}