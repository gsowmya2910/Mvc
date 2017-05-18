// ----------------------------------------------------------------------
// <copyright file="ConfigInterpServiceCipUpdateIntegrationTests.cs" company="CoreLink">
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
    using Bl.Update;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using ServiceLibrary;
    using TestUtilities;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConfigInterpServiceCipUpdateIntegrationTests
    {
        /// <summary>
        /// The employee number
        /// </summary>
        private const short EmployeeNumber = 16823;

        /// <summary>
        /// Applies the conditional step.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyConditionalStep()
        {
            var steps = new ConfiguredSteps
            {
                ConditionalSteps = new[]
                {
                    new ConditionalStep
                    {
                        Index = 1,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                FieldNumber = 2330006,
                                CompareType = CompareType.GreaterThan,
                                Qualifier = 1000,
                                FieldType = FieldType.KeyWord,
                                Operation = ConditionOperation.If,
                                ParameterType = RecordValueType.Decimal,
                                DecimalParameters = new List<DecimalValueWithThru>
                                {
                                    new DecimalValueWithThru
                                    {
                                        Value = (decimal)1.1,
                                        ValueThru = (decimal)1.9
                                    }
                                }
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 8,
                                NumericParameters = new List<NumericValue>
                                {
                                    new NumericValue
                                    {
                                        Value = 838030
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var request = GetDefaultRequest(steps);
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var response = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Applies the enough steps to cause batch processing step.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyEnoughStepsToCauseBatchProcessingStep()
        {
            var rand = new Random();
            var steps = new ConfiguredSteps
            {
                ExceptionSteps = Enumerable.Range(1, 535)
                .Select(_ => new ExceptionStep
                {
                    Index = (short)_,
                    ExceptionId = (short)rand.Next(1, 50)
                })
                .ToArray()
            };
            var request = GetDefaultRequest(steps);
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var response = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Applies the exception step.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyExceptionStep()
        {
            var steps = new ConfiguredSteps
            {
                ExceptionSteps = new[]
                {
                    new ExceptionStep
                    {
                        Index = 1,
                        ExceptionId = 25
                    }
                }
            };
            var request = GetDefaultRequest(steps);
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var response = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Applies the exception step.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyTamiExceptionStep()
        {
            var request = new UpdateInterpDetailRequest
            {
                Region = 1,
                ApplicationId = "UnitTest",
                UserId = "id16823",
                UnisysUsercode = "CL168236821",
                CorrespondenceLocation = "CL",
                Data = new InterpDetailData
                {
                    Outline = 34,
                    Category = 240,
                    SubCategory = 15,
                    AdmitInterp = 8005,
                    Comment = "Ooops",
                    LineOfBusiness = LineOfBusiness.Professional,
                    EmployeeNumber = 11120,
                    CurrentStatus = InterpStatus.Test,
                    EmployeeRegion = Plan.BCBSND,
                    ConfiguredSteps = new ConfiguredSteps
                    {
                        ExceptionSteps = new[]
                        {
                            new ExceptionStep
                            {
                                Index = 1,
                                ExceptionId = 35
                            },
                             new ExceptionStep
                            {
                                Index = 2,
                                ExceptionId = 35
                            },
                             new ExceptionStep
                            {
                                Index = 3,
                                ExceptionId = 35
                            }
                        }
                    }
                }
            };
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var response = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Applies the exception step.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void GetTamiExceptionStep()
        {
            var request = new InquireRequest
            {
                Region = 1,
                ApplicationId = "UnitTest",
                UserId = "id16823",
                UnisysUsercode = "CL168236821",
                CorrespondenceLocation = "CL",
                Data = new InquireInputData
                {
                    Outline = 34,
                    Category = 240,
                    SubCategory = 15,
                    AdmitInterp = 8005,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = InterpStatus.Active
                }
            };
            var service = new ConfigInterpService(new Validation(), new CipInquireHandler(), null, null, null, null, null, new Converter(new StepConverter()));

            var response = service.GetInterpDetail(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Applies the many step variants.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyManyStepVariants()
        {
            var steps = GetComplexSteps();
            var request = GetDefaultRequest(steps);
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var response = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Applies the maximum records for transaction.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyMaxRecordsForTransaction()
        {
            var rand = new Random();
            var list = new List<ExceptionStep>();
            var steps = new ConfiguredSteps();
            var request = GetDefaultRequest(steps);
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var seed = Enumerable.Range(1, CipUpdateHandler.MaxStepsToSave)
                .Select(_ => new ExceptionStep
                {
                    Index = (short)_,
                    ExceptionId = (short)rand.Next(1, 50)
                })
                .ToArray();
            list.AddRange(seed);

            steps.ExceptionSteps = list.ToArray();

            var response = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Applies the till the mainframe breaks.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyTillTheMainframeBreaks()
        {
            var rand = new Random();
            var list = new List<ExceptionStep>();
            var steps = new ConfiguredSteps();
            var request = GetDefaultRequest(steps);
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var seed = Enumerable.Range(1, 175)
                .Select(_ => new ExceptionStep
                {
                    Index = (short)_,
                    ExceptionId = (short)rand.Next(1, 50)
                })
                .ToArray();
            list.AddRange(seed);
            short seedCount = (short)(seed.Length + 1);
            for (short i = seedCount; i < 1000; i += 5)
            {
                short localIndex = i;
                var smallBatch = Enumerable.Range(0, 5)
                    .Select(_ => new ExceptionStep
                    {
                        Index = (short)(_ + localIndex),
                        ExceptionId = (short)rand.Next(1, 50)
                    })
                    .ToArray();
                var found = smallBatch.FirstOrDefault(_ => _.Index == 178);
                if (found != null)
                {
                    Console.WriteLine("{0}:{1}", found.Index, found.ExceptionId);
                }

                list.AddRange(smallBatch);

                steps.ExceptionSteps = list.ToArray();

                var response = service.UpdateInterpConfig(request);

                Assert.AreEqual(ResponseStatus.Success, response.Status, string.Format("Index:{0}; Message:{1}", i, GetErrorMessage(response)));
            }
        }

        /// <summary>
        /// Applies the unconditional step.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ApplyUnconditionalStep()
        {
            var steps = new ConfiguredSteps
            {
                UnconditionalSteps = new[]
                {
                    new UnconditionalStep
                    {
                        Index = 1,
                        Action = new StepAction
                        {
                            ActionId = 8,
                            NumericParameters = new List<NumericValue>
                            {
                                new NumericValue
                                {
                                    Value = 838030
                                }
                            }
                        }
                    }
                }
            };
            var request = GetDefaultRequest(steps);
            var service = new ConfigInterpService(new Validation(), null, new CipUpdateHandler(), null, null, null, null, new Converter(new StepConverter()));

            var response = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Checks the equality.
        /// </summary>
        [TestMethod]
        public void CheckEquality()
        {
            var first = GetComplexSteps();
            var second = GetComplexSteps();
            var result = EqualityChecker.Compare(first, second);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Checks the status changes.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [TestProperty("Remarks", "Non-repeatable without external help")]
        public void CheckStatusChanges()
        {
            var service = new ConfigInterpService(new ConfigInterpService.DependanciesForService
            {
                Validation = new MockValidation(true),
                Update = new CipUpdateHandler(),
                BenefitMatrix = new BenefitMatrixHandler(),
                Inquire = new CipInquireHandler(),
                Workflow = new WorkflowManager(new BenefitMatrixHandler(), new CipUpdateHandler(), new CipInquireHandler())
            });

            short outline = 34;
            short cat = 120;
            short sub = 12;
            short admit = 100;

            var inquierNarr = service.InquireInterpNarrative(new InquireInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL168236821",
                UserId = "id16823",
                Data = new InquireInterpNarrativeData
                {
                    Outline = outline,
                    Category = cat,
                    SubCategory = sub,
                    AdmitInterp = admit,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.Maintenance
                }
            });
            Assert.IsNotNull(inquierNarr);
            Assert.AreEqual(ResponseStatus.Success, inquierNarr.Status, GetErrorMessage(inquierNarr));

            var inquire = service.GetInterp(new InquireRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL168236821",
                UserId = "id16823",
                Data = new InquireInputData
                {
                    Outline = outline,
                    Category = cat,
                    SubCategory = sub,
                    AdmitInterp = admit,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = InterpStatus.Test
                }
            });
            Assert.IsNotNull(inquire);
            Assert.AreEqual(ResponseStatus.Success, inquire.Status, GetErrorMessage(inquire));

            var deleteResponse = service.DeleteInterp(new DeleteCipInterpRequest
                  {
                      Region = 1,
                      ApplicationId = "Test",
                      CorrespondenceLocation = "Test",
                      UnisysUsercode = "CL168236821",
                      UserId = "id16823",
                      Data = new DeleteCipInterpData
                      {
                          Outline = outline,
                          Category = cat,
                          SubCategory = sub,
                          AdmitInterp = admit,
                          LineOfBusiness = LineOfBusiness.Professional
                      }
                  });

            Assert.IsNotNull(deleteResponse);
            Assert.AreEqual(ResponseStatus.Success, deleteResponse.Status, GetErrorMessage(deleteResponse));

            var narCreateResponse = service.CreateInterpNarrative(new CreateInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL168236821",
                UserId = "id16823",
                Data = new CreateInterpNarrativeData
                {
                    Outline = outline,
                    Category = cat,
                    SubCategory = sub,
                    AdmitInterp = admit,
                    LineOfBusiness = LineOfBusiness.Professional
                }
            });
            Assert.IsNotNull(narCreateResponse);
            Assert.AreEqual(ResponseStatus.Success, narCreateResponse.Status, GetErrorMessage(narCreateResponse));

            var narUpdate = service.UpdateInterpNarrative(new UpdateInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL168236821",
                UserId = "id16823",
                Data = new UpdateInterpNarrativeData
                {
                    Outline = outline,
                    Category = cat,
                    SubCategory = sub,
                    AdmitInterp = admit,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.Maintenance,
                    NarrativeLines = Enumerable.Range(1, 50).Select(_ => string.Format("Value {0}", _)).ToArray()
                }
            });
            Assert.IsNotNull(narUpdate);
            Assert.AreEqual(ResponseStatus.Success, narUpdate.Status, GetErrorMessage(narUpdate));

            var addStepResponse = service.UpdateInterpConfig(new UpdateInterpDetailRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL168236821",
                UserId = "id16823",
                Data = new InterpDetailData
                {
                    Outline = outline,
                    Category = cat,
                    SubCategory = sub,
                    AdmitInterp = admit,
                    LineOfBusiness = LineOfBusiness.Professional,
                    CurrentStatus = InterpStatus.Test,
                    Comment = "for status changes",
                    EmployeeRegion = Plan.BCBSND,
                    EmployeeNumber = 0,
                    ConfiguredSteps = new ConfiguredSteps
                    {
                        ExceptionSteps = new[]
                        {
                            new ExceptionStep
                            {
                                ExceptionId   = 3,
                                Index = 1
                            }
                        }
                    }
                }
            });
            Assert.IsNotNull(addStepResponse);
            Assert.AreEqual(ResponseStatus.Success, addStepResponse.Status, GetErrorMessage(addStepResponse));
            var request = new StatusChangeRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL168236821",
                UserId = "id16823",
                Data = new StatusData
                {
                    Outline = outline,
                    Category = cat,
                    SubCategory = sub,
                    AdmitInterp = admit,
                    LineOfBusiness = LineOfBusiness.Professional,
                    CurrentStatus = InterpStatus.Test,
                    TargetStatus = InterpStatus.Active
                }
            };
            var response = service.UpdateInterpStatus(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Tests the clone.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void CloneInterpTest()
        {
            var request = new CloneInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL33266842",
                UserId = "id03326",
                LineOfBusiness = LineOfBusiness.Professional,
                CurrentStatus = InterpStatus.Test,
                Source = new CloneInterpNarrativeData
                {
                    Outline = 34,
                    Category = 560,
                    SubCategory = 4,
                    AdmitInterp = 0007,
                },
                Target = new CloneInterpNarrativeData
                {
                    Outline = 34,
                    Category = 240,
                    SubCategory = 15,
                    AdmitInterp = 8002,
                },
            };

            var service = new ConfigInterpService(new Validation(), null, null, null, null, null, new WorkflowManager(new BenefitMatrixHandler(), new CipUpdateHandler(), new CipInquireHandler()), new Converter(null));

            var response = service.CloneInterp(request);
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// Checks the status changes.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void DeleteInterpTest()
        {
            var request = new DeleteCipInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL33266842",
                UserId = "id03326",

                Data = new DeleteCipInterpData
                {
                    Outline = 34,
                    Category = 120,
                    SubCategory = 0,
                    AdmitInterp = 8003,
                    LineOfBusiness = LineOfBusiness.Professional
                }
            };

            var service = new ConfigInterpService(new ConfigInterpService.DependanciesForService
            {
                Validation = new Validation(),
                BenefitMatrix = new BenefitMatrixHandler(),
                Update = new CipUpdateHandler()
            });

            var response = service.DeleteInterp(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Checks the status changes.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void DeleteInterpTest2()
        {
            var request = new DeleteCipInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "CL33266842",
                UserId = "id03326",

                Data = new DeleteCipInterpData
                {
                    Outline = 34,
                    Category = 012,
                    SubCategory = 0,
                    AdmitInterp = 0100,
                    LineOfBusiness = LineOfBusiness.Professional,
                }
            };

            var service = new ConfigInterpService(new ConfigInterpService.DependanciesForService
            {
                Validation = new Validation(),
                BenefitMatrix = new BenefitMatrixHandler(),
                Update = new CipUpdateHandler()
            });

            var response = service.DeleteInterp(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Helpings the tami test.
        /// </summary>
        [TestCategory("Integration")]
        [TestMethod]
        public void HelpingTamiCloneTest()
        {
            var service = new ConfigInterpService(new ConfigInterpService.DependanciesForService
            {
                Validation = new Validation(),
                Workflow = new WorkflowManager(new BenefitMatrixHandler(), new CipUpdateHandler(), new CipInquireHandler())
            });

            var request = new CloneInterpRequest
            {
                Region = 1,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "CL",
                UserId = "id11120",
                UnisysUsercode = "CL111206773",
                LineOfBusiness = LineOfBusiness.Professional,
                CurrentStatus = InterpStatus.Active,
                Source = new CloneInterpNarrativeData
                {
                    Outline = 34,
                    Category = 560,
                    SubCategory = 4,
                    AdmitInterp = 7
                },
                Target = new CloneInterpNarrativeData
                {
                    Outline = 34,
                    Category = 240,
                    SubCategory = 15,
                    AdmitInterp = 8004
                }
            };
            var response = service.CloneInterp(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Helpings the tami test.
        /// </summary>
        [TestCategory("Integration")]
        [TestMethod]
        public void HelpingTamiGetDetailTest()
        {
            var service = new ConfigInterpService(new ConfigInterpService.DependanciesForService
            {
                Validation = new Validation(),
                Inquire = new CipInquireHandler()
            });

            var request = new InquireRequest
            {
                Region = 1,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "CL",
                UserId = "id11120",
                UnisysUsercode = "CL111206773",
                Data = new InquireInputData
                {
                    Outline = 34,
                    Category = 560,
                    SubCategory = 4,
                    AdmitInterp = 7,
                    Status = InterpStatus.Active,
                    LineOfBusiness = LineOfBusiness.Professional
                }
            };
            var response = service.GetInterpDetail(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Helpings the tami test.
        /// </summary>
        [TestCategory("Integration")]
        [TestMethod]
        public void HelpingTamiStatusTest()
        {
            var service = new ConfigInterpService(new ConfigInterpService.DependanciesForService
            {
                Validation = new Validation(),
                Workflow = new WorkflowManager(new BenefitMatrixHandler(), new CipUpdateHandler(), new CipInquireHandler())
            });

            var request = new StatusChangeRequest
            {
                Region = 1,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "CL",
                UserId = "id11120",
                UnisysUsercode = "CL111206773",
                Data = new StatusData
                {
                    Outline = 34,
                    Category = 120,
                    SubCategory = 1,
                    AdmitInterp = 7005,
                    LineOfBusiness = LineOfBusiness.Professional,
                    CurrentStatus = InterpStatus.Test,
                    TargetStatus = InterpStatus.Active
                }
            };
            var response = service.UpdateInterpStatus(request);

            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Validates the objects from inquire.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void ValidateObjectsFromInquire()
        {
            var service = new ConfigInterpService(new Validation(), new CipInquireHandler(), null, null, null, null, null, new Converter(new StepConverter()));

            var inquireRequest = new InquireRequest
            {
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Region = 1,
                UnisysUsercode = "Test",
                UserId = "Test",
                Data = new InquireInputData
                {
                    Outline = 34,
                    Category = 340,
                    SubCategory = 20,
                    AdmitInterp = 2,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = InterpStatus.Test
                }
            };
            var response = service.GetInterpDetail(inquireRequest);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.IsNotNull(response.Data);
            bool result = EqualityChecker.Compare(response.Data.ConfiguredSteps, GetComplexSteps());
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Gets the complex steps.
        /// </summary>
        /// <returns>the value</returns>
        private static ConfiguredSteps GetComplexSteps()
        {
            return new ConfiguredSteps
            {
                UnconditionalSteps = new[]
                {
                    new UnconditionalStep
                    {
                        Index = 13,
                        Action = new StepAction
                        {
                            ActionId = 8
                        }
                    },
                    new UnconditionalStep
                    {
                        Index = 1,
                        Action = new StepAction
                        {
                            ActionId = 8,
                            NumericParameters = new List<NumericValue>
                            {
                                new NumericValue
                                {
                                    Value = 838030
                                }
                            }
                        }
                    },
                    new UnconditionalStep
                    {
                        Index = 3,
                        Action = new StepAction
                        {
                            ActionId = 1,
                            NumericParameters = new List<NumericValue>
                            {
                                new NumericValue
                                {
                                    Value = 838030
                                },
                                new NumericValue
                                {
                                    Value = 433
                                },
                                new NumericValue
                                {
                                    Value = 32
                                }
                            }
                        }
                    },
                    new UnconditionalStep
                    {
                        Index = 4,
                        Action = new StepAction
                        {
                            ActionId = 5,
                            AlphaParameters = new List<AlphaValue>
                            {
                                new AlphaValue
                                {
                                    Value = "HELP"
                                }
                            }
                        }
                    },
                    new UnconditionalStep
                    {
                        Index = 7,
                        Action = new StepAction
                        {
                            ActionId = 23,
                            AlphaParameters = new List<AlphaValue>
                            {
                                new AlphaValue
                                {
                                    Value = "HELPME"
                                }
                            }
                        }
                    },
                    new UnconditionalStep
                    {
                        Index = 9,
                        Action = new StepAction
                        {
                            ActionId = 5,
                            DecimalParameters = new List<DecimalValue>
                            {
                                new DecimalValue
                                {
                                    Value = (decimal)2.2
                                }
                            }
                        }
                    },
                    new UnconditionalStep
                    {
                        Index = 11,
                        Action = new StepAction
                        {
                            ActionId = 5,
                            DecimalParameters = new List<DecimalValue>
                            {
                                new DecimalValue
                                {
                                    Value = (decimal)2.2
                                },
                                new DecimalValue
                                {
                                    Value = (decimal)9.3
                                },
                                new DecimalValue
                                {
                                    Value = (decimal)42.01
                                }
                            }
                        }
                    }
                },
                ConditionalSteps = new[]
                {
                    new ConditionalStep
                    {
                        Index = 20,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                CompareType = CompareType.Equals,
                                FieldNumber = 5,
                                FieldType = FieldType.Line,
                                Qualifier = 78,
                                ParameterType = RecordValueType.Decimal,
                                Operation = ConditionOperation.If
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 981
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 17,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                CompareType = CompareType.Equals,
                                FieldNumber = 5,
                                FieldType = FieldType.Limit,
                                Qualifier = 78,
                                Operation = ConditionOperation.If
                            },
                            new Condition
                            {
                                CompareType = CompareType.Equals,
                                FieldNumber = 5,
                                FieldType = FieldType.Line,
                                Qualifier = 78,
                                ParameterType = RecordValueType.Decimal,
                                Operation = ConditionOperation.AndIf,
                                DecimalParameters = new List<DecimalValueWithThru>
                                {
                                    new DecimalValueWithThru
                                    {
                                        Value = (decimal)1.1,
                                        ValueThru = 99
                                    },
                                    new DecimalValueWithThru
                                    {
                                        Value = 200
                                    }
                                }
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 4987
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 18,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                CompareType = CompareType.GreaterThan,
                                FieldNumber = 9,
                                FieldType = FieldType.Accumulator,
                                Qualifier = 8,
                                ParameterType = RecordValueType.Numeric,
                                Operation = ConditionOperation.If,
                                NumericParameters = new List<NumericValueWithThru>
                                {
                                    new NumericValueWithThru
                                    {
                                        Value = 798
                                    }
                                }
                            },
                            new Condition
                            {
                                FieldType = FieldType.Line,
                                FieldNumber = 7,
                                Operation = ConditionOperation.AndIf,
                                Qualifier = 7,
                                ParameterType = RecordValueType.Alpha,
                                CompareType = CompareType.Found,
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 698
                            }
                        },
                        FalseActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 987,
                            },
                            new StepAction
                            {
                                ActionId = 924,
                                NumericParameters = new List<NumericValue>
                                {
                                    new NumericValue
                                    {
                                        Value = 789
                                    },
                                    new NumericValue
                                    {
                                        Value = 1204
                                    }
                                }
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 16,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                FieldType = FieldType.Fixed,
                                Qualifier = 1111,
                                FieldNumber = 69,
                                Operation = ConditionOperation.If,
                                ParameterType = RecordValueType.Alpha,
                                CompareType = CompareType.Equals,
                                AlphaParameters = new List<AlphaValueWithThru>
                                {
                                    new AlphaValueWithThru
                                    {
                                        Value = "happy day"
                                    }
                                }
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 364,
                                DecimalParameters = new List<DecimalValue>
                                {
                                    new DecimalValue
                                    {
                                        Value = (decimal)9.99
                                    }
                                }
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 12,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                FieldType = FieldType.KeyWord,
                                Operation = ConditionOperation.If,
                                CompareType = CompareType.Found,
                                FieldNumber = 78,
                                Qualifier = 966
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 357,
                                AlphaParameters = new List<AlphaValue>
                                {
                                    new AlphaValue
                                    {
                                        Value = "cloud"
                                    }
                                }
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 19,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                FieldType = FieldType.Calculated,
                                Operation = ConditionOperation.If,
                                Qualifier = 45,
                                CompareType = CompareType.LessThan,
                                ParameterType = RecordValueType.Numeric,
                                FieldNumber = 745,
                                NumericParameters = new List<NumericValueWithThru>
                                {
                                    new NumericValueWithThru
                                    {
                                        Value = 544
                                    },
                                    new NumericValueWithThru
                                    {
                                        Value = 744,
                                        ValueThru = 984
                                    },
                                    new NumericValueWithThru
                                    {
                                        ValueThru = 744
                                    }
                                }
                            },
                            new Condition
                            {
                                FieldType = FieldType.Line,
                                Qualifier = 7,
                                CompareType = CompareType.GreaterThanOrEqual,
                                Operation = ConditionOperation.AndIf,
                                FieldNumber = 54,
                                ParameterType = RecordValueType.Numeric
                            },
                            new Condition
                            {
                                FieldType = FieldType.CurrentLineAccumulator,
                                Operation = ConditionOperation.AndIf,
                                ParameterType = RecordValueType.Decimal,
                                FieldNumber = 74,
                                CompareType = CompareType.GreaterThanOrEqual,
                                Qualifier = 7,
                                DecimalParameters = new List<DecimalValueWithThru>
                                {
                                    new DecimalValueWithThru
                                    {
                                        Value = 6854,
                                        ValueThru = 8444
                                    },
                                    new DecimalValueWithThru
                                    {
                                        Value = 444
                                    }
                                }
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 4895,
                                DecimalParameters = new List<DecimalValue>
                                {
                                    new DecimalValue
                                    {
                                        Value = 498
                                    },
                                    new DecimalValue
                                    {
                                        Value = 466
                                    },
                                    new DecimalValue
                                    {
                                        Value = 111
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 788,
                                AlphaParameters = new List<AlphaValue>
                                {
                                    new AlphaValue
                                    {
                                        Value = "BigData"
                                    },
                                    new AlphaValue
                                    {
                                        Value = "MuchWork"
                                    },
                                    new AlphaValue
                                    {
                                        Value = "WOW"
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 654,
                            }
                        },
                        FalseActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 645,
                                NumericParameters = new List<NumericValue>
                                {
                                    new NumericValue
                                    {
                                        Value = 74
                                    },
                                    new NumericValue
                                    {
                                        Value = 744
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 9
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 5,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                FieldType = FieldType.Accumulator,
                                Operation = ConditionOperation.If,
                                CompareType = CompareType.Equals,
                                FieldNumber = 4,
                                Qualifier = 4,
                                ParameterType = RecordValueType.Numeric
                            },
                            new Condition
                            {
                                FieldType = FieldType.Fixed,
                                Operation = ConditionOperation.AndIf,
                                Qualifier = 74,
                                CompareType = CompareType.GreaterThan,
                                ParameterType = RecordValueType.Decimal,
                                FieldNumber = 7,
                                DecimalParameters = new List<DecimalValueWithThru>
                                {
                                    new DecimalValueWithThru
                                    {
                                        Value = 1
                                    },
                                    new DecimalValueWithThru
                                    {
                                        Value = 11,
                                        ValueThru = (decimal)1.1
                                    }
                                }
                            },
                            new Condition
                            {
                                FieldType = FieldType.Line,
                                Operation = ConditionOperation.OrIf,
                                FieldNumber = 77,
                                CompareType = CompareType.NotEqual,
                                ParameterType = RecordValueType.Alpha,
                                Qualifier = 1,
                                AlphaParameters = new List<AlphaValueWithThru>
                                {
                                    new AlphaValueWithThru
                                    {
                                        Value = "No One"
                                    },
                                    new AlphaValueWithThru
                                    {
                                        Value = "Can"
                                    },
                                    new AlphaValueWithThru
                                    {
                                        Value = "Stop",
                                        ValueThru = "Me"
                                    },
                                    new AlphaValueWithThru
                                    {
                                        Value = "Now"
                                    }
                                }
                            },
                            new Condition
                            {
                                FieldType = FieldType.Accumulator,
                                Operation = ConditionOperation.AndIf,
                                CompareType = CompareType.True,
                                ParameterType = RecordValueType.Decimal,
                                Qualifier = 167,
                                FieldNumber = 369
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 4563
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 8,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                FieldType = FieldType.Calculated,
                                Operation = ConditionOperation.If,
                                CompareType = CompareType.Equals,
                                ParameterType = RecordValueType.Numeric,
                                FieldNumber = 3,
                                Qualifier = 987,
                                NumericParameters = new List<NumericValueWithThru>
                                {
                                    new NumericValueWithThru
                                    {
                                        Value = 9831
                                    }
                                }
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 3
                            },
                            new StepAction
                            {
                                ActionId = 7
                            },
                            new StepAction
                            {
                                ActionId = 9
                            },
                            new StepAction
                            {
                                ActionId = 67,
                                DecimalParameters = new List<DecimalValue>
                                {
                                    new DecimalValue
                                    {
                                        Value = 2
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 43
                            },
                            new StepAction
                            {
                                ActionId = 964
                            },
                            new StepAction
                            {
                                ActionId = 123,
                                NumericParameters = new List<NumericValue>
                                {
                                    new NumericValue
                                    {
                                        Value = 1
                                    },
                                    new NumericValue
                                    {
                                        Value = 18
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 300
                            },
                            new StepAction
                            {
                                ActionId = 123
                            }
                        },
                        FalseActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 647,
                                AlphaParameters = new List<AlphaValue>
                                {
                                    new AlphaValue
                                    {
                                        Value = "FarTooBig"
                                    },
                                    new AlphaValue
                                    {
                                        Value = "Yup"
                                    },
                                    new AlphaValue
                                    {
                                        Value = "Confirmed"
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 87
                            },
                            new StepAction
                            {
                                ActionId = 687,
                                DecimalParameters = new List<DecimalValue>
                                {
                                    new DecimalValue
                                    {
                                        Value = 987
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 67
                            },
                            new StepAction
                            {
                                ActionId = 68
                            },
                            new StepAction
                            {
                                ActionId = 17
                            },
                            new StepAction
                            {
                                ActionId = 197
                            }
                        }
                    },
                    new ConditionalStep
                    {
                        Index = 10,
                        Conditions = new List<Condition>
                        {
                            new Condition
                            {
                                FieldType = FieldType.CurrentLineAccumulator,
                                CompareType = CompareType.Equals,
                                Operation = ConditionOperation.If,
                                ParameterType = RecordValueType.Decimal,
                                Qualifier = 87,
                                FieldNumber = 321,
                                DecimalParameters = new List<DecimalValueWithThru>
                                {
                                    new DecimalValueWithThru
                                    {
                                        Value = (decimal)1.1
                                    }
                                }
                            }
                        },
                        TrueActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 951
                            }
                        },
                        FalseActions = new List<StepAction>
                        {
                            new StepAction
                            {
                                ActionId = 354
                            },
                            new StepAction
                            {
                                ActionId = 542
                            },
                            new StepAction
                            {
                                ActionId = 531,
                                NumericParameters = new List<NumericValue>
                                {
                                    new NumericValue
                                    {
                                        Value = 98
                                    },
                                    new NumericValue
                                    {
                                        Value = 31
                                    },
                                    new NumericValue
                                    {
                                        Value = 75
                                    },
                                    new NumericValue
                                    {
                                        Value = 96
                                    },
                                    new NumericValue
                                    {
                                        Value = 13
                                    }
                                }
                            },
                            new StepAction
                            {
                                ActionId = 164
                            },
                            new StepAction
                            {
                                ActionId = 264
                            },
                            new StepAction
                            {
                                ActionId = 85
                            }
                        }
                    }
                },
                ExceptionSteps = new[]
                {
                    new ExceptionStep
                    {
                        Index = 2,
                        ExceptionId = 44
                    },
                    new ExceptionStep
                    {
                        Index = 6,
                        ExceptionId = 99
                    },
                    new ExceptionStep
                    {
                        Index = 14,
                        ExceptionId = 79
                    },
                    new ExceptionStep
                    {
                        Index = 15,
                        ExceptionId = 32
                    },
                }
            };
        }

        /// <summary>
        /// Gets the default request.
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static UpdateInterpDetailRequest GetDefaultRequest(ConfiguredSteps steps)
        {
            var request = new UpdateInterpDetailRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "Test",
                UserId = "Test",
                Data = new InterpDetailData
                {
                    Outline = 34,
                    Category = 340,
                    SubCategory = 20,
                    AdmitInterp = 2,
                    LineOfBusiness = LineOfBusiness.Professional,
                    CurrentStatus = InterpStatus.Test,
                    EmployeeNumber = EmployeeNumber,
                    Comment = "Test",
                    EmployeeRegion = Plan.BCBSND,
                    ConfiguredSteps = steps
                }
            };
            return request;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static string GetErrorMessage(ResponseBase result)
        {
            string errorMessage = string.Empty;
            if (result.Errors != null && result.Errors.Any())
            {
                errorMessage = string.Join(Environment.NewLine, result.Errors.Select(_ => string.Format("Prop:{0}{1}Message:{2}", _.Prop, Environment.NewLine, _.Message)));
            }

            return errorMessage;
        }
    }
}