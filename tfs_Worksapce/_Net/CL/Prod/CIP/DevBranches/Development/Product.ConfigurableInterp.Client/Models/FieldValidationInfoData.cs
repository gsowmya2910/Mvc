//----------------------------------------------------------------
// <copyright file="FieldValidationInfoData.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// This Class represents the Field Validation Info Data Structure
    /// </summary>
    public class FieldValidationInfoData
    {
        /// <summary>
        /// Enumeration for Value Types passed in the GetFieldValidationInfo API.
        /// Not sure if these are needed yet, but this replaces the lack of being able to get to these values from the database.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "CoreLink Service Generated Values from Database")]
        private enum ValueType
        {
            /// <summary>
            /// Alphanumeric value type
            /// </summary>
            Alphanumeric = 1,

            /// <summary>
            /// Numeric value type
            /// </summary>
            Numeric = 2,

            /// <summary>
            /// Decimal value type
            /// </summary>
            Decimal = 3,

            /// <summary>
            /// ICD 10 CM value type
            /// </summary>
            Icd10CM = 4,

            /// <summary>
            /// ICD 9 CM value type
            /// </summary>
            Icd9CM = 5,

            /// <summary>
            /// Date value type
            /// </summary>
            Date = 6,

            /// <summary>
            /// Boolean value type
            /// </summary>
            Boolean = 7
        }

        /// <summary>
        /// Gets or sets FormatDescription
        /// </summary>
        public string FormatDescription { get; set; }

        /// <summary>
        /// Gets or sets FormatInputHintDescription
        /// </summary>
        public string FormatInputHintDescription { get; set; }

        /// <summary>
        /// Gets or sets FormatInputPattern
        /// </summary>
        public string FormatInputPattern { get; set; }

        /// <summary>
        /// Gets or sets FormatTypeId
        /// </summary>
        public short FormatTypeId { get; set; }

        /// <summary>
        /// Gets or sets MaxSize
        /// </summary>
        public short MaxSize { get; set; }

        /// <summary>
        /// Gets or sets MinSize
        /// </summary>
        public short MinSize { get; set; }

        /// <summary>
        /// Gets or sets QualifierTypeNumber
        /// </summary>
        public short QualifierTypeNumber { get; set; }

        /// <summary>
        /// Gets or sets ValueTypeId
        /// </summary>
        public short ValueTypeId { get; set; }

        /// <summary>
        /// Gets the enumerated string value of the ValueTypeId
        /// </summary>
        public string ValueTypeString
        {
            get { return ((ValueType)this.ValueTypeId).ToString(); }
        }
    }
}