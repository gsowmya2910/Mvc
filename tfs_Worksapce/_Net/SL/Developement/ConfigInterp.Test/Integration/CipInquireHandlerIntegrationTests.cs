// ----------------------------------------------------------------------
// <copyright file="CipInquireHandlerIntegrationTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Bl;
    using Bl.BenefitMatrix;
    using Bl.Inquire;
    using Bl.Interfaces;
    using Contracts.DataContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestUtilities;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CipInquireHandlerIntegrationTests
    {
        /// <summary>
        /// The region
        /// </summary>
        private const short Region = 1;

        /// <summary>
        /// Inquires the interp detail test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireInterpDetailTest()
        {
            ICipInquireHandler handler = new CipInquireHandler();

            var inquireInput = new InquireInput
            {
                MainFrameUsercode = "CL168236821",
                Outline = 34,
                Category = 100,
                SubCategory = 0,
                AdmitInterp = 146,
                SystemType = LineOfBusiness.Professional,
                Region = 1,
                Status = InterpStatus.Test
            };
            var result = handler.InquireInterpDetail(inquireInput);
            Assert.IsNotNull(result);
            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Inquires the simple data test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireSimpleDataTest()
        {
            ICipInquireHandler handler = new CipInquireHandler();

            var inquireInput = new InquireInput
            {
                MainFrameUsercode = "CL168236821",
                Outline = 34,
                Category = 100,
                SubCategory = 0,
                AdmitInterp = 146,
                SystemType = LineOfBusiness.Professional,
                Region = 1,
                Status = InterpStatus.Test
            };
            var result = handler.InquireSimpleData(inquireInput);
            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Outputs the many interps as objects.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void OutputManyInterps()
        {
            var items = new[]
            {
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 100, SubCategory = 000, AdmitInterp = 0146, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 180, SubCategory = 001, AdmitInterp = 0014, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 560, SubCategory = 004, AdmitInterp = 0007, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 080, SubCategory = 001, AdmitInterp = 0007, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 340, SubCategory = 020, AdmitInterp = 0002, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 120, SubCategory = 012, AdmitInterp = 0100, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 240, SubCategory = 015, AdmitInterp = 0001, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 100, SubCategory = 000, AdmitInterp = 0146, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 155, SubCategory = 015, AdmitInterp = 0001, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 080, SubCategory = 011, AdmitInterp = 0002, Level = 23 }, InterpStatus.Test),
                new Tuple<Interp, InterpStatus>(new Interp { Outline = 34, Category = 180, SubCategory = 001, AdmitInterp = 0014, Level = 23 }, InterpStatus.Test)
            };

            ICipInquireHandler handler = new CipInquireHandler();
            var notFounds = new List<string>();
            foreach (var tuple in items)
            {
                IInquireInput inquireInput = new InquireInput
                {
                    SubCategory = tuple.Item1.SubCategory,
                    Category = tuple.Item1.Category,
                    Region = Region,
                    Status = tuple.Item2,
                    AdmitInterp = tuple.Item1.AdmitInterp,
                    Outline = tuple.Item1.Outline,
                    SystemType = Converter.ReverseLookup(tuple.Item1.Level)
                };
                var result = handler.InquireInterpDetail(inquireInput);
                Assert.IsNotNull(result);
                Assert.AreEqual(OperationResult.Success, result.Result);
                if (result.Success)
                {
                    var name = tuple.Item1.DebugDisplay + "Steps";
                    TestDump.OutputDataObjects(result.StepData, name);
                    TestDump.OutputDataCsv(result.StepData, name);
                }
                else
                {
                    notFounds.Add(tuple.Item1.DebugDisplay);
                }
            }

            Assert.IsFalse(notFounds.Any(), Environment.NewLine + string.Join(Environment.NewLine, notFounds));
        }
    }
}