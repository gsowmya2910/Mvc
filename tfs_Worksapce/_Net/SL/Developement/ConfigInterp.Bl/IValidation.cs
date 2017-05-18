// ----------------------------------------------------------------------
// <copyright file="IValidation.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    using System.Collections.Generic;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;

    /// <summary>
    /// the interface
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool AllowedAction(DeleteInterpNarrativeData data, IList<ErrorItem> errors);

        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool AllowedAction(UpdateInterpNarrativeData data, IList<ErrorItem> errors);

        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool AllowedAction(InterpDetailData data, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool AllowedAction(StatusData value, IList<ErrorItem> errors);

        /// <summary>
        /// Allows the action.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool AllowedAction(DeleteCipInterpData data, List<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(OutlineData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(SubCategoryData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(CategoryData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(LevelData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(InquireInputData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(CreateInterpNarrativeData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(DeleteInterpNarrativeData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(UpdateInterpNarrativeData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(InquireInterpNarrativeData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(InterpDetailData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool HasData(ListRequest request, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool HasData(SystemTypeRequest request, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool HasData(OutlineCategoryListRequest request, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool HasData(FieldValidationInfoRequest request, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified request has data.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>The Value</returns>
        bool HasData(DeleteCipInterpRequest request, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(StatusData value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether [has header values] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasHeaderValues(RequestHeaderBase value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasRequest(RequestHeaderBase value, IList<ErrorItem> errors);

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        bool HasData(CloneInterpRequest request, IList<ErrorItem> errors);
    }
}