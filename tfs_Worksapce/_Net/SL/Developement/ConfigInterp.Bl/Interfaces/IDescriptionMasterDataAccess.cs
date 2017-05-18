// ----------------------------------------------------------------------
// <copyright file="IDescriptionMasterDataAccess.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Interfaces
{
    using CoreLink.DescriptionMaster.DA;

    /// <summary>
    /// The Interface
    /// </summary>
    public interface IDescriptionMasterDataAccess
    {
        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="code">The code.</param>
        /// <returns>The Value</returns>
        DescriptionMasterRecord GetByCode(short type, string code);
    }
}