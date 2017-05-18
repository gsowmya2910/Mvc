// ----------------------------------------------------------------------
// <copyright file="MockInquire.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Mocks
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Interfaces;
    using CIPINQ01;
    using Microsoft.HostIntegration.TI;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.ITiCipInquire" />
    [ExcludeFromCodeCoverage]
    internal class MockInquire : ITiCipInquire
    {
        /// <summary>
        /// Gets or sets the data maps out.
        /// </summary>
        /// <value>
        /// The data maps out.
        /// </value>
        public DataMapsOut[] DataMapsOut { private get; set; }

        /// <summary>
        /// Gets or sets the header out.
        /// </summary>
        /// <value>
        /// The header out.
        /// </value>
        public HeaderOut HeaderOut { private get; set; }

        /// <summary>
        /// Gets the input common.
        /// </summary>
        /// <value>
        /// The input common.
        /// </value>
        public InputCommon InputCommon { get; private set; }

        /// <summary>
        /// Gets the input header.
        /// </summary>
        /// <value>
        /// The input header.
        /// </value>
        public InputHeader InputHeader { get; private set; }

        /// <summary>
        /// Gets or sets the key information out.
        /// </summary>
        /// <value>
        /// The key information out.
        /// </value>
        public KeyInfoOut KeyInfoOut { private get; set; }

        /// <summary>
        /// Gets or sets the table occurs.
        /// </summary>
        /// <value>
        /// The table occurs.
        /// </value>
        public short TableOccurs { private get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [throw ti exception].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [throw ti exception]; otherwise, <c>false</c>.
        /// </value>
        public bool ThrowTiException { private get; set; }

        /// <summary>
        /// Inquires the interp data.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="inputCommon">The input common.</param>
        /// <param name="headerOut">The header out.</param>
        /// <param name="keyInfoOut">The key information out.</param>
        /// <param name="tableOccurs">The table occurs</param>
        /// <exception cref="CustomTIException">Fake exception</exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpsData(InputHeader inputHeader, InputCommon inputCommon, out HeaderOut headerOut, out KeyInfoOut keyInfoOut, out short tableOccurs)
        {
            this.InputHeader = inputHeader;
            this.InputCommon = inputCommon;
            if (this.ThrowTiException)
            {
                throw new CustomTIException();
            }

            headerOut = this.HeaderOut;
            keyInfoOut = this.KeyInfoOut;
            tableOccurs = this.TableOccurs;
        }

        /// <summary>
        /// Inquires the interp detail.
        /// </summary>
        /// <param name="inputHeader">The input header.</param>
        /// <param name="inputCommon">The input common.</param>
        /// <param name="headerOut">The header out.</param>
        /// <param name="keyInfoOut">The key information out.</param>
        /// <param name="tableOccurs">The table occurs</param>
        /// <param name="dataMapsOut">The data maps out.</param>
        /// <exception cref="CustomTIException">Fake exception</exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpsDetail(InputHeader inputHeader, InputCommon inputCommon, out HeaderOut headerOut, out KeyInfoOut keyInfoOut, out short tableOccurs, out DataMapsOut[] dataMapsOut)
        {
            this.InputHeader = inputHeader;
            this.InputCommon = inputCommon;
            if (this.ThrowTiException)
            {
                throw new CustomTIException();
            }

            headerOut = this.HeaderOut;
            keyInfoOut = this.KeyInfoOut;
            tableOccurs = this.TableOccurs;
            dataMapsOut = this.DataMapsOut;
        }
    }
}