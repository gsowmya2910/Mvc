// ----------------------------------------------------------------------
// <copyright file="Validation.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Update;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.IValidation" />
    public class Validation : IValidation
    {
        /// <summary>
        /// The maximum line length
        /// </summary>
        internal const int MaxLineLength = 78;

        /// <summary>
        /// The maximum word length
        /// </summary>
        internal const int MaxWordLength = 45;

        /// <summary>
        /// The false actions
        /// </summary>
        private const string FalseActions = "FalseActions";

        /// <summary>
        /// The true actions
        /// </summary>
        private const string TrueActions = "TrueActions";

        /// <summary>
        /// The field types
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:ReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<FieldType[]> _fieldTypes = new Lazy<FieldType[]>(Utilities.ExplicitValues<FieldType>);

        /// <summary>
        /// The interp statuses
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:ReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<InterpStatus[]> _interpStatuses = new Lazy<InterpStatus[]>(Utilities.ExplicitValues<InterpStatus>);

        /// <summary>
        /// The line of businesses
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:ReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<LineOfBusiness[]> _lineOfBusinesses = new Lazy<LineOfBusiness[]>(Utilities.ExplicitValues<LineOfBusiness>);

        /// <summary>
        /// The plan number
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:ReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<Plan[]> _plans = new Lazy<Plan[]>(Utilities.ExplicitValues<Plan>);

        /// <summary>
        /// The record value types
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:ReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<RecordValueType[]> _recordValueTypes = new Lazy<RecordValueType[]>(Utilities.ExplicitValues<RecordValueType>);

        /// <summary>
        /// The statuses
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:ReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<Status[]> _statuses = new Lazy<Status[]>(Utilities.ExplicitValues<Status>);

        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool AllowedAction(InterpDetailData data, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (data.CurrentStatus != InterpStatus.Draft)
            {
                list.Add(new ErrorItem("CurrentStatus", "Can Only Be Draft"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool AllowedAction(StatusData value, IList<ErrorItem> errors)
        {
            ////TODO: phase 1 only supports elevating to active
            var list = new List<ErrorItem>();

            var directions = new List<Tuple<InterpStatus, InterpStatus>>
            {
                new Tuple<InterpStatus, InterpStatus>(InterpStatus.Draft, InterpStatus.Test),
                new Tuple<InterpStatus, InterpStatus>(InterpStatus.Test, InterpStatus.Draft),
                new Tuple<InterpStatus, InterpStatus>(InterpStatus.Test, InterpStatus.Active)
            };

            var currentAllowed = directions.Select(_ => _.Item1).Distinct().ToArray();
            var targetAllowed = directions.Select(_ => _.Item2).Distinct().ToArray();
            if (!currentAllowed.Any(_ => _ == value.CurrentStatus))
            {
                list.Add(new ErrorItem("CurrentStatus", string.Format("Supported Values Are: {0}", string.Join(", ", currentAllowed))));
            }

            if (!targetAllowed.Any(_ => _ == value.TargetStatus))
            {
                list.Add(new ErrorItem("TargetStatus", string.Format("Supported Values Are: {0}", string.Join(", ", targetAllowed))));
            }

            if (!directions.Any(_ => value.CurrentStatus == _.Item1 && value.TargetStatus == _.Item2))
            {
                var message = string.Format("Status Change Direction Not supported. Compatible Changes Are {0}", string.Join(", ", directions.Select(_ => string.Format("{0}->{1}", _.Item1, _.Item2))));
                list.Add(new ErrorItem("CurrentStatus;TargetStatus", message));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool AllowedAction(DeleteCipInterpData data, List<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (data.Status != InterpStatus.Draft)
            {
                list.Add(new ErrorItem("CurrentStatus", "Can Only Be Draft"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool AllowedAction(DeleteInterpNarrativeData data, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (data.Status == Status.Active)
            {
                list.Add(new ErrorItem("Status", "Cannot Delete An Active Item"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool AllowedAction(UpdateInterpNarrativeData data, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (data.Status == Status.Active)
            {
                list.Add(new ErrorItem("Status", "Cannot Update An Active Item"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(OutlineData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("OutlineData", "Not Null"));
            }
            else
            {
                CheckOutline(value.Outline, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(SubCategoryData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("SubCategoryData", "Not Null"));
            }
            else
            {
                CheckOutline(value.Outline, list);
                CheckCategory(value.Category, list);
                CheckSubCategory(value.SubCategory, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(CategoryData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("CategoryData", "Not Null"));
            }
            else
            {
                CheckOutline(value.Outline, list);
                CheckCategory(value.Category, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(LevelData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("LevelData", "Not Null"));
            }
            else
            {
                CheckOutline(value.Outline, list);
                CheckBusiness(value.LineOfBusiness, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(InquireInputData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("InquireInputData", "Not Null"));
            }
            else
            {
                CheckOutline(value.Outline, list);
                CheckCategory(value.Category, list);
                CheckSubCategory(value.SubCategory, list);
                CheckAdmitInterp(value.AdmitInterp, list);

                if (_interpStatuses.Value.All(_ => _ != value.Status))
                {
                    list.Add(new ErrorItem("Status", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _interpStatuses.Value))));
                }
                else if (value.Status == InterpStatus.None)
                {
                    list.Add(new ErrorItem("Status", "Cannot use 'None'. This is a default value"));
                }

                CheckBusiness(value.LineOfBusiness, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines if input had data
        /// </summary>
        /// <param name="request">The value</param>
        /// <param name="errors">Delete Request</param>
        /// <returns>the result</returns>
        public bool HasData(DeleteCipInterpRequest request, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (request == null)
            {
                list.Add(new ErrorItem("DeleteCIPInterpRequest", "Not Null"));
            }
            else
            {
                CheckOutline(request.Data.Outline, list);
                CheckCategory(request.Data.Category, list);
                CheckSubCategory(request.Data.SubCategory, list);
                CheckAdmitInterp(request.Data.AdmitInterp, list);
                CheckBusiness(request.Data.LineOfBusiness, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(CreateInterpNarrativeData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("CreateInterpNarrativeData", "Not Null"));
            }
            else
            {
                CheckInterpValues(value, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(DeleteInterpNarrativeData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("DeleteInterpNarrativeData", "Not Null"));
            }
            else
            {
                CheckInterpValues(value, list);
                CheckStatus(value, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(UpdateInterpNarrativeData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("UpdateInterpNarrativeData", "Not Null"));
            }
            else
            {
                CheckInterpValues(value, list);
                CheckStatus(value, list);
                if (value.NarrativeLines == null)
                {
                    list.Add(new ErrorItem("NarrativeLines", "Not Null"));
                }
                else if (value.NarrativeLines.All(string.IsNullOrWhiteSpace))
                {
                    list.Add(new ErrorItem("NarrativeLines", "Must Have Narrative Text"));
                }
                else
                {
                    var newlineSets = new[] { "\r", "\n", "\r\n", Environment.NewLine };
                    var invalidCharacters = new[] { "[", "]", "{", "}", "<", ">", "^", "_", "`", "'" };

                    for (int index = 0; index < value.NarrativeLines.Length; index++)
                    {
                        var line = value.NarrativeLines[index];
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        if (line.Length > MaxLineLength)
                        {
                            list.Add(new ErrorItem(string.Format("NarrativeLines:[{0}]", index), string.Format("Cannot Exceed {0} characters in length", MaxLineLength)));
                        }

                        if (newlineSets.Any(_ => line.Contains(_)))
                        {
                            list.Add(new ErrorItem(string.Format("NarrativeLines:[{0}]", index), "Must Not Contain Newline Characters"));
                        }

                        if (invalidCharacters.Any(_ => line.Contains(_)))
                        {
                            list.Add(new ErrorItem(string.Format("NarrativeLines:[{0}]", index), string.Format("Must Not Contain Special Characters Like the Following : {0}", string.Join(",", invalidCharacters))));
                        }

                        if (line.Length >= MaxWordLength)
                        {
                            if (line.Split(' ').Any(_ => _.Length > MaxWordLength))
                            {
                                list.Add(new ErrorItem(string.Format("NarrativeLines:[{0}]", index), string.Format("No words can exceed {0} in length", MaxWordLength)));
                            }
                        }
                    }
                }
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(InquireInterpNarrativeData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("InquireInterpNarrativeData", "Not Null"));
            }
            else
            {
                CheckInterpValues(value, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(InterpDetailData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();

            if (value == null)
            {
                list.Add(new ErrorItem("InterpDetailData", "Not Null"));
            }
            else
            {
                CheckInterpData(value, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(ListRequest request, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (request.Id < 1)
            {
                list.Add(new ErrorItem("Id", "Must Use Positive Value"));
            }

            CheckBusiness(request.LineOfBusiness, list);

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(SystemTypeRequest request, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            CheckBusiness(request.LineOfBusiness, list);

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(OutlineCategoryListRequest request, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            CheckBusiness(request.LineOfBusiness, list);

            if (request.OutlineId < 1)
            {
                list.Add(new ErrorItem("OutlineId", "Must Use Positive Value"));
            }

            if (request.CategoryId < 1)
            {
                list.Add(new ErrorItem("CategoryId", "Must Use Positive Value"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(FieldValidationInfoRequest request, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            CheckBusiness(request.LineOfBusiness, list);

            if (request.TypeId < 1)
            {
                list.Add(new ErrorItem("TypeId", "Must Use Positive Value"));
            }

            if (request.FieldId < 1)
            {
                list.Add(new ErrorItem("FieldId", "Must Use Positive Value"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(StatusData value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            CheckInterpValues(value, list);

            if (_interpStatuses.Value.All(_ => _ != value.CurrentStatus))
            {
                errors.Add(new ErrorItem("CurrentStatus", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _interpStatuses.Value))));
            }
            else if (value.CurrentStatus == InterpStatus.None)
            {
                errors.Add(new ErrorItem("CurrentStatus", "Cannot use 'None'. This is a default value"));
            }

            if (_interpStatuses.Value.All(_ => _ != value.TargetStatus))
            {
                errors.Add(new ErrorItem("TargetStatus", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _interpStatuses.Value))));
            }
            else if (value.TargetStatus == InterpStatus.None)
            {
                errors.Add(new ErrorItem("TargetStatus", "Cannot use 'None'. This is a default value"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether [has header values] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasHeaderValues(RequestHeaderBase value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (string.IsNullOrWhiteSpace(value.ApplicationId))
            {
                list.Add(new ErrorItem("ApplicationId", "Required Value"));
            }

            if (string.IsNullOrWhiteSpace(value.UserId))
            {
                list.Add(new ErrorItem("UserId", "Required Value"));
            }

            var planRegions = new[] { 1, 3, 4 };
            if (!planRegions.Any(_ => value.Region == _))
            {
                list.Add(new ErrorItem("Region", string.Format("Supported Values are: {0}", string.Join(", ", planRegions))));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasRequest(RequestHeaderBase value, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (value == null)
            {
                list.Add(new ErrorItem("Request", "Not Null"));
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Checks the clone request for data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(CloneInterpRequest request, IList<ErrorItem> errors)
        {
            var list = new List<ErrorItem>();
            if (request == null)
            {
                list.Add(new ErrorItem("CloneInterp", "Not Null"));
            }
            else
            {
                CheckInterpsDiffer(request.Source, request.Target, errors);
                CheckInterpValues(request, list);
                CheckStatus(request, list);
            }

            list.ForEach(errors.Add);
            return !list.Any();
        }

        /// <summary>
        /// Checks the actions.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="stepName">Name of the step.</param>
        /// <param name="actionPath">The action path.</param>
        internal static void CheckActions(StepAction action, int stepIndex, IList<ErrorItem> errors, string stepName, string actionPath)
        {
            if (action.ActionId < 1)
            {
                errors.Add(new ErrorItem(
                    string.Format("ConfiguredSteps.{1}[{0}].{2}.ActionId", stepIndex, stepName, actionPath),
                    "Action Id Must Be Set"));
            }

            if (action.ActionId > 9999)
            {
                errors.Add(new ErrorItem(
                    string.Format("ConfiguredSteps.{1}[{0}].{2}.ActionId", stepIndex, stepName, actionPath),
                    "Action Id Cannot Exceed 9999"));
            }

            var alphaIsNull = action.AlphaParameters == null;
            var decimalIsNull = action.DecimalParameters == null;
            var numericIsNull = action.NumericParameters == null;
            //// ReSharper disable InconsistentNaming
            const int CountOfExpectedNulls = 2;
            const int MaxNumberOfParameters = 5;
            //// ReSharper restore InconsistentNaming

            if (new[] { alphaIsNull, decimalIsNull, numericIsNull }.Count(_ => _) == CountOfExpectedNulls)
            {
                if (!alphaIsNull)
                {
                    if (action.AlphaParameters.Count > MaxNumberOfParameters)
                    {
                        errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{1}[{0}].{2}.AlphaParameters", stepIndex, stepName, actionPath), string.Format("Cannot Exceed The Maximum Of {0} parameters", MaxNumberOfParameters)));
                    }
                    else
                    {
                        CheckAlphas(action.AlphaParameters, stepIndex, errors, stepName, actionPath);
                    }
                }

                if (!decimalIsNull)
                {
                    if (action.DecimalParameters.Count > MaxNumberOfParameters)
                    {
                        errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{1}[{0}].{2}.DecimalParameters", stepIndex, stepName, actionPath), string.Format("Cannot Exceed The Maximum Of {0} parameters", MaxNumberOfParameters)));
                    }
                    else
                    {
                        CheckDecimal(action.DecimalParameters, stepIndex, errors, stepName, actionPath);
                    }
                }

                if (!numericIsNull)
                {
                    if (action.NumericParameters.Count > MaxNumberOfParameters)
                    {
                        errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{1}[{0}].{2}.NumericParameters", stepIndex, stepName, actionPath), string.Format("Cannot Exceed The Maximum Of {0} parameters", MaxNumberOfParameters)));
                    }
                    else
                    {
                        CheckNumerics(action.NumericParameters, stepIndex, errors, stepName, actionPath);
                    }
                }
            }
            else
            {
                if (alphaIsNull && decimalIsNull && numericIsNull)
                {
                }
                else
                {
                    errors.Add(new ErrorItem(
                            string.Format("ConfiguredSteps.{1}[{0}].{2}", stepIndex, stepName, actionPath),
                            "Parameters For An Action Must Be In Only 1 Parameter Type"));
                }
            }
        }

        /// <summary>
        /// Checks the actions.
        /// </summary>
        /// <param name="trueActions">The true actions.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="propertyName">Name of the property.</param>
        internal static void CheckActions(List<StepAction> trueActions, int stepIndex, IList<ErrorItem> errors, string propertyName)
        {
            if (trueActions.Any())
            {
                for (int index = 0; index < trueActions.Count; index++)
                {
                    var action = trueActions[index];

                    var stepName = "ConditionalSteps";
                    var actionPath = string.Format("{0}[{1}]", propertyName, index);

                    CheckActions(action, stepIndex, errors, stepName, actionPath);
                }
            }
            else
            {
                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].{1}", stepIndex, propertyName), "Is Declared, But Contains No Elements"));
            }
        }

        /// <summary>
        /// Checks the admit interp.
        /// </summary>
        /// <param name="admitInterp">The admit interp.</param>
        /// <param name="list">The list.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        internal static void CheckAdmitInterp(short admitInterp, IList<ErrorItem> list)
        {
            CheckRange(admitInterp, "AdmitInterp", 0, 9999, list);
        }

        /// <summary>
        /// Checks the alphas.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="stepName">Name of the step.</param>
        /// <param name="actionPath">The action path.</param>
        internal static void CheckAlphas(List<AlphaValue> parameters, int stepIndex, IList<ErrorItem> errors, string stepName, string actionPath)
        {
            if (parameters != null)
            {
                if (parameters.Any())
                {
                    for (int index = 0; index < parameters.Count; index++)
                    {
                        var parameter = parameters[index];
                        if (parameter == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.AlphaParameters[{1}]", stepIndex, index, stepName, actionPath), "Not Null"));
                        }
                        else if (string.IsNullOrEmpty(parameter.Value))
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.AlphaParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Not Null"));
                        }
                        else if (parameter.Value.Length > 12)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.AlphaParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Cannot Exceed 12 characters"));
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{1}[{0}].{2}.AlphaParameters", stepIndex, stepName, actionPath), "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the alphas.
        /// </summary>
        /// <param name="condition">the condition</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="conditionIndex">Index of the condition.</param>
        internal static void CheckAlphas(Condition condition, int stepIndex, IList<ErrorItem> errors, int conditionIndex)
        {
            if (condition.AlphaParameters != null)
            {
                if (condition.AlphaParameters.Any())
                {
                    if (condition.ParameterType != RecordValueType.Alpha)
                    {
                        errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].ParameterType", stepIndex, conditionIndex), "Parameter Type Must Match Parameters Passed In"));
                    }

                    for (int index = 0; index < condition.AlphaParameters.Count; index++)
                    {
                        var parameter = condition.AlphaParameters[index];
                        if (parameter == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].AlphaParameters[{2}]", stepIndex, conditionIndex, index), "Not Null"));
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(parameter.Value))
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].AlphaParameters[{2}].Value", stepIndex, conditionIndex, index), "Not Null"));
                            }
                            else if (parameter.Value.Length > 17)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].AlphaParameters[{2}].Value", stepIndex, conditionIndex, index), "Cannot Exceed 17 characters"));
                            }

                            if (parameter.ValueThru != null && parameter.ValueThru.Length > 17)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].AlphaParameters[{2}].ValueThru", stepIndex, conditionIndex, index), "Cannot Exceed 17 characters"));
                            }
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].AlphaParameters", stepIndex, conditionIndex), "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the business.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        internal static void CheckBusiness(LineOfBusiness value, IList<ErrorItem> list)
        {
            if (_lineOfBusinesses.Value.All(_ => _ != value))
            {
                list.Add(new ErrorItem("LineOfBusiness", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _lineOfBusinesses.Value))));
            }
            else if (value == LineOfBusiness.None)
            {
                list.Add(new ErrorItem("LineOfBusiness", "Cannot use 'None'. This is a default value"));
            }
        }

        /// <summary>
        /// Checks the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="list">The list.</param>
        internal static void CheckCategory(short category, IList<ErrorItem> list)
        {
            CheckRange(category, "Category", 0, 999, list);
        }

        /// <summary>
        /// Checks the complexity exceeded.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckComplexityExceeded(ConfiguredStep step, IList<ErrorItem> errors)
        {
            if (step != null)
            {
                if (CipUpdateHandler.MaxStepsToSave < StepConverter.ComplexityCount(step))
                {
                    errors.Add(new ErrorItem(step.GetType().Name, string.Format("Step Has Exceeded Complexity Availability. Index={0}", step.Index)));
                }
            }
        }

        /// <summary>
        /// Checks the conditional actions.
        /// </summary>
        /// <param name="step">the conditional step</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckConditionalActions(ConditionalStep step, int stepIndex, IList<ErrorItem> errors)
        {
            var list = new List<StepAction>();
            if (step.TrueActions == null)
            {
                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].{1}", stepIndex, TrueActions), "Not Null"));
            }
            else
            {
                list.AddRange(step.TrueActions);
                CheckActions(step.TrueActions, stepIndex, errors, TrueActions);
            }

            if (step.FalseActions != null)
            {
                list.AddRange(step.FalseActions);
                CheckActions(step.FalseActions, stepIndex, errors, FalseActions);
            }

            if (list.Count > 99)
            {
                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}] : All Actions", stepIndex), "Total Action Count Of True Or False Actions Cannot Exceed 99 Actions"));
            }
        }

        /// <summary>
        /// Checks the conditional steps.
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckConditionalSteps(ConditionalStep[] steps, IList<ErrorItem> errors)
        {
            if (steps != null)
            {
                if (steps.Any())
                {
                    for (int index = 0; index < steps.Length; index++)
                    {
                        var step = steps[index];

                        if (step == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}]", index), "Not Null"));
                        }
                        else
                        {
                            CheckConditions(step.Conditions, index, errors);
                            CheckConditionalActions(step, index, errors);
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem("ConfiguredSteps.ConditionalSteps", "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the conditions.
        /// </summary>
        /// <param name="conditions">The conditions.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckConditions(List<Condition> conditions, int stepIndex, IList<ErrorItem> errors)
        {
            if (conditions == null)
            {
                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions", stepIndex), "Not Null"));
            }
            else if (conditions.Any())
            {
                if (conditions.Count > 99)
                {
                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}]", stepIndex), "Cannot Exceed 99 Conditions"));
                }

                for (int index = 0; index < conditions.Count; index++)
                {
                    var condition = conditions[index];
                    if (condition == null)
                    {
                        errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}]", stepIndex, index), "Not Null"));
                    }
                    else
                    {
                        if (index == 0)
                        {
                            if (condition.Operation != ConditionOperation.If)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}]", stepIndex, index), string.Format("Must Use {0} As Its Operation", ConditionOperation.If)));
                            }
                        }
                        else
                        {
                            if (condition.Operation != ConditionOperation.AndIf && condition.Operation != ConditionOperation.OrIf)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}]", stepIndex, index), string.Format("Must Use Either {0} or {1} As Its Operation", ConditionOperation.AndIf, ConditionOperation.OrIf)));
                            }
                        }

                        if (condition.FieldNumber < 1)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].FieldNumber", stepIndex, index), "FieldNumber Not Set"));
                        }

                        if (_fieldTypes.Value.All(_ => _ != condition.FieldType))
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].FieldType", stepIndex, index), string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _interpStatuses.Value))));
                        }
                        else if (condition.FieldType == FieldType.None)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].FieldType", stepIndex, index), "Cannot use 'None'. This is a default value"));
                        }

                        if (_recordValueTypes.Value.All(_ => _ != condition.ParameterType))
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].ParameterType", stepIndex, index), string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _recordValueTypes.Value))));
                        }
                        else if (condition.ParameterType == RecordValueType.NotApplicable)
                        {
                            if (condition.FieldType != FieldType.KeyWord && condition.FieldType != FieldType.Limit)
                            {
                                var prop = string.Format(
                                    "ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].ParameterType",
                                    stepIndex,
                                    index);
                                var message = string.Format(
                                    "Cannot Use '{0}' For Parameter Type, You Must Use {1} When Using Field Type Of Either {2} or {3}",
                                    condition.ParameterType,
                                    RecordValueType.NotApplicable,
                                    FieldType.KeyWord,
                                    FieldType.Limit);
                                errors.Add(new ErrorItem(prop, message));
                            }
                        }

                        CheckParameters(condition, stepIndex, errors, index);
                    }
                }
            }
            else
            {
                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions", stepIndex), "Is Declared, But Contains No Elements"));
            }
        }

        /// <summary>
        /// Checks the decimal.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="conditionIndex">Index of the condition.</param>
        internal static void CheckDecimal(Condition condition, int stepIndex, IList<ErrorItem> errors, int conditionIndex)
        {
            if (condition.DecimalParameters != null)
            {
                if (condition.DecimalParameters.Any())
                {
                    if (condition.ParameterType != RecordValueType.Decimal)
                    {
                        errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].ParameterType", stepIndex, conditionIndex), "Parameter Type Must Match Parameters Passed In"));
                    }

                    for (int index = 0; index < condition.DecimalParameters.Count; index++)
                    {
                        var parameter = condition.DecimalParameters[index];
                        if (parameter == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}]", stepIndex, conditionIndex, index), "Not Null"));
                        }
                        else
                        {
                            var fromAsText = parameter.Value.ToString(CultureInfo.InvariantCulture);
                            if (fromAsText.Length > 12)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].Value", stepIndex, conditionIndex, index), "Cannot Exceed 12 characters"));
                            }

                            var fromParts = fromAsText.Split('.');
                            if (fromParts.Length == 1)
                            {
                                var whole = fromParts[0];
                                if (whole.Length > 7)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].Value", stepIndex, conditionIndex, index), "Value Before Decimal Cannot Be Larger Than 7 Digits"));
                                }
                            }
                            else
                            {
                                var whole = fromParts[0];
                                var partial = fromParts[1];
                                if (whole.Length > 7)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].Value", stepIndex, conditionIndex, index), "Precision Before Decimal Cannot Be Larger Than 7 Digits"));
                                }

                                if (partial.Length > 3)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].Value", stepIndex, conditionIndex, index), "Precision After Decimal Cannot Be Larger Than 3 Digits"));
                                }
                            }

                            var thruAsText = parameter.ValueThru.ToString(CultureInfo.InvariantCulture);
                            if (thruAsText.Length > 12)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].ValueThru", stepIndex, conditionIndex, index), "Cannot Exceed 12 characters"));
                            }

                            var thruParts = thruAsText.Split('.');
                            if (thruParts.Length == 1)
                            {
                                var whole = thruParts[0];
                                if (whole.Length > 7)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].ValueThru", stepIndex, conditionIndex, index), "Value Before Decimal Cannot Be Larger Than 7 Digits"));
                                }
                            }
                            else
                            {
                                var whole = thruParts[0];
                                var partial = thruParts[1];
                                if (whole.Length > 7)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].ValueThru", stepIndex, conditionIndex, index), "Precision Before Decimal Cannot Be Larger Than 7 Digits"));
                                }

                                if (partial.Length > 3)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters[{2}].ValueThru", stepIndex, conditionIndex, index), "Precision After Decimal Cannot Be Larger Than 3 Digits"));
                                }
                            }
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].DecimalParameters", stepIndex, conditionIndex), "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the decimal.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="stepName">Name of the step.</param>
        /// <param name="actionPath">The action path.</param>
        internal static void CheckDecimal(List<DecimalValue> parameters, int stepIndex, IList<ErrorItem> errors, string stepName, string actionPath)
        {
            if (parameters != null)
            {
                if (parameters.Any())
                {
                    for (int index = 0; index < parameters.Count; index++)
                    {
                        var parameter = parameters[index];
                        if (parameter == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.DecimalParameters[{1}]", stepIndex, index, stepName, actionPath), "Not Null"));
                        }
                        else
                        {
                            var parameterAsText = parameter.Value.ToString(CultureInfo.InvariantCulture);
                            if (parameterAsText.Length > 12)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.DecimalParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Cannot Exceed 12 characters"));
                            }

                            var parts = parameterAsText.Split('.');
                            if (parts.Length == 1)
                            {
                                var whole = parts[0];
                                if (whole.Length > 7)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.DecimalParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Value Before Decimal Cannot Be Larger Than 7 Digits"));
                                }
                            }
                            else
                            {
                                var whole = parts[0];
                                var partial = parts[1];
                                if (whole.Length > 7)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.DecimalParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Precision Before Decimal Cannot Be Larger Than 7 Digits"));
                                }

                                if (partial.Length > 3)
                                {
                                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.DecimalParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Precision After Decimal Cannot Be Larger Than 3 Digits"));
                                }
                            }
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{1}[{0}].{2}.DecimalParameters", stepIndex, stepName, actionPath), "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the exception steps.
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckExceptionSteps(ExceptionStep[] steps, IList<ErrorItem> errors)
        {
            if (steps != null)
            {
                if (steps.Any())
                {
                    for (int index = 0; index < steps.Length; index++)
                    {
                        var step = steps[index];
                        if (step == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ExceptionSteps[{0}]", index), "Not Null"));
                        }
                        else if (step.ExceptionId < 1)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ExceptionSteps[{0}].ExceptionId", index), "Exception Id must be set"));
                        }
                        else if (step.ExceptionId > 99)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ExceptionSteps[{0}].ExceptionId", index), "Exception Id cannot exceed 99"));
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem("ConfiguredSteps.ExceptionSteps", "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the interp data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        internal static void CheckInterpData(InterpDetailData value, IList<ErrorItem> errors)
        {
            CheckInterpValues(value, errors);

            if (_interpStatuses.Value.All(_ => _ != value.CurrentStatus))
            {
                errors.Add(new ErrorItem("CurrentStatus", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _interpStatuses.Value))));
            }
            else if (value.CurrentStatus == InterpStatus.None)
            {
                errors.Add(new ErrorItem("CurrentStatus", "Cannot use 'None'. This is a default value"));
            }

            if (_plans.Value.All(_ => _ != value.EmployeeRegion))
            {
                errors.Add(new ErrorItem("EmployeeRegion", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _interpStatuses.Value))));
            }
            else if (value.EmployeeRegion == Plan.None)
            {
                errors.Add(new ErrorItem("EmployeeRegion", "Cannot use 'None'. This is a default value"));
            }

            if (value.Comment != null)
            {
                if (value.Comment.Length > 78)
                {
                    errors.Add(new ErrorItem("Comment", "Cannot Be Longer Than 78 Characters"));
                }
            }

            if (value.ConfiguredSteps == null)
            {
                errors.Add(new ErrorItem("ConfiguredSteps", "Not Null"));
            }
            else
            {
                var steps = value.ConfiguredSteps;
                var list = new List<ConfiguredStep>();
                list.AddRange(steps.ConditionalSteps ?? Enumerable.Empty<ConfiguredStep>());
                list.AddRange(steps.UnconditionalSteps ?? Enumerable.Empty<ConfiguredStep>());
                list.AddRange(steps.ExceptionSteps ?? Enumerable.Empty<ConfiguredStep>());
                if (list.Any())
                {
                    var expectedIndexies = Enumerable.Range(1, list.Count).ToList();
                    foreach (var step in list)
                    {
                        if (expectedIndexies.Any(_ => _ == step.Index))
                        {
                            expectedIndexies.Remove(step.Index);
                        }
                        else
                        {
                            errors.Add(new ErrorItem("ConfiguredSteps", string.Format("Unexpected Index Found : {0}", step.Index)));
                        }

                        CheckComplexityExceeded(step, errors);
                    }

                    if (expectedIndexies.Any())
                    {
                        errors.Add(new ErrorItem("ConfiguredSteps", string.Format("Step Count Doe Not Match Index Requirements. Indexes Must Use 1-{0}, Inclusively", list.Count)));
                    }
                    else
                    {
                        CheckConditionalSteps(steps.ConditionalSteps, errors);
                        CheckUnconditionalSteps(steps.UnconditionalSteps, errors);
                        CheckExceptionSteps(steps.ExceptionSteps, errors);
                    }
                }
                else
                {
                    errors.Add(new ErrorItem("ConfiguredSteps", "Must Have At Least 1 Step"));
                }
            }
        }

        /// <summary>
        /// Checks the interp narrative.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        internal static void CheckInterpValues(InterpDataBase value, IList<ErrorItem> errors)
        {
            CheckOutline(value.Outline, errors);
            CheckCategory(value.Category, errors);
            CheckSubCategory(value.SubCategory, errors);
            CheckAdmitInterp(value.AdmitInterp, errors);

            CheckBusiness(value.LineOfBusiness, errors);
        }

        /// <summary>
        /// Checks the numerics.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="conditionIndex">Index of the condition.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        internal static void CheckNumerics(Condition condition, int stepIndex, IList<ErrorItem> errors, int conditionIndex)
        {
            if (condition.NumericParameters != null)
            {
                if (condition.NumericParameters.Any())
                {
                    if (condition.ParameterType != RecordValueType.Numeric)
                    {
                        errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].ParameterType", stepIndex, conditionIndex), "Parameter Type Must Match Parameters Passed In"));
                    }

                    for (int index = 0; index < condition.NumericParameters.Count; index++)
                    {
                        var parameter = condition.NumericParameters[index];
                        if (parameter == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].NumericParameters[{2}]", stepIndex, conditionIndex, index), "Not Null"));
                        }
                        else
                        {
                            if (parameter.Value > 999999999999)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].NumericParameters[{2}].Value", stepIndex, conditionIndex, index), "Cannot Exceed 999999999999"));
                            }
                            else if (parameter.Value < 0)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].NumericParameters[{2}].Value", stepIndex, conditionIndex, index), "Cannot Be Below Zero"));
                            }

                            if (parameter.ValueThru > 999999999999)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].NumericParameters[{2}].ValueThru", stepIndex, conditionIndex, index), "Cannot Exceed 999999999999"));
                            }
                            else if (parameter.ValueThru < 0)
                            {
                                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].NumericParameters[{2}].ValueThru", stepIndex, conditionIndex, index), "Cannot Be Below Zero"));
                            }
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}].NumericParameters", stepIndex, conditionIndex), "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the numerics.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="stepName">Name of the step.</param>
        /// <param name="actionPath">The action path.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        internal static void CheckNumerics(List<NumericValue> parameters, int stepIndex, IList<ErrorItem> errors, string stepName, string actionPath)
        {
            if (parameters != null)
            {
                if (parameters.Any())
                {
                    for (int index = 0; index < parameters.Count; index++)
                    {
                        var parameter = parameters[index];
                        if (parameter == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.NumericParameters[{1}]", stepIndex, index, stepName, actionPath), "Not Null"));
                        }
                        else if (parameter.Value > 999999999999)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.NumericParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Cannot Exceed 999999999999"));
                        }
                        else if (parameter.Value < 0)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{2}[{0}].{3}.NumericParameters[{1}].Value", stepIndex, index, stepName, actionPath), "Cannot Be Below Zero"));
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem(string.Format("ConfiguredSteps.{1}[{0}].{2}.NumericParameters", stepIndex, stepName, actionPath), "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Checks the Outline.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="list">The list.</param>
        internal static void CheckOutline(short outline, IList<ErrorItem> list)
        {
            CheckRange(outline, "Outline", 1, 99, list);
        }

        /// <summary>
        /// Checks the parameters.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="conditionIndex">Index of the condition.</param>
        internal static void CheckParameters(Condition condition, int stepIndex, IList<ErrorItem> errors, int conditionIndex)
        {
            var alphaIsNull = condition.AlphaParameters == null;
            var decimalIsNull = condition.DecimalParameters == null;
            var numericIsNull = condition.NumericParameters == null;
            //// ReSharper disable once InconsistentNaming
            const int CountOfExpectedNulls = 2;
            if (new[] { alphaIsNull, decimalIsNull, numericIsNull }.Count(_ => _) == CountOfExpectedNulls)
            {
                if (!alphaIsNull)
                {
                    CheckAlphas(condition, stepIndex, errors, conditionIndex);
                }

                if (!decimalIsNull)
                {
                    CheckDecimal(condition, stepIndex, errors, conditionIndex);
                }

                if (!numericIsNull)
                {
                    CheckNumerics(condition, stepIndex, errors, conditionIndex);
                }
            }
            else
            {
                if (alphaIsNull && decimalIsNull && numericIsNull)
                {
                }
                else
                {
                    errors.Add(new ErrorItem(
                            string.Format("ConfiguredSteps.ConditionalSteps[{0}].Conditions[{1}]", stepIndex, conditionIndex),
                            "Parameters For A Condition Must Be In Only 1 Parameter Type"));
                }
            }
        }

        /// <summary>
        /// Checks for match.
        /// </summary>
        /// <param name="fromInterp">The source interp.</param>
        /// <param name="toInterp">The target interp.</param>
        /// <param name="list">The list.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        internal static void CheckInterpsDiffer(InterpBase fromInterp, InterpBase toInterp, IList<ErrorItem> list)
        {
            if (fromInterp == toInterp)
            {
                list.Add(new ErrorItem("Clone", "Source and Target are the same"));
            }
        }

        /// <summary>
        /// Checks the range.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="name">The name.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="list">The list.</param>
        internal static void CheckRange(int input, string name, int min, int max, IList<ErrorItem> list)
        {
            if (input < min || input > max)
            {
                list.Add(new ErrorItem(name, string.Format("Value Out of Range; Supported Range {0}-{1}", min, max)));
            }
        }

        /// <summary>
        /// Checks the status.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        internal static void CheckStatus(InterpDataStatusBase value, IList<ErrorItem> list)
        {
            if (_statuses.Value.All(_ => _ != value.Status))
            {
                list.Add(new ErrorItem("Status", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _statuses.Value))));
            }
            else if (value.Status == Status.None)
            {
                list.Add(new ErrorItem("Status", "Cannot use 'None'. This is a default value"));
            }
        }

        /// <summary>
        /// Checks the sub category.
        /// </summary>
        /// <param name="subCategory">The sub category.</param>
        /// <param name="list">The list.</param>
        internal static void CheckSubCategory(short subCategory, IList<ErrorItem> list)
        {
            CheckRange(subCategory, "SubCategory", 0, 999, list);
        }

        /// <summary>
        /// Checks the unconditional action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="stepIndex">Index of the step.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckUnconditionalAction(StepAction action, int stepIndex, IList<ErrorItem> errors)
        {
            if (action == null)
            {
                errors.Add(new ErrorItem(string.Format("ConfiguredSteps.UnconditionalSteps[{0}].Action", stepIndex), "Not Null"));
            }
            else
            {
                var stepName = "UnconditionalSteps";
                var actionPath = "Action";

                CheckActions(action, stepIndex, errors, stepName, actionPath);
            }
        }

        /// <summary>
        /// Checks the unconditional steps.
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckUnconditionalSteps(UnconditionalStep[] steps, IList<ErrorItem> errors)
        {
            if (steps != null)
            {
                if (steps.Any())
                {
                    for (int index = 0; index < steps.Length; index++)
                    {
                        var step = steps[index];
                        if (step == null)
                        {
                            errors.Add(new ErrorItem(string.Format("ConfiguredSteps.UnconditionalSteps[{0}]", index), "Not Null"));
                        }
                        else
                        {
                            CheckUnconditionalAction(step.Action, index, errors);
                        }
                    }
                }
                else
                {
                    errors.Add(new ErrorItem("ConfiguredSteps.UnconditionalSteps", "Is Declared, But Contains No Elements"));
                }
            }
        }

        /// <summary>
        /// Data edits for the value.
        /// </summary>
        /// <param name="value">The values.</param>
        /// <param name="errors">The errors.</param>
        internal static void CheckInterpValues(CloneInterpRequest value, IList<ErrorItem> errors)
        {
            CheckOutline(value.Source.Outline, errors);
            CheckCategory(value.Source.Category, errors);
            CheckSubCategory(value.Source.SubCategory, errors);
            CheckAdmitInterp(value.Source.AdmitInterp, errors);
            CheckOutline(value.Target.Outline, errors);
            CheckCategory(value.Target.Category, errors);
            CheckSubCategory(value.Target.SubCategory, errors);
            CheckAdmitInterp(value.Target.AdmitInterp, errors);
            CheckBusiness(value.LineOfBusiness, errors);
        }

        /// <summary>
        /// Checks the status.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        internal static void CheckStatus(CloneInterpRequest value, List<ErrorItem> list)
        {
            if (_interpStatuses.Value.All(_ => _ != value.CurrentStatus))
            {
                list.Add(new ErrorItem("Status", string.Format("Must use explicit values from enumeration. \n Supported values are {0}", string.Join(",", _interpStatuses.Value))));
            }
            else if (value.CurrentStatus == InterpStatus.None)
            {
                list.Add(new ErrorItem("Status", "Cannot use 'None'. This is a default value"));
            }
        }
    }
}