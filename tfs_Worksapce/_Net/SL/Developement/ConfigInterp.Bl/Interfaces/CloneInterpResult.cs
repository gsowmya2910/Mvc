// ----------------------------------------------------------------------
// <copyright file="CloneInterpResult.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl
{
    using ConfigInterp.Bl.Interfaces;

    /// <summary>
    /// the class
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Dev", MessageId = "Interp")]
    public class CloneInterpResult : DataResultBase, IDetailedInquireResult
    {
        /// <summary>
        /// Gets or sets the occurs
        /// </summary>
        public short TableOccurs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets step data
        /// </summary>
        public IStepDataMap[] StepData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets comment
        /// </summary>
        public string Comment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets create by revision
        /// </summary>
        public short CreateByRevision
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets status
        /// </summary>
        public Contracts.DataContracts.InterpStatus CurrentStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets employee number
        /// </summary>
        public short EmployeeNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets employee region
        /// </summary>
        public Contracts.DataContracts.Plan EmployeeRegion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets revision number
        /// </summary>
        public short RevisionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets revision sequence
        /// </summary>
        public short RevisionSequence
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets status
        /// </summary>
        public System.DateTime StatusDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets step count
        /// </summary>
        public short StepCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets system type
        /// </summary>
        public Contracts.DataContracts.LineOfBusiness SystemType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets level
        /// </summary>
        public short Level
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets category
        /// </summary>
        public short Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets admit
        /// </summary>
        public short AdmitInterp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets step data
        /// </summary>outline
        public short Outline
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets sub category
        /// </summary>
        public short SubCategory
        {
            get;
            set;
        }
    }
}