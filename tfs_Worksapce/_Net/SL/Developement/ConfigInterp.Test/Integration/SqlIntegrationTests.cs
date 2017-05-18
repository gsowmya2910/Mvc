// ----------------------------------------------------------------------
// <copyright file="SqlIntegrationTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test.Integration
{
    using System.Linq;
    using Contracts.DataContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sql;

    /// <summary>
    /// The SqlIntegrationTests class
    /// </summary>
    [TestClass]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
    public class SqlIntegrationTests
    {
        /// <summary>
        /// The GetActionDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetActionDescriptionTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetActionDescription(LineOfBusiness.Professional, 2);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetActionDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetActionDescriptionTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetActionDescription(LineOfBusiness.Professional, 2);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetActionParamDescAndValidationInfoTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetActionParamDescAndValidationInfoTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetActionParameterDescriptionAndValidationInfo(LineOfBusiness.Professional, 8);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetActionParamDescAndValidationInfoTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetActionParamDescAndValidationInfoTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetActionParameterDescriptionAndValidationInfo(LineOfBusiness.Professional, 8);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetActionTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetActionTypeDescriptionTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetActionTypeDescription(LineOfBusiness.Professional);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetActionTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetActionTypeDescriptionTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetActionTypeDescription(LineOfBusiness.Professional);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetAvailableOutlineCategoryTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetAvailableOutlineCategoryTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.AvailableOutlineCategory(LineOfBusiness.Professional, 34, 1);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetAvailableOutlineCategoryTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetAvailableOutlineCategoryTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.AvailableOutlineCategory(LineOfBusiness.Professional, 34, 1);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetCompareTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetCompareTypeDescriptionTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetCompareTypeDescription(LineOfBusiness.Professional, 1);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetCompareTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetCompareTypeDescriptionTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetCompareTypeDescription(LineOfBusiness.Professional, 1);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetConditionTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetConditionTypeDescriptionTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetConditionTypeDescription();
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetConditionTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetConditionTypeDescriptionTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetConditionTypeDescription();
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetExceptionDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetExceptionDescriptionTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetExceptionDescription(LineOfBusiness.Professional);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetExceptionDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetExceptionDescriptionTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetExceptionDescription(LineOfBusiness.Professional);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldNameDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldNameDescriptionInCipTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetFieldNameDescription(LineOfBusiness.Professional, 4);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldNameDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldNameDescriptionInCipTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetFieldNameDescription(LineOfBusiness.Professional, 4);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldNameDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldNameDescriptionInCommonTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetFieldNameDescription(LineOfBusiness.Professional, 5);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldNameDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldNameDescriptionInCommonTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetFieldNameDescription(LineOfBusiness.Professional, 5);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldTypeDescriptionTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetFieldTypeDescription(LineOfBusiness.Professional);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldTypeDescriptionTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldTypeDescriptionTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());
            var result = handler.GetFieldTypeDescription(LineOfBusiness.Professional);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldValidationInfoTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldValidationInfoTest()
        {
            var handler = new ConfigInterpSqlHandler(new DirectSqlServerDataAccess());
            var result = handler.GetFieldValidationInfo(LineOfBusiness.Professional, 2, 186);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }

        /// <summary>
        /// The GetFieldValidationInfoTest method
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldValidationInfoTest2()
        {
            var handler = new ConfigInterpSqlHandler(new EntityFrameworkDataAccess());

            var result = handler.GetFieldValidationInfo(LineOfBusiness.Professional, 2, 186);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Any());
        }
    }
}