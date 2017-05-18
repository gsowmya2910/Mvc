// ----------------------------------------------------------------------
// <copyright file="DescriptionMasterIntegrationDataTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test.Integration
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Description;
    using Contracts.DataContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The Object
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DescriptionMasterIntegrationDataTests
    {
        /// <summary>
        /// The category
        /// </summary>
        private const short Category = 180;

        /// <summary>
        /// The level
        /// </summary>
        private const short Level = 23;

        /// <summary>
        /// The Outline
        /// </summary>
        private const short Outline = 34;

        /// <summary>
        /// The region
        /// </summary>
        private const short Region = 1;

        /// <summary>
        /// The sub category
        /// </summary>
        private const short SubCategory = 1;

        /// <summary>
        /// Checks the category data is real test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void CheckCategoryDataIsRealTest()
        {
            var dmh = new DescriptionMasterHandler();
            var result = dmh.GetCategoryDescription(Outline, Category, Region);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual("DIAGNOSTICS", result.Value);
        }

        /// <summary>
        /// Checks the level data is real test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void CheckLevelDataIsRealTest()
        {
            var dmh = new DescriptionMasterHandler();
            var result = dmh.GetLevelDescription(Outline, Level, Region);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual("PROFESSIONAL BENEFIT ADMINISTRATION (OPTION 4)", result.Value);
        }

        /// <summary>
        /// Checks the Outline data is real test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void CheckOutlineDataIsRealTest()
        {
            var dmh = new DescriptionMasterHandler();
            var result = dmh.GetOutlineDescription(Outline, Region);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual("CONTRACT BENEFITS (MEDICAL)", result.Value);
        }

        /// <summary>
        /// Checks the sub category data is real test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void CheckSubCategoryDataIsRealTest()
        {
            var dmh = new DescriptionMasterHandler();
            var result = dmh.GetSubCategoryDescription(Outline, Category, SubCategory, Region);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual("CATEGORY PAYMENT METHOD/MAXIMUM ALLOWANCE", result.Value);
        }
    }
}