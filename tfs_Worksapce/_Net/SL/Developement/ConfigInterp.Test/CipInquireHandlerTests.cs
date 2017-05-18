// ----------------------------------------------------------------------
// <copyright file="CipInquireHandlerTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Bl.Inquire;
    using Bl.Interfaces;
    using CIPINQ01;
    using Contracts.DataContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CipInquireHandlerTests
    {
        /// <summary>
        /// Inquires the interp detail throw exception test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpDetailThrowExceptionTest()
        {
            var input = new InquireInput
            {
                AdmitInterp = 1,
                SubCategory = 1,
                Category = 1,
                Outline = 1,
                Status = InterpStatus.Deactivated,
                SystemType = LineOfBusiness.Institutional,
                Region = 1,
                MainFrameUsercode = "user"
            };
            var mockInquire = new MockInquire { ThrowTiException = true };
            var handle = new CipInquireHandler { Implementation = mockInquire };
            var result = handle.InquireInterpDetail(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Failed, result.Result);
            Assert.IsNotNull(result.Exception);
            var properties = typeof(IDetailedInquireResult).GetProperties(
                 BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var property in properties)
            {
                property.GetValue(result, null);
            }
        }

        /// <summary>
        /// Inquires the interp detail valid data test.
        /// </summary>
        [TestMethod]
        [Ignore]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpDetailValidDataTest()
        {
            var input = new InquireInput
            {
                AdmitInterp = 1,
                SubCategory = 1,
                Category = 1,
                Outline = 1,
                Status = InterpStatus.Deactivated,
                SystemType = LineOfBusiness.Institutional,
                Region = 1,
                MainFrameUsercode = "user"
            };
            var mockInquire = new MockInquire
            {
                HeaderOut = new HeaderOut
                {
                    MessageNumber = 1,
                    MessageText = "Text"
                },
                KeyInfoOut = new KeyInfoOut
                {
                    AdmitIntp = 1,
                    Category = 1,
                    Comment = "comment",
                    CreateByRevision = 1,
                    CurrentStatus = 1,
                    EmployeeNum = 1,
                    EmployeeRegion = 1,
                    Level = 1,
                    OutLine = 1,
                    RevisonNumber = 1,
                    RevisonSequence = 1,
                    ////StatusDate = 20160930,
                    ////StatusTime = 151515,
                    StatusDate = 1,
                    StatusTime = 1,
                    StepCount = 1,
                    SubCategory = 1,
                    SystemType = 1
                },
                TableOccurs = 1,
                DataMapsOut = new[] { new DataMapsOut() }
            };
            var handle = new CipInquireHandler { Implementation = mockInquire };
            var result = handle.InquireInterpDetail(input);
            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNotNull(result.StepData);
            Assert.AreEqual(1, result.StepData.Length);
        }

        /// <summary>
        /// Inquires the simple data throw exception test.
        /// </summary>
        [TestMethod]
        public void InquireSimpleDataThrowExceptionTest()
        {
            var input = new InquireInput
            {
                AdmitInterp = 1,
                SubCategory = 1,
                Category = 1,
                Outline = 1,
                Status = InterpStatus.Deactivated,
                SystemType = LineOfBusiness.Institutional,
                Region = 1,
                MainFrameUsercode = "user"
            };
            var mockInquire = new MockInquire { ThrowTiException = true };
            var handle = new CipInquireHandler { Implementation = mockInquire };
            var result = handle.InquireSimpleData(input);

            Assert.IsNotNull(result);
            var properties = typeof(ISimpleInquire).GetProperties(
                 BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var property in properties)
            {
                property.GetValue(result, null);
            }

            Assert.AreEqual(OperationResult.Failed, result.Result);
            Assert.IsNotNull(result.Exception);
        }

        /// <summary>
        /// Inquires the simple data valid data test.
        /// </summary>
        [TestMethod]
        [Ignore]
        public void InquireSimpleDataValidDataTest()
        {
            var mockInquire = new MockInquire
            {
                HeaderOut = new HeaderOut
                {
                    MessageNumber = 1,
                    MessageText = "Text"
                },
                KeyInfoOut = new KeyInfoOut
                {
                    AdmitIntp = 1,
                    Category = 1,
                    Comment = "comment",
                    CreateByRevision = 1,
                    CurrentStatus = 1,
                    EmployeeNum = 1,
                    EmployeeRegion = 1,
                    Level = 1,
                    OutLine = 1,
                    RevisonNumber = 1,
                    RevisonSequence = 1,
                    StatusDate = 20160930,
                    StatusTime = 151515,
                    StepCount = 1,
                    SubCategory = 1,
                    SystemType = 1
                }
            };
            var handle = new CipInquireHandler { Implementation = mockInquire };
            var input = new InquireInput
            {
                AdmitInterp = 1,
                SubCategory = 1,
                Category = 1,
                Outline = 1,
                Status = InterpStatus.Deactivated,
                SystemType = LineOfBusiness.Institutional,
                Region = 1,
                MainFrameUsercode = "user"
            };

            var result = handle.InquireSimpleData(input);

            Assert.IsNotNull(result);
            var properties = typeof(ISimpleInquire).GetProperties(
                 BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var property in properties)
            {
                property.GetValue(result, null);
            }

            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual(new DateTime(2016, 9, 30, 15, 15, 15), result.StatusDateTime);
        }
    }
}