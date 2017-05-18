// ----------------------------------------------------------------------
// <copyright file="IDeleteInfo.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using Interfaces;

    /// <summary>
    /// the interface
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IInterp" />
    /// <seealso cref="ConfigInterp.Bl.Update.IInterpKeyInfo" />
    public interface IDeleteInfo : IInterpAsType, IInterpKeyInfo, IRevisionInfo
    {
        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        int EmployeeNumber { get; set; }
    }
}