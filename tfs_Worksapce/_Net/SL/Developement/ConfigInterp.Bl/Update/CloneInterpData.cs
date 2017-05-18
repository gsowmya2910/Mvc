// ----------------------------------------------------------------------
// <copyright file="CloneInterpData.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using ConfigInterp.Bl.Interfaces;
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Update.IStatusChange" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Dev", MessageId = "Interp")]
    public class CloneInterpData : ICloneInterpData
    {
        /// <summary>
        /// Gets or sets the main frame user code.
        /// </summary>
        /// <value>
        /// The user code.
        /// </value>
        public string MainFrameUsercode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public short Region
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public IInterpBaseType Source
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the system.
        /// </summary>
        /// <value>
        /// The system.
        /// </value>
        public LineOfBusiness SystemType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public IInterpBaseType Target
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the blue user.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public string BlueUser
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public InterpStatus CurrentStatus
        {
            get;
            set;
        }
    }
}