// ----------------------------------------------------------------------
// <copyright file="UpdateMock.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.Mocks
{
    using System.Diagnostics.CodeAnalysis;
    using Bl.Update;

    /// <summary>
    ///  the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Update.ICipUpdateHandler" />
    [ExcludeFromCodeCoverage]
    internal class UpdateMock : ICipUpdateHandler
    {
        /// <summary>
        /// Gets or sets the passed delete data.
        /// </summary>
        /// <value>
        /// The passed delete data.
        /// </value>
        public IDeleteInterp PassedDeleteData { get; set; }

        /// <summary>
        /// Gets or sets the passed status data.
        /// </summary>
        /// <value>
        /// The passed status data.
        /// </value>
        public IStatusChange PassedStatusData { get; set; }

        /// <summary>
        /// Gets or sets the passed input.
        /// </summary>
        /// <value>
        /// The passed input.
        /// </value>
        public IUpdateInterp PassedUpdateData { get; set; }

        /// <summary>
        /// Gets or sets the update result.
        /// </summary>
        /// <value>
        /// The update result.
        /// </value>
        public UpdateResult UpdateResult { get; set; }

        /// <summary>
        /// Deletes the Interp
        /// </summary>
        /// <param name="input">the input</param>
        /// <returns>a record</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public UpdateResult DeleteInterp(IDeleteInterp input)
        {
            this.PassedDeleteData = input;
            return this.UpdateResult;
        }

        /// <summary>
        /// Updates the interp.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the value
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public UpdateResult UpdateInterp(IUpdateInterp input)
        {
            this.PassedUpdateData = input;
            return this.UpdateResult;
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the value</returns>
        public UpdateResult UpdateStatus(IStatusChange input)
        {
            this.PassedStatusData = input;
            return this.UpdateResult;
        }
    }
}