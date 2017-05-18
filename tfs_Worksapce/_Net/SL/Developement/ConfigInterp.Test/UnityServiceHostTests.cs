// ----------------------------------------------------------------------
// <copyright file="UnityServiceHostTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System;
    using Host.IIS;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ServiceLibrary;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    public class UnityServiceHostTests
    {
        /// <summary>
        /// Unities the service host test.
        /// </summary>
        [TestMethod]
        public void UnityServiceHostTest()
        {
            Uri baseAddress = new Uri("http://localhost:2344");
            var host = new UnityServiceHost(typeof(ConfigInterpService), baseAddress);
            host.Open();
        }
    }
}
