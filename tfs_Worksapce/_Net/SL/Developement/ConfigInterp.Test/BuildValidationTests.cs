// ----------------------------------------------------------------------
// <copyright file="BuildValidationTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// TestClass Object
    /// </summary>
 #if (LOCALDEVBUILD)
    [Ignore]
#endif  
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BuildValidationTests
    {
        /// <summary>
        ///  Test For Build Detection Test
        /// </summary>
        [TestMethod]
        [SuppressMessage("ReSharper", "EventExceptionNotDocumented", Justification = "Dev")]
        public void BuildShouldRunNormalUnitTests()
        {
            Func<bool> func = () => true;
            // ReSharper disable once EventExceptionNotDocumented
            Assert.IsTrue(func.Invoke());
        }

        /// <summary>
        /// Builds the should exclude integration.
        /// </summary>
        [TestCategory("Integration")]
        [TestMethod]
        [TestProperty("ResultFailure", "This is expected to fail locally")]
        public void BuildShouldExcludeIntegration()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Builds the should exclude long running.
        /// </summary>
        [TestCategory("LongRunning")]
        [TestMethod]
        [TestProperty("ResultFailure", "This is expected to fail locally")]
        public void BuildShouldExcludeLongRunning()
        {
            Assert.Fail();
        }
    }
}