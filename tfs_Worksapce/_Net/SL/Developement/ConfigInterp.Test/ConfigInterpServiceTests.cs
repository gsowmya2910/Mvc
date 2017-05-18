// ----------------------------------------------------------------------
// <copyright file="ConfigInterpServiceTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Bl;
    using Bl.BenefitMatrix;
    using Bl.Description;
    using Bl.Update;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Microsoft.HostIntegration.TI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using ServiceLibrary;
    using TestUtilities;

    /// <summary>
    /// The Object
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ConfigInterpServiceTests
    {
        /// <summary>
        /// Analyses the duplicate indexes.
        /// </summary>
        [TestMethod]
        public void AnalyseDuplicateIndexes()
        {
            var handler = new UpdateMock
            {
                UpdateResult = new UpdateResult
                {
                    MessageNumber = 0,
                    MessageText = "FakeSucceed",
                    Result = OperationResult.Success
                }
            };
            var service = new ConfigInterpService(new Validation(), null, handler, null, null, null, null, new Converter(new StepConverter()));

            var request = new UpdateInterpDetailRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "Test",
                UserId = "Test",
                Data = new InterpDetailData
                {
                    AdmitInterp = 2,
                    Category = 340,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Outline = 34,
                    CurrentStatus = InterpStatus.Draft,
                    EmployeeNumber = 1,
                    Comment = "Test",
                    SubCategory = 20,
                    EmployeeRegion = Plan.BCBSND,
                    ConfiguredSteps = new ConfiguredSteps
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
                    }
                }
            };
            var result = service.UpdateInterpConfig(request);

            Assert.AreEqual(ResponseStatus.Success, result.Status);
            TestDump.OutputDataCsv(handler.PassedUpdateData, "FullDrop");
            TestDump.OutputDataCsv(handler.PassedUpdateData.Steps, "AnalyseDuplicateIndeces");
        }

        /// <summary>
        /// Gets the category description bad header test.
        /// </summary>
        [TestMethod]
        public void GetCategoryDescriptionBadHeaderTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetCategoryDescription(new CategoryRequest());
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(4, response.Errors.Count);
        }

        /// <summary>
        /// Gets the category description failure test.
        /// </summary>
        [TestMethod]
        public void GetCategoryDescriptionFailureTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Failed,
                    Exception = new CustomTIException("fake".PadRight(11))
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));
            var request = new CategoryRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new CategoryData
                {
                    Category = 1,
                    Outline = 1
                }
            };
            var response = service.GetCategoryDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the category description null test.
        /// </summary>
        [TestMethod]
        public void GetCategoryDescriptionNullTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetCategoryDescription(null);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the category description success test.
        /// </summary>
        [TestMethod]
        public void GetCategoryDescriptionSuccessTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Success,
                    Value = "Example"
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));
            var request = new CategoryRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new CategoryData
                {
                    Category = 1,
                    Outline = 1
                }
            };
            var response = service.GetCategoryDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.AreEqual(0, response.Errors.Count);
            Assert.AreEqual("Example", response.Description);
        }

        /// <summary>
        /// Gets the interp bad header test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void GetInterpBadHeaderTest()
        {
            var service = new ConfigInterpService(new Validation(), new InquireMock(), null, null, null, null, null, new Converter(null));
            var response = service.GetInterp(new InquireRequest());
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(4, response.Errors.Count);
        }

        /// <summary>
        /// Gets the interp failure test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void GetInterpFailureTest()
        {
            var inquireMock = new InquireMock
            {
                InquireDataResultBase = new MockSimpleInquireResult
                {
                    Result = OperationResult.Failed,
                    Exception = new CustomTIException()
                }
            };
            var service = new ConfigInterpService(new Validation(), inquireMock, null, null, null, null, null, new Converter(null));
            var request = new InquireRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new InquireInputData
                {
                    AdmitInterp = 1,
                    Category = 1,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Outline = 1,
                    Status = InterpStatus.DraftRevision,
                    SubCategory = 1
                }
            };
            var response = service.GetInterp(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the interp null test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void GetInterpNullTest()
        {
            var service = new ConfigInterpService(new Validation(), new InquireMock(), null, null, null, null, null, new Converter(null));
            var response = service.GetInterp(null);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the interp success test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void GetInterpSuccessTest()
        {
            var inquireMock = new InquireMock
            {
                InquireDataResultBase = new MockSimpleInquireResult
                {
                    Result = OperationResult.Success,
                    AdmitInterp = 1,
                    Category = 1,
                    Comment = "Comment",
                    CreateByRevision = 1,
                    CurrentStatus = InterpStatus.DraftRevision,
                    EmployeeNumber = 1,
                    EmployeeRegion = Plan.BCBSND,
                    Level = 1,
                    MessageNumber = 1,
                    MessageText = "Text",
                    Outline = 1,
                    RevisionNumber = 1,
                    RevisionSequence = 1,
                    StatusDateTime = DateTime.Today,
                    StepCount = 1,
                    SubCategory = 1,
                    SystemType = LineOfBusiness.Professional,
                    Success = true
                }
            };
            var service = new ConfigInterpService(new Validation(), inquireMock, null, null, null, null, null, new Converter(null));
            var request = new InquireRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new InquireInputData
                {
                    AdmitInterp = 1,
                    Category = 1,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Outline = 1,
                    Status = InterpStatus.DraftRevision,
                    SubCategory = 1
                }
            };
            var response = service.GetInterp(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.AreEqual(0, response.Errors.Count);
            Assert.IsNotNull(response.Data);
        }

        /// <summary>
        /// Gets the level description bad header test.
        /// </summary>
        [TestMethod]
        public void GetLevelDescriptionBadHeaderTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetLevelDescription(new LevelRequest());
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(4, response.Errors.Count);
        }

        /// <summary>
        /// Gets the level description failure test.
        /// </summary>
        [TestMethod]
        public void GetLevelDescriptionFailureTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Failed,
                    Exception = new CustomTIException("fake".PadRight(11))
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));

            var request = new LevelRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new LevelData
                {
                    LineOfBusiness = LineOfBusiness.Institutional,
                    Outline = 1
                }
            };
            var response = service.GetLevelDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the level description null test.
        /// </summary>
        [TestMethod]
        public void GetLevelDescriptionNullTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetLevelDescription(null);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the level description success test.
        /// </summary>
        [TestMethod]
        public void GetLevelDescriptionSuccessTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Success,
                    Value = "Example"
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));

            var request = new LevelRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new LevelData
                {
                    LineOfBusiness = LineOfBusiness.Institutional,
                    Outline = 1
                }
            };
            var response = service.GetLevelDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.AreEqual(0, response.Errors.Count);
            Assert.AreEqual("Example", response.Description);
        }

        /// <summary>
        /// Gets the Outline description bad header test.
        /// </summary>
        [TestMethod]
        public void GetOutlineDescriptionBadHeaderTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetOutlineDescription(new OutlineRequest());
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(4, response.Errors.Count);
        }

        /// <summary>
        /// Gets the Outline description failure test.
        /// </summary>
        [TestMethod]
        public void GetOutlineDescriptionFailureTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Failed,
                    Exception = new CustomTIException("fake".PadRight(11))
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));

            var request = new OutlineRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new OutlineData
                {
                    Outline = 1
                }
            };
            var response = service.GetOutlineDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the Outline description null test.
        /// </summary>
        [TestMethod]
        public void GetOutlineDescriptionNullTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetOutlineDescription(null);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the Outline description success test.
        /// </summary>
        [TestMethod]
        public void GetOutlineDescriptionSuccessTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Success,
                    Value = "Example"
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));

            var request = new OutlineRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new OutlineData
                {
                    Outline = 1
                }
            };
            var response = service.GetOutlineDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.AreEqual(0, response.Errors.Count);
            Assert.AreEqual("Example", response.Description);
        }

        /// <summary>
        /// Gets the sub category description bad header test.
        /// </summary>
        [TestMethod]
        public void GetSubCategoryDescriptionBadHeaderTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetSubCategoryDescription(new SubCategoryRequest());
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(4, response.Errors.Count);
        }

        /// <summary>
        /// Gets the sub category description failure test.
        /// </summary>
        [TestMethod]
        public void GetSubCategoryDescriptionFailureTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Failed,
                    Exception = new CustomTIException("fake".PadRight(11))
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));

            var request = new SubCategoryRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new SubCategoryData
                {
                    Category = 1,
                    SubCategory = 1,
                    Outline = 1
                }
            };
            var response = service.GetSubCategoryDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the sub category description null test.
        /// </summary>
        [TestMethod]
        public void GetSubCategoryDescriptionNullTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, null, new DescriptionMock(), null, new Converter(null));
            var response = service.GetSubCategoryDescription(null);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Gets the sub category description success test.
        /// </summary>
        [TestMethod]
        public void GetSubCategoryDescriptionSuccessTest()
        {
            var descriptionMock = new DescriptionMock
            {
                DataResult = new DataResult
                {
                    Result = OperationResult.Success,
                    Value = "Example"
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, null, descriptionMock, null, new Converter(null));

            var request = new SubCategoryRequest
            {
                Region = 1,
                ApplicationId = "Application",
                CorrespondenceLocation = "core",
                UnisysUsercode = "user",
                UserId = "user",
                Data = new SubCategoryData
                {
                    Category = 1,
                    SubCategory = 1,
                    Outline = 1
                }
            };
            var response = service.GetSubCategoryDescription(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.AreEqual(0, response.Errors.Count);
            Assert.AreEqual("Example", response.Description);
        }

        /// <summary>
        /// Updates the interp narrative bad data test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpNarrativeBadDataTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, new MockBenefitMatrix(), null, null, new Converter(null));

            var request = new UpdateInterpRequest();
            var response = service.UpdateInterpNarrative(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(4, response.Errors.Count);
        }

        /// <summary>
        /// Updates the interp narrative failed due to exception test.
        /// </summary>
        [TestMethod]
        [Ignore]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpNarrativeFailedDueToExceptionTest()
        {
            var mockBenefitMatrix = new MockBenefitMatrix
            {
                CompletionResult = new CompletionResult
                {
                    Result = OperationResult.Failed,
                    Exception = new Exception("Test")
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, mockBenefitMatrix, null, null, new Converter(null));

            var request = new UpdateInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "Test",
                UserId = "Test",
                Data = new UpdateInterpNarrativeData
                {
                    SubCategory = 1,
                    Category = 1,
                    Status = Status.Maintenance,
                    Outline = 1,
                    AdmitInterp = 1,
                    LineOfBusiness = LineOfBusiness.Institutional,
                    NarrativeLines = new[] { "Test" }
                }
            };
            var response = service.UpdateInterpNarrative(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Updates the interp narrative failed due to response test.
        /// </summary>
        [TestMethod]
        [Ignore]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpNarrativeFailedDueToResponseTest()
        {
            var mockBenefitMatrix = new MockBenefitMatrix
            {
                CompletionResult = new CompletionResult
                {
                    Result = OperationResult.Success,
                    MessageNumber = 1,
                    MessageText = "Test"
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, mockBenefitMatrix, null, null, new Converter(null));

            var request = new UpdateInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "Test",
                UserId = "Test",
                Data = new UpdateInterpNarrativeData
                {
                    SubCategory = 1,
                    Category = 1,
                    Status = Status.Maintenance,
                    Outline = 1,
                    AdmitInterp = 1,
                    LineOfBusiness = LineOfBusiness.Institutional,
                    NarrativeLines = new[] { "Test" }
                }
            };
            var response = service.UpdateInterpNarrative(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Failure, response.Status);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Updates the interp narrative null test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpNarrativeNullTest()
        {
            var service = new ConfigInterpService(new Validation(), null, null, null, new MockBenefitMatrix(), null, null, new Converter(null));
            var response = service.UpdateInterpNarrative(null);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.IsNotNull(response.Errors);
            Assert.AreEqual(1, response.Errors.Count);
        }

        /// <summary>
        /// Updates the interp narrative rejected test.
        /// </summary>
        [TestMethod]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpNarrativeRejectedTest()
        {
            var mockBenefitMatrix = new MockBenefitMatrix
            {
                CompletionResult = new CompletionResult
                {
                    MessageNumber = 0,
                    Result = OperationResult.Success
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, mockBenefitMatrix, null, null, new Converter(null));

            var request = new UpdateInterpRequest
            {
                Region = 0,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "Test",
                UserId = "Test",
                Data = null
            };
            var response = service.UpdateInterpNarrative(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Rejected, response.Status);
            Assert.AreEqual(2, response.Errors.Count);
        }

        /// <summary>
        /// Updates the interp narrative success test.
        /// </summary>
        [TestMethod]
        [Ignore]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public void UpdateInterpNarrativeSuccessTest()
        {
            var mockBenefitMatrix = new MockBenefitMatrix
            {
                CompletionResult = new CompletionResult
                {
                    MessageNumber = 0,
                    Result = OperationResult.Success
                }
            };
            var service = new ConfigInterpService(new Validation(), null, null, null, mockBenefitMatrix, null, null, new Converter(null));

            var request = new UpdateInterpRequest
            {
                Region = 1,
                ApplicationId = "Test",
                CorrespondenceLocation = "Test",
                UnisysUsercode = "Test",
                UserId = "Test",
                Data = new UpdateInterpNarrativeData
                {
                    SubCategory = 1,
                    Category = 1,
                    Status = Status.Maintenance,
                    Outline = 1,
                    AdmitInterp = 1,
                    LineOfBusiness = LineOfBusiness.Institutional,
                    NarrativeLines = new[] { "Test" }
                }
            };
            var response = service.UpdateInterpNarrative(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseStatus.Success, response.Status);
            Assert.AreEqual(0, response.Errors.Count);
        }
    }
}