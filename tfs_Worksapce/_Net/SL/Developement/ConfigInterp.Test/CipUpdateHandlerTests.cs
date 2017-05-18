// ----------------------------------------------------------------------
// <copyright file="CipUpdateHandlerTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Bl.Interfaces;
    using Bl.Update;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]

    public class CipUpdateHandlerTests
    {
        /// <summary>
        /// Checks the batching works for many test.
        /// </summary>
        [TestMethod]
        [TestCategory("LongRunning")]
        public void CheckBatchingWorksForManyTest()
        {
            var recordTables = new List<IStepDataMap>();
            var random = new Random();
            foreach (var stepId in Enumerable.Range(1, 1000))
            {
                foreach (var record in Enumerable.Range(1, random.Next(1, 40)))
                {
                    recordTables.Add(new TestMap
                    {
                        StepId = (short)stepId,
                        ActionId = (short)record
                    });
                }
            }

            var results = CipUpdateHandler.Batch(recordTables);

            var flattened = results.SelectMany(_ => _).ToList();
            foreach (var recordTable in recordTables)
            {
                var records = flattened.Where(_ => _.StepId == recordTable.StepId && _.ActionId == recordTable.ActionId).ToList();
                Assert.AreEqual(1, records.Count);
                var record = records.First();
                Assert.IsNotNull(record);
                Assert.AreNotEqual(0, record.ActionId);
                Assert.AreNotEqual(0, record.StepId);
            }
        }
    }
}