// ----------------------------------------------------------------------
// <copyright file="CipUpdateHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using CIPUPD01;
    using Contracts.DataContracts;
    using Interfaces;
    using Microsoft.HostIntegration.TI;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Update.ICipUpdateHandler" />
    public class CipUpdateHandler : ICipUpdateHandler
    {
        /// <summary>
        /// The maximum steps to save
        /// </summary>
        public const short MaxStepsToSave = 150;

        /// <summary>
        /// The application name
        /// </summary>
        private const string ApplicationName = "CIP";

        /// <summary>
        /// The date format
        /// </summary>
        private const string DateFormat = "yyyyMMdd";

        /// <summary>
        /// The time format
        /// </summary>
        private const string TimeFormat = "HHmmss";

        /// <summary>
        /// The transaction code
        /// </summary>
        private const string TransactionCode = "CIPUPD";

        /// <summary>
        /// The version number
        /// </summary>
        private const short VersionNumber = 1;

        /// <summary>
        /// Gets or sets the implementation.
        /// </summary>
        /// <value>
        /// The implementation.
        /// </value>
        internal ICipUpdateTiWrapper Implementation { get; set; }

        /// <summary>
        /// Updates the interp.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public UpdateResult UpdateInterp(IUpdateInterp input)
        {
            ICipUpdateTiWrapper com = this.GetImplementation(input.Region);
            InputHeader header = CreateHeader(input);
            KeyInfo info = CreateInfo(input);
            var batches = Batch(input.Steps).ToArray();
            var responses = new List<UpdateResult>();
            short page = 1;
            foreach (var batch in batches)
            {
                var batchTable = batch.ToArray();
                RecordTable[] inRecTable = CreateRecords(batchTable);
                var stepCountInTransaction = inRecTable.Select(_ => _.StepID).Distinct().Count();

                KeyInfo batchInfo = info;
                batchInfo.TransactionCount = page;
                batchInfo.StepCount = (short)stepCountInTransaction;
                short inTableOccurs = (short)batchTable.Length;
                OutputHeader response = default(OutputHeader);

                OperationResult result;
                CustomTIException exception = null;
                try
                {
                    com.UpdateInterp(header, batchInfo, inTableOccurs, inRecTable, out response);
                    result = OperationResult.Success;
                }
                catch (CustomTIException e)
                {
                    exception = e;
                    result = OperationResult.Failed;
                }

                responses.Add(new UpdateResult
                {
                    MessageNumber = response.MessageNumber,
                    MessageText = response.MessageText,
                    Result = result,
                    Exception = exception
                });

                page++;
            }

            var compiledResponse = new UpdateResult
            {
                Result = responses.All(_ => _.Result == OperationResult.Success) ? OperationResult.Success : OperationResult.Failed,
            };
            if (compiledResponse.Result == OperationResult.Failed)
            {
                compiledResponse.Exception = responses.First(_ => _.Exception != null).Exception;
            }
            else if (responses.Any(_ => !_.Success))
            {
                var transactionFailure = responses.First(_ => !_.Success);
                compiledResponse.MessageNumber = transactionFailure.MessageNumber;
                compiledResponse.MessageText = transactionFailure.MessageText;
            }

            return compiledResponse;
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The value.</returns>
        public UpdateResult UpdateStatus(IStatusChange input)
        {
            ICipUpdateTiWrapper com = this.GetImplementation(input.Region);
            InputHeader header = CreateHeader(input);
            KeyInfo info = CreateInfo(input);

            OutputHeader response = default(OutputHeader);

            OperationResult operationResult;
            CustomTIException exception = null;
            try
            {
                com.UpdateInterpStatus(header, info, out response);
                operationResult = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                operationResult = OperationResult.Failed;
            }

            var result = new UpdateResult
            {
                MessageNumber = response.MessageNumber,
                MessageText = response.MessageText,
                Result = operationResult,
                Exception = exception
            };
            return result;
        }

        /// <summary>Deletes  the interp.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public UpdateResult DeleteInterp(IDeleteInterp input)
        {
            ICipUpdateTiWrapper com = this.GetImplementation(input.Region);
            InputHeader header = CreateHeader(input);
            KeyInfo info = DeleteInfo(input);

            OutputHeader outHeader = default(OutputHeader);

            OperationResult result;
            CustomTIException exception = null;
            try
            {
                com.DeleteInterp(header, info, out outHeader);
                result = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                result = OperationResult.Failed;
            }

            var response = new UpdateResult
            {
                MessageNumber = outHeader.MessageNumber,
                MessageText = outHeader.MessageText,
                Result = result,
                Exception = exception
            };
            return response;
        }

        /// <summary>
        /// Batches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static IEnumerable<IEnumerable<IStepDataMap>> Batch(IEnumerable<IStepDataMap> input)
        {
            var superList = new List<List<IStepDataMap>>();
            var currentList = new List<IStepDataMap>();
            foreach (var groupedRecords in input.GroupBy(_ => _.StepId))
            {
                var records = groupedRecords.ToArray();
                if (records.Length + currentList.Count > MaxStepsToSave)
                {
                    superList.Add(currentList);
                    currentList = new List<IStepDataMap>();
                    currentList.AddRange(records);
                }
                else
                {
                    currentList.AddRange(records);
                }
            }

            superList.Add(currentList);
            return superList;
        }

        /// <summary>
        /// Gets the implementation.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns>
        /// the value
        /// </returns>
        [ExcludeFromCodeCoverage]
        internal ICipUpdateTiWrapper GetImplementation(short region)
        {
            return this.Implementation ?? new CipUpdateTiWrapper(region);
        }

        /// <summary>
        /// Creates the header.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static InputHeader CreateHeader(IMainFrameUsercode input)
        {
            var value = new InputHeader
            {
                MainFrameUsercode = input.MainFrameUsercode,
                VersionNumber = VersionNumber,
                Trancode = TransactionCode,
                AppName = ApplicationName
            };
            return value;
        }

        /// <summary>
        /// Creates the information.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        private static KeyInfo CreateInfo(IStatusChange input)
        {
            var value = new KeyInfo
            {
                Outline = input.Outline,
                Category = input.Category,
                SubCategory = input.SubCategory,
                AdmitIntp = input.AdmitInterp,
                SystemType = (short)input.SystemType,
                Comment = input.Comment,
                CurrentStatus = (short)input.TargetStatus,
                EmployeeRegion = (short)input.EmployeeRegion,
                StatusDate = int.Parse(input.StatusDateTime.ToString(DateFormat)),
                StatusTime = int.Parse(input.StatusDateTime.ToString(TimeFormat)),
                EmployeeNumber = input.EmployeeNumber,
                CreateByRevision = 1,
                RevisionNumber = input.RevisionNumber,
                RevisionSequence = input.RevisionSequence
            };
            return value;
        }

        /// <summary>
        /// Creates the information.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        private static KeyInfo DeleteInfo(IDeleteInterp input)
        {
            var value = new KeyInfo
            {
                Outline = input.Outline,
                Category = input.Category,
                SubCategory = input.SubCategory,
                AdmitIntp = input.AdmitInterp,
                SystemType = (short)input.SystemType,
                Comment = input.Comment,
                EmployeeRegion = (short)input.EmployeeRegion,
                StatusDate = int.Parse(input.StatusDateTime.ToString(DateFormat)),
                StatusTime = int.Parse(input.StatusDateTime.ToString(TimeFormat)),
                EmployeeNumber = input.EmployeeNumber,
                CreateByRevision = input.CreateByRevision,
                RevisionNumber = input.RevisionNumber,
                RevisionSequence = input.RevisionSequence
            };
            return value;
        }

        /// <summary>
        /// Creates the information.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static KeyInfo CreateInfo(IKeyInfoIn input)
        {
            var value = new KeyInfo
            {
                Outline = input.Outline,
                Category = input.Category,
                SubCategory = input.SubCategory,
                AdmitIntp = input.AdmitInterp,
                SystemType = (short)input.SystemType,
                Comment = input.Comment,
                CurrentStatus = (short)input.CurrentStatus,
                EmployeeRegion = (short)input.EmployeeRegion,
                StatusDate = int.Parse(input.StatusDateTime.ToString(DateFormat)),
                StatusTime = int.Parse(input.StatusDateTime.ToString(TimeFormat)),
                EmployeeNumber = input.EmployeeNumber,
                CreateByRevision = 1,
                RevisionNumber = 1,
                RevisionSequence = 1
            };
            return value;
        }

        /// <summary>
        /// Creates the records.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static RecordTable[] CreateRecords(IEnumerable<IStepDataMap> input)
        {
            if (input != null)
            {
                var records = input.Select(_ => new RecordTable
                {
                    ActionActualParamCount = _.ActionActualParameterCount,
                    AlphaValueThru = _.AlphaValueThru,
                    ActionFalseCount = _.ActionFalseCount,
                    ActionType = (short)_.ActionType,
                    ActionID = _.ActionId,
                    ActionTrueCount = _.ActionTrueCount,
                    ActionSequence = _.ActionSequence,
                    ActionParamsDecimal = _.ActionParameterDecimal,
                    ActionParamsNumeric = _.ActionParameterNumeric,
                    ActionParamsAlpha = _.ActionParameterAlpha,
                    AlphaValue = _.AlphaValue,
                    ActionParamsSquence = _.ActionParameterSequence,
                    ConditionCompareToFieldNum = _.ConditionCompareToFieldNumber,
                    ConditionCompareToFieldType = _.ConditionCompareToFieldType,
                    ConditionCompareToQualifier = _.ConditionCompareToQualifier,
                    ConditionCount = _.ConditionCount,
                    ConditionRangeUse = _.ConditionRangeUse,
                    ConditionValueType = (short)_.ConditionParameterValueType,
                    DecimalValue = _.DecimalValue,
                    DecimalValueThru = _.DecimalValueThru,
                    ExceptionID = _.ExceptionId,
                    GenericFieldType = (short)_.GenericFieldType,
                    GenericFieldQualifier = _.GenericFieldQualifier,
                    GenericCompareType = (short)_.GenericCompareType,
                    GenericFieldNum = _.GenericFieldNumber,
                    GenericConditionLevel1 = (short)_.GenericConditionOperation,
                    GenericConditionLevel2 = _.GenericConditionSequence,
                    NumericValue = _.NumericValue,
                    NumericValueThru = _.NumericValueThru,
                    RecordType = (short)_.RecordType,
                    StepID = _.StepId,
                    StepType = (short)_.StepType,
                    ValueType = (short)_.ParametersValueType,
                }).ToArray();
                return records;
            }

            return new RecordTable[0];
        }
    }
}