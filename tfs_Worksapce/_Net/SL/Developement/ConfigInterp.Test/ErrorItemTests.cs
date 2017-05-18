// ----------------------------------------------------------------------
// <copyright file="ErrorItemTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using Contracts.DataContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    public class ErrorItemTests
    {
        /// <summary>
        /// Errors the item as identifier test.
        /// </summary>
        [TestMethod]
        public void ErrorItemAsIdTest()
        {
            var item = new ErrorItem(123, "message");
            Assert.IsNotNull(item.Prop);
            Assert.IsNotNull(item.Message);
        }

        /// <summary>
        /// Errors the item as property test.
        /// </summary>
        [TestMethod]
        public void ErrorItemAsPropTest()
        {
            var item = new ErrorItem("prop", "message");
            Assert.IsNotNull(item.Prop);
            Assert.IsNotNull(item.Message);
        }
    }
}