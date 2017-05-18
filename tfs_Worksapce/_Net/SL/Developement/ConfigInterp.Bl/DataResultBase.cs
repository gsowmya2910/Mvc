// ----------------------------------------------------------------------
// <copyright file="DataResultBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl
{
    using System;
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IDataResultBase" />
    public abstract class DataResultBase : IDataResultBase
    {
        /// <summary>
        /// The is success
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly Func<DataResultBase, bool> _isSuccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataResultBase"/> class.
        /// </summary>
        /// <param name="isSuccess">The is success.</param>
        protected DataResultBase(Func<DataResultBase, bool> isSuccess)
        {
            this._isSuccess = isSuccess;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataResultBase"/> class.
        /// </summary>
        protected DataResultBase() : this(NumberInterpreter.Default)
        {
        }

        /// <summary>
        /// Gets or sets the ti exception.
        /// </summary>
        /// <value>
        /// The ti exception.
        /// </value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the message number.
        /// </summary>
        /// <value>
        /// The message number.
        /// </value>
        public short MessageNumber { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        public string MessageText { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public OperationResult Result { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="DataResultBase" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success
        {
            get
            {
                // ReSharper disable once EventExceptionNotDocumented
                return this._isSuccess(this);
            }
        }
    }
}