// ----------------------------------------------------------------------
// <copyright file="DescriptionMasterTiWrapper.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Description
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using CoreLink.DescriptionMaster.DA;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="IDescriptionMasterDataAccess" />
    [ExcludeFromCodeCoverage]
    public class DescriptionMasterTiWrapper : IDescriptionMasterDataAccess
    {
        /// <summary>
        /// The application name
        /// </summary>
        private const string ApplicationName = "CFGINTRP";

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionMasterTiWrapper"/> class.
        /// </summary>
        /// <param name="region">The region.</param>
        public DescriptionMasterTiWrapper(short region)
        {
            this.Implementation = new DataAccess(region, ApplicationName);
        }

        /// <summary>
        /// Gets or sets the implementation.
        /// </summary>
        /// <value>
        /// The implementation.
        /// </value>
        private IDataAccess Implementation { get; set; }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="code">The code.</param>
        /// <returns>The Value</returns>
        public DescriptionMasterRecord GetByCode(short type, string code)
        {
            DescriptionMasterRecord returnValue = null;
            var start = DateTime.Now;
            do
            {
                try
                {
                    returnValue = this.Implementation.GetByCode(type, code);
                }
                catch (TypeLoadException)
                {
                    if (DateTime.Now - start > TimeSpan.FromSeconds(5))
                    {
                        break;
                    }
                }
            }
            while (returnValue == null);

            return returnValue ?? new DescriptionMasterRecord();
        }
    }
}