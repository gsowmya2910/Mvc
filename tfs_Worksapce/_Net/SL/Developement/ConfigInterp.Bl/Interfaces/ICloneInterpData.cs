// ----------------------------------------------------------------------
// <copyright file="ICloneInterpData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    using Contracts.DataContracts;

    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IRegion" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IMainFrameUsercode" />
    public interface ICloneInterpData : IRegion, ICloneInterp, IMainFrameUsercode
    {
        /// <summary>
        /// Gets or sets the blue user.
        /// </summary>
        /// <value>
        /// The blue user.
        /// </value>
        string BlueUser { get; set; }

        /// <summary>
        /// Gets or sets the current status
        /// </summary>
        /// <value>
        /// The current Status
        /// </value>
        InterpStatus CurrentStatus { get; set; }
    }
}