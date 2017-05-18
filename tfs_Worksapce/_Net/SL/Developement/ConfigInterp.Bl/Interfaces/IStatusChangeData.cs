// ----------------------------------------------------------------------
// <copyright file="IStatusChangeData.cs" company="CoreLink">
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
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IInterpAsType" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IMainFrameUsercode" />
    public interface IStatusChangeData : IRegion, IInterpAsType, IMainFrameUsercode
    {
        /// <summary>
        /// Gets or sets the blue user.
        /// </summary>
        /// <value>
        /// The blue user.
        /// </value>
        string BlueUser { get; set; }

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        InterpStatus CurrentStatus { get; set; }

        /// <summary>
        /// Gets or sets the target status.
        /// </summary>
        /// <value>
        /// The target status.
        /// </value>
        InterpStatus TargetStatus { get; set; }
    }
}