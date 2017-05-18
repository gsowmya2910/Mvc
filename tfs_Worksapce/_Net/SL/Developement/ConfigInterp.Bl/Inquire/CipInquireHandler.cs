// ----------------------------------------------------------------------
// <copyright file="CipInquireHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Inquire
{
    using System.Diagnostics.CodeAnalysis;
    using CIPINQ01;
    using Contracts.DataContracts;
    using Interfaces;
    using Microsoft.HostIntegration.TI;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.ICipInquireHandler" />
    public class CipInquireHandler : ICipInquireHandler
    {
        /// <summary>
        /// The application name
        /// </summary>
        private const string ApplicationName = "CIP";

        /// <summary>
        /// The transaction code
        /// </summary>
        private const string TransactionCode = "CIPINQ";

        /// <summary>
        /// The version number
        /// </summary>
        private const short VersionNumber = 1;

        /// <summary>
        /// Gets or sets the implementation.
        /// </summary>
        /// <value>
        /// The test implementation.
        /// </value>
        internal ITiCipInquire Implementation { get; set; }

        /// <summary>
        /// Inquires the detailed data.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The result
        /// </returns>
        public IDetailedInquireResult InquireInterpDetail(IInquireInput input)
        {
            ITiCipInquire com = this.GetImplementation(input.Region);

            var inputHeader = CreateHeader(input);
            var inputCommon = CreateInput(input);

            HeaderOut headerOut = default(HeaderOut);
            KeyInfoOut keyInfoOut = default(KeyInfoOut);
            short tableOccurs = 0;
            DataMapsOut[] dataMapsOut = null;

            OperationResult result;
            CustomTIException exception = null;
            try
            {
                com.InquireInterpsDetail(inputHeader, inputCommon, out headerOut, out keyInfoOut, out tableOccurs, out dataMapsOut);
                result = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                result = OperationResult.Failed;
            }

            result = Resolve(headerOut, result);

            var retValue = new DetailedInquireResult(keyInfoOut, tableOccurs, dataMapsOut)
            {
                Result = result,
                MessageNumber = headerOut.MessageNumber,
                MessageText = headerOut.MessageText,
                Exception = exception
            };
            return retValue;
        }

        /// <summary>
        /// Inquires the simple data.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The result
        /// </returns>
        public ISimpleInquire InquireSimpleData(IInquireInput input)
        {
            ITiCipInquire com = this.GetImplementation(input.Region);

            var inputHeader = CreateHeader(input);
            var inputCommon = CreateInput(input);

            HeaderOut headerOut = default(HeaderOut);
            KeyInfoOut keyInfoOut = default(KeyInfoOut);
            // ReSharper disable once TooWideLocalVariableScope
            short tableOccurs;

            OperationResult result;
            CustomTIException exception = null;
            try
            {
                com.InquireInterpsData(inputHeader, inputCommon, out headerOut, out keyInfoOut, out tableOccurs);
                result = OperationResult.Success;
            }
            catch (CustomTIException e)
            {
                exception = e;
                result = OperationResult.Failed;
            }

            result = Resolve(headerOut, result);

            var retValue = new SimpleInquireResult(keyInfoOut)
            {
                Result = result,
                MessageNumber = headerOut.MessageNumber,
                MessageText = headerOut.MessageText,
                Exception = exception
            };
            return retValue;
        }

        /// <summary>
        /// Gets the implementation.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns>
        /// The result
        /// </returns>
        [ExcludeFromCodeCoverage]
        internal ITiCipInquire GetImplementation(short region)
        {
            return this.Implementation ?? new CipInquireTiWrapper(region);
        }

        /// <summary>
        /// Creates the header.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The result
        /// </returns>
        private static InputHeader CreateHeader(IMainFrameUsercode input)
        {
            return new InputHeader
            {
                AppNAME = ApplicationName,
                MainFraimeUsercode = input.MainFrameUsercode,
                Trancode = TransactionCode,
                VersionNumber = VersionNumber
            };
        }

        /// <summary>
        /// Creates the input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The result
        /// </returns>
        private static InputCommon CreateInput(IInquireInput input)
        {
            return new InputCommon
            {
                AdmitInterp = input.AdmitInterp,
                Category = input.Category,
                SystemType = (short)input.SystemType,
                OutLine = input.Outline,
                Status = (short)input.Status,
                SubCategory = input.SubCategory
            };
        }

        /// <summary>
        /// Resolves the specified header out.
        /// </summary>
        /// <param name="headerOut">The header out.</param>
        /// <param name="result">The result.</param>
        /// <returns>The value.</returns>
        private static OperationResult Resolve(HeaderOut headerOut, OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                if (headerOut.MessageNumber == 1)
                {
                    return OperationResult.NotFound;
                }
            }

            return result;
        }
    }
}