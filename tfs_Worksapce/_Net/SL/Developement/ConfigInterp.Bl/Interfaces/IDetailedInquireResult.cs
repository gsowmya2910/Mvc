// ----------------------------------------------------------------------
// <copyright file="IDetailedInquireResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    /// <summary>
    /// The Object
    /// </summary>
    public interface IDetailedInquireResult : IInquireDataResultBase
    {
        /// <summary>
        /// Gets the table occurs.
        /// </summary>
        /// <value>
        /// The table occurs.
        /// </value>
        short TableOccurs { get; }

        /// <summary>
        /// Gets the step data.
        /// </summary>
        /// <value>
        /// The step data.
        /// </value>
        IStepDataMap[] StepData { get; }
    }
}