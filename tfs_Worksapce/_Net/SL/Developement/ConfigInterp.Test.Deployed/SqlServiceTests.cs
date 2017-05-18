// ----------------------------------------------------------------------
// <copyright file="SqlServiceTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Deployed
{
    using System;

    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.ServiceModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ResearchService;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SqlServiceTests
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
        /// The location
        /// </summary>
        private const string Location = "cl";

        /// <summary>
        /// The region
        /// </summary>
        private const short Region = 1;

        /// <summary>
        /// The Unisys user
        /// </summary>
        private const string UnisysUser = "CL168236821";

        /// <summary>
        /// Gets the field name description.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldNameDescription4()
        {
            ErrorItem[] errors;
            ResponseStatus status;
            FieldNameData[] value;
            //// ReSharper disable once TooWideLocalVariableScope
            OperationResult reason;

            using (var client = new ConfigInterpServiceClient())
            {
                try
                {
                    value = client.GetFieldNameDescription(ApplicationId, Location, Region, UnisysUser, BlueUser, 4, LineOfBusiness.Professional, out errors, out reason, out status);
                }
                catch (FaultException<UnhandledExceptionFault> e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            Assert.AreEqual(ResponseStatus.Success, status);
            Assert.IsNotNull(errors);
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Any());
        }

        /// <summary>
        /// Gets the field name description.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetFieldNameDescription5()
        {
            ErrorItem[] errors;
            ResponseStatus status;
            FieldNameData[] value;
            //// ReSharper disable once TooWideLocalVariableScope
            OperationResult reason;

            using (var client = new ConfigInterpServiceClient())
            {
                try
                {
                    value = client.GetFieldNameDescription(ApplicationId, Location, Region, UnisysUser, BlueUser, 5, LineOfBusiness.Professional, out errors, out reason, out status);
                }
                catch (FaultException<UnhandledExceptionFault> e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            Assert.AreEqual(ResponseStatus.Success, status);
            Assert.IsNotNull(errors); 
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Any());
        }
    }
}