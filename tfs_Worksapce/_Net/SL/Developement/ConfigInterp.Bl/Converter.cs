// ----------------------------------------------------------------------
// <copyright file="Converter.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using BenefitMatrix;
    using Contracts.DataContracts;
    using Contracts.MessageContracts;
    using Inquire;
    using Interfaces;
    using Update;

    /// <summary>
    /// The class
    /// </summary>
    public class Converter : IConverter
    {
        /// <summary>
        /// The businesses
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<IEnumerable<LineOfBusiness>> _businesses = new Lazy<IEnumerable<LineOfBusiness>>(() => Utilities.ExplicitValues<LineOfBusiness>().Where(_ => _.NarrativeType() > 0));

        /// <summary>
        /// The business lookup
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<IDictionary<short, LineOfBusiness>> _businessLookup = new Lazy<IDictionary<short, LineOfBusiness>>(() => _businesses.Value.ToDictionary(_ => _.NarrativeType(), _ => _));

        /// <summary>
        /// The status lookup
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<IDictionary<string, Status>> _statusLookup = new Lazy<IDictionary<string, Status>>(() => Utilities.ExplicitValues<Status>().ToDictionary(_ => _.GetDescriptionValue(), _ => _));

        /// <summary>
        /// The step converter
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private readonly IStepConverter _stepConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="stepConverter">The step converter.</param>
        public Converter(IStepConverter stepConverter)
        {
            this._stepConverter = stepConverter;
        }

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The value
        /// </returns>
        public IInquireInput Convert(InquireRequest request)
        {
            var retValue = new InquireInput
            {
                SubCategory = request.Data.SubCategory,
                Category = request.Data.Category,
                Status = request.Data.Status,
                Outline = request.Data.Outline,
                AdmitInterp = request.Data.AdmitInterp,
                MainFrameUsercode = request.UnisysUsercode,
                SystemType = request.Data.LineOfBusiness,
                Region = (short)request.Region
            };
            return retValue;
        }

        /// <summary>
        /// Converts for the clone request
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>
        /// the value
        /// </returns>
        public IInquireInput Convert(CloneInterpRequest request)
        {
            var retValue = new InquireInput
            {
                SubCategory = request.Source.SubCategory,
                Category = request.Source.Category,
                Status = request.CurrentStatus,
                Outline = request.Source.Outline,
                AdmitInterp = request.Source.AdmitInterp,
                MainFrameUsercode = request.UnisysUsercode,
                SystemType = request.LineOfBusiness,
                Region = (short)request.Region
            };
            return retValue;
        }

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        public IBenefitMatrixCreateInput Convert(CreateInterpRequest request)
        {
            var returnValue = new BenefitMatrixCreateInput();
            SetCommon(returnValue, request);
            SetInterp(returnValue, request.Data);
            return returnValue;
        }

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        public IBenefitMatrixNarrativeDeleteable Convert(DeleteInterpRequest request)
        {
            var returnValue = new BenefitMatrixDeleteInput();
            SetCommon(returnValue, request);
            SetInterp(returnValue, request.Data);
            SetStatus(returnValue, request.Data);
            return returnValue;
        }

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        public IBenefitMatrixChangeable Convert(UpdateInterpRequest request)
        {
            IBenefitMatrixChangeable returnValue = new BenefitMatrixChange
            {
                Narrative = request.Data.NarrativeLines
            };
            SetCommon(returnValue, request);
            SetInterp(returnValue, request.Data);
            SetStatus(returnValue, request.Data);
            return returnValue;
        }

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// the value
        /// </returns>
        public IBenefitMatrixNarrativeInquireable Convert(InquireInterpRequest request)
        {
            IBenefitMatrixNarrativeInquireable returnValue = new BenefitMatrixInqureInput();
            SetCommon(returnValue, request);
            SetInterp(returnValue, request.Data);
            SetStatus(returnValue, request.Data);
            return returnValue;
        }

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="narrative">The narrative.</param>
        /// <returns>
        /// the value
        /// </returns>
        public InquireNarrativeOutputData Convert(INarrative narrative)
        {
            Status value = _statusLookup.Value[narrative.Status];

            var returnValue = new InquireNarrativeOutputData
            {
                Category = narrative.Category,
                EmployeeName = narrative.Employee.Name,
                EmployeeNumber = narrative.Employee.Number,
                AdmitInterp = narrative.AdmitInterp,
                MaintenanceDate = narrative.MaintenanceDate,
                Outline = narrative.Outline,
                SequenceNumber = narrative.SequenceNumber,
                StatusDate = narrative.StatusDate,
                SubCategory = narrative.Subcategory,
                Status = value,
                LineOfBusiness = ReverseLookup(narrative.NarrativeType)
            };

            return returnValue;
        }

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="request">The narrative.</param>
        /// <returns>
        /// the value
        /// </returns>
        public IUpdateInterp Convert(UpdateInterpDetailRequest request)
        {
            IUpdateInterp value = new UpdateInterpSteps
            {
                SubCategory = request.Data.SubCategory,
                Category = request.Data.Category,
                Region = (short)request.Region,
                SystemType = request.Data.LineOfBusiness,
                Outline = request.Data.Outline,
                AdmitInterp = request.Data.AdmitInterp,
                Comment = request.Data.Comment,
                EmployeeRegion = request.Data.EmployeeRegion,
                CurrentStatus = request.Data.CurrentStatus,
                EmployeeNumber = request.Data.EmployeeNumber,
                MainFrameUsercode = request.UnisysUsercode,
                Steps = this.ConvertSteps(request.Data.ConfiguredSteps),
                StatusDateTime = DateTime.Now
            };

            return value;
        }

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="request">The narrative.</param>
        /// <returns>
        /// the value
        /// </returns>
        public IDeleteInterpIntialData Convert(DeleteCipInterpRequest request)
        {
            IDeleteInterpIntialData value = new DeleteInterpIntialData
            {
                SubCategory = request.Data.SubCategory,
                Category = request.Data.Category,
                Region = (short)request.Region,
                SystemType = request.Data.LineOfBusiness,
                Outline = request.Data.Outline,
                AdmitInterp = request.Data.AdmitInterp,
                MainFrameUsercode = request.UnisysUsercode,
                Status = request.Data.Status,
                BlueUser = request.UserId
            };
            return value;
        }

        /// <summary>
        /// Converts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The value.
        /// </returns>
        public IStatusChangeData Convert(StatusChangeRequest request)
        {
            IStatusChangeData retValue = new StatusChange
            {
                SubCategory = request.Data.SubCategory,
                Category = request.Data.Category,
                Region = (short)request.Region,
                Outline = request.Data.Outline,
                AdmitInterp = request.Data.AdmitInterp,
                SystemType = request.Data.LineOfBusiness,
                CurrentStatus = request.Data.CurrentStatus,
                MainFrameUsercode = request.UnisysUsercode,
                TargetStatus = request.Data.TargetStatus,
                BlueUser = request.UserId
            };
            return retValue;
        }

        /// <summary>
        /// Performs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// The value
        /// </returns>
        public InquireSimpleOutputData Perform(ISimpleInquire result)
        {
            var retValue = new InquireSimpleOutputData();
            SetInquireBase(retValue, result);
            SetLastEdited(result, retValue);
            retValue.Level = result.Level;
            return retValue;
        }

        /// <summary>
        /// Performs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// The value
        /// </returns>
        public InterpDetailOutData Perform(IDetailedInquireResult result)
        {
            var retValue = new InterpDetailOutData();
            SetInquireBase(retValue, result);

            SetLastEdited(result, retValue);
            this.ConvertSteps(retValue, result.StepData);
            return retValue;
        }

        /// <summary>
        /// Performs the clone
        /// </summary>
        /// <param name="request">clone request</param>
        /// <returns>clone data</returns>
        public ICloneInterpData Perform(CloneInterpRequest request)
        {
            ICloneInterpData value = new CloneInterpData
            {
                BlueUser = request.UserId,
                CurrentStatus = request.CurrentStatus,
                MainFrameUsercode = request.UnisysUsercode,
                Region = (short)request.Region,
                Source = new InterpNoType
                {
                    AdmitInterp = request.Source.AdmitInterp,
                    Category = request.Source.Category,
                    Outline = request.Source.Outline,
                    SubCategory = request.Source.SubCategory
                },

                Target = new InterpNoType
                {
                    AdmitInterp = request.Target.AdmitInterp,
                    Category = request.Target.Category,
                    Outline = request.Target.Outline,
                    SubCategory = request.Target.SubCategory
                },
                SystemType = request.LineOfBusiness
            };
            return value;
        }

        /// <summary>
        /// Performs the specified result.
        /// </summary>
        /// <param name="target">The interp data base.</param>
        /// <param name="result">The detailed.</param>
        /// <returns>
        /// The value
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public InterpDetailOutData PerformCloneMove(InterpDataBase target, IDetailedInquireResult result)
        {
            var retValue = new InterpDetailOutData();

            // Set inital status to Draft
            SetInquireBaseClone(target, result);
            this.ConvertSteps(retValue, result.StepData);
            return retValue;
        }

        /// <summary>
        /// Reverses the lookup.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static LineOfBusiness ReverseLookup(short value)
        {
            LineOfBusiness lookedUpBusiness;
            if (_businessLookup.Value.TryGetValue(value, out lookedUpBusiness))
            {
                return lookedUpBusiness;
            }

            foreach (var business in _businesses.Value)
            {
                var firstFromType = business.NarrativeType().ToString().First();
                var firstFromValue = value.ToString().First();
                if (firstFromValue == firstFromType)
                {
                    return business;
                }
            }

            return LineOfBusiness.None;
        }

        /// <summary>
        /// Sets the common.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        internal static void SetCommon(IBenefitMatrixNarrativeInputBase target, RequestHeaderBase source)
        {
            target.MainframeUsercode = source.UnisysUsercode;
            target.BlueUser = source.UserId;
            target.Region = (short)source.Region;
        }

        /// <summary>
        /// Inquires the base.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="source">The source.</param>
        internal static void SetInquireBase(InterpConfigBase target, IInquireDataResultBase source)
        {
            target.AdmitInterp = source.AdmitInterp;
            target.Category = source.Category;
            target.Comment = source.Comment;
            target.CurrentStatus = source.CurrentStatus;
            target.EmployeeNumber = source.EmployeeNumber;
            target.EmployeeRegion = source.EmployeeRegion;
            target.Outline = source.Outline;
            target.SubCategory = source.SubCategory;
            target.LineOfBusiness = source.SystemType;
        }

        /// <summary>
        /// Inquires the base.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="source">The source.</param>
        internal static void SetInquireBase(InterpDetailOutData target, IInquireDataResultBase source)
        {
            target.AdmitInterp = source.AdmitInterp;
            target.Category = source.Category;
            target.Comment = source.Comment;
            target.CurrentStatus = source.CurrentStatus;
            target.EmployeeNumber = source.EmployeeNumber;
            target.EmployeeRegion = source.EmployeeRegion;
            target.Outline = source.Outline;
            target.SubCategory = source.SubCategory;
            target.LineOfBusiness = source.SystemType;
        }

        /// <summary>
        /// Inquires the base.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="source">The source.</param>
        internal static void SetInquireBaseClone(InterpDataBase target, IInquireDataResultBase source)
        {
            target.AdmitInterp = source.AdmitInterp;
            target.Category = source.Category;
            target.Outline = source.Outline;
            target.SubCategory = source.SubCategory;
            target.LineOfBusiness = source.SystemType;
        }

        /// <summary>
        /// Sets the interp.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        internal static void SetInterp(IBenefitMatrixNarrativeInputBase target, InterpDataBase source)
        {
            target.Interp = new Interp
            {
                SubCategory = source.SubCategory,
                Category = source.Category,
                Level = source.LineOfBusiness.NarrativeType(),
                Outline = source.Outline,
                AdmitInterp = source.AdmitInterp
            };
        }

        /// <summary>
        /// Sets the last edited.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="retValue">The ret value.</param>
        internal static void SetLastEdited(ISimpleInquire result, InquireSimpleOutputData retValue)
        {
            if (result.StatusDateTime != default(DateTime))
            {
                retValue.LastEdited = result.StatusDateTime;
            }
        }

        /// <summary>
        /// Sets the last edited.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="retValue">The ret value.</param>
        internal static void SetLastEdited(IDetailedInquireResult result, InterpDetailOutData retValue)
        {
            if (result.StatusDateTime != default(DateTime))
            {
                retValue.LastEdited = result.StatusDateTime;
            }
        }

        /// <summary>
        /// Sets the status.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        internal static void SetStatus(IHasStatus target, InterpDataStatusBase source)
        {
            target.Status = source.Status;
        }

        /// <summary>
        /// Converts the steps.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="source">The step data.</param>
        internal void ConvertSteps(InterpDetailData target, IEnumerable<IStepDataMap> source)
        {
            target.ConfiguredSteps = this._stepConverter.ConvertSteps(source);
        }

        /// <summary>
        /// Converts the steps.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="source">The step data.</param>
        internal void ConvertSteps(InterpDetailOutData target, IEnumerable<IStepDataMap> source)
        {
            target.ConfiguredSteps = this._stepConverter.ConvertSteps(source);
        }

        /// <summary>
        /// Converts the steps.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal IStepDataMap[] ConvertSteps(ConfiguredSteps source)
        {
            var value = this._stepConverter.ConvertToFlatData(source).ToArray();
            return value;
        }
    }
}