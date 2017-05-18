// ----------------------------------------------------------------------
// <copyright file="IDeleteInterpIntialData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IRegion" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IMainFrameUsercode" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IInterpAsType" />
    public interface IDeleteInterpIntialData : IRegion, IMainFrameUsercode, IInterpAsType
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
        InterpStatus Status { get; set; }
    }
}