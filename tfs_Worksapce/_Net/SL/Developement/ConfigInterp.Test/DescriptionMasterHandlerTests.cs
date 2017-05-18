// ----------------------------------------------------------------------
// <copyright file="DescriptionMasterHandlerTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Description;
    using Contracts.DataContracts;
    using CoreLink.DescriptionMaster.DA;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    /// <summary>
    /// The Object
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DescriptionMasterHandlerTests
    {
        /// <summary>
        /// Gets the category description test.
        /// </summary>
        [TestMethod]
        public void GetCategoryDescriptionTest()
        {
            var mockAccess = new MockDataAccess { RetrievedTestCode = "Value" };
            var dmh = new DescriptionMasterHandler
            {
                TestImplementation = mockAccess
            };

            var result = dmh.GetCategoryDescription(1, 1, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual(MockDataAccess.DescriptionTestValue, result.Value);
            Assert.AreEqual((int)DescriptionMasterHandler.DescriptionType.Category, mockAccess.Type);
            Assert.AreEqual("001001", mockAccess.SentCode);
        }

        /// <summary>
        /// Not the found test.
        /// </summary>
        [TestMethod]
        public void NotFoundTest()
        {
            var mockAccess = new MockDataAccess { TestRecord = new DescriptionMasterRecord() };
            var dmh = new DescriptionMasterHandler
            {
                TestImplementation = mockAccess
            };

            var result = dmh.GetCategoryDescription(1, 1, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.NotFound, result.Result);
            Assert.AreEqual((int)DescriptionMasterHandler.DescriptionType.Category, mockAccess.Type);
            Assert.AreEqual("001001", mockAccess.SentCode);
        }

        /// <summary>
        /// Tis the exception handled test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void TiExceptionHandledTest()
        {
            var mockAccess = new MockDataAccess { ThrowTiException = true };
            var dmh = new DescriptionMasterHandler
            {
                TestImplementation = mockAccess
            };

            var result = dmh.GetCategoryDescription(1, 1, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Failed, result.Result);
            Assert.IsNotNull(result.Exception);

            Assert.AreEqual((int)DescriptionMasterHandler.DescriptionType.Category, mockAccess.Type);
            Assert.AreEqual("001001", mockAccess.SentCode);
        }

        /// <summary>
        /// Gets the level description test.
        /// </summary>
        [TestMethod]
        public void GetLevelDescriptionTest()
        {
            var mockAccess = new MockDataAccess { RetrievedTestCode = "Value" };
            var dmh = new DescriptionMasterHandler
            {
                TestImplementation = mockAccess
            };

            var result = dmh.GetLevelDescription(1, 1, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual(MockDataAccess.DescriptionTestValue, result.Value);
            Assert.AreEqual((int)DescriptionMasterHandler.DescriptionType.Level, mockAccess.Type);
            Assert.AreEqual("001001", mockAccess.SentCode);
        }

        /// <summary>
        /// Gets the Outline description test.
        /// </summary>
        [TestMethod]
        public void GetOutlineDescriptionTest()
        {
            var mockAccess = new MockDataAccess { RetrievedTestCode = "Value" };
            var dmh = new DescriptionMasterHandler
            {
                TestImplementation = mockAccess
            };

            var result = dmh.GetOutlineDescription(1, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual(MockDataAccess.DescriptionTestValue, result.Value);
            Assert.AreEqual((int)DescriptionMasterHandler.DescriptionType.Outline, mockAccess.Type);
            Assert.AreEqual("001", mockAccess.SentCode);
        }

        /// <summary>
        /// Gets the sub category description test.
        /// </summary>
        [TestMethod]
        public void GetSubCategoryDescriptionTest()
        {
            var mockAccess = new MockDataAccess { RetrievedTestCode = "Value" };
            var dmh = new DescriptionMasterHandler
            {
                TestImplementation = mockAccess
            };

            var result = dmh.GetSubCategoryDescription(1, 1, 1, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual(MockDataAccess.DescriptionTestValue, result.Value);
            Assert.AreEqual((int)DescriptionMasterHandler.DescriptionType.SubCategory, mockAccess.Type);
            Assert.AreEqual("001001001", mockAccess.SentCode);
        }
    }
}