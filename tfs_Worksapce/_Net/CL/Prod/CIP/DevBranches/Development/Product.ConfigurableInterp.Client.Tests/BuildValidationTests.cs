// ----------------------------------------------------------------------
// <copyright file="BuildValidationTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace Product.ConfigurableInterp.Client.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// the build test class
    /// </summary>
    [TestClass]
    public class BuildValidationTests
    {
        /// <summary>
        /// checks that Builds should run normal unit tests.
        /// </summary>
        [TestMethod]
        public void BuildShouldRunNormalUnitTests()
        {
            Func<bool> func = () => true;
            Assert.IsTrue(func.Invoke());
        }
    }
}