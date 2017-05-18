// ----------------------------------------------------------------------
// <copyright file="InquireDataResultBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Inquire
{
    using System;
    using System.Globalization;
    using CIPINQ01;
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="IInquireDataResultBase" />
    /// <seealso cref="DataResultBase" />
    internal abstract class InquireDataResultBase : DataResultBase, IInquireDataResultBase
    {
        /// <summary>
        /// The date time format
        /// </summary>
        internal const string DateTimeFormat = "yyyyMMddHHmmss";
        
        /// <summary>
        /// The key information
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly KeyInfoOut _keyInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="InquireDataResultBase" /> class.
        /// </summary>
        /// <param name="keyInfo">The key information.</param>
        protected InquireDataResultBase(KeyInfoOut keyInfo)
        {
            this._keyInfo = keyInfo;
        }

        /// <summary>
        /// Gets the admit interp.
        /// </summary>
        /// <value>
        /// The admit interp.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public short AdmitInterp
        {
            get { return this._keyInfo.AdmitIntp; }
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public short Category
        {
            get { return this._keyInfo.Category; }
        }

        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment
        {
            get { return this._keyInfo.Comment; }
        }

        /// <summary>
        /// Gets the create by revision.
        /// </summary>
        /// <value>
        /// The create by revision.
        /// </value>
        public short CreateByRevision
        {
            get { return this._keyInfo.CreateByRevision; }
        }

        /// <summary>
        /// Gets the current status.
        /// </summary>
        /// <value>
        /// The current status.
        /// </value>
        public InterpStatus CurrentStatus
        {
            get { return (InterpStatus)this._keyInfo.CurrentStatus; }
        }

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <value>
        /// The employee number.
        /// </value>
        public short EmployeeNumber
        {
            get { return this._keyInfo.EmployeeNum; }
        }

        /// <summary>
        /// Gets the employee region.
        /// </summary>
        /// <value>
        /// The employee region.
        /// </value>
        public Plan EmployeeRegion
        {
            get { return (Plan)this._keyInfo.EmployeeRegion; }
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public short Level
        {
            get { return this._keyInfo.Level; }
        }

        /// <summary>
        /// Gets the out line.
        /// </summary>
        /// <value>
        /// The out line.
        /// </value>
        public short Outline
        {
            get { return this._keyInfo.OutLine; }
        }

        /// <summary>
        /// Gets the revision number.
        /// </summary>
        /// <value>
        /// The revision number.
        /// </value>
        public short RevisionNumber
        {
            get { return this._keyInfo.RevisonNumber; }
        }

        /// <summary>
        /// Gets the revision sequence.
        /// </summary>
        /// <value>
        /// The revision sequence.
        /// </value>
        public short RevisionSequence
        {
            get { return this._keyInfo.RevisonSequence; }
        }

        /// <summary>
        /// Gets the status date.
        /// </summary>
        /// <value>
        /// The status date.
        /// </value>
        /// <remarks>
        /// date format ccyyMMdd
        /// time format hhmmss
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public DateTime StatusDateTime
        {
            get
            {
                var combined = string.Format("{0}{1}", this._keyInfo.StatusDate.ToString().PadLeft(8, '0'), this._keyInfo.StatusTime.ToString().PadLeft(6, '0'));
                if (combined.Length == DateTimeFormat.Length)
                {
                    DateTime parsed;
                    if (DateTime.TryParseExact(combined, DateTimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out parsed))
                    {
                        return parsed;
                    }
                }

                return default(DateTime);
            }
        }

        /// <summary>
        /// Gets the step count.
        /// </summary>
        /// <value>
        /// The step count.
        /// </value>
        public short StepCount
        {
            get { return this._keyInfo.StepCount; }
        }

        /// <summary>
        /// Gets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public short SubCategory
        {
            get { return this._keyInfo.SubCategory; }
        }

        /// <summary>
        /// Gets the type of the system.
        /// </summary>
        /// <value>
        /// The type of the system.
        /// </value>
        public LineOfBusiness SystemType
        {
            get { return (LineOfBusiness)this._keyInfo.SystemType; }
        }
    }
}