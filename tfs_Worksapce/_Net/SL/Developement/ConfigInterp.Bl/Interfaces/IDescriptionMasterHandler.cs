// ----------------------------------------------------------------------
// <copyright file="IDescriptionMasterHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Interfaces
{
    using Description;

    /// <summary>
    /// The Interface
    /// </summary>
    public interface IDescriptionMasterHandler
    {
        /// <summary>
        /// Gets the category description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="category">The category.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        DataResult GetCategoryDescription(short outline, short category, short region);

        /// <summary>
        /// Gets the level description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="level">The level.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        DataResult GetLevelDescription(short outline, short level, short region);

        /// <summary>
        /// Gets the Outline description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        DataResult GetOutlineDescription(short outline, short region);

        /// <summary>
        /// Gets the sub category description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="category">The category.</param>
        /// <param name="subCategory">The sub category.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        DataResult GetSubCategoryDescription(short outline, short category, short subCategory, short region);
    }
}