// ----------------------------------------------------------------------
// <copyright file="InterpNoType.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using ConfigInterp.Bl.Interfaces;

    /// <summary>
    /// the class
    /// </summary>
    internal class InterpNoType : IInterpBaseType
    {
        /// <summary>
        /// Gets or sets the category
        /// </summary>
        public short Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the admit
        /// </summary>
        public short AdmitInterp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the outline
        /// </summary>
        public short Outline
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the subcategory
        /// </summary>
        public short SubCategory
        {
            get;
            set;
        }
    }
}