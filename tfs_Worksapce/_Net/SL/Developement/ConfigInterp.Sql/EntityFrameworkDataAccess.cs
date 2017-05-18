// ----------------------------------------------------------------------
// <copyright file="EntityFrameworkDataAccess.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Sql.ISqlServerDataAccess" />
    /// <seealso cref="ConfigInterp.Sql.IConfigInterpSqlHandler" />
    [ExcludeFromCodeCoverage]
    public class EntityFrameworkDataAccess : UsesConnectionStringsBase, ISqlServerDataAccess
    {
        /// <summary>
        /// The name
        /// </summary>
        internal const string CipConfigName = "CipEntitiesConfig";

        /// <summary>
        /// The name
        /// </summary>
        internal const string CipDatabaseName = "CipEntities";

        /// <summary>
        /// The name
        /// </summary>
        internal const string CoreConfigName = "CoreEntitiesConfig";

        /// <summary>
        /// The name
        /// </summary>
        internal const string CoreDatabaseName = "CoreEntities";

        /// <summary>
        /// the text replacement token
        /// </summary>
        internal const string Token = "{[(TOKEN)]}";

        /// <summary>
        /// Gets the action description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        public void GetActionDescription(int systemTypeId, int id, List<DescriptionCommon> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetActionDesc(systemTypeId, id);
                var converted = data.Select(_ => new DescriptionCommon
                {
                    Description = _.ActionDesc,
                    PseudoDescription = _.ActionPseudoDesc,
                    TypeId = (short)_.ActionId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the action parameter description and validation information.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        public void GetActionParameterDescriptionAndValidationInfo(int systemTypeId, int id, List<ActionParameterDescriptionValidationInfoData> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetActionParmDescAndValidationInfo(systemTypeId, id);
                var converted = data.Select(_ => new ActionParameterDescriptionValidationInfoData
                {
                    FormatDescription = _.FormatDesc,
                    FormatInputHintDescription = _.FormatInputHintDesc,
                    FormatInputPattern = _.FormatInputPattern,
                    FormatTypeId = (short)_.FormatTypeId,
                    IsOptional = _.IsOptional,
                    MaximumSize = _.MaxSize,
                    MinimumSize = _.MinSize,
                    OrderSequence = _.OrderSequence,
                    ParameterDescription = _.ParamDesc,
                    ParameterPseudoDescription = _.ParamPseudoDesc,
                    ValueTypeId = (short)_.ValueTypeId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the action type description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        public void GetActionTypeDescription(int systemTypeId, List<DescriptionCommon> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetActionTypeDesc(systemTypeId);
                var converted = data.Select(_ => new DescriptionCommon
                {
                    Description = _.ActionTypeDesc,
                    PseudoDescription = _.ActionTypePseudoDesc,
                    TypeId = (short)_.ActionTypeId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Available Outline category.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="outlineId">The Outline identifier.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="list">The list.</param>
        public void GetAvailableOutlineCategory(int systemTypeId, int outlineId, int categoryId, List<AvailableOutlineCategoryData> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetAvailableOutlineCategory(systemTypeId, outlineId, categoryId);
                var converted = data.Select(_ => new AvailableOutlineCategoryData
                {
                    OutlineId = (short)_.OutlineId,
                    CategoryId = (short)_.CategoryId,
                    PseudoCategoryLiteralDescription = _.PseudoCategoryLiteralDesc,
                    StatusId = (short)_.StatusId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the compare type description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        public void GetCompareTypeDescription(int systemTypeId, int id, List<DescriptionCommon> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetCompareTypeDesc(systemTypeId, id);
                var converted = data.Select(_ => new DescriptionCommon
                 {
                     Description = _.CompareTypeDesc,
                     PseudoDescription = _.CompareTypePseudoDesc,
                     TypeId = (short)_.CompareTypeId
                 }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the condition type description.
        /// </summary>
        /// <param name="list">The list.</param>
        public void GetConditionTypeDescription(List<DescriptionCommon> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetConditionTypeDesc();
                var converted = data.Select(_ => new DescriptionCommon
                {
                    Description = _.ConditionTypeDesc,
                    PseudoDescription = _.ConditionTypeDesc,
                    TypeId = (short)_.ConditionTypeId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the exception description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        public void GetExceptionDescription(int systemTypeId, List<DescriptionCommon> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetExceptionDesc(systemTypeId);
                var converted = data.Select(_ => new DescriptionCommon
                {
                    Description = _.ExceptionDesc,
                    PseudoDescription = _.ExceptionPseudoDesc,
                    TypeId = (short)_.ExceptionId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the field name description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        public void GetFieldNameDescription(int systemTypeId, int id, List<FieldNameData> list)
        {
            if (DataSourceSelector.UseCommonDatabase(id))
            {
                using (var context = new CoreEntities(GetCoreString()))
                {
                    var data = context.GetBenefitMatrixNarrativeVersion();
                    var converted = data.Select(_ => new FieldNameData
                    {
                        FieldId = _.FieldId,
                        FieldDescription = _.DescriptionKey,
                        FieldPseudoDescription = DataFormatter.CreatePseudoCode(_.DescriptionKey, _.FieldId)
                    })
                    .ToList();
                    list.AddRange(converted);
                }
            }
            else
            {
                using (var context = new CipEntities(GetCipString()))
                {
                    var data = context.GetFieldnameDesc(systemTypeId, id);
                    var converted = data.Select(_ => new FieldNameData
                    {
                        FieldDescription = _.FieldDesc,
                        FieldId = _.FieldId.ToString(),
                        FieldPseudoDescription = _.FieldPseudoDesc,
                        QualifierPseudoDescription = _.QualifierPseudoDesc
                    })
                    .ToList();
                    list.AddRange(converted);
                }
            }
        }

        /// <summary>
        /// Gets the field type description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        public void GetFieldTypeDescription(int systemTypeId, List<DescriptionCommon> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetFieldTypeDesc(systemTypeId);
                var converted = data.Select(_ => new DescriptionCommon
                {
                    Description = _.FieldTypeDesc,
                    PseudoDescription = _.FieldTypePseudoDesc,
                    TypeId = (short)_.FieldTypeId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the field validation information.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="fieldId">The field identifier.</param>
        /// <param name="list">The list.</param>
        public void GetFieldValidationInfo(int systemTypeId, int typeId, int fieldId, List<FieldValidationInfoData> list)
        {
            using (var context = new CipEntities(GetCipString()))
            {
                var data = context.GetFieldValidationInfo(systemTypeId, typeId, fieldId);
                var converted = data.Select(_ => new FieldValidationInfoData
                {
                    FormatDescription = _.FormatDesc,
                    FormatInputHintDescription = _.FormatInputHintDesc,
                    FormatInputPattern = _.FormatInputPattern,
                    FormatTypeId = (short)_.FormatTypeId,
                    MaxSize = _.MaxSize,
                    MinSize = _.MinSize,
                    QualifierTypeNumber = (short)_.QualifierTypeNum,
                    ValueTypeId = (short)_.ValueTypeId
                }).ToList();
                list.AddRange(converted);
            }
        }

        /// <summary>
        /// Gets the weaved connection string.
        /// </summary>
        /// <returns>the value</returns>
        internal static string GetCipString()
        {
            var machineName = GetConnectionString(CipDatabaseName);
            var seed = GetConnectionString(CipConfigName);

            return seed.Replace(Token, machineName);
        }

        /// <summary>
        /// Gets the weaved connection string.
        /// </summary>
        /// <returns>the value</returns>
        internal static string GetCoreString()
        {
            var machineName = GetConnectionString(CoreDatabaseName);
            var seed = GetConnectionString(CoreConfigName);

            return seed.Replace(Token, machineName);
        }
    }
}