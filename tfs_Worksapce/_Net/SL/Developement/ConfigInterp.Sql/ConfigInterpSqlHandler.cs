// <copyright file="ConfigInterpSqlHandler.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Contracts.DataContracts;

    /// <summary>
    /// The SQL handler
    /// </summary>
    public class ConfigInterpSqlHandler : IConfigInterpSqlHandler
    {
        /// <summary>
        /// The implementation
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly ISqlServerDataAccess _dataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigInterpSqlHandler"/> class.
        /// </summary>
        /// <param name="dataAccess">The data access.</param>
        public ConfigInterpSqlHandler(ISqlServerDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        /// <summary>
        /// The SQL results for AvailableOutlineCategory
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="outlineId">Out Line</param>
        /// <param name="categoryId">Category ID</param>
        /// <returns>List of available Outlines</returns>
        public AvailableOutlineCategoryResult AvailableOutlineCategory(LineOfBusiness business, int outlineId, int categoryId)
        {
            var list = new List<AvailableOutlineCategoryData>();
            var result = new AvailableOutlineCategoryResult
            {
                Data = list
            };

            try
            {
                this._dataAccess.GetAvailableOutlineCategory((short)business, outlineId, categoryId, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for GetActionDescription
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Action ID</param>
        /// <returns>List of Actions</returns>
        public DescriptionCommonSqlDataResult GetActionDescription(LineOfBusiness business, int id)
        {
            var list = new List<DescriptionCommon>();
            var result = new DescriptionCommonSqlDataResult
            {
                Data = list
            };

            try
            {
                this._dataAccess.GetActionDescription((short)business, id, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for ActionParameterDescriptionValidationInfoResult
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Action ID</param>
        /// <returns>List of parameters for that action</returns>
        public ActionParameterDescriptionValidationInfoResult GetActionParameterDescriptionAndValidationInfo(LineOfBusiness business, int id)
        {
            var list = new List<ActionParameterDescriptionValidationInfoData>();
            var result = new ActionParameterDescriptionValidationInfoResult
            {
                Data = list
            };

            try
            {
                this._dataAccess.GetActionParameterDescriptionAndValidationInfo((short)business, id, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for GetActionTypeDescription
        /// </summary>
        /// <param name="business">The business</param>
        /// <returns>List of Action Information</returns>
        public DescriptionCommonSqlDataResult GetActionTypeDescription(LineOfBusiness business)
        {
            var list = new List<DescriptionCommon>();
            var result = new DescriptionCommonSqlDataResult
            {
                Data = list
            };
            try
            {
                this._dataAccess.GetActionTypeDescription((short)business, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for GetCompareTypeDescription
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Value Type</param>
        /// <returns>List of Compare types</returns>
        public DescriptionCommonSqlDataResult GetCompareTypeDescription(LineOfBusiness business, int id)
        {
            var list = new List<DescriptionCommon>();
            var result = new DescriptionCommonSqlDataResult
            {
                Data = list
            };
            try
            {
                this._dataAccess.GetCompareTypeDescription((short)business, id, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for Get Condition Type Description
        /// </summary>
        /// <returns>
        /// List of condition descriptions
        /// </returns>
        public DescriptionCommonSqlDataResult GetConditionTypeDescription()
        {
            var list = new List<DescriptionCommon>();
            var result = new DescriptionCommonSqlDataResult
            {
                Data = list
            };
            try
            {
                this._dataAccess.GetConditionTypeDescription(list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for GetExceptionDescription
        /// </summary>
        /// <param name="business">The business</param>
        /// <returns>List of Exceptions</returns>
        public DescriptionCommonSqlDataResult GetExceptionDescription(LineOfBusiness business)
        {
            var list = new List<DescriptionCommon>();
            var result = new DescriptionCommonSqlDataResult
            {
                Data = list
            };
            try
            {
                this._dataAccess.GetExceptionDescription((short)business, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for GetFieldNameDescription
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Field ID</param>
        /// <returns>List of Field descriptions</returns>
        public FieldNameResult GetFieldNameDescription(LineOfBusiness business, int id)
        {
            var list = new List<FieldNameData>();
            var result = new FieldNameResult
            {
                Data = list
            };

            try
            {
                this._dataAccess.GetFieldNameDescription((short)business, id, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// The SQL results for GetFieldTypeDescription
        /// </summary>
        /// <param name="business">The business</param>
        /// <returns>List of Field types</returns>
        public DescriptionCommonSqlDataResult GetFieldTypeDescription(LineOfBusiness business)
        {
            var list = new List<DescriptionCommon>();
            var result = new DescriptionCommonSqlDataResult
            {
                Data = list
            };
            try
            {
                this._dataAccess.GetFieldTypeDescription((short)business, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }
        
        /// <summary>
        /// The SQL results for GetFieldValidationInfo
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="typeId">Field ID</param>
        /// <param name="fieldId">The field identifier.</param>
        /// <returns>
        /// Field Validation Information
        /// </returns>
        public FieldValidationInfoResult GetFieldValidationInfo(LineOfBusiness business, int typeId, int fieldId)
        {
            var list = new List<FieldValidationInfoData>();
            var result = new FieldValidationInfoResult
            {
                Data = list
            };

            try
            {
                this._dataAccess.GetFieldValidationInfo((short)business, typeId, fieldId, list);
                result.Result = OperationResult.Success;
            }
            catch (Exception e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }
    }
}