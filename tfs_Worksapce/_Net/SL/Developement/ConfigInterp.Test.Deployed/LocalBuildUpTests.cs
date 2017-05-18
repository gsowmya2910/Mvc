// ----------------------------------------------------------------------
// <copyright file="LocalBuildUpTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Deployed
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using LocalService;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LocalBuildUpTests
    {
        /// <summary>
        /// Checks the Outline test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void CheckOutlineTest()
        {
            var outlineData = new OutlineData
            {
                Outline = 34
            };
            //// ReSharper disable once TooWideLocalVariableScope
            ErrorItem[] errors;
            ResponseStatus response;
            string text;
            using (var client = new ConfigInterpServiceClient())
            {
                try
                {
                    OperationResult reason;
                    text = client.GetOutlineDescription("Test", "Test", 1, "CL168236821", "id16823", outlineData, out errors, out reason, out response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            Assert.AreEqual(ResponseStatus.Success, response);
            Assert.IsNotNull(text);
        }
    }
}