// <copyright file="IConfigInterpService.cs" company="CoreLink">
//     Copyright © CoreLink 2016. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ConfigInterp.Contracts
{
    using System.ServiceModel;
    using CoreLink.Core.CoreMessages.v1;
    using MessageContracts;

    /// <summary>
    /// Methods for the Config Interp service
    /// </summary>
    [ServiceContract(Namespace = ServiceNamespaces.ServiceContracts)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
    public interface IConfigInterpService
    {
        /// <summary>
        /// Clones the interp.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DetailedInterpResponse CloneInterp(CloneInterpRequest request);

        /// <summary>
        /// Creates the interp narrative.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        InterpNarrativeResponse CreateInterpNarrative(CreateInterpRequest request);

        /// <summary>
        /// Deletes the interp.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        ChangeInterpResultResponse DeleteInterp(DeleteCipInterpRequest request);

        /// <summary>
        /// Gets the action  description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>action list</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionCommonResponse GetActionDescription(ListRequest request);

        /// <summary>
        /// Gets the parameter description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>action list</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        ActionParameterDescriptionValidationInfoResponse GetActionParameterDescriptionValidationInfo(ListRequest request);

        /// <summary>
        /// Gets the action type description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// system type request
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionCommonResponse GetActionTypeDescription(SystemTypeRequest request);

        /// <summary>
        /// Gets the Outline.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// Outline list
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        AvailableOutlineCategoryResponse GetAvailableOutlineCategory(OutlineCategoryListRequest request);

        /// <summary>
        /// Gets the category description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionResponse GetCategoryDescription(CategoryRequest request);

        /// <summary>
        /// Gets the compare type description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>value list</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionCommonResponse GetCompareTypeDescription(ListRequest request);

        /// <summary>
        /// Gets the compare type description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>value list</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionCommonResponse GetConditionTypeDescription(DefaultRequest request);

        /// <summary>
        /// Gets the exception description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>system type request</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionCommonResponse GetExceptionDescription(SystemTypeRequest request);

        /// <summary>
        /// Gets the field name description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>field list</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        FieldNameResponse GetFieldNameDescription(ListRequest request);

        /// <summary>
        /// Gets the field type description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>system type request</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionCommonResponse GetFieldTypeDescription(SystemTypeRequest request);

        /// <summary>
        /// Gets the field validation info.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>field list</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        FieldValidationInfoResponse GetFieldValidationInfo(FieldValidationInfoRequest request);

        /// <summary>
        /// Gets the interp.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        SimpleInterpResponse GetInterp(InquireRequest request);

        /// <summary>
        /// Gets the interp detail.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DetailedInterpResponse GetInterpDetail(InquireRequest request);

        /// <summary>
        /// Gets the level description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionResponse GetLevelDescription(LevelRequest request);

        /// <summary>
        /// Gets the Outline description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionResponse GetOutlineDescription(OutlineRequest request);

        /// <summary>
        /// Gets the sub category description.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The Value
        /// </returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        DescriptionResponse GetSubCategoryDescription(SubCategoryRequest request);

        /// <summary>
        /// Inquires the interp narrative.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        InquireInterpResponse InquireInterpNarrative(InquireInterpRequest request);

        /// <summary>
        /// Updates the interp configuration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        ChangeInterpResultResponse UpdateInterpConfig(UpdateInterpDetailRequest request);

        /// <summary>
        /// Updates the interp narrative.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        InterpNarrativeResponse UpdateInterpNarrative(UpdateInterpRequest request);

        /// <summary>
        /// Updates the interp status.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>the value</returns>
        [OperationContract]
        [FaultContract(typeof(BusinessFault))]
        [FaultContract(typeof(ServiceUnavailableFault))]
        [FaultContract(typeof(UnhandledExceptionFault))]
        [FaultContract(typeof(ValidationFault))]
        [ServiceKnownType(typeof(AbstractCoreLinkSolutionFault))]
        ChangeInterpResultResponse UpdateInterpStatus(StatusChangeRequest request);
    }
}