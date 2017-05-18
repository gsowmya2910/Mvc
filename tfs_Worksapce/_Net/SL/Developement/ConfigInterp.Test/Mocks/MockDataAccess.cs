// ----------------------------------------------------------------------
// <copyright file="MockDataAccess.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Mocks
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Interfaces;
    using CoreLink.DescriptionMaster.DA;
    using Microsoft.HostIntegration.TI;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="IDescriptionMasterDataAccess" />
    [ExcludeFromCodeCoverage]
    internal class MockDataAccess : IDescriptionMasterDataAccess
    {
        /// <summary>
        /// The description test value
        /// </summary>
        public const string DescriptionTestValue = "TestValue";

        /// <summary>
        /// Gets or sets the retrieved test code.
        /// </summary>
        /// <value>
        /// The retrieved test code.
        /// </value>
        public string RetrievedTestCode { get; set; }

        /// <summary>
        /// Gets the sent code.
        /// </summary>
        /// <value>
        /// The sent code.
        /// </value>
        public string SentCode { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether [throw ti exception].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [throw ti exception]; otherwise, <c>false</c>.
        /// </value>
        public bool ThrowTiException { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; private set; }

        /// <summary>
        /// Gets or sets the test record.
        /// </summary>
        /// <value>
        /// The test record.
        /// </value>
        public DescriptionMasterRecord TestRecord { get; set; }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="code">The code.</param>
        /// <returns>The Value</returns>
        /// <exception cref="CustomTIException">The Exception</exception>
        public DescriptionMasterRecord GetByCode(short type, string code)
        {
            this.Type = type;
            this.SentCode = code;
            if (this.ThrowTiException)
            {
                throw new CustomTIException();
            }

            return this.TestRecord ?? new DescriptionMasterRecord
            {
                DescriptionRest = DescriptionTestValue,
                Code = this.RetrievedTestCode
            };
        }
    }
}