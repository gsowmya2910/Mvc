// ----------------------------------------------------------------------
// <copyright file="LocalDevelopmentSetupTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Integration
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.BenefitMatrix;
    using Bl.Description;
    using Bl.Inquire;
    using Bl.Update;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sql;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LocalDevelopmentSetupTests
    {
        /// <summary>
        /// ti is installed into IIS test.
        /// </summary>
        [TestMethod]
        [TestCategory("Local Setup")]
        [TestCategory("Integration")]
        public void BenefitMatrixTiIsInstalledIntoIisTest()
        {
            var obj = new BenefitMatrixTiWrapper(1);
            Assert.IsNotNull(obj);
        }

        /// <summary>
        /// ti is installed into IIS test.
        /// </summary>
        [TestMethod]
        [TestCategory("Local Setup")]
        [TestCategory("Integration")]
        public void CipInquireTiIsInstalledIntoIisTest()
        {
            var obj = new CipInquireTiWrapper(1);
            Assert.IsNotNull(obj);
        }

        /// <summary>
        /// ti is installed into IIS test.
        /// </summary>
        [TestMethod]
        [TestCategory("Local Setup")]
        [TestCategory("Integration")]
        public void CipUpdateTiIsInstalledIntoIisTest()
        {
            var obj = new CipUpdateTiWrapper(1);
            Assert.IsNotNull(obj);
        }

        /// <summary>
        /// Connections the strings are in place test.
        /// </summary>
        [TestMethod]
        [TestCategory("Local Setup")]
        [TestCategory("Integration")]
        public void ConnectionStringsAreInPlaceTest()
        {
            var names = new[]
            {
                DirectSqlServerDataAccess.CipDatabaseName,
                DirectSqlServerDataAccess.CommonDatabaseName,
                EntityFrameworkDataAccess.CipDatabaseName,
                EntityFrameworkDataAccess.CoreDatabaseName,
                EntityFrameworkDataAccess.CipConfigName,
                EntityFrameworkDataAccess.CoreConfigName
            };
            foreach (var name in names)
            {
                var value = UsesConnectionStringsBase.GetConnectionString(name);
                Assert.IsNotNull(value);
            }
        }

        /// <summary>
        /// Connections the strings are weaved test.
        /// </summary>
        [TestMethod]
        [TestCategory("Local Setup")]
        [TestCategory("Integration")]
        public void ConfigStringsAreWeavedProperlyTests()
        {
            var core = EntityFrameworkDataAccess.GetCoreString();
            Assert.IsNotNull(core);

            var cip = EntityFrameworkDataAccess.GetCipString();
            Assert.IsNotNull(cip);
        }

        /// <summary>
        /// ti is installed into IIS test.
        /// </summary>
        [TestMethod]
        [TestCategory("Local Setup")]
        [TestCategory("Integration")]
        public void DescriptionTiIsInstalledIntoIisTest()
        {
            var obj = new DescriptionMasterTiWrapper(1);
            Assert.IsNotNull(obj);
        }
    }
}