// ----------------------------------------------------------------------
// <copyright file="ITiCipInquire.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Interfaces
{
    using CIPINQ01;

    /// <summary>
    /// The Interface
    /// </summary>
    internal interface ITiCipInquire
    {
        /// <summary>
        /// Inquires the interp detail.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="inputCommon">The input common.</param>
        /// <param name="headerOut">The header out.</param>
        /// <param name="keyInfoOut">The key information out.</param>
        /// <param name="tableOccurs">The table occurs</param>
        /// <param name="dataMapsOut">The data maps out.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        void InquireInterpsDetail(InputHeader inputHeader, InputCommon inputCommon, out HeaderOut headerOut, out KeyInfoOut keyInfoOut, out short tableOccurs, out DataMapsOut[] dataMapsOut);

        /// <summary>
        /// Inquires the interp data.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="inputCommon">The input common.</param>
        /// <param name="headerOut">The header out.</param>
        /// <param name="keyInfoOut">The key information out.</param>
        /// <param name="tableOccurs">The table occurs</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        void InquireInterpsData(InputHeader inputHeader, InputCommon inputCommon, out HeaderOut headerOut, out KeyInfoOut keyInfoOut, out short tableOccurs);
    }
}