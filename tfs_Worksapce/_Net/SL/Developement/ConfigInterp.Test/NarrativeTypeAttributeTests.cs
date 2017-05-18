// ----------------------------------------------------------------------
// <copyright file="NarrativeTypeAttributeTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using Bl;
    using Contracts.DataContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    public class NarrativeTypeAttributeTests
    {
        /// <summary>
        /// the enum
        /// </summary>
        private enum DirtyEnum
        {
            /// <summary>
            /// The only value
            /// </summary>
            [NarrativeType(13)]
            OnlyValue
        }

        /// <summary>
        /// Narratives the type attribute test.
        /// </summary>
        [TestMethod]
        public void NarrativeTypeAttributeTest()
        {
            var value = DirtyEnum.OnlyValue;

            var attribute = value.GetAttribute<NarrativeTypeAttribute>();

            Assert.IsNotNull(attribute);
            Assert.AreEqual(13, attribute.Narrative);
        }
    }
}