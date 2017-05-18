// ----------------------------------------------------------------------
// <copyright file="ConverterTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Bl;
    using Bl.Inquire;
    using CIPINQ01;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConverterTests
    {
        /// <summary>
        /// Converts the test.
        /// </summary>
        [TestMethod]
        public void ConvertInquireRequestTest()
        {
            var inquireRequest = new InquireRequest
            {
                Region = 1,
                Data = new InquireInputData
                {
                    AdmitInterp = 1,
                    Category = 1,
                    LineOfBusiness = LineOfBusiness.Institutional,
                    Outline = 1,
                    SubCategory = 1,
                    Status = InterpStatus.Active
                },
                UnisysUsercode = "user",
                ApplicationId = "application",
                CorrespondenceLocation = "1",
                UserId = "user"
            };

            var result = new Converter(null).Convert(inquireRequest);

            Assert.AreEqual(1, result.AdmitInterp);
            Assert.AreEqual(1, result.Category);
            Assert.AreEqual("user", result.MainFrameUsercode);
            Assert.AreEqual(1, result.Outline);
            Assert.AreEqual(1, result.Region);
            Assert.AreEqual(InterpStatus.Active, result.Status);
            Assert.AreEqual(1, result.SubCategory);
            Assert.AreEqual(LineOfBusiness.Institutional, result.SystemType);
        }

        /// <summary>
        /// Inquires the base does not have date.
        /// </summary>
        [TestMethod]
        public void InquireBaseDoesNotHaveDate()
        {
            var target = new InquireSimpleOutputData();
            var source = new MockDataBase();

            Converter.SetInquireBase(target, source);

            Assert.IsFalse(target.LastEdited.HasValue);
        }

        /// <summary>
        /// Inquires the base has date test.
        /// </summary>
        [TestMethod]
        public void InquireBaseHasDateTest()
        {
            var keyInfo = new KeyInfoOut
            {
                AdmitIntp = 1,
                Category = 1,
                Comment = "comment",
                CurrentStatus = 0,
                EmployeeNum = 1,
                EmployeeRegion = 0,
                Level = 1,
                OutLine = 1,
                RevisonSequence = 1,
                StatusDate = 20160930,
                StatusTime = 081635,
                SubCategory = 1,
                SystemType = 0
            };
            var inquire = new SimpleInquireResult(keyInfo)
            {
                MessageNumber = 1,
                MessageText = "Text"
            };
            var result = new Converter(null).Perform(inquire);

            Assert.AreEqual(1, result.SubCategory);
            Assert.AreEqual(1, result.Outline);
            Assert.AreEqual(1, result.Category);
            Assert.AreEqual(LineOfBusiness.None, result.LineOfBusiness);
            Assert.AreEqual(1, result.AdmitInterp);
            Assert.AreEqual(1, result.Level);
            Assert.AreEqual("comment", result.Comment);
            Assert.AreEqual(Plan.None, result.EmployeeRegion);
            Assert.AreEqual(InterpStatus.None, result.CurrentStatus);
            Assert.AreEqual(1, result.EmployeeNumber);
            Assert.AreEqual(new DateTime(2016, 9, 30, 8, 16, 35), result.LastEdited);
        }

        /// <summary>
        /// Inquires the base no date test.
        /// </summary>
        [TestMethod]
        public void InquireBaseNoDateTest()
        {
            var keyInfo = new KeyInfoOut
            {
                AdmitIntp = 1,
                Category = 1,
                Comment = "comment",
                CurrentStatus = 0,
                EmployeeNum = 1,
                EmployeeRegion = 0,
                Level = 1,
                OutLine = 1,
                RevisonSequence = 1,
                StatusDate = 1,
                StatusTime = 1,
                SubCategory = 1,
                SystemType = 0
            };
            var inquire = new SimpleInquireResult(keyInfo)
            {
                MessageNumber = 1,
                MessageText = "Text"
            };
            var result = new Converter(null).Perform(inquire);

            Assert.AreEqual(1, result.SubCategory);
            Assert.AreEqual(1, result.Outline);
            Assert.AreEqual(1, result.Category);
            Assert.AreEqual(LineOfBusiness.None, result.LineOfBusiness);
            Assert.AreEqual(1, result.AdmitInterp);
            Assert.AreEqual(1, result.Level);
            Assert.AreEqual("comment", result.Comment);
            Assert.AreEqual(Plan.None, result.EmployeeRegion);
            Assert.AreEqual(InterpStatus.None, result.CurrentStatus);
            Assert.AreEqual(1, result.EmployeeNumber);
            Assert.AreEqual(null, result.LastEdited);
        }
    }
}