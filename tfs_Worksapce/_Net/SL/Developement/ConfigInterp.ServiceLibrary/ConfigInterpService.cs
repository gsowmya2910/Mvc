// <copyright file="ConfigInterpService.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.ServiceLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.ServiceModel.Activation;
    using Bl;
    using Bl.BenefitMatrix;
    using Bl.Interfaces;
    using Bl.Update;
    using Contracts;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Microsoft.Practices.Unity;
    using Sql;

    /// <summary>
    /// Implementation for the Name Inquiry service
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.IConfigInterpService" />
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ConfigInterpService : IConfigInterpService
    {
        /// <summary>
        /// The benefit matrix
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly IBenefitMatrixHandler _benefitMatrix;

        /// <summary>
        /// The Cip Inquire
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly ICipInquireHandler _cipInquire;

        /// <summary>
        /// The Cip update
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly ICipUpdateHandler _cipUpdate;

        /// <summary>
        /// The converter
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly IConverter _converter;

        /// <summary>
        /// SQL handler update
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly IConfigInterpSqlHandler _configInterpSql;

        /// <summary>
        /// The description master
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly IDescriptionMasterHandler _descriptionMaster;

        /// <summary>
        /// The flow manager
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly IWorkflowManager _flowManager;

        /// <summary>
        /// The validation
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly IValidation _validation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigInterpService" /> class.
        /// </summary>
        /// <param name="validation">The validation.</param>
        /// <param name="cipInquire">The cip inquire.</param>
        /// <param name="cipUpdate">The cip update.</param>
        /// <param name="configInterpSql">The configuration interp SQL.</param>
        /// <param name="benefitMatrix">The benefit matrix.</param>
        /// <param name="descriptionMaster">The description master.</param>
        /// <param name="flowManager">The flow manager</param>
        /// <param name="converter">The converter.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [InjectionConstructor]
        public ConfigInterpService(IValidation validation, ICipInquireHandler cipInquire, ICipUpdateHandler cipUpdate, IConfigInterpSqlHandler configInterpSql, IBenefitMatrixHandler benefitMatrix, IDescriptionMasterHandler descriptionMaster, IWorkflowManager flowManager, IConverter converter)
        {
            this._validation = validation;
            this._cipInquire = cipInquire;
            this._cipUpdate = cipUpdate;
            this._configInterpSql = configInterpSql;
            this._benefitMatrix = benefitMatrix;
            this._descriptionMaster = descriptionMaster;
            this._flowManager = flowManager;
            this._converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigInterpService"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        internal ConfigInterpService(DependanciesForService input)
            : this(input.Validation, input.Inquire, input.Update, input.Sql, input.BenefitMatrix, input.DescriptionMaster, input.Workflow, input.Converter)
        {
        }

        /// <summary>
        /// This service creates the Outline 23 narrative record for the source interp, then inquires on the target interp, then returns the configuration information with the target interp
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public DetailedInterpResponse CloneInterp(CloneInterpRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DetailedInterpResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    ICloneInterpData value = this._converter.Perform(request);
                    var result = this._flowManager.CloneInterp(value);

                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Data = this._converter.Perform(result);
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Creates the interp narrative.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public InterpNarrativeResponse CreateInterpNarrative(CreateInterpRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new InterpNarrativeResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    IBenefitMatrixCreateInput value = this._converter.Convert(request);
                    var result = this._benefitMatrix.CreateNarrative(value);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Deletes an interp
        /// </summary>
        /// <param name="request">a delete request</param>
        /// <returns>a delete response</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public ChangeInterpResultResponse DeleteInterp(DeleteCipInterpRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new ChangeInterpResultResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors) && this._validation.AllowedAction(request.Data, errors))
                {
                    IDeleteInterpIntialData value = this._converter.Convert(request);
                    var result = this._flowManager.DeleteInterp(value);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Deletes the interp narrative.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public InterpNarrativeResponse DeleteInterpNarrative(DeleteInterpRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new InterpNarrativeResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors) && this._validation.AllowedAction(request.Data, errors))
                {
                    IBenefitMatrixNarrativeDeleteable value = this._converter.Convert(request);
                    var result = this._benefitMatrix.DeleteNarrative(value);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the action description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>action list</returns>
        public DescriptionCommonResponse GetActionDescription(ListRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionCommonResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetActionDescription(request.LineOfBusiness, request.Id);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Descriptions = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the parameter response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>validation info</returns>
        public ActionParameterDescriptionValidationInfoResponse GetActionParameterDescriptionValidationInfo(ListRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new ActionParameterDescriptionValidationInfoResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetActionParameterDescriptionAndValidationInfo(request.LineOfBusiness, request.Id);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Data = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the action type description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>system request</returns>
        public DescriptionCommonResponse GetActionTypeDescription(SystemTypeRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionCommonResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetActionTypeDescription(request.LineOfBusiness);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Descriptions = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the Outline categories.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Outline list</returns>
        public AvailableOutlineCategoryResponse GetAvailableOutlineCategory(OutlineCategoryListRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new AvailableOutlineCategoryResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.AvailableOutlineCategory(request.LineOfBusiness, request.OutlineId, request.CategoryId);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Data = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the category description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DescriptionResponse GetCategoryDescription(CategoryRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionResponse
            {
                Errors = errors
            };

            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    var result = this._descriptionMaster.GetCategoryDescription(request.Data.Outline, request.Data.Category, (short)request.Region);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Description = result.Value;
                        response.Status = ResponseStatus.Success;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the compare description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value list
        /// </returns>
        public DescriptionCommonResponse GetCompareTypeDescription(ListRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionCommonResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetCompareTypeDescription(request.LineOfBusiness, request.Id);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Descriptions = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the condition type description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DescriptionCommonResponse GetConditionTypeDescription(DefaultRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionCommonResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors))
                {
                    var result = this._configInterpSql.GetConditionTypeDescription();
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Descriptions = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the exception description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The system type
        /// </returns>
        public DescriptionCommonResponse GetExceptionDescription(SystemTypeRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionCommonResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetExceptionDescription(request.LineOfBusiness);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Descriptions = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the field name description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The list
        /// </returns>
        public FieldNameResponse GetFieldNameDescription(ListRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new FieldNameResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetFieldNameDescription(request.LineOfBusiness, request.Id);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Descriptions = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the field type description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DescriptionCommonResponse GetFieldTypeDescription(SystemTypeRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionCommonResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetFieldTypeDescription(request.LineOfBusiness);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Descriptions = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the field validation info.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>field list</returns>
        public FieldValidationInfoResponse GetFieldValidationInfo(FieldValidationInfoRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new FieldValidationInfoResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request, errors))
                {
                    var result = this._configInterpSql.GetFieldValidationInfo(request.LineOfBusiness, request.TypeId, request.FieldId);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Status = ResponseStatus.Success;
                        response.Data = result.Data;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the interp.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public SimpleInterpResponse GetInterp(InquireRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new SimpleInterpResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    IInquireInput input = this._converter.Convert(request);

                    var result = this._cipInquire.InquireSimpleData(input);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Data = this._converter.Perform(result);
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                            response.FailureReason = result.Result;
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the interp detail.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public DetailedInterpResponse GetInterpDetail(InquireRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DetailedInterpResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    IInquireInput input = this._converter.Convert(request);

                    var result = this._cipInquire.InquireInterpDetail(input);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Data = this._converter.Perform(result);
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                            response.FailureReason = result.Result;
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the level description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DescriptionResponse GetLevelDescription(LevelRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionResponse
            {
                Errors = errors
            };

            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    var result = this._descriptionMaster.GetLevelDescription(request.Data.Outline, request.Data.LineOfBusiness.NarrativeType(), (short)request.Region);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Description = result.Value;
                        response.Status = ResponseStatus.Success;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the Outline description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DescriptionResponse GetOutlineDescription(OutlineRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionResponse
            {
                Errors = errors
            };

            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    var result = this._descriptionMaster.GetOutlineDescription(request.Data.Outline, (short)request.Region);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Description = result.Value;
                        response.Status = ResponseStatus.Success;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Gets the sub category description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DescriptionResponse GetSubCategoryDescription(SubCategoryRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new DescriptionResponse
            {
                Errors = errors
            };

            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    var result = this._descriptionMaster.GetSubCategoryDescription(request.Data.Outline, request.Data.Category, request.Data.SubCategory, (short)request.Region);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        response.Description = result.Value;
                        response.Status = ResponseStatus.Success;
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Inquires the interp narrative.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public InquireInterpResponse InquireInterpNarrative(InquireInterpRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new InquireInterpResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors))
                {
                    IBenefitMatrixNarrativeInquireable value = this._converter.Convert(request);
                    var result = this._benefitMatrix.InquireNarrative(value);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else
                    {
                        if (result.Success)
                        {
                            if (request.Data.Status == Status.None)
                            {
                                response.Status = ResponseStatus.Success;
                            }
                            else
                            {
                                response.Status = ResponseStatus.Success;
                                response.Data = this._converter.Convert(result.Narrative);
                            }
                        }
                        else
                        {
                            if (request.Data.Status == Status.None && result.Result == OperationResult.NotFound)
                            {
                                response.Status = ResponseStatus.Success;
                            }
                            else
                            {
                                response.Status = ResponseStatus.Failure;
                                errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                                response.FailureReason = result.Result;
                            }
                        }
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Updates the interp configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public ChangeInterpResultResponse UpdateInterpConfig(UpdateInterpDetailRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new ChangeInterpResultResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors) && this._validation.AllowedAction(request.Data, errors))
                {
                    IUpdateInterp value = this._converter.Convert(request);
                    var result = this._cipUpdate.UpdateInterp(value);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Updates the interp narrative.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public InterpNarrativeResponse UpdateInterpNarrative(UpdateInterpRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new InterpNarrativeResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors) && this._validation.AllowedAction(request.Data, errors))
                {
                    IBenefitMatrixChangeable value = this._converter.Convert(request);

                    CompletionResult result = this._flowManager.UpdateNarrative(value);
                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Updates the interp status.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public ChangeInterpResultResponse UpdateInterpStatus(StatusChangeRequest request)
        {
            var errors = new List<ErrorItem>();
            var response = new ChangeInterpResultResponse
            {
                Errors = errors
            };
            if (this._validation.HasRequest(request, errors))
            {
                if (this._validation.HasHeaderValues(request, errors) & this._validation.HasData(request.Data, errors) &&
                    this._validation.AllowedAction(request.Data, errors))
                {
                    IStatusChangeData value = this._converter.Convert(request);
                    var result = this._flowManager.UpdateStatus(value);

                    if (result.Result == OperationResult.Failed)
                    {
                        response.Status = ResponseStatus.Failure;
                        ErrorForException(errors, result.Exception);
                    }
                    else if (result.Result == OperationResult.Success)
                    {
                        if (result.Success)
                        {
                            response.Status = ResponseStatus.Success;
                        }
                        else
                        {
                            response.Status = ResponseStatus.Failure;
                            errors.Add(new ErrorItem(result.MessageNumber, result.MessageText));
                        }
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failure;
                        response.FailureReason = result.Result;
                    }
                }
                else
                {
                    response.Status = ResponseStatus.Rejected;
                }
            }
            else
            {
                response.Status = ResponseStatus.Rejected;
            }

            return response;
        }

        /// <summary>
        /// Errors for exception.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <param name="exception">The exception.</param>
        internal static void ErrorForException(ICollection<ErrorItem> errors, Exception exception)
        {
            errors.Add(new ErrorItem(exception.GetType().FullName, exception.Message));
        }

        /// <summary>
        /// The class
        /// </summary>
        internal class DependanciesForService
        {
            /// <summary>
            /// Gets or sets the benefit matrix.
            /// </summary>
            /// <value>
            /// The benefit matrix.
            /// </value>
            public IBenefitMatrixHandler BenefitMatrix { get; set; }

            /// <summary>
            /// Gets or sets the description master.
            /// </summary>
            /// <value>
            /// The description master.
            /// </value>
            public IDescriptionMasterHandler DescriptionMaster { get; set; }

            /// <summary>
            /// Gets or sets the inquire.
            /// </summary>
            /// <value>
            /// The inquire.
            /// </value>
            public ICipInquireHandler Inquire { get; set; }

            /// <summary>Gets or sets the sql.
            /// </summary>
            /// <value>
            /// The SQL.
            /// </value>
            [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
            public IConfigInterpSqlHandler Sql { get; set; }

            /// <summary>
            /// Gets or sets the update.
            /// </summary>
            /// <value>
            /// The update.
            /// </value>
            public ICipUpdateHandler Update { get; set; }

            /// <summary>
            /// Gets or sets the validation.
            /// </summary>
            /// <value>
            /// The validation.
            /// </value>
            public IValidation Validation { get; set; }

            /// <summary>
            /// Gets or sets the workflow.
            /// </summary>
            /// <value>
            /// The workflow.
            /// </value>
            public IWorkflowManager Workflow { get; set; }

            /// <summary>
            /// Gets or sets the converter.
            /// </summary>
            /// <value>
            /// The converter.
            /// </value>
            public IConverter Converter { get; set; }
        }
    }
}