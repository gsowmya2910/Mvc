//----------------------------------------------------------------
// <copyright file="CriInterpServiceClient.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.ServiceCode
{
    #region references
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    #endregion

    /// <summary>
    /// This class hold CRI Mock Interp Service call
    /// </summary>
    public class CriInterpServiceClient : ClientBase<IInterpService>, IInterpService
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CriInterpServiceClient"/> class.
        /// </summary>
        public CriInterpServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CriInterpServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public CriInterpServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CriInterpServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CriInterpServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CriInterpServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CriInterpServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CriInterpServiceClient"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CriInterpServiceClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        #endregion

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns IsValidInterpIdResponse object</returns>
        public IsValidInterpIdResponse IsValidInterpId(IsValidInterpIdRequest request)
        {
            return this.Channel.IsValidInterpId(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetInterpIdsResponse object</returns>
        public GetInterpIdsResponse GetInterpIds(GetInterpIdsRequest request)
        {
            return this.Channel.GetInterpIds(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetInterpDetailResponse object</returns>
        public GetInterpDetailResponse GetInterpDetail(GetInterpDetailRequest request)
        {
            return this.Channel.GetInterpDetail(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns CreateInterpResponse object</returns>
        public CreateInterpResponse CreateInterp(CreateInterpRequest request)
        {
            return this.Channel.CreateInterp(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns UpdateInterpStatusResponse object</returns>
        public UpdateInterpStatusResponse UpdateInterpStatus(UpdateInterpStatusRequest request)
        {
            return this.Channel.UpdateInterpStatus(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns UpdateInterpConfigResponse object</returns>
        public UpdateInterpConfigResponse UpdateInterpConfig(UpdateInterpConfigRequest request)
        {
            return this.Channel.UpdateInterpConfig(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns CloneInterpResponse object</returns>
        public CloneInterpResponse CloneInterp(CloneInterpRequest request)
        {
            return this.Channel.CloneInterp(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns DeleteInterpResponse object</returns>
        public DeleteInterpResponse DeleteInterp(DeleteInterpRequest request)
        {
            return this.DeleteInterp(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetFieldNamesResponse object</returns>
        public GetFieldNamesResponse GetFieldNames(GetFieldNamesRequest request)
        {
            return this.Channel.GetFieldNames(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetOutlineDescResponse object</returns>
        public GetOutlineDescResponse GetOutlineDesc(GetOutlineDescRequest request)
        {
            return this.Channel.GetOutlineDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetCategoryDescResponse object</returns>
        public GetCategoryDescResponse GetCategoryDesc(GetCategoryDescRequest request)
        {
            return this.Channel.GetCategoryDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetSubcategoryDescResponse object</returns>
        public GetSubcategoryDescResponse GetSubcategoryDesc(GetSubcategoryDescRequest request)
        {
            return this.Channel.GetSubcategoryDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetLevelDescResponse object</returns>
        public GetLevelDescResponse GetLevelDesc(GetLevelDescRequest request)
        {
            return this.Channel.GetLevelDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetExceptionDescResponse object</returns>
        public GetExceptionDescResponse GetExceptionDesc(GetExceptionDescRequest request)
        {
            return this.Channel.GetExceptionDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetActionTypeDescResponse object</returns>
        public GetActionTypeDescResponse GetActionTypeDesc(GetActionTypeDescRequest request)
        {
            return this.Channel.GetActionTypeDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetActionDescResponse object</returns>
        public GetActionDescResponse GetActionDesc(GetActionDescRequest request)
        {
            return this.Channel.GetActionDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetFieldTypeResponse object</returns>
        public GetFieldTypeResponse GetFieldType(GetFieldTypeRequest request)
        {
            return this.Channel.GetFieldType(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetFieldDescResponse object</returns>
        public GetFieldDescResponse GetFieldDesc(GetFieldDescRequest request)
        {
            return this.Channel.GetFieldDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetCompareTypeDescResponse object</returns>
        public GetCompareTypeDescResponse GetCompareTypeDesc(GetCompareTypeDescRequest request)
        {
            return this.Channel.GetCompareTypeDesc(request);
        }

        /// <summary>
        /// Returns response object
        /// </summary>
        /// <param name="request">request object</param>
        /// <returns>Returns GetConditionTypeDescResponse object</returns>
        public GetConditionTypeDescResponse GetConditionTypeDesc(GetConditionTypeDescRequest request)
        {
            return this.Channel.GetConditionTypeDesc(request);
        }
    }
}