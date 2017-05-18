// ----------------------------------------------------------------------
// <copyright file="CipInquireTiWrapper.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Inquire
{
    using System.Diagnostics.CodeAnalysis;
    using CIPINQ01;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="ITiCipInquire" />
    [ExcludeFromCodeCoverage]
    internal class CipInquireTiWrapper : ITiCipInquire
    {
        /// <summary>
        /// The region
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly short _region;

        /// <summary>
        /// Initializes a new instance of the <see cref="CipInquireTiWrapper"/> class.
        /// </summary>
        /// <param name="region">The region.</param>
        public CipInquireTiWrapper(short region)
        {
            this._region = region;
            this.Implementation = new CIPINQ();
        }

        /// <summary>
        /// Gets or sets the implementation.
        /// </summary>
        /// <value>
        /// The implementation.
        /// </value>
        private ICIPINQ Implementation { get; set; }

        /// <summary>
        /// Inquires the interp data.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="inputCommon">The input common.</param>
        /// <param name="headerOut">The header out.</param>
        /// <param name="keyInfoOut">The key information out.</param>
        /// <param name="tableOccurs">The table occurs</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpsData(InputHeader inputHeader, InputCommon inputCommon, out HeaderOut headerOut, out KeyInfoOut keyInfoOut, out short tableOccurs)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.InquireInterpsData(inputHeader, inputCommon, out headerOut, out keyInfoOut, out tableOccurs, ref context);
        }

        /// <summary>
        /// Inquires the interp detail.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="inputCommon">The input common.</param>
        /// <param name="headerOut">The header out.</param>
        /// <param name="keyInfoOut">The hey information out.</param>
        /// <param name="tableOccurs">The table occurs</param>
        /// <param name="dataMapsOut">The data maps out.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpsDetail(InputHeader inputHeader, InputCommon inputCommon, out HeaderOut headerOut, out KeyInfoOut keyInfoOut, out short tableOccurs, out DataMapsOut[] dataMapsOut)
        {
            var context = ClientContextMapper.MetaData(this._region);
            this.Implementation.InquireInterpsDetail(inputHeader, inputCommon, out headerOut, out keyInfoOut, out tableOccurs, out dataMapsOut, ref context);
        }
    }
}