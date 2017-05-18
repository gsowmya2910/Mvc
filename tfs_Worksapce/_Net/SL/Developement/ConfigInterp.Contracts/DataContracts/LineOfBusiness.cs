// ----------------------------------------------------------------------
// <copyright file="LineOfBusiness.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Contracts.DataContracts
{
    /// <summary>
    /// The Enum
    /// </summary>
    public enum LineOfBusiness : short
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The institutional
        /// </summary>
        [NarrativeType(13)]
        Institutional = 1,

        /// <summary>
        /// The professional
        /// </summary>
        [NarrativeType(23)]
        Professional = 2////,

        ////[NarrativeType(33)]
        ////Dental = 3
    }
}