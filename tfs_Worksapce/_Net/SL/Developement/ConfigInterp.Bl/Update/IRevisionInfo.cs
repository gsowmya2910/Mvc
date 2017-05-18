// ----------------------------------------------------------------------
// <copyright file="IRevisionInfo.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IRegion" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IMainFrameUsercode" />
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IInterpAsType" />
    public interface IRevisionInfo
    {
        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        short CreateByRevision { get; set; }

        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        short RevisionNumber { get; }

        /// <summary>
        /// Gets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        short RevisionSequence { get; }
    }
}