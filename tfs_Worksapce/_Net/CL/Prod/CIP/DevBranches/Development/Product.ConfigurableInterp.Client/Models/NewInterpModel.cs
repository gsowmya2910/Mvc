//----------------------------------------------------------------
// <copyright file="NewInterpModel.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    #region references
    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// This class will hold New Interp Model structure
    /// </summary>
    public class NewInterpModel
    {
        /// <summary>
        /// Gets or sets Interp Id property
        /// </summary>
        [Display(Name = "Interp Number")]
        public string InterpId { get; set; }

        /// <summary>
        /// Gets or sets Interp Message from Web service
        /// </summary>
        [DisplayFormat(NullDisplayText = "")]
        public string InterpMessage { get; set; }

        /// <summary>
        /// Gets or sets Outline Number property
        /// </summary>
        [Display(Name = "Outline")]
        [DisplayFormat(NullDisplayText = "")]
        public string OutlineNumber { get; set; }

        /// <summary>
        /// Gets or sets Outline Description message from web service
        /// </summary>
        [DisplayFormat(NullDisplayText = "")]
        public string OutlineDescription { get; set; }

        /// <summary>
        /// Gets or sets Category Number property
        /// </summary>
        [Display(Name = "Category")]
        [DisplayFormat(NullDisplayText = "")]
        public string CategoryNumber { get; set; }

        /// <summary>
        /// Gets or sets Category Description message from web service
        /// </summary>
        [DisplayFormat(NullDisplayText = "")]
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets Subcategory Number property
        /// </summary>
        [Display(Name = "Sub Category")]
        [DisplayFormat(NullDisplayText = "")]
        public string SubcategoryNumber { get; set; }

        /// <summary>
        /// Gets or sets Subcategory Description message from web service
        /// </summary>
        [DisplayFormat(NullDisplayText = "")]
        public string SubcategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets Interp Id Number property 
        /// </summary>
        [Display(Name = "Interp ID")]
        [DisplayFormat(NullDisplayText = "")]
        public string InterpIdNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Is Valid Interp Id property
        /// </summary>
        public bool IsValidInterpId { get; set; }

        /// <summary>
        /// Gets or sets Level Description message from web service
        /// </summary>
        [Display(Name = "Level")]
        public string LevelDescription { get; set; }
    }
}