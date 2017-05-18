// ----------------------------------------------------------------------
// <copyright file="DescriptionMasterHandler.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Description
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Contracts.DataContracts;
    using CoreLink.DescriptionMaster.DA;
    using Interfaces;
    using Microsoft.HostIntegration.TI;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="IDescriptionMasterHandler" />
    public class DescriptionMasterHandler : IDescriptionMasterHandler
    {
        /// <summary>
        /// The _lazy DCM
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<DescriptionMasterRecord> _lazyDcm = new Lazy<DescriptionMasterRecord>(() => new DescriptionMasterRecord());

        /// <summary>
        /// The Object
        /// </summary>
        internal enum DescriptionType : short
        {
            /// <summary>
            /// The category
            /// </summary>
            Category = 1,

            /// <summary>
            /// The subcategory
            /// </summary>
            SubCategory = 2,

            /// <summary>
            /// The Outline
            /// </summary>
            Outline = 8,

            /// <summary>
            /// The level
            /// </summary>
            Level = 9
        }

        /// <summary>
        /// Gets or sets the test implementation.
        /// </summary>
        /// <value>
        /// The test implementation.
        /// </value>
        internal IDescriptionMasterDataAccess TestImplementation { get; set; }

        /// <summary>
        /// Gets the category description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="category">The category.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        public DataResult GetCategoryDescription(short outline, short category, short region)
        {
            var code = string.Format("{0}{1}", PadLeftZeros(outline), PadLeftZeros(category));
            return this.GetDescription(region, DescriptionType.Category, code);
        }

        /// <summary>
        /// Gets the level description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="level">The level.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        public DataResult GetLevelDescription(short outline, short level, short region)
        {
            var code = string.Format("{0}{1}", PadLeftZeros(outline), PadLeftZeros(level));
            return this.GetDescription(region, DescriptionType.Level, code);
        }

        /// <summary>
        /// Gets the Outline description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        public DataResult GetOutlineDescription(short outline, short region)
        {
            var code = PadLeftZeros(outline);
            return this.GetDescription(region, DescriptionType.Outline, code);
        }

        /// <summary>
        /// Gets the sub category description.
        /// </summary>
        /// <param name="outline">The Outline.</param>
        /// <param name="category">The category.</param>
        /// <param name="subCategory">The sub category.</param>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        public DataResult GetSubCategoryDescription(short outline, short category, short subCategory, short region)
        {
            var code = string.Format("{0}{1}{2}", PadLeftZeros(outline), PadLeftZeros(category), PadLeftZeros(subCategory));
            return this.GetDescription(region, DescriptionType.SubCategory, code);
        }

        /// <summary>
        /// Pads the left zeros.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The Value</returns>
        private static string PadLeftZeros(short input)
        {
            return input.ToString().PadLeft(3, '0');
        }

        /// <summary>
        /// Gets the data access.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns>The Value</returns>
        [ExcludeFromCodeCoverage]
        private IDescriptionMasterDataAccess GetDataAccess(short region)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (this.TestImplementation != null)
            {
                return this.TestImplementation;
            }

            return new DescriptionMasterTiWrapper(region);
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="type">The type.</param>
        /// <param name="code">The code.</param>
        /// <returns>The Value</returns>
        /// <remarks>
        /// it was thought that the code needed to be padded to be 10 characters of whitespace, but it doesn't
        /// </remarks>
        private DataResult GetDescription(short region, DescriptionType type, string code)
        {
            DataResult result = new DataResult();
            IDescriptionMasterDataAccess da = this.GetDataAccess(region);
            try
            {
                var dmr = da.GetByCode((short)type, code);
                if (_lazyDcm.Value.Equals(dmr))
                {
                    result.Result = OperationResult.NotFound;
                }
                else
                {
                    result.Result = OperationResult.Success;
                    result.Value = dmr.DescriptionRest;
                }
            }
            catch (CustomTIException e)
            {
                result.Result = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }
    }
}