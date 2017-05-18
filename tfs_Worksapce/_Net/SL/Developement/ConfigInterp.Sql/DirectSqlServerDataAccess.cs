// ----------------------------------------------------------------------
// <copyright file="DirectSqlServerDataAccess.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Sql.UsesConnectionStringsBase" />
    /// <seealso cref="ConfigInterp.Sql.ISqlServerDataAccess" />
    [ExcludeFromCodeCoverage]
    public class DirectSqlServerDataAccess : UsesConnectionStringsBase, ISqlServerDataAccess
    {
        /// <summary>
        /// The data base name
        /// </summary>
        internal const string CipDatabaseName = "CIP";

        /// <summary>
        /// The data base name
        /// </summary>
        internal const string CommonDatabaseName = "COMMONDB";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureAvailableOutlineCategory = "GetAvailableOutlineCategory";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetActionDescription = "GetActionDesc";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetActionParmDescAndValidationInfo = "GetActionParmDescAndValidationInfo";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetActionTypeDescription = "GetActionTypeDesc";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetCompareTypeDescription = "GetCompareTypeDesc";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetConditionTypeDescription = "GetConditionTypeDesc";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetExceptionDescription = "GetExceptionDesc";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetFieldNameDescription = "GetFieldNameDesc";

        /// <summary>
        /// Stored procedure that hits joins DCM-type-code 5 in Description master and the interp versions located on BMNarrative master
        /// </summary>
        private const string ProcedureGetFieldNameDescriptionKeyword = "GetBMNarrativeVersion";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetFieldTypeDescription = "GetFieldTypeDesc";

        /// <summary>
        /// Stored Procedure constants
        /// </summary>
        private const string ProcedureGetFieldValidationInfo = "GetFieldValidationInfo";

        /// <summary>
        /// Gets or sets the Timeout information for the SQL calls
        /// </summary>
        private const int Timeout = 115;

        /// <summary>
        /// Available the Outline category.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="outlineId">The Outline identifier.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="list">The list.</param>
        public void GetAvailableOutlineCategory(int systemTypeId, int outlineId, int categoryId, List<AvailableOutlineCategoryData> list)
        {
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureAvailableOutlineCategory, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));
                    cmd.Parameters.Add(new SqlParameter("@OutlineID", outlineId));
                    cmd.Parameters.Add(new SqlParameter("@CategoryID", categoryId));

                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new AvailableOutlineCategoryData
                            {
                                OutlineId = sdr["OutlineID"].ToInt16(),
                                CategoryId = sdr["categoryID"].ToInt16(),
                                StatusId = sdr["statusID"].ToInt16(),
                                PseudoCategoryLiteralDescription = sdr["pseudoCategoryLiteralDesc"].ToString(),
                            };
                            list.Add(newRecord);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the action description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="list">The list.</param>
        public void GetActionDescription(int systemTypeId, int id, List<DescriptionCommon> list)
        {
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetActionDescription, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));
                    cmd.Parameters.Add(new SqlParameter("@actionTypeID", id));
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new DescriptionCommon
                            {
                                TypeId = sdr["actionID"].ToInt16(),
                                Description = sdr["actionDesc"].ToString(),
                                PseudoDescription = sdr["actionPseudoDesc"].ToString()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
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
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetActionParmDescAndValidationInfo, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));
                    cmd.Parameters.Add(new SqlParameter("@ActionID", id));
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new ActionParameterDescriptionValidationInfoData
                            {
                                ParameterDescription = sdr["parmDesc"].ToString(),
                                ValueTypeId = sdr["valueTypeID"].ToInt16(),
                                OrderSequence = sdr["orderSequence"].ToInt16(),
                                FormatTypeId = sdr["formatTypeID"].ToInt16(),
                                FormatDescription = sdr["formatDesc"].ToString(),
                                FormatInputPattern = sdr["formatInputPattern"].ToString(),
                                FormatInputHintDescription = sdr["formatInputHintDesc"].ToString(),
                                MinimumSize = sdr["minSize"].ToInt16(),
                                MaximumSize = sdr["maxSize"].ToInt16(),
                                ////           IsOptional = sdr.GetBoolean(sdr["isOptional"].ToInt16()),
                                IsOptional = (bool)sdr["isOptional"],
                                ParameterPseudoDescription = sdr["parmPseudoDesc"].ToString()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the action type description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        public void GetActionTypeDescription(int systemTypeId, List<DescriptionCommon> list)
        {
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetActionTypeDescription, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));
                    conn.Open();
                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new DescriptionCommon
                            {
                                TypeId = sdr["actionTypeID"].ToInt16(),
                                Description = sdr["actionTypeDesc"].ToString(),
                                PseudoDescription = sdr["actionTypePseudoDesc"].ToString()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
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
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetCompareTypeDescription, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));
                    cmd.Parameters.Add(new SqlParameter("@ValueTypeID", id));
                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new DescriptionCommon
                            {
                                TypeId = sdr["compareTypeID"].ToInt16(),
                                Description = sdr["compareTypeDesc"].ToString(),
                                PseudoDescription = sdr["compareTypePseudoDesc"].ToString()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the condition type description.
        /// </summary>
        /// <param name="list">The list.</param>
        public void GetConditionTypeDescription(List<DescriptionCommon> list)
        {
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetConditionTypeDescription, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    conn.Open();
                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new DescriptionCommon
                            {
                                TypeId = sdr["conditionTypeID"].ToInt16(),
                                Description = sdr["conditionTypeDesc"].ToString(),
                                PseudoDescription = sdr["conditionTypePseudoDesc"].ToString()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the exception description.
        /// </summary>
        /// <param name="systemTypeId">The system type identifier.</param>
        /// <param name="list">The list.</param>
        public void GetExceptionDescription(int systemTypeId, List<DescriptionCommon> list)
        {
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetExceptionDescription, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));

                    conn.Open();
                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new DescriptionCommon
                            {
                                TypeId = sdr["exceptionID"].ToInt16(),
                                Description = sdr["exceptionDesc"].ToString(),
                                PseudoDescription = sdr["exceptionPseudoDesc"].ToString()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
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
                using (SqlConnection conn = new SqlConnection(GetConnectionString(CommonDatabaseName)))
                {
                    using (var cmd = new SqlCommand(ProcedureGetFieldNameDescriptionKeyword, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Timeout;
                        conn.Open();

                        using (var sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                var tempDescription = DataFormatter.CreatePseudoCode(sdr["dcm_description"].ToString(), sdr["fieldID"].ToString());
                                var initialVersion = tempDescription.Substring(tempDescription.LastIndexOf("/", StringComparison.Ordinal) + 1);
                                var tempVersion = initialVersion.TrimEnd(')');
                                var newRecord = new FieldNameData
                                {
                                    FieldPseudoDescription = tempDescription,
                                    FieldId = DataFormatter.FormatFieldId(sdr["fieldID"].ToString()),
                                    FieldDescription = string.Format("{0}/{1}", sdr["dcm_description"].ToString().Remove(0, 1), tempVersion),
                                    QualifierPseudoDescription = null
                                };
                                list.Add(newRecord);
                            }
                        }
                    }
                }
            }
            else
            {
                using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
                {
                    using (var cmd = new SqlCommand(ProcedureGetFieldNameDescription, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = Timeout;
                        cmd.Parameters.Add(new SqlParameter("@systemTypeID", systemTypeId));
                        cmd.Parameters.Add(new SqlParameter("@fieldTypeID", id));
                        conn.Open();

                        using (var sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                var newRecord = new FieldNameData
                                {
                                    FieldId = sdr["fieldID"].ToString(),
                                    FieldDescription = sdr["fieldDesc"].ToString(),
                                    FieldPseudoDescription = sdr["fieldPseudoDesc"].ToString(),
                                    QualifierPseudoDescription = sdr["qualifierPseudoDesc"].ToString()
                                };
                                list.Add(newRecord);
                            }
                        }
                    }
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
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetFieldTypeDescription, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));
                    conn.Open();
                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new DescriptionCommon
                            {
                                TypeId = sdr["fieldTypeID"].ToInt16(),
                                Description = sdr["fieldTypeDesc"].ToString(),
                                PseudoDescription = sdr["fieldTypePseudoDesc"].ToString()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
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
            using (var conn = new SqlConnection(GetConnectionString(CipDatabaseName)))
            {
                using (var cmd = new SqlCommand(ProcedureGetFieldValidationInfo, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Timeout;
                    cmd.Parameters.Add(new SqlParameter("@SystemTypeID", systemTypeId));
                    cmd.Parameters.Add(new SqlParameter("@FieldID", fieldId));
                    cmd.Parameters.Add(new SqlParameter("@FieldTypeID", typeId));

                    conn.Open();

                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            var newRecord = new FieldValidationInfoData
                            {
                                ValueTypeId = sdr["valueTypeID"].ToInt16(),
                                FormatTypeId = sdr["formatTypeID"].ToInt16(),
                                FormatDescription = sdr["formatDesc"].ToString(),
                                FormatInputPattern = sdr["formatInputPattern"].ToString(),
                                FormatInputHintDescription = sdr["formatInputHintDesc"].ToString(),
                                MinSize = sdr["minSize"].ToInt16(),
                                MaxSize = sdr["maxSize"].ToInt16(),
                                QualifierTypeNumber = sdr["qualifierTypeNum"].ToInt16()
                            };
                            list.Add(newRecord);
                        }
                    }
                }
            }
        }
    }
}