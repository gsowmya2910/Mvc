// ----------------------------------------------------------------------
// <copyright file="SimpleInquireResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Inquire
{
    using CIPINQ01;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="InquireDataResultBase" />
    internal class SimpleInquireResult : InquireDataResultBase, ISimpleInquire
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleInquireResult"/> class.
        /// </summary>
        /// <param name="keyInfo">The key information.</param>
        public SimpleInquireResult(KeyInfoOut keyInfo)
            : base(keyInfo)
        {
        }
    }
}