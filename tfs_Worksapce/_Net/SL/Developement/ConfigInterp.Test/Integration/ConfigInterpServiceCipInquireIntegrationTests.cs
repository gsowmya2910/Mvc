// ----------------------------------------------------------------------
// <copyright file="ConfigInterpServiceCipInquireIntegrationTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Integration
{
    using System.Diagnostics.CodeAnalysis;
    using Bl;
    using Bl.BenefitMatrix;
    using Bl.Inquire;
    using Contracts;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ServiceLibrary;

    /// <summary>
    /// the test class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConfigInterpServiceCipInquireIntegrationTests
    {
        /// <summary>
        /// The Unisys user
        /// </summary>
        private const string UnisysUser = "CL168236821";

        /// <summary>
        /// The blue user
        /// </summary>
        private const string BlueUser = "id16823";

        /// <summary>
        /// Gets the simple interp full stack test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [ExcludeFromCodeCoverage]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void GetInterpFullStackTest()
        {
            IConfigInterpService service = new ConfigInterpService(new Validation(), new CipInquireHandler(), null, null, null, null, null, new Converter(null));

            var inquireRequest = new InquireRequest
            {
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Region = 1,
                UnisysUsercode = UnisysUser,
                UserId = BlueUser,
                Data = new InquireInputData
                {
                    Outline = 86,
                    Category = 600,
                    SubCategory = 0,
                    AdmitInterp = 1,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = InterpStatus.Test
                }
            };
            var response = service.GetInterp(inquireRequest);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.IsNotNull(response.Data);
        }

        /// <summary>
        /// Gets the interp detail full stack test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [ExcludeFromCodeCoverage]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void GetInterpDetailFullStackTest()
        {
            IConfigInterpService service = new ConfigInterpService(new Validation(), new CipInquireHandler(), null, null, null, null, null, new Converter(new StepConverter()));

            var inquireRequest = new InquireRequest
            {
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Region = 1,
                UnisysUsercode = UnisysUser,
                UserId = BlueUser,
                Data = new InquireInputData
                {
                    Outline = 86,
                    Category = 600,
                    SubCategory = 0,
                    AdmitInterp = 1,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = InterpStatus.Test
                }
            };
            var response = service.GetInterpDetail(inquireRequest);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.IsNotNull(response.Data);
        }

        /// <summary>
        /// Gets the interp full stack not found not supposed to happen test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [ExcludeFromCodeCoverage]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void GetInterpFullStackNotFoundNotSupposedToHappenTest()
        {
            IConfigInterpService service = new ConfigInterpService(new Validation(), new CipInquireHandler(), null, null, null, null, null, new Converter(null));

            var inquireRequest = new InquireRequest
            {
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Region = 1,
                UnisysUsercode = UnisysUser,
                UserId = BlueUser,
                Data = new InquireInputData
                {
                    Outline = 34,
                    Category = 560,
                    SubCategory = 4,
                    AdmitInterp = 7,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = InterpStatus.Active
                }
            };
            var response = service.GetInterp(inquireRequest);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.IsNull(response.Data);
        }

        /// <summary>
        /// Updates the interp narrative full stack.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [ExcludeFromCodeCoverage]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpNarrativeFullStack()
        {
            IConfigInterpService service = new ConfigInterpService(new Validation(), null, null, null, new BenefitMatrixHandler(), null, null, new Converter(null));

            var request = new UpdateInterpRequest
            {
                Region = 1,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                UnisysUsercode = UnisysUser,
                UserId = BlueUser,
                Data = new UpdateInterpNarrativeData
                {
                    Outline = 34,
                    Category = 560,
                    SubCategory = 4,
                    AdmitInterp = 1,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.Maintenance,
                    NarrativeLines = new[]
                    {
                        "Test",
                        "Tami",
                        "will",
                        "be",
                        "angry",
                        "if",
                        "this",
                        "only",
                        "works",
                        "here"
                    }
                }
            };
            var response = service.UpdateInterpNarrative(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
        }
    }
}