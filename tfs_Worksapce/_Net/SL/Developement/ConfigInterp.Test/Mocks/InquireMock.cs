// ----------------------------------------------------------------------
// <copyright file="InquireMock.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Mocks
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Interfaces;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.ICipInquireHandler" />
    [ExcludeFromCodeCoverage]
    internal class InquireMock : ICipInquireHandler
    {
        /// <summary>
        /// Gets or sets the detailed inquire result.
        /// </summary>
        /// <value>
        /// The detailed inquire result.
        /// </value>
        public IDetailedInquireResult DetailedInquireResult { get; set; }

        /// <summary>
        /// Gets or sets the inquire data result base.
        /// </summary>
        /// <value>
        /// The inquire data result base.
        /// </value>
        public ISimpleInquire InquireDataResultBase { get; set; }

        /// <summary>
        /// Inquires the detailed data.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The result
        /// </returns>
        public IDetailedInquireResult InquireInterpDetail(IInquireInput input)
        {
            return this.DetailedInquireResult;
        }

        /// <summary>
        /// Inquires the simple data.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The result
        /// </returns>
        public ISimpleInquire InquireSimpleData(IInquireInput input)
        {
            return this.InquireDataResultBase;
        }
    }
}