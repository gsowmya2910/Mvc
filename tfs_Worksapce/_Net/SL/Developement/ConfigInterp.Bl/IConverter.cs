// ----------------------------------------------------------------------
// <copyright file="IConverter.cs" company="CoreLink">
//        Copyright © CoreLink 2017. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    using BenefitMatrix;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Interfaces;
    using Update;

    /// <summary>
    /// The Interface
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The value
        /// </returns>
        IInquireInput Convert(InquireRequest request);

        /// <summary>
        /// Converts for the clone request
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>
        /// the value
        /// </returns>
        IInquireInput Convert(CloneInterpRequest request);

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        IBenefitMatrixCreateInput Convert(CreateInterpRequest request);

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        IBenefitMatrixNarrativeDeleteable Convert(DeleteInterpRequest request);

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        IBenefitMatrixChangeable Convert(UpdateInterpRequest request);

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        IBenefitMatrixNarrativeInquireable Convert(InquireInterpRequest request);

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="narrative">The narrative.</param>
        /// <returns>
        /// the value
        /// </returns>
        InquireNarrativeOutputData Convert(INarrative narrative);

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="request">The narrative.</param>
        /// <returns>
        /// the value
        /// </returns>
        IUpdateInterp Convert(UpdateInterpDetailRequest request);

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="request">The narrative.</param>
        /// <returns>
        /// the value
        /// </returns>
        IDeleteInterpIntialData Convert(DeleteCipInterpRequest request);

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The value.
        /// </returns>
        IStatusChangeData Convert(StatusChangeRequest request);

        /// <summary>
        /// Performs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// The value
        /// </returns>
        InquireSimpleOutputData Perform(ISimpleInquire result);

        /// <summary>
        /// Performs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// The value
        /// </returns>
        InterpDetailOutData Perform(IDetailedInquireResult result);

        /// <summary>
        /// Performs the specified result.
        /// </summary>
        /// <param name="target">The interp data base.</param>
        /// <param name="result">The detailed.</param>
        /// <returns>
        /// The value
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        InterpDetailOutData PerformCloneMove(InterpDataBase target, IDetailedInquireResult result);

        /// <summary>
        /// Performs the clone
        /// </summary>
        /// <param name="request">clone request</param>
        /// <returns>clone data</returns>
        ICloneInterpData Perform(CloneInterpRequest request);
    }
}