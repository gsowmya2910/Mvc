// ----------------------------------------------------------------------
// <copyright file="BenefitMatrixHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.BenefitMatrix
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using BMNARR01;
    using Contracts.DataContracts;
    using Microsoft.HostIntegration.TI;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.BenefitMatrix.IBenefitMatrixHandler" />
    public class BenefitMatrixHandler : IBenefitMatrixHandler
    {
        /// <summary>
        /// The date format
        /// </summary>
        internal const string DateFormat = "yyyyMMdd";

        /// <summary>
        /// The date time format
        /// </summary>
        internal const string DateTimeFormat = "yyyyMMddHHmmss";

        /// <summary>
        /// The maximum lines
        /// </summary>
        internal const int MaxLines = 99;

        /// <summary>
        /// The application name
        /// </summary>
        private const string ApplicationName = "CIPADMIN";

        /// <summary>
        /// The transaction code
        /// </summary>
        private const string TransactionCode = "BMNARR";

        /// <summary>
        /// The version number
        /// </summary>
        private const short VersionNumber = 1;

        /// <summary>
        /// Gets or sets the test implementation.
        /// </summary>
        /// <value>
        /// The test implementation.
        /// </value>
        internal ITBenefitMatrix TestImplementation { get; set; }

        /// <summary>
        /// Creates the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        public CreationCompletionResult CreateNarrative(IBenefitMatrixCreateInput input)
        {
            var bm = this.GetImplementation(input.Region);
            var commonInput = CreateCommonInput(input);
            var narrativeInput = CreateNarrativeInput(input);
            narrativeInput.Status = Status.Maintenance.GetDescriptionValue();
            CommonOutput commonOut = default(CommonOutput);

            //// ReSharper disable TooWideLocalVariableScope
            NarrativeOutput narrativeOut;
            short recordCount;
            NarrativeLineRecord[] lineRecords;
            //// ReSharper restore TooWideLocalVariableScope

            OperationResult result;
            CustomTIException exception = null;
            try
            {
                bm.Create(commonInput, narrativeInput, out commonOut, out narrativeOut, out recordCount, out lineRecords);
                result = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                result = OperationResult.Failed;
            }

            result = InterpretCreate(result, commonOut.MessageNumber);
            var completionResult = new CreationCompletionResult
            {
                Result = result,
                Exception = exception,
                MessageText = commonOut.MessageText,
                MessageNumber = commonOut.MessageNumber
            };

            if (completionResult.Success)
            {
                completionResult.Status = Status.Maintenance;
            }

            return completionResult;
        }

        /// <summary>
        /// Deletes the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        public CompletionResult DeleteNarrative(IBenefitMatrixNarrativeDeleteable input)
        {
            var bm = this.GetImplementation(input.Region);
            var commonInput = CreateCommonInput(input);
            var narrativeInput = CreateNarrativeInput(input);
            narrativeInput.Status = input.Status.GetDescriptionValue();
            narrativeInput.SequenceNumber = input.SequenceNumber;
            CommonOutput commonOut = default(CommonOutput);

            //// ReSharper disable TooWideLocalVariableScope
            NarrativeOutput narrativeOut;
            short recordCount;
            NarrativeLineRecord[] lineRecords;
            //// ReSharper restore TooWideLocalVariableScope

            OperationResult result;
            CustomTIException exception = null;
            try
            {
                bm.Delete(commonInput, narrativeInput, out commonOut, out narrativeOut, out recordCount, out lineRecords);
                result = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                result = OperationResult.Failed;
            }

            return new CompletionResult
            {
                Result = result,
                Exception = exception,
                MessageText = commonOut.MessageText,
                MessageNumber = commonOut.MessageNumber,
            };
        }

        /// <summary>
        /// Inquires the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        public NarrativeResult InquireNarrative(IBenefitMatrixNarrativeInquireable input)
        {
            var bm = this.GetImplementation(input.Region);
            var commonInput = CreateCommonInput(input);
            var narrativeInput = CreateNarrativeInput(input);
            narrativeInput.Status = input.Status.GetDescriptionValue();

            NarrativeLineRecord[] lineRecords = null;
            NarrativeOutput narrativeOut = default(NarrativeOutput);
            CommonOutput commonOut = default(CommonOutput);

            //// ReSharper disable TooWideLocalVariableScope
            short recordCount;
            //// ReSharper restore TooWideLocalVariableScope

            OperationResult result;
            CustomTIException exception = null;
            try
            {
                bm.Inquire(commonInput, narrativeInput, out commonOut, out narrativeOut, out recordCount, out lineRecords);
                result = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                result = OperationResult.Failed;
            }

            result = InterpretInquire(result, commonOut.MessageNumber);
            return new NarrativeResult
            {
                Result = result,
                MessageText = commonOut.MessageText,
                MessageNumber = commonOut.MessageNumber,
                Exception = exception,
                Narrative = Convert(narrativeOut, lineRecords)
            };
        }

        /// <summary>
        /// Updates the narrative.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        public CompletionResult UpdateNarrative(IBenefitMatrixChangeable input)
        {
            var bm = this.GetImplementation(input.Region);
            var commonInput = CreateCommonInput(input);
            var narrativeInput = CreateNarrativeInput(input);
            narrativeInput.Status = input.Status.GetDescriptionValue();

            CommonOutput commonOut = default(CommonOutput);

            //// ReSharper disable TooWideLocalVariableScope
            NarrativeOutput narrativeOut;
            short recordCount;
            NarrativeLineRecord[] lineRecords;
            //// ReSharper restore TooWideLocalVariableScope

            OperationResult result;
            CustomTIException exception = null;
            try
            {
                bm.Update(commonInput, narrativeInput, out commonOut, out narrativeOut, out recordCount, out lineRecords);
                result = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                result = OperationResult.Failed;
            }

            return new CompletionResult
            {
                Result = result,
                Exception = exception,
                MessageText = commonOut.MessageText,
                MessageNumber = commonOut.MessageNumber,
            };
        }

        /// <summary>
        /// Converts the specified narrative out.
        /// </summary>
        /// <param name="narrativeOut">The narrative out.</param>
        /// <param name="lineRecords">The line records.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static INarrative Convert(NarrativeOutput narrativeOut, NarrativeLineRecord[] lineRecords)
        {
            var narrative = new Narrative
            {
                Category = narrativeOut.Category,
                Employee = new Employee
                {
                    Name = narrativeOut.MaintenanceEmployeeName,
                    Number = narrativeOut.MaintenanceEmployeeID
                },
                AdmitInterp = narrativeOut.Interp,
                MaintenanceDate = ParseDate(narrativeOut.MaintenanceDate, narrativeOut.MaintenanceTime),
                NarrativeType = narrativeOut.NarrativeType,
                Outline = narrativeOut.OutlineType,
                SequenceNumber = narrativeOut.SequenceNumber,
                Status = narrativeOut.Status,
                StatusDate = ParseDate(narrativeOut.StatusDate, narrativeOut.StatusTime),
                Subcategory = narrativeOut.Subcategory
            };
            if (lineRecords != null)
            {
                narrative.Lines = lineRecords.Select(_ => _.NarrativeLine).ToArray();
            }

            return narrative;
        }

        /// <summary>
        /// Creates the common input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static CommonInput CreateCommonInput(IBenefitMatrixCommonInput input)
        {
            return new CommonInput
            {
                ApplicationID = ApplicationName,
                Trancode = TransactionCode,
                MainframeVersion = VersionNumber,
                MainframeUsercode = input.MainframeUsercode
            };
        }

        /// <summary>
        /// Creates the narrative input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static NarrativeInput CreateNarrativeInput(IBenefitMatrixNarrativeInputBase input)
        {
            var id = Utilities.GetOnlyNumber(input.BlueUser);
            var narrativeInput = new NarrativeInput
            {
                Category = input.Interp.Category,
                EmployeeID = id,
                Interp = input.Interp.AdmitInterp,
                KeywordRevision = 0,
                NarrativeLines = new string[MaxLines],
                ////TODO: does this work???
                ////NarrativeLines = input.Narrative,
                NarrativeType = input.Interp.Level,
                OutlineType = input.Interp.Outline,
                RegionCode = input.Region,
                SequenceNumber = 0,
                Subcategory = input.Interp.SubCategory
            };

            var hasLines = input as IBenefitMatrixChangeable;
            if (hasLines != null && hasLines.Narrative != null)
            {
                narrativeInput.NumberOfLines = (short)hasLines.Narrative.Length;

                var lines = hasLines.Narrative;
                for (var i = 0; i < lines.Length && i < MaxLines; i++)
                {
                    narrativeInput.NarrativeLines[i] = lines[i];
                }
            }

            return narrativeInput;
        }

        /// <summary>
        /// Parses the date.
        /// </summary>
        /// <param name="date">The date value.</param>
        /// <param name="time">The time value.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static DateTime? ParseDate(int date, int time)
        {
            var combined = string.Format("{0}{1}", date.ToString().PadLeft(8, '0'), time.ToString().PadLeft(6, '0'));
            if (combined.Length == DateTimeFormat.Length)
            {
                DateTime parsed;
                if (DateTime.TryParseExact(combined, DateTimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out parsed))
                {
                    return parsed;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the implementation.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns>
        /// the value
        /// </returns>
        [ExcludeFromCodeCoverage]
        internal ITBenefitMatrix GetImplementation(short region)
        {
            return this.TestImplementation ?? new BenefitMatrixTiWrapper(region);
        }

        /// <summary>
        /// Interprets the create.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="messageNumber">The message number.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static OperationResult InterpretCreate(OperationResult result, short messageNumber)
        {
            if (result == OperationResult.Success)
            {
                Console.WriteLine(messageNumber);
            }

            return result;
        }

        /// <summary>
        /// Interprets the inquire.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="messageNumber">The message number.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static OperationResult InterpretInquire(OperationResult result, short messageNumber)
        {
            if (result == OperationResult.Success)
            {
                switch (messageNumber)
                {
                    case 1:
                        return OperationResult.NotFound;

                    case 4:
                        return OperationResult.AlreadyExists;

                    case 5:
                        return OperationResult.InterpNotConfigurable;

                    case 6:
                        return OperationResult.ZeroLevelDoesNotExist;

                    default:
                        return result;
                }
            }

            return result;
        }
    }
}