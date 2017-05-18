//----------------------------------------------------------------
// <copyright file="InterpSections.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    #region references
    using Product.ConfigurableInterp.Client.ServiceCode;
    #endregion

    /// <summary>
    /// This Class represents the Interp Sections data
    /// </summary>
    public class InterpSections
    {
        /// <summary>
        /// The level ID Number, currently hardcoded.
        /// </summary>
        private const string LevelIdNumber = "23";

        /// <summary>
        /// The level Description, currently hardcoded.
        /// </summary>
        private const string LevelDescription = "Professional";

        /// <summary>
        /// Initializes a new instance of the <see cref="InterpSections"/> class.
        /// </summary>
        /// <param name="client">The client object</param>
        /// <param name="interpId">The Interp Id number</param>
        /// <param name="doInterpVerify">Flag to determine if the InterpIdNumber should be created causing a Interp Verify API call</param>
        public InterpSections(InterpClientData client, string interpId, bool doInterpVerify)
        {
            this.InterpId = interpId;
            this.BuildSections(client, doInterpVerify);
        }

        /// <summary>
        /// Gets or sets the full Interp ID number
        /// </summary>
        public string InterpId { get; set; }

        /// <summary>
        /// Gets or sets Outline Number
        /// </summary>
        public string OutlineNumber { get; set; }

        /// <summary>
        /// Gets or sets Outline Description
        /// </summary>
        public string OutlineDescription { get; set; }

        /// <summary>
        /// Gets or sets Category Number
        /// </summary>
        public string CategoryNumber { get; set; }

        /// <summary>
        /// Gets or sets Category Description
        /// </summary>
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets Subcategory Number
        /// </summary>
        public string SubcategoryNumber { get; set; }

        /// <summary>
        /// Gets or sets Subcategory Description
        /// </summary>
        public string SubcategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets InterpId Number section
        /// </summary>
        public string InterpIdNumber { get; set; }

        /// <summary>
        /// Gets display line for the Outline Number and Description
        /// </summary>
        public string OutlineDisplay
        {
            get { return this.OutlineNumber + " - " + this.OutlineDescription; }
        }

        /// <summary>
        /// Gets display line for the Category Number and Description
        /// </summary>
        public string CategoryDisplay
        {
            get { return this.CategoryNumber + " - " + this.CategoryDescription; }
        }

        /// <summary>
        /// Gets display line for the Subcategory Number and Description
        /// </summary>
        public string SubcategoryDisplay
        {
            get { return this.SubcategoryNumber + " - " + this.SubcategoryDescription; }
        }

        /// <summary>
        /// Gets display line for the Subcategory Number and Description
        /// </summary>
        public string LevelDisplay
        {
            get
            {
                if (!string.IsNullOrEmpty(this.InterpId) && !string.IsNullOrEmpty(this.OutlineNumber) &&
                    !string.IsNullOrEmpty(this.CategoryNumber) && !string.IsNullOrEmpty(this.SubcategoryNumber) &&
                    !string.IsNullOrEmpty(this.InterpIdNumber))
                {
                    return LevelIdNumber + " - " + LevelDescription;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Builds the sections and descriptions for the supplied Interp Id
        /// </summary>
        /// <param name="client">The client object.</param>
        /// <param name="doInterpVerify">Flag to decide if the InterpIdNumber should be built also doing a verify on Interp Number</param>
        public void BuildSections(InterpClientData client, bool doInterpVerify)
        {
            this.OutlineNumber = client.GetInterpSection(this.InterpId, InterpIdSection.Outline);
            this.OutlineDescription = !string.IsNullOrEmpty(this.OutlineNumber)
                ? client.OutlineDescription(this.OutlineNumber)
                : string.Empty;
            this.CategoryNumber = client.GetInterpSection(this.InterpId, InterpIdSection.Category);
            this.CategoryDescription = !string.IsNullOrEmpty(this.CategoryNumber)
                ? client.CategoryDescription(this.OutlineNumber, this.CategoryNumber)
                : string.Empty;
            this.SubcategoryNumber = client.GetInterpSection(this.InterpId, InterpIdSection.Subcategory);
            this.SubcategoryDescription = !string.IsNullOrEmpty(this.SubcategoryNumber)
                ? client.SubcategoryDescription(this.OutlineNumber, this.CategoryNumber, this.SubcategoryNumber)
                : string.Empty;

            this.InterpIdNumber = client.GetInterpSection(this.InterpId, InterpIdSection.InterpId, doInterpVerify);
        }
    }
}