// ----------------------------------------------------------------------
// <copyright file="DescriptionMock.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Mocks
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Description;
    using Bl.Interfaces;

    /// <summary>
    /// The class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IDescriptionMasterHandler" />
    [ExcludeFromCodeCoverage]
    internal class DescriptionMock : IDescriptionMasterHandler
    {
        /// <summary>
        /// Gets or sets the data result.
        /// </summary>
        /// <value>
        /// The data result.
        /// </value>
        public DataResult DataResult { get; set; }

        /// <summary>
        /// Gets the category description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="category">The category.</param>
        /// <param name="region">The region.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DataResult GetCategoryDescription(short outline, short category, short region)
        {
            return this.DataResult;
        }

        /// <summary>
        /// Gets the level description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="level">The level.</param>
        /// <param name="region">The region.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DataResult GetLevelDescription(short outline, short level, short region)
        {
            return this.DataResult;
        }

        /// <summary>
        /// Gets the Outline description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="region">The region.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DataResult GetOutlineDescription(short outline, short region)
        {
            return this.DataResult;
        }

        /// <summary>
        /// Gets the sub category description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="category">The category.</param>
        /// <param name="subCategory">The sub category.</param>
        /// <param name="region">The region.</param>
        /// <returns>
        /// The Value
        /// </returns>
        public DataResult GetSubCategoryDescription(short outline, short category, short subCategory, short region)
        {
            return this.DataResult;
        }
    }
}