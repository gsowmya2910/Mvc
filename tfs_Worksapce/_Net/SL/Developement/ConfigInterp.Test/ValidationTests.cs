// ----------------------------------------------------------------------
// <copyright file="ValidationTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Bl;
    using Bl.Update;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The Object
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ValidationTests
    {
        /// <summary>
        /// Checks that only one set of parameters are passed in
        /// </summary>
        [TestMethod]
        public void CheckActionHasOnlyOneTypeOfParameters()
        {
            var list = new List<ErrorItem>();

            var stepAction = new StepAction
            {
                ActionId = 1,
                AlphaParameters = new List<AlphaValue>
                {
                    new AlphaValue
                    {
                        Value = "Test"
                    }
                }
            };

            Validation.CheckActions(stepAction, 1, list, string.Empty, string.Empty);

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Checks the complexity exceeded conditional test.
        /// </summary>
        [TestMethod]
        public void CheckComplexityExceededConditionalTest()
        {
            var countToGenerate = CipUpdateHandler.MaxStepsToSave / 2;
            var list = new List<ErrorItem>();
            var step = new ConditionalStep
            {
                Conditions = Enumerable.Repeat(new Condition(), countToGenerate).ToList(),
                TrueActions = Enumerable.Repeat(new StepAction(), countToGenerate).ToList(),
                FalseActions = Enumerable.Repeat(new StepAction(), countToGenerate).ToList()
            };
            Validation.CheckComplexityExceeded(step, list);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Checks the complexity is safe with very weird values test.
        /// </summary>
        [TestMethod]
        public void CheckComplexityIsSafeWithVeryWeirdValuesTest()
        {
            var list = new List<ErrorItem>();

            var steps = new ConfiguredSteps
            {
                ConditionalSteps = new[]
                {
                    null,
                    new ConditionalStep(),
                    new ConditionalStep
                    {
                        Conditions = new List<Condition>
                        {
                            null,
                            new Condition(),
                            new Condition
                            {
                                AlphaParameters = new List<AlphaValueWithThru>
                                {
                                    null,
                                    new AlphaValueWithThru()
                                },
                                DecimalParameters = new List<DecimalValueWithThru>
                                {
                                    null,
                                    new DecimalValueWithThru()
                                },
                                NumericParameters = new List<NumericValueWithThru>
                                {
                                    null,
                                    new NumericValueWithThru()
                                }
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            null,
                            new StepAction(),
                            new StepAction
                            {
                                AlphaParameters = new List<AlphaValue>
                                {
                                    null,
                                    new AlphaValue()
                                },
                                DecimalParameters = new List<DecimalValue>
                                {
                                    null,
                                    new DecimalValue()
                                },
                                NumericParameters = new List<NumericValue>
                                {
                                    null,
                                    new NumericValue()
                                }
                            }
                        },
                        FalseActions = new List<StepAction>
                        {
                            null,
                            new StepAction(),
                            new StepAction
                            {
                                AlphaParameters = new List<AlphaValue>
                                {
                                    null,
                                    new AlphaValue()
                                },
                                DecimalParameters = new List<DecimalValue>
                                {
                                    null,
                                    new DecimalValue()
                                },
                                NumericParameters = new List<NumericValue>
                                {
                                    null,
                                    new NumericValue()
                                }
                            }
                        }
                    }
                },
                ExceptionSteps = new[]
                {
                    null,
                    new ExceptionStep()
                },
                UnconditionalSteps = new[]
                {
                    null,
                    new UnconditionalStep(),
                    new UnconditionalStep
                    {
                        Action = new StepAction
                        {
                            AlphaParameters = new List<AlphaValue>
                                {
                                    null,
                                    new AlphaValue()
                                },
                                DecimalParameters = new List<DecimalValue>
                                {
                                    null,
                                    new DecimalValue()
                                },
                                NumericParameters = new List<NumericValue>
                                {
                                    null,
                                    new NumericValue()
                                }
                        }
                    }
                }
            };
            var combined =
                steps.ConditionalSteps.Union<ConfiguredStep>(steps.ExceptionSteps)
                    .Union(steps.UnconditionalSteps)
                    .ToList();
            foreach (var step in combined)
            {
                Validation.CheckComplexityExceeded(step, list);
            }

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Checks the complexity not exceeded conditional test.
        /// </summary>
        [TestMethod]
        public void CheckComplexityNotExceededConditionalTest()
        {
            var list = new List<ErrorItem>();
            var step = new ConditionalStep();
            Validation.CheckComplexityExceeded(step, list);
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Checks the complexity not exceeded exception test.
        /// </summary>
        [TestMethod]
        public void CheckComplexityNotExceededExceptionTest()
        {
            var list = new List<ErrorItem>();
            var step = new ExceptionStep();
            Validation.CheckComplexityExceeded(step, list);
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Checks the complexity not exceeded unconditional test.
        /// </summary>
        [TestMethod]
        public void CheckComplexityNotExceededUnconditionalTest()
        {
            var list = new List<ErrorItem>();
            var step = new UnconditionalStep();
            Validation.CheckComplexityExceeded(step, list);
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Checks that only one set of parameters are passed in
        /// </summary>
        [TestMethod]
        public void CheckConditionHasOnlyOneTypeOfParameters()
        {
            var list = new List<ErrorItem>();

            var alphaCondition = new Condition
            {
                ParameterType = RecordValueType.Alpha,
                AlphaParameters = new List<AlphaValueWithThru>
                {
                    new AlphaValueWithThru
                    {
                        Value = "Test"
                    }
                }
            };

            var decimalCondition = new Condition
            {
                ParameterType = RecordValueType.Decimal,
                DecimalParameters = new List<DecimalValueWithThru>
                {
                    new DecimalValueWithThru
                    {
                        Value = 987
                    }
                }
            };

            var numericCondition = new Condition
            {
                ParameterType = RecordValueType.Numeric,
                NumericParameters = new List<NumericValueWithThru>
                {
                    new NumericValueWithThru
                    {
                        Value = 123
                    }
                }
            };

            Validation.CheckParameters(alphaCondition, 1, list, 1);
            Validation.CheckParameters(decimalCondition, 1, list, 1);
            Validation.CheckParameters(numericCondition, 1, list, 1);

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Checks the invalid range test.
        /// </summary>
        [TestMethod]
        public void CheckInvalidRangeTest()
        {
            var list = new List<ErrorItem>();

            Validation.CheckRange(3, "Prop", 1, 3, list);

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Checks the valid range test.
        /// </summary>
        [TestMethod]
        public void CheckValidRangeTest()
        {
            var list = new List<ErrorItem>();

            Validation.CheckRange(2, "Prop", 1, 3, list);

            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Determines whether [has data category data has data test].
        /// </summary>
        [TestMethod]
        public void HasDataCategoryDataHasDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new CategoryData
            {
                Category = 1,
                Outline = 1
            };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Determines whether [has data category data has invalid data test].
        /// </summary>
        [TestMethod]
        public void HasDataCategoryDataHasInvalidDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new CategoryData
            {
                Category = -1
            };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(2, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data category data null test].
        /// </summary>
        [TestMethod]
        public void HasDataCategoryDataNullTest()
        {
            var list = new List<ErrorItem>();

            var result = new Validation().HasData((CategoryData)null, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data inquire input data has data test].
        /// </summary>
        [TestMethod]
        public void HasDataInquireInputDataHasDataTest()
        {
            var data = new InquireInputData
            {
                AdmitInterp = 35,
                Category = 1,
                SubCategory = 1,
                Outline = 1,
                LineOfBusiness = LineOfBusiness.Institutional,
                Status = InterpStatus.Deactivated
            };
            var list = new List<ErrorItem>();
            var result = new Validation().HasData(data, list);
            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Determines whether [has data inquire input data has invalid default data test].
        /// </summary>
        [TestMethod]
        public void HasDataInquireInputDataHasInvalidDefaultDataTest()
        {
            var data = new InquireInputData
            {
                AdmitInterp = -1,
                Category = -1,
                SubCategory = -1,
                Outline = 0,
                LineOfBusiness = LineOfBusiness.None,
                Status = InterpStatus.None
            };
            var list = new List<ErrorItem>();
            var result = new Validation().HasData(data, list);
            Assert.AreEqual(6, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data inquire input data has invalid interesting data test].
        /// </summary>
        [TestMethod]
        public void HasDataInquireInputDataHasInvalidInterestingDataTest()
        {
            var data = new InquireInputData
            {
                AdmitInterp = 1,
                Category = 1,
                SubCategory = 1,
                Outline = 1,
                LineOfBusiness = (LineOfBusiness)short.MaxValue,
                Status = (InterpStatus)short.MaxValue
            };
            var list = new List<ErrorItem>();
            var result = new Validation().HasData(data, list);
            Assert.AreEqual(2, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data inquire input data null test].
        /// </summary>
        [TestMethod]
        public void HasDataInquireInputDataNullTest()
        {
            var list = new List<ErrorItem>();
            var result = new Validation().HasData((InquireInputData)null, list);
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data level data has data test].
        /// </summary>
        [TestMethod]
        public void HasDataLevelDataHasDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new LevelData { LineOfBusiness = LineOfBusiness.Institutional, Outline = 1 };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Determines whether [has data level data has invalid data test].
        /// </summary>
        [TestMethod]
        public void HasDataLevelDataHasInvalidDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new LevelData();

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(2, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data level data null test].
        /// </summary>
        [TestMethod]
        public void HasDataLevelDataNullTest()
        {
            var list = new List<ErrorItem>();

            var result = new Validation().HasData((LevelData)null, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data Outline data has data test].
        /// </summary>
        [TestMethod]
        public void HasDataOutlineDataHasDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new OutlineData { Outline = 1 };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Determines whether [has data Outline data has invalid data test].
        /// </summary>
        [TestMethod]
        public void HasDataOutlineDataHasInvalidDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new OutlineData();

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data Outline data null test].
        /// </summary>
        [TestMethod]
        public void HasDataOutlineDataNullTest()
        {
            var list = new List<ErrorItem>();

            var result = new Validation().HasData((OutlineData)null, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data sub category data has data test].
        /// </summary>
        [TestMethod]
        public void HasDataSubCategoryDataHasDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new SubCategoryData
            {
                SubCategory = 1,
                Outline = 1,
                Category = 1
            };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Determines whether [has data sub category data has invalid data test].
        /// </summary>
        [TestMethod]
        public void HasDataSubCategoryDataHasInvalidDataTest()
        {
            var list = new List<ErrorItem>();
            var data = new SubCategoryData
            {
                SubCategory = -1,
                Category = -1
            };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(3, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data sub category data null test].
        /// </summary>
        [TestMethod]
        public void HasDataSubCategoryDataNullTest()
        {
            var list = new List<ErrorItem>();

            var result = new Validation().HasData((SubCategoryData)null, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data update interp narrative data invalid narrative test].
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void HasDataUpdateInterpNarrativeDataInvalidNarrativeTest()
        {
            var list = new List<ErrorItem>();

            var data = new UpdateInterpNarrativeData
            {
                Outline = 1,
                Category = 1,
                SubCategory = 1,
                AdmitInterp = 1,
                LineOfBusiness = LineOfBusiness.Institutional,
                Status = Status.Active,
                NarrativeLines = new string[] { null }
            };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data update interp narrative data invalid test].
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void HasDataUpdateInterpNarrativeDataInvalidTest()
        {
            var list = new List<ErrorItem>();

            var data = new UpdateInterpNarrativeData
            {
                SubCategory = -1,
                Category = -1
            };

            var result = new Validation().HasData(data, list);

            Assert.AreEqual(6, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data update interp narrative data null test].
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void HasDataUpdateInterpNarrativeDataNullTest()
        {
            var list = new List<ErrorItem>();
            var result = new Validation().HasData((UpdateInterpNarrativeData)null, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has data update interp narrative data test].
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void HasDataUpdateInterpNarrativeDataTest()
        {
            var data = new UpdateInterpNarrativeData
            {
                Outline = 1,
                Category = 1,
                SubCategory = 1,
                AdmitInterp = 1,
                LineOfBusiness = LineOfBusiness.Institutional,
                Status = Status.Active,
                NarrativeLines = new[] { "value1", "value2", "value3" }
            };
            var list = new List<ErrorItem>();
            var result = new Validation().HasData(data, list);
            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Determines whether [has header invalid values test].
        /// </summary>
        [TestMethod]
        public void HasHeaderInvalidValuesTest()
        {
            var list = new List<ErrorItem>();
            var data = new LevelRequest();

            var result = new Validation().HasHeaderValues(data, list);

            Assert.AreEqual(3, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has header values test].
        /// </summary>
        [TestMethod]
        public void HasHeaderValuesTest()
        {
            var list = new List<ErrorItem>();
            var data = new LevelRequest
            {
                ApplicationId = "Test",
                Region = 1,
                UserId = "Test"
            };

            var result = new Validation().HasHeaderValues(data, list);

            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Determines whether [has request null test].
        /// </summary>
        [TestMethod]
        public void HasRequestNullTest()
        {
            var list = new List<ErrorItem>();

            var result = new Validation().HasRequest(null, list);

            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether [has request test].
        /// </summary>
        [TestMethod]
        public void HasRequestTest()
        {
            var list = new List<ErrorItem>();
            var data = new LevelRequest();

            var result = new Validation().HasRequest(data, list);

            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(result);
        }
    }
}