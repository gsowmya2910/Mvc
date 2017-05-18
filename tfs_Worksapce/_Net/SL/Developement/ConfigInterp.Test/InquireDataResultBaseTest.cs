// ----------------------------------------------------------------------
// <copyright file="InquireDataResultBaseTest.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Inquire;
    using CIPINQ01;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InquireDataResultBaseTest
    {
        /// <summary>
        /// Unused the properties do convert test.
        /// </summary>
        [TestMethod]
        public void UnusedPropertiesDoConvertTest()
        {
            var keyInfo = new KeyInfoOut
            {
                CreateByRevision = 1,
                RevisonNumber = 1,
                StepCount = 1
            };

            InquireDataResultBase item = new SimpleInquireResult(keyInfo);

            Assert.AreEqual(1, item.CreateByRevision);
            Assert.AreEqual(1, item.RevisionNumber);
            Assert.AreEqual(1, item.StepCount);
        }
    }
}