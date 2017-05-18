// ----------------------------------------------------------------------
// <copyright file="ICipInquireHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    /// <summary>
    /// The Interface
    /// </summary>
    public interface ICipInquireHandler
    {
        /// <summary>
        /// Inquires the simple data.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The result</returns>
        ISimpleInquire InquireSimpleData(IInquireInput input);

        /// <summary>
        /// Inquires the detailed data.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The result</returns>
        IDetailedInquireResult InquireInterpDetail(IInquireInput input);
    }
}