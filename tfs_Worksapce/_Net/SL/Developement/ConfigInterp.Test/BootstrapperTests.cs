// ----------------------------------------------------------------------
// <copyright file="BootstrapperTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using Contracts;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Unity;

    /// <summary>
    /// TestClass Object
    /// </summary>
    [TestClass]
    public class BootstrapperTests
    {
        /// <summary>
        /// checks that unity is wired up properly
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ConfigureTest()
        {
            var container = new UnityContainer();
            Bootstrapper.Configure(container);
            var service = container.Resolve<IConfigInterpService>();
            Assert.IsNotNull(service);
        }
    }
}
