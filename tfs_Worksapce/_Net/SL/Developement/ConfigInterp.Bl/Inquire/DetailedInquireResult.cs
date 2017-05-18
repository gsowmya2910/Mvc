// ----------------------------------------------------------------------
// <copyright file="DetailedInquireResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Inquire
{
    using System.Linq;
    using CIPINQ01;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="InquireDataResultBase" />
    /// <seealso cref="IDetailedInquireResult" />
    internal class DetailedInquireResult : InquireDataResultBase, IDetailedInquireResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedInquireResult"/> class.
        /// </summary>
        /// <param name="keyInfo">The key information.</param>
        /// <param name="tableOccurs">The occurrence for the table</param>
        /// <param name="steps">The steps.</param>
        public DetailedInquireResult(KeyInfoOut keyInfo, short tableOccurs, DataMapsOut[] steps)
            : base(keyInfo)
        {
            this.TableOccurs = tableOccurs;

            this.StepData = (steps ?? Enumerable.Empty<DataMapsOut>()).Select(_ => (IStepDataMap)new StepDataMap(_)).ToArray();
        }

        /// <summary>
        /// Gets the table occurs.
        /// </summary>
        /// <value>
        /// The table occurs.
        /// </value>
        public short TableOccurs { get; private set; }

        /// <summary>
        /// Gets the step data.
        /// </summary>
        /// <value>
        /// The step data.
        /// </value>
        public IStepDataMap[] StepData { get; private set; }
    }
}