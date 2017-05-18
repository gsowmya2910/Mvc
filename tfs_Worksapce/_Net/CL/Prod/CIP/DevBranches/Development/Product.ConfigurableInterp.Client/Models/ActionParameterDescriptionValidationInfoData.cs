//----------------------------------------------------------------
// <copyright file="ActionParameterDescriptionValidationInfoData.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    /// <summary>
    /// This Class represents the Action Parameter Description Validation Info Data Structure
    /// This includes the fields listed in the FieldValidationInfoData class
    /// </summary>
    public class ActionParameterDescriptionValidationInfoData : FieldValidationInfoData
    {
        /// <summary>
        /// Gets or sets a value indicating whether the parameter is optional
        /// </summary>
        public bool IsOptional { get; set; }

        /// <summary>
        /// Gets or sets OrderSequence
        /// </summary>
        public int OrderSequence { get; set; }

        /// <summary>
        /// Gets or sets ParameterDescription
        /// </summary>
        public string ParameterDescription { get; set; }

        /// <summary>
        /// Gets or sets ParameterPseudoDescription
        /// </summary>
        public string ParameterPseudoDescription { get; set; }
    }
}