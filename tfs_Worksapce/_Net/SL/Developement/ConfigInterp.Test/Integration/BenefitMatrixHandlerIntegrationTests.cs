// ----------------------------------------------------------------------
// <copyright file="BenefitMatrixHandlerIntegrationTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test.Integration
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Bl;
    using Bl.BenefitMatrix;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Microsoft.HostIntegration.TI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ServiceLibrary;

    /// <summary>
    /// tThe class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BenefitMatrixHandlerIntegrationTests
    {
        /// <summary>
        /// The interp value
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        private const short AdmitInterp = 14;

        /// <summary>
        /// The blue user
        /// </summary>
        private const string BlueUser = "id16823";

        /// <summary>
        /// The category
        /// </summary>
        private const short Category = 180;

        /// <summary>
        /// The fake interp number
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        private const short FakeInterpNumber = 1234;

        /// <summary>
        /// The level
        /// </summary>
        private const short Level = 23;

        /// <summary>
        /// The Outline
        /// </summary>
        private const short Outline = 34;

        /// <summary>
        /// The region
        /// </summary>
        private const short Region = 1;

        /// <summary>
        /// The sub category
        /// </summary>
        private const short SubCategory = 1;

        /// <summary>
        /// The Unisys user
        /// </summary>
        private const string UnisysUser = "CL168236821";

        /// <summary>
        /// Creates the inquire delete narrative test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void CreateInquireDeleteNarrativeTest()
        {
            var matrix = new BenefitMatrixHandler();
            DeleteIfThere(matrix, FakeInterpNumber);
            var interp = new Interp
            {
                Outline = Outline,
                Category = Category,
                SubCategory = SubCategory,
                Level = Level,
                AdmitInterp = FakeInterpNumber
            };
            var change = new BenefitMatrixCreateInput
            {
                BlueUser = BlueUser,
                Region = Region,
                Interp = interp,
                MainframeUsercode = UnisysUser,
            };
            var createResult = matrix.CreateNarrative(change);
            Assert.AreEqual(OperationResult.Success, createResult.Result);
            Assert.AreEqual(0, createResult.MessageNumber, createResult.MessageText);

            var input = new BenefitMatrixInqureInput
            {
                BlueUser = BlueUser,
                Interp = interp,
                Region = Region,
                MainframeUsercode = UnisysUser,
                Status = Status.Maintenance
            };
            var inquireResult = matrix.InquireNarrative(input);
            Assert.AreEqual(OperationResult.Success, inquireResult.Result);
            Assert.AreEqual(0, inquireResult.MessageNumber, inquireResult.MessageText);

            var matrixChange = new BenefitMatrixDeleteInput
            {
                BlueUser = BlueUser,
                Interp = interp,
                Region = Region,
                MainframeUsercode = UnisysUser,
                Status = Status.Maintenance
            };
            var deleteResult = matrix.DeleteNarrative(matrixChange);
            Assert.AreEqual(OperationResult.Success, deleteResult.Result);
            Assert.AreEqual(0, deleteResult.MessageNumber, deleteResult.MessageText);
        }

        /// <summary>
        /// Inquires the bad edge case for status default to active2.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireBadEdgeCaseForInterpNotFound()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.Active,
                BlueUser = BlueUser,
                Interp = new Interp
                {
                    Outline = 34,
                    Category = 080,
                    SubCategory = 000,
                    AdmitInterp = 0226,
                    Level = 13
                },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Inquires the bad edge case for status.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireBadEdgeCaseForStatus()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.Active,
                BlueUser = BlueUser,
                Interp = new Interp { Outline = 34, Category = 260, SubCategory = 000, AdmitInterp = 0050, Level = 13 },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Inquires the bad edge case for status default to active.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireBadEdgeCaseForStatusDefaultToActive()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.Active,
                BlueUser = BlueUser,
                Interp = new Interp { Outline = 34, Category = 180, SubCategory = 001, AdmitInterp = 14, Level = 23 },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Inquires the bad edge case for status default to active2.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireBadEdgeCaseForStatusDefaultToActive2()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.Active,
                BlueUser = BlueUser,
                Interp = new Interp { Outline = 34, Category = 180, SubCategory = 001, AdmitInterp = 14, Level = 23 },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Inquires the many proper edge cases.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1012:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void InquireManyProperEdgeCases()
        {
            var items = new[]
            {
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 180, SubCategory = 001, AdmitInterp = 0014, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 01, Category = 001, SubCategory = 000, AdmitInterp = 0002, Level = 23 }, Status.Revision),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 560, SubCategory = 004, AdmitInterp = 0007, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 01, Category = 001, SubCategory = 000, AdmitInterp = 0002, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 080, SubCategory = 000, AdmitInterp = 0226, Level = 13 }, Status.Maintenance),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 080, SubCategory = 001, AdmitInterp = 0007, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 340, SubCategory = 020, AdmitInterp = 0002, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 01, Category = 001, SubCategory = 000, AdmitInterp = 0001, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 120, SubCategory = 012, AdmitInterp = 0100, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 240, SubCategory = 015, AdmitInterp = 0001, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 100, SubCategory = 000, AdmitInterp = 0146, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 01, Category = 031, SubCategory = 036, AdmitInterp = 0011, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 260, SubCategory = 000, AdmitInterp = 0050, Level = 13 }, Status.Revision),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 155, SubCategory = 015, AdmitInterp = 0001, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 080, SubCategory = 011, AdmitInterp = 0002, Level = 23 }, Status.Active),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 180, SubCategory = 001, AdmitInterp = 0014, Level = 23 }, Status.Revision),
                new Tuple<Interp, Status>(new Interp { Outline = 34, Category = 260, SubCategory = 000, AdmitInterp = 0050, Level = 13 }, Status.Active)
            };
            var inputs = items.Select(_ => new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = _.Item2,
                BlueUser = BlueUser,
                Interp = _.Item1,
                MainframeUsercode = UnisysUser
            }).ToArray();
            var matrix = new BenefitMatrixHandler();

            foreach (var input in inputs)
            {
                var result = matrix.InquireNarrative(input);
                Assert.IsTrue(result.Success);
                Assert.AreEqual(OperationResult.Success, result.Result, ((Interp)input.Interp).DebugDisplay);
            }
        }

        /// <summary>
        /// Inquires the narrative test.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeTest()
        {
            var matrix = new BenefitMatrixHandler();

            var input = new BenefitMatrixInqureInput
            {
                BlueUser = BlueUser,
                Interp = new Interp
                {
                    Category = Category,
                    AdmitInterp = AdmitInterp,
                    SubCategory = SubCategory,
                    Level = Level,
                    Outline = Outline
                },
                Region = Region,
                MainframeUsercode = UnisysUser,
                Status = Status.Active
            };
            var result = matrix.InquireNarrative(input);

            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Inquires the Narrative record should exist.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldExist()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.None,
                BlueUser = BlueUser,
                Interp = new Interp
                {
                    Outline = 34,
                    Category = 120,
                    SubCategory = 900,
                    AdmitInterp = 0001,
                    Level = 23
                },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(OperationResult.NotFound, result.Result);
        }

        /// <summary>
        /// Inquires the Narrative record should exist.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldExist2()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.Maintenance,
                BlueUser = BlueUser,
                Interp = new Interp
                {
                    Outline = 34,
                    Category = 120,
                    SubCategory = 900,
                    AdmitInterp = 0001,
                    Level = 23
                },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(OperationResult.NotFound, result.Result);
        }

        /// <summary>
        /// Inquires the Narrative record should exist stack.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldExistStack()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, new BenefitMatrixHandler(), null, null, new Converter(null));
            var response = service.InquireInterpNarrative(new InquireInterpRequest
                 {
                     Region = Region,
                     UserId = BlueUser,
                     UnisysUsercode = UnisysUser,
                     ApplicationId = "UnitTest",
                     CorrespondenceLocation = "Test",
                     Data = new InquireInterpNarrativeData
                     {
                         Outline = 34,
                         Category = 120,
                         SubCategory = 900,
                         AdmitInterp = 0001,
                         LineOfBusiness = LineOfBusiness.Professional,
                         Status = Status.Maintenance
                     }
                 });

            Assert.AreEqual(OperationResult.NotFound, response.FailureReason);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
        }

        /// <summary>
        /// Inquires the Narrative record should exist stack.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldExistStack2()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, new BenefitMatrixHandler(), null, null, new Converter(null));
            var response = service.InquireInterpNarrative(new InquireInterpRequest
            {
                Region = Region,
                UserId = BlueUser,
                UnisysUsercode = UnisysUser,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Data = new InquireInterpNarrativeData
                {
                    Outline = 34,
                    Category = 120,
                    SubCategory = 900,
                    AdmitInterp = 0001,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.None
                }
            });

            Assert.AreEqual(OperationResult.None, response.FailureReason);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
        }

        /// <summary>
        /// Inquires the Narrative record should exist stack.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldExistStack3()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, new BenefitMatrixHandler(), null, null, new Converter(null));
            var response = service.InquireInterpNarrative(new InquireInterpRequest
            {
                Region = Region,
                UserId = BlueUser,
                UnisysUsercode = UnisysUser,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Data = new InquireInterpNarrativeData
                {
                    Outline = 34,
                    Category = 180,
                    SubCategory = 900,
                    AdmitInterp = 0001,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.Maintenance
                }
            });

            Assert.AreEqual(OperationResult.None, response.FailureReason);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
        }

        /// <summary>
        /// Inquires the Narrative record should exist stack.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldExistStack4()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, new BenefitMatrixHandler(), null, null, new Converter(null));
            var response = service.InquireInterpNarrative(new InquireInterpRequest
            {
                Region = Region,
                UserId = BlueUser,
                UnisysUsercode = UnisysUser,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Data = new InquireInterpNarrativeData
                {
                    Outline = 34,
                    Category = 180,
                    SubCategory = 900,
                    AdmitInterp = 0001,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.None
                }
            });

            Assert.AreEqual(OperationResult.AlreadyExists, response.FailureReason);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
        }

        /// <summary>
        /// Inquires the Narrative record should exist stack.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldExistStack5()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, new BenefitMatrixHandler(), null, null, new Converter(null));
            var response = service.InquireInterpNarrative(new InquireInterpRequest
            {
                Region = Region,
                UserId = BlueUser,
                UnisysUsercode = UnisysUser,
                ApplicationId = "UnitTest",
                CorrespondenceLocation = "Test",
                Data = new InquireInterpNarrativeData
                {
                    Outline = 34,
                    Category = 180,
                    SubCategory = 900,
                    AdmitInterp = 0002,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.None
                }
            });

            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.AreEqual(OperationResult.None, response.FailureReason);
        }

        /// <summary>
        /// Inquires the Narrative record shouldn't exist.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldNotExist()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.None,
                BlueUser = BlueUser,
                Interp = new Interp
                {
                    Outline = 34,
                    Category = 180,
                    SubCategory = 900,
                    AdmitInterp = 0001,
                    Level = 23
                },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(OperationResult.AlreadyExists, result.Result);
        }

        /// <summary>
        /// Inquires the Narrative record shouldn't exist.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void InquireNarrativeRecordShouldNotExist2()
        {
            var input = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.Maintenance,
                BlueUser = BlueUser,
                Interp = new Interp
                {
                    Outline = 34,
                    Category = 180,
                    SubCategory = 900,
                    AdmitInterp = 0001,
                    Level = 23
                },
                MainframeUsercode = UnisysUser
            };

            var matrix = new BenefitMatrixHandler();

            var result = matrix.InquireNarrative(input);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        /// <summary>
        /// Updates the interp narrative large data success test.
        /// </summary>
        [TestCategory("Integration")]
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [SuppressMessage("ReSharper", "EmptyGeneralCatchClause", Justification = "Legacy code")]
        public void UpdateInterpNarrativeLargeDataSuccessTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, null, new WorkflowManager(new BenefitMatrixHandler(), null, null), new Converter(null));

            var request = new UpdateInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = UnisysUser,
                UserId = BlueUser,
                Data = new UpdateInterpNarrativeData
                {
                    Outline = 34,
                    Category = 120,
                    SubCategory = 1,
                    AdmitInterp = 7000,
                    Status = Status.Maintenance,
                    LineOfBusiness = LineOfBusiness.Professional,
                    NarrativeLines = Enumerable.Range(1, 250).Select(_ => string.Format("Test Line : {0}", _)).ToArray()
                }
            };
            var response = service.UpdateInterpNarrative(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status, GetErrorMessage(response));
        }

        /// <summary>
        /// Updates the narrative returned nothing.
        /// </summary>
        [TestMethod]
        [TestCategory("Integration")]
        public void UpdateNarrativeReturnedNothing()
        {
            var matrix = new BenefitMatrixHandler();
            var interp = new Interp
            {
                Outline = 34,
                Category = 560,
                SubCategory = 4,
                AdmitInterp = 1,
                Level = 23
            };
            var input = new BenefitMatrixChange
            {
                BlueUser = BlueUser,
                Interp = interp,
                MainframeUsercode = UnisysUser,
                Narrative = new[]
                {
                    "This is only a Test",
                    "Test text only",
                    "Testing is so much fun"
                },
                Region = 1,
                Status = Status.Maintenance
            };

            var result = matrix.UpdateNarrative(input);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(OperationResult.Success, result.Result);

            var inqureInput = new BenefitMatrixInqureInput
            {
                Region = Region,
                Status = Status.Maintenance,
                BlueUser = BlueUser,
                Interp = interp,
                MainframeUsercode = UnisysUser
            };
            var inquireResult = matrix.InquireNarrative(inqureInput);

            Assert.IsTrue(inquireResult.Success);
            Assert.AreEqual(OperationResult.Success, inquireResult.Result);
        }

        /// <summary>
        /// Deletes if there.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="interpNumber">The interp number.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        private static void DeleteIfThere(BenefitMatrixHandler matrix, short interpNumber)
        {
            var matrixChange = new BenefitMatrixDeleteInput
            {
                BlueUser = BlueUser,
                Interp = new Interp
                {
                    Category = Category,
                    AdmitInterp = interpNumber,
                    SubCategory = SubCategory,
                    Level = Level,
                    Outline = Outline
                },
                Region = Region,
                MainframeUsercode = UnisysUser,
                Status = Status.Maintenance
            };
            var result = matrix.DeleteNarrative(matrixChange);

            if (result.Result == OperationResult.Failed)
            {
                var exception = result.Exception as CustomTIException;
                if (exception != null)
                {
                    StringAssert.Contains(exception.TIExceptionMsgId, "1521", result.Exception.Message);
                }
            }

            if (OperationResult.Success == result.Result)
            {
                Assert.AreEqual(0, result.MessageNumber, result.MessageText);
            }
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