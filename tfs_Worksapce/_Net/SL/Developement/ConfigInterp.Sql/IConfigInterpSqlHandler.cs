// <copyright file="IConfigInterpSQLHandler.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Sql
{
    using System.Diagnostics.CodeAnalysis;
    using Contracts.DataContracts;

    /// <summary>
    /// Methods for the Config Interp SQL service
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
    public interface IConfigInterpSqlHandler
    {
        /// <summary>
        /// Gets a list of Condition Type Descriptions
        /// </summary>
        /// <returns>
        /// a Condition List
        /// </returns>
        DescriptionCommonSqlDataResult GetConditionTypeDescription();

        /// <summary>
        /// Gets a List of Field Type Descriptions
        /// </summary>
        /// <param name="business">The business</param>
        /// <returns>
        /// A list of field descriptions
        /// </returns>
        DescriptionCommonSqlDataResult GetFieldTypeDescription(LineOfBusiness business);

        /// <summary>
        /// Gets a list of Comparison type descriptions
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Type ID</param>
        /// <returns>
        /// A list of comparisons
        /// </returns>
        DescriptionCommonSqlDataResult GetCompareTypeDescription(LineOfBusiness business, int id);

        /// <summary>
        /// Gets a list of Field Names
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Field ID</param>
        /// <returns>
        /// a list of Field Names
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", Justification = "Dev", MessageId = "FieldName")]
        FieldNameResult GetFieldNameDescription(LineOfBusiness business, int id);

        /// <summary>
        /// Gets the information for valid fields
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="typeId">Field ID</param>
        /// <param name="fieldId">The field identifier.</param>
        /// <returns>
        /// Validation Information
        /// </returns>
        FieldValidationInfoResult GetFieldValidationInfo(LineOfBusiness business, int typeId, int fieldId);

        /// <summary>
        /// Gets a list of Action type Descriptions
        /// </summary>
        /// <param name="business">The business</param>
        /// <returns>
        /// a list of action type descriptions
        /// </returns>
        DescriptionCommonSqlDataResult GetActionTypeDescription(LineOfBusiness business);

        /// <summary>
        /// Gets a list of actions
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Action ID</param>
        /// <returns>
        /// List of Actions
        /// </returns>
        DescriptionCommonSqlDataResult GetActionDescription(LineOfBusiness business, int id);

        /// <summary>
        /// Gets a list of Action Parameters
        /// </summary>
        /// <param name="business">The business</param>
        /// <param name="id">Action ID</param>
        /// <returns>
        /// A list of valid parameters
        /// </returns>
        ActionParameterDescriptionValidationInfoResult GetActionParameterDescriptionAndValidationInfo(LineOfBusiness business, int id);

        /// <summary>
        /// Gets a list of Exceptions
        /// </summary>
        /// <param name="business">The business</param>
        /// <returns>
        /// A list of Exceptions
        /// </returns>
        DescriptionCommonSqlDataResult GetExceptionDescription(LineOfBusiness business);

        /// <summary>
        /// Gets the Available Outlines
        /// </summary>
        /// <param name="business">The business Id</param>
        /// <param name="outlineId">Outline ID</param>
        /// <param name="categoryId">Category id</param>
        /// <returns>
        /// Returns a list of available Outlines
        /// </returns>
        AvailableOutlineCategoryResult AvailableOutlineCategory(LineOfBusiness business, int outlineId, int categoryId);
    }
}