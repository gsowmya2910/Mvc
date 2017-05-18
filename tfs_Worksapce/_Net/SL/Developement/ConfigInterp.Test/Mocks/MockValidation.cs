// ----------------------------------------------------------------------
// <copyright file="MockValidation.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test.Mocks
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Bl;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.IValidation" />
    [ExcludeFromCodeCoverage]
    public class MockValidation : IValidation
    {
        /// <summary>
        /// The return value for all
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly bool _returnValueForAll;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockValidation"/> class.
        /// </summary>
        /// <param name="returnValueForAll">if set to <c>true</c> [return value for all methods].</param>
        public MockValidation(bool returnValueForAll)
        {
            this._returnValueForAll = returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
        }

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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
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
            return this._returnValueForAll;
        }

        /// <summary>
        /// Determines whether the specified value has data.
        /// </summary>
        /// <param name="request">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(DeleteCipInterpRequest request, IList<ErrorItem> errors)
        {
            return this._returnValueForAll;
        }

        /// <summary>
        /// Determines whether the specified value has request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public bool HasData(CloneInterpRequest request, IList<ErrorItem> errors)
        {
            return this._returnValueForAll;
        }
    }
}