// ----------------------------------------------------------------------
// <copyright file="DescriptionServiceTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test.Deployed
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ServiceModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ResearchService;

    /// <summary>
    /// The Object
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DescriptionServiceTests
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
        /// Gets the category description from the live service
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetCategoryDescription()
        {
            var categoryData = new CategoryData
            {
                Category = Category,
                Outline = Outline
            };
            ErrorItem[] errors;
            ResponseStatus status;
            string value;

            using (var client = new ConfigInterpServiceClient())
            {
                try
                {
                    OperationResult reason;

                    value = client.GetCategoryDescription(ApplicationId, Location, Region, UnisysUser, BlueUser, categoryData, out errors, out reason, out status);
                }
                catch (FaultException<UnhandledExceptionFault> e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            Assert.AreEqual(ResponseStatus.Success, status);
            Assert.AreEqual("DIAGNOSTICS", value);
            Assert.IsNotNull(errors);
        }

        /// <summary>
        /// Gets the level description from the live service
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetLevelDescription()
        {
            var categoryData = new LevelData
            {
                Outline = Outline,
                LineOfBusiness = LineOfBusiness.Professional
            };
            ErrorItem[] errors;
            ResponseStatus status;
            string value;

            using (var client = new ConfigInterpServiceClient())
            {
                OperationResult reason;

                value = client.GetLevelDescription(ApplicationId, Location, Region, UnisysUser, BlueUser, categoryData, out errors, out reason, out status);
            }

            Assert.AreEqual(ResponseStatus.Success, status);
            Assert.AreEqual("PROFESSIONAL BENEFIT ADMINISTRATION (OPTION 4)", value);
            Assert.IsNotNull(errors);
        }

        /// <summary>
        /// Gets the Outline description from the live service
        /// </summary>
        [TestCategory("Integration")]
        [TestMethod]
        public void GetOutlineDescription()
        {
            var categoryData = new OutlineData
            {
                Outline = Outline
            };
            ErrorItem[] errors;
            ResponseStatus status;
            string value;

            using (var client = new ConfigInterpServiceClient())
            {
                OperationResult reason;
                value = client.GetOutlineDescription(ApplicationId, Location, Region, UnisysUser, BlueUser, categoryData, out errors, out reason, out status);
            }

            Assert.AreEqual(ResponseStatus.Success, status);
            Assert.AreEqual("CONTRACT BENEFITS (MEDICAL)", value);
            Assert.IsNotNull(errors);
        }

        /// <summary>
        /// Gets the subcategory description from the live service
        /// </summary>
        [TestCategory("Integration")]
        [TestMethod]
        public void GetSubCategoryDescription()
        {
            var categoryData = new SubCategoryData
            {
                Category = Category,
                Outline = Outline,
                SubCategory = SubCategory
            };
            ErrorItem[] errors;
            ResponseStatus status;
            string value;

            using (var client = new ConfigInterpServiceClient())
            {
                OperationResult reason;
                value = client.GetSubCategoryDescription(ApplicationId, Location, Region, UnisysUser, BlueUser, categoryData, out errors, out reason, out status);
            }

            Assert.AreEqual(ResponseStatus.Success, status);
            Assert.AreEqual("CATEGORY PAYMENT METHOD/MAXIMUM ALLOWANCE", value);
            Assert.IsNotNull(errors);
        }
    }
}