// ----------------------------------------------------------------------
// <copyright file="UtilitiesTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Bl;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilitiesTests
    {
        /// <summary>
        /// Batches the has correct batches.
        /// </summary>
        [TestMethod]
        public void BatchHasCorrectBatches()
        {
            var batchSize = 20;
            var total = 95;
            var remaider = total % batchSize;
            var values = Enumerable.Range(1, total).ToList();
            var batches = values.Batch(batchSize).ToList();
            for (var index = 0; index < batches.Count; index++)
            {
                var batch = batches[index].ToList();
                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (index == batches.Count - 1)
                {
                    Assert.AreEqual(remaider, batch.Count);
                }
                else
                {
                    Assert.AreEqual(batchSize, batch.Count);
                }
            }
        }

        /// <summary>
        /// Explicit the values bad type test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExplicitValuesBadTypeTest()
        {
            var types = new[] { typeof(IComparable), typeof(IFormattable), typeof(IConvertible) };
            var foundTypes = typeof(string).Assembly.GetTypes()
                .Where(_ => types.All(targetType => targetType.IsAssignableFrom(_)))
                .ToList();
            Assert.IsTrue(foundTypes.Any());

            Utilities.ExplicitValues<double>();
        }

        /// <summary>
        /// Explicit the values test.
        /// </summary>
        [TestMethod]
        public void ExplicitValuesTest()
        {
            var colors = Utilities.ExplicitValues<ConsoleColor>();
            Assert.IsNotNull(colors);
            Assert.IsTrue(colors.Any());
        }
    }
}