// ----------------------------------------------------------------------
// <copyright file="InterpNarrativeSerivceTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test.Deployed
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ResearchService;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InterpNarrativeSerivceTests
    {
        /// <summary>
        /// The application identifier
        /// </summary>
        private const string ApplicationId = "CipTest";

        /// <summary>
        /// The blue user
        /// </summary>
        private const string BlueUser = "id16823";

        /// <summary>
        /// The category
        /// </summary>
        private const short Category = 180;

        /// <summary>
        /// The interp value
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        private const short InterpValue = 14;

        /// <summary>
        /// The location
        /// </summary>
        private const string Location = "cl";

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
        /// The Unisys user
        /// </summary>
        private const string UnisysUser = "CL168236821";

        /// <summary>
        /// Inquires the interp narrative test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpNarrativeTest()
        {
            var narrativeData = new InquireInterpNarrativeData
            {
                Category = Category,
                SubCategory = SubCategory,
                LineOfBusiness = LineOfBusiness.Professional,
                Outline = Outline,
                AdmitInterp = InterpValue
            };

            //// ReSharper disable TooWideLocalVariableScope
            ErrorItem[] errors;
            //// ReSharper restore TooWideLocalVariableScope

            ResponseStatus status;
            InquireNarrativeOutputData result;

            using (var client = new ConfigInterpServiceClient())
            {
                OperationResult reason;
                result = client.InquireInterpNarrative(ApplicationId, Location, Region, UnisysUser, BlueUser, narrativeData, out errors, out reason, out status);
            }

            Assert.IsNotNull(result);
            Assert.AreEqual(ResponseStatus.Success, status);
        }

        /// <summary>
        /// Updates the narrative test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void UpdateNarrativeTest()
        {
            ResponseStatus status;
            ErrorItem[] errors;
            var data = new UpdateInterpNarrativeData
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
                    "angrier bb                                                                                                                                                                                                           ",
                    "if",
                    "this",
                    "only",
                    "works",
                    "here"
                }
            };
            using (var client = new ConfigInterpServiceClient())
            {
                OperationResult reason;
                errors = client.UpdateInterpNarrative(
                    ApplicationId, 
                    Location, 
                    Region, 
                    UnisysUser, 
                    BlueUser,
                    data, 
                    out reason,
                    out status);
            }

            Assert.AreEqual(ResponseStatus.Success, status);
            Assert.IsNotNull(errors);
        }
    }
}