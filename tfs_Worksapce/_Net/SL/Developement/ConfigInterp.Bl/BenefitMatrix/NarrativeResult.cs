// ----------------------------------------------------------------------
// <copyright file="NarrativeResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.BenefitMatrix
{
    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.DataResultBase" />
    public class NarrativeResult : DataResultBase
    {
        /// <summary>
        /// Gets or sets the narrative.
        /// </summary>
        /// <value>
        /// The narrative.
        /// </value>
        public INarrative Narrative { get; set; }
    }
}