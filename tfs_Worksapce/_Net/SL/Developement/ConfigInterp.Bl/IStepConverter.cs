// ----------------------------------------------------------------------
// <copyright file="IStepConverter.cs" company="CoreLink">
//        Copyright © CoreLink 2017. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    using System.Collections.Generic;
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// The interface
    /// </summary>
    public interface IStepConverter
    {
        /// <summary>
        /// Converts the steps.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// the value
        /// </returns>
        ConfiguredSteps ConvertSteps(IEnumerable<IStepDataMap> source);

        /// <summary>
        /// Converts to flat data.
        /// </summary>
        /// <param name="configuredSteps">The configured steps.</param>
        /// <returns>
        /// the value
        /// </returns>
        IEnumerable<IStepDataMap> ConvertToFlatData(ConfiguredSteps configuredSteps);
    }
}