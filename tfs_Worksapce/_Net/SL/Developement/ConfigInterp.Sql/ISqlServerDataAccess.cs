// ----------------------------------------------------------------------
// <copyright file="ISqlServerDataAccess.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    using System.Collections.Generic;
    using Contracts.DataContracts;

    /// <summary>
    /// the interface
    /// </summary>
    public interface ISqlServerDataAccess
    {
        /// <summary>
        /// Available Outline category.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="outlineId">The Outline identifier.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="list">The list.</param>
        void GetAvailableOutlineCategory(int systemTypeId, int outlineId, int categoryId, List<AvailableOutlineCategoryData> list);

        /// <summary>
        /// Gets the action description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        void GetActionDescription(int systemTypeId, int id, List<DescriptionCommon> list);

        /// <summary>
        /// Gets the action parameter description and validation information.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        void GetActionParameterDescriptionAndValidationInfo(int systemTypeId, int id, List<ActionParameterDescriptionValidationInfoData> list);

        /// <summary>
        /// Gets the action type description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        void GetActionTypeDescription(int systemTypeId, List<DescriptionCommon> list);

        /// <summary>
        /// Gets the compare type description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        void GetCompareTypeDescription(int systemTypeId, int id, List<DescriptionCommon> list);

        /// <summary>
        /// Gets the condition type description.
        /// </summary>
        /// <param name="list">The list.</param>
        void GetConditionTypeDescription(List<DescriptionCommon> list);

        /// <summary>
        /// Gets the exception description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        void GetExceptionDescription(int systemTypeId, List<DescriptionCommon> list);

        /// <summary>
        /// Gets the field name description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        void GetFieldNameDescription(int systemTypeId, int id, List<FieldNameData> list);

        /// <summary>
        /// Gets the field type description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        void GetFieldTypeDescription(int systemTypeId, List<DescriptionCommon> list);

        /// <summary>
        /// Gets the field validation information.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="fieldId">The field identifier.</param>
        /// <param name="list">The list.</param>
        void GetFieldValidationInfo(int systemTypeId, int typeId, int fieldId, List<FieldValidationInfoData> list);
    }
}