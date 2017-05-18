//----------------------------------------------------------------
// <copyright file="InterpServiceClient.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.ServiceCode
{
    #region references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Text;
    using System.Threading.Tasks;
    using schemas.corelinksolutions.com.infrastructure.schema.coremessages.v1;
    #endregion

    /// <summary>
    /// This class is CoreLink Interp service client
    /// </summary>
    public class InterpServiceClient : ClientBase<IConfigInterpService>, IConfigInterpService
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="InterpServiceClient"/> class.
        /// </summary>
        public InterpServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterpServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public InterpServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterpServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public InterpServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterpServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public InterpServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterpServiceClient"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public InterpServiceClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        #endregion

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns InterpNarrativeResponse object </returns>
        public InterpNarrativeResponse CreateInterpNarrative(CreateInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("CreateInterpNarrative Request: ", request);
            return this.Channel.CreateInterpNarrative(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object </returns>
        public DescriptionCommonResponse GetActionDescription(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetActionDescription Request: ", request);
            return this.Channel.GetActionDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ActionParameterDescriptionValidationInfoResponse object </returns>
        public ActionParameterDescriptionValidationInfoResponse GetActionParameterDescriptionValidationInfo(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetActionParameterDescriptionValidationInfo Request: ", request);
            return this.Channel.GetActionParameterDescriptionValidationInfo(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object </returns>
        public DescriptionCommonResponse GetActionTypeDescription(SystemTypeRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetActionTypeDescription Request: ", request);
            return this.Channel.GetActionTypeDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns AvailableOutlineCategoryResponse object </returns>
        public AvailableOutlineCategoryResponse GetAvailableOutlineCategory(OutlineCategoryListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetAvailableOutlineCategory Request: ", request);
            return this.Channel.GetAvailableOutlineCategory(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object </returns>
        public DescriptionResponse GetCategoryDescription(CategoryRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetCategoryDescription Request: ", request);
            return this.Channel.GetCategoryDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object </returns>
        public DescriptionCommonResponse GetCompareTypeDescription(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetCompareTypeDescription Request: ", request);
            return this.Channel.GetCompareTypeDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object </returns>
        public DescriptionCommonResponse GetConditionTypeDescription(DefaultRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetConditionTypeDescription Request: ", request);
            return this.Channel.GetConditionTypeDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object </returns>
        public DescriptionCommonResponse GetExceptionDescription(SystemTypeRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetExceptionDescription Request: ", request);
            return this.Channel.GetExceptionDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns FieldNameResponse object </returns>
        public FieldNameResponse GetFieldNameDescription(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetFieldNameDescription Request: ", request);
            return this.Channel.GetFieldNameDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object </returns>
        public DescriptionCommonResponse GetFieldTypeDescription(SystemTypeRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetFieldTypeDescription Request: ", request);
            return this.Channel.GetFieldTypeDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns FieldValidationInfoResponse object </returns>
        public FieldValidationInfoResponse GetFieldValidationInfo(FieldValidationInfoRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetFieldValidationInfo Request: ", request);
            return this.Channel.GetFieldValidationInfo(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns SimpleInterpResponse object </returns>
        public SimpleInterpResponse GetInterp(InquireRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetInterp Request: ", request);
            return this.Channel.GetInterp(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DetailedInterpResponse object </returns>
        public DetailedInterpResponse GetInterpDetail(InquireRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetInterpDetail Request: ", request);
            return this.Channel.GetInterpDetail(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object </returns>
        public DescriptionResponse GetLevelDescription(LevelRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetLevelDescription Request: ", request);
            return this.Channel.GetLevelDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object </returns>
        public DescriptionResponse GetOutlineDescription(OutlineRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetOutlineDescription Request: ", request);
            return this.Channel.GetOutlineDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object </returns>
        public DescriptionResponse GetSubCategoryDescription(SubCategoryRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetSubCategoryDescription Request: ", request);
            return this.Channel.GetSubCategoryDescription(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns InquireInterpResponse object </returns>
        public InquireInterpResponse InquireInterpNarrative(InquireInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("InquireInterpNarrative Request: ", request);
            return this.Channel.InquireInterpNarrative(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ChangeInterpResultResponse object </returns>
        public ChangeInterpResultResponse UpdateInterpConfig(UpdateInterpDetailRequest request)
        {
            Helpers.Utility.ConsoleLogger("UpdateInterpConfig Request: ", request);
            return this.Channel.UpdateInterpConfig(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns InquireInterpResponse object </returns>
        public InterpNarrativeResponse UpdateInterpNarrative(UpdateInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("UpdateInterpNarrative Request: ", request);
            return this.Channel.UpdateInterpNarrative(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DetailedInterpResponse object</returns>
        public DetailedInterpResponse CloneInterp(CloneInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("CloneInterp Request: ", request);
            return this.Channel.CloneInterp(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns Task of DetailedInterpResponse object</returns>
        public Task<DetailedInterpResponse> CloneInterpAsync(CloneInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("CloneInterpAsync Request: ", request);
            return this.Channel.CloneInterpAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns InterpNarrativeResponse object</returns>
        public Task<InterpNarrativeResponse> CreateInterpNarrativeAsync(CreateInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("CreateInterpNarrativeAsync Request: ", request);
            return this.Channel.CreateInterpNarrativeAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ChangeInterpResultResponse object</returns>
        public ChangeInterpResultResponse DeleteInterp(DeleteCipInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("DeleteInterp Request: ", request);
            return this.Channel.DeleteInterp(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ChangeInterpResultResponse object</returns>
        public Task<ChangeInterpResultResponse> DeleteInterpAsync(DeleteCipInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("DeleteInterpAsync Request: ", request);
            return this.Channel.DeleteInterpAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object</returns>
        public Task<DescriptionCommonResponse> GetActionDescriptionAsync(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetActionDescriptionAsync Request: ", request);
            return this.Channel.GetActionDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ActionParameterDescriptionValidationInfoResponse object</returns>
        public Task<ActionParameterDescriptionValidationInfoResponse> GetActionParameterDescriptionValidationInfoAsync(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetActionParameterDescriptionValidationInfoAsync Request: ", request);
            return this.Channel.GetActionParameterDescriptionValidationInfoAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object</returns>
        public Task<DescriptionCommonResponse> GetActionTypeDescriptionAsync(SystemTypeRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetActionTypeDescriptionAsync Request: ", request);
            return this.Channel.GetActionTypeDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns AvailableOutlineCategoryResponse object</returns>
        public Task<AvailableOutlineCategoryResponse> GetAvailableOutlineCategoryAsync(OutlineCategoryListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetAvailableOutlineCategoryAsync Request: ", request);
            return this.Channel.GetAvailableOutlineCategoryAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object</returns>
        public Task<DescriptionResponse> GetCategoryDescriptionAsync(CategoryRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetCategoryDescriptionAsync Request: ", request);
            return this.Channel.GetCategoryDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object</returns>
        public Task<DescriptionCommonResponse> GetCompareTypeDescriptionAsync(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetCompareTypeDescriptionAsync Request: ", request);
            return this.Channel.GetCompareTypeDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object</returns>
        public Task<DescriptionCommonResponse> GetConditionTypeDescriptionAsync(DefaultRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetConditionTypeDescriptionAsync Request: ", request);
            return this.Channel.GetConditionTypeDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object</returns>
        public Task<DescriptionCommonResponse> GetExceptionDescriptionAsync(SystemTypeRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetExceptionDescriptionAsync Request: ", request);
            return this.Channel.GetExceptionDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns FieldNameResponse object</returns>
        public Task<FieldNameResponse> GetFieldNameDescriptionAsync(ListRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetFieldNameDescriptionAsync Request: ", request);
            return this.Channel.GetFieldNameDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionCommonResponse object</returns>
        public Task<DescriptionCommonResponse> GetFieldTypeDescriptionAsync(SystemTypeRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetFieldTypeDescriptionAsync Request: ", request);
            return this.Channel.GetFieldTypeDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns FieldValidationInfoResponse object</returns>
        public Task<FieldValidationInfoResponse> GetFieldValidationInfoAsync(FieldValidationInfoRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetFieldValidationInfoAsync Request: ", request);
            return this.Channel.GetFieldValidationInfoAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns SimpleInterpResponse object</returns>
        public Task<SimpleInterpResponse> GetInterpAsync(InquireRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetInterpAsync Request: ", request);
            return this.Channel.GetInterpAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DetailedInterpResponse object</returns>
        public Task<DetailedInterpResponse> GetInterpDetailAsync(InquireRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetInterpDetailAsync Request: ", request);
            return this.Channel.GetInterpDetailAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object</returns>
        public Task<DescriptionResponse> GetLevelDescriptionAsync(LevelRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetLevelDescriptionAsync Request: ", request);
            return this.Channel.GetLevelDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object</returns>
        public Task<DescriptionResponse> GetOutlineDescriptionAsync(OutlineRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetOutlineDescriptionAsync Request: ", request);
            return this.Channel.GetOutlineDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DescriptionResponse object</returns>
        public Task<DescriptionResponse> GetSubCategoryDescriptionAsync(SubCategoryRequest request)
        {
            Helpers.Utility.ConsoleLogger("GetSubCategoryDescriptionAsync Request: ", request);
            return this.Channel.GetSubCategoryDescriptionAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns InquireInterpResponse object</returns>
        public Task<InquireInterpResponse> InquireInterpNarrativeAsync(InquireInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("InquireInterpNarrativeAsync Request: ", request);
            return this.Channel.InquireInterpNarrativeAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ChangeInterpResultResponse object</returns>
        public Task<ChangeInterpResultResponse> UpdateInterpConfigAsync(UpdateInterpDetailRequest request)
        {
            Helpers.Utility.ConsoleLogger("UpdateInterpConfigAsync Request: ", request);
            return this.Channel.UpdateInterpConfigAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns InterpNarrativeResponse object</returns>
        public Task<InterpNarrativeResponse> UpdateInterpNarrativeAsync(UpdateInterpRequest request)
        {
            Helpers.Utility.ConsoleLogger("UpdateInterpNarrativeAsync Request: ", request);
            return this.Channel.UpdateInterpNarrativeAsync(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ChangeInterpResultResponse object</returns>
        public ChangeInterpResultResponse UpdateInterpStatus(StatusChangeRequest request)
        {
            Helpers.Utility.ConsoleLogger("UpdateInterpStatus Request: ", request);
            return this.Channel.UpdateInterpStatus(request);
        }

        /// <summary>
        /// Return response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns ChangeInterpResultResponse object</returns>
        public Task<ChangeInterpResultResponse> UpdateInterpStatusAsync(StatusChangeRequest request)
        {
            Helpers.Utility.ConsoleLogger("UpdateInterpStatusAsync Request: ", request);
            return this.Channel.UpdateInterpStatusAsync(request);
        }
    }
}