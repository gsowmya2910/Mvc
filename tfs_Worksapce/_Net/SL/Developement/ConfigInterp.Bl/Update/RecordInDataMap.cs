// ----------------------------------------------------------------------
// <copyright file="RecordInDataMap.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Update
{
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IStepDataMap" />
    internal class RecordInDataMap : IStepDataMap
    {
        /// <summary>
        /// Gets or sets the action actual parameter count.
        /// </summary>
        /// <value>
        /// The action actual parameter count.
        /// </value>
        public short ActionActualParameterCount { get; set; }

        /// <summary>
        /// Gets or sets the action false count.
        /// </summary>
        /// <value>
        /// The action false count.
        /// </value>
        public short ActionFalseCount { get; set; }

        /// <summary>
        /// Gets or sets the action identifier.
        /// </summary>
        /// <value>
        /// The action identifier.
        /// </value>
        public short ActionId { get; set; }

        /// <summary>
        /// Gets or sets the action parameters alpha.
        /// </summary>
        /// <value>
        /// The action parameters alpha.
        /// </value>
        public string ActionParameterAlpha { get; set; }

        /// <summary>
        /// Gets or sets the action parameters decimal.
        /// </summary>
        /// <value>
        /// The action parameters decimal.
        /// </value>
        public decimal ActionParameterDecimal { get; set; }

        /// <summary>
        /// Gets or sets the action parameters numeric.
        /// </summary>
        /// <value>
        /// The action parameters numeric.
        /// </value>
        public long ActionParameterNumeric { get; set; }

        /// <summary>
        /// Gets or sets the action parameters sequence.
        /// </summary>
        /// <value>
        /// The action parameters sequence.
        /// </value>
        public short ActionParameterSequence { get; set; }

        /// <summary>
        /// Gets or sets the action sequence.
        /// </summary>
        /// <value>
        /// The action sequence.
        /// </value>
        public short ActionSequence { get; set; }

        /// <summary>
        /// Gets or sets the action true count.
        /// </summary>
        /// <value>
        /// The action true count.
        /// </value>
        public short ActionTrueCount { get; set; }

        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// Gets or sets the alpha value.
        /// </summary>
        /// <value>
        /// The alpha value.
        /// </value>
        public string AlphaValue { get; set; }

        /// <summary>
        /// Gets or sets the alpha value thru.
        /// </summary>
        /// <value>
        /// The alpha value thru.
        /// </value>
        public string AlphaValueThru { get; set; }

        /// <summary>
        /// Gets or sets the condition compare to field number.
        /// </summary>
        /// <value>
        /// The condition compare to field number.
        /// </value>
        public int ConditionCompareToFieldNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the condition compare to field.
        /// </summary>
        /// <value>
        /// The type of the condition compare to field.
        /// </value>
        public short ConditionCompareToFieldType { get; set; }

        /// <summary>
        /// Gets or sets the condition compare to qualifier.
        /// </summary>
        /// <value>
        /// The condition compare to qualifier.
        /// </value>
        public short ConditionCompareToQualifier { get; set; }

        /// <summary>
        /// Gets or sets the condition count.
        /// </summary>
        /// <value>
        /// The condition count.
        /// </value>
        public short ConditionCount { get; set; }

        /// <summary>
        /// Gets or sets the type of the condition parameter value.
        /// </summary>
        /// <value>
        /// The type of the condition parameter value.
        /// </value>
        public RecordValueType ConditionParameterValueType { get; set; }

        /// <summary>
        /// Gets or sets the condition range use.
        /// </summary>
        /// <value>
        /// The condition range use.
        /// </value>
        public short ConditionRangeUse { get; set; }

        /// <summary>
        /// Gets or sets the decimal value.
        /// </summary>
        /// <value>
        /// The decimal value.
        /// </value>
        public decimal DecimalValue { get; set; }

        /// <summary>
        /// Gets or sets the decimal value thru.
        /// </summary>
        /// <value>
        /// The decimal value thru.
        /// </value>
        public decimal DecimalValueThru { get; set; }

        /// <summary>
        /// Gets or sets the exception identifier.
        /// </summary>
        /// <value>
        /// The exception identifier.
        /// </value>
        public short ExceptionId { get; set; }

        /// <summary>
        /// Gets or sets the type of the generic comp.
        /// </summary>
        /// <value>
        /// The type of the generic comp.
        /// </value>
        public CompareType GenericCompareType { get; set; }

        /// <summary>
        /// Gets or sets the generic condition level.
        /// </summary>
        /// <value>
        /// The generic condition level.
        /// </value>
        public ConditionOperation GenericConditionOperation { get; set; }

        /// <summary>
        /// Gets or sets the generic condition level2.
        /// </summary>
        /// <value>
        /// The generic condition level2.
        /// </value>
        public short GenericConditionSequence { get; set; }

        /// <summary>
        /// Gets or sets the generic field number.
        /// </summary>
        /// <value>
        /// The generic field number.
        /// </value>
        public int GenericFieldNumber { get; set; }

        /// <summary>
        /// Gets or sets the generic field qualifier.
        /// </summary>
        /// <value>
        /// The generic field qualifier.
        /// </value>
        public short GenericFieldQualifier { get; set; }

        /// <summary>
        /// Gets or sets the type of the generic field.
        /// </summary>
        /// <value>
        /// The type of the generic field.
        /// </value>
        public FieldType GenericFieldType { get; set; }

        /// <summary>
        /// Gets or sets the numeric value.
        /// </summary>
        /// <value>
        /// The numeric value.
        /// </value>
        public long NumericValue { get; set; }

        /// <summary>
        /// Gets or sets the numeric value thru.
        /// </summary>
        /// <value>
        /// The numeric value thru.
        /// </value>
        public long NumericValueThru { get; set; }

        /// <summary>
        /// Gets or sets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        public RecordValueType ParametersValueType { get; set; }

        /// <summary>
        /// Gets or sets the type of the record.
        /// </summary>
        /// <value>
        /// The type of the record.
        /// </value>
        public RecordType RecordType { get; set; }

        /// <summary>
        /// Gets or sets the step identifier.
        /// </summary>
        /// <value>
        /// The step identifier.
        /// </value>
        public short StepId { get; set; }

        /// <summary>
        /// Gets or sets the type of the step.
        /// </summary>
        /// <value>
        /// The type of the step.
        /// </value>
        public StepType StepType { get; set; }
    }
}