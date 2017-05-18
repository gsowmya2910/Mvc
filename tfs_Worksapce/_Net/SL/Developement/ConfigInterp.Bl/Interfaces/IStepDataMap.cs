// ----------------------------------------------------------------------
// <copyright file="IStepDataMap.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl.Interfaces
{
    using Contracts.DataContracts;

    /// <summary>
    /// The Interface
    /// </summary>
    public interface IStepDataMap
    {
        /// <summary>
        /// Gets the action actual parameter count.
        /// </summary>
        /// <value>
        /// The action actual parameter count.
        /// </value>
        short ActionActualParameterCount { get; }

        /// <summary>
        /// Gets the action false count.
        /// </summary>
        /// <value>
        /// The action false count.
        /// </value>
        short ActionFalseCount { get; }

        /// <summary>
        /// Gets the action identifier.
        /// </summary>
        /// <value>
        /// The action identifier.
        /// </value>
        short ActionId { get; }

        /// <summary>
        /// Gets the action parameters alpha.
        /// </summary>
        /// <value>
        /// The action parameters alpha.
        /// </value>
        string ActionParameterAlpha { get; }

        /// <summary>
        /// Gets the action parameters decimal.
        /// </summary>
        /// <value>
        /// The action parameters decimal.
        /// </value>
        decimal ActionParameterDecimal { get; }

        /// <summary>
        /// Gets the action parameters numeric.
        /// </summary>
        /// <value>
        /// The action parameters numeric.
        /// </value>
        long ActionParameterNumeric { get; }

        /// <summary>
        /// Gets the action parameters sequence.
        /// </summary>
        /// <value>
        /// The action parameters sequence.
        /// </value>
        short ActionParameterSequence { get; }

        /// <summary>
        /// Gets the action sequence.
        /// </summary>
        /// <value>
        /// The action sequence.
        /// </value>
        short ActionSequence { get; }

        /// <summary>
        /// Gets the action true count.
        /// </summary>
        /// <value>
        /// The action true count.
        /// </value>
        short ActionTrueCount { get; }

        /// <summary>
        /// Gets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        ActionType ActionType { get; }

        /// <summary>
        /// Gets the alpha value.
        /// </summary>
        /// <value>
        /// The alpha value.
        /// </value>
        string AlphaValue { get; }

        /// <summary>
        /// Gets the alpha value thru.
        /// </summary>
        /// <value>
        /// The alpha value thru.
        /// </value>
        string AlphaValueThru { get; }

        /// <summary>
        /// Gets the condition compare to field number.
        /// </summary>
        /// <value>
        /// The condition compare to field number.
        /// </value>
        int ConditionCompareToFieldNumber { get; }

        /// <summary>
        /// Gets the type of the condition compare to field.
        /// </summary>
        /// <value>
        /// The type of the condition compare to field.
        /// </value>
        short ConditionCompareToFieldType { get; }

        /// <summary>
        /// Gets the condition compare to qualifier.
        /// </summary>
        /// <value>
        /// The condition compare to qualifier.
        /// </value>
        short ConditionCompareToQualifier { get; }

        /// <summary>
        /// Gets the condition count.
        /// </summary>
        /// <value>
        /// The condition count.
        /// </value>
        short ConditionCount { get; }

        /// <summary>
        /// Gets the type of the condition parameter value.
        /// </summary>
        /// <value>
        /// The type of the condition parameter value.
        /// </value>
        RecordValueType ConditionParameterValueType { get; }

        /// <summary>
        /// Gets the condition range use.
        /// </summary>
        /// <value>
        /// The condition range use.
        /// </value>
        short ConditionRangeUse { get; }

        /// <summary>
        /// Gets the decimal value.
        /// </summary>
        /// <value>
        /// The decimal value.
        /// </value>
        decimal DecimalValue { get; }

        /// <summary>
        /// Gets the decimal value thru.
        /// </summary>
        /// <value>
        /// The decimal value thru.
        /// </value>
        decimal DecimalValueThru { get; }

        /// <summary>
        /// Gets the exception identifier.
        /// </summary>
        /// <value>
        /// The exception identifier.
        /// </value>
        short ExceptionId { get; }

        /// <summary>
        /// Gets the type of the generic comp.
        /// </summary>
        /// <value>
        /// The type of the generic comp.
        /// </value>
        CompareType GenericCompareType { get; }

        /// <summary>
        /// Gets the generic condition level.
        /// </summary>
        /// <value>
        /// The generic condition level.
        /// </value>
        ConditionOperation GenericConditionOperation { get; }

        /// <summary>
        /// Gets the generic condition level2.
        /// </summary>
        /// <value>
        /// The generic condition level2.
        /// </value>
        short GenericConditionSequence { get; }

        /// <summary>
        /// Gets the generic field number.
        /// </summary>
        /// <value>
        /// The generic field number.
        /// </value>
        int GenericFieldNumber { get; }

        /// <summary>
        /// Gets the generic field qualifier.
        /// </summary>
        /// <value>
        /// The generic field qualifier.
        /// </value>
        short GenericFieldQualifier { get; }

        /// <summary>
        /// Gets the type of the generic field.
        /// </summary>
        /// <value>
        /// The type of the generic field.
        /// </value>
        FieldType GenericFieldType { get; }

        /// <summary>
        /// Gets the numeric value.
        /// </summary>
        /// <value>
        /// The numeric value.
        /// </value>
        long NumericValue { get; }

        /// <summary>
        /// Gets the numeric value thru.
        /// </summary>
        /// <value>
        /// The numeric value thru.
        /// </value>
        long NumericValueThru { get; }

        /// <summary>
        /// Gets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        RecordValueType ParametersValueType { get; }

        /// <summary>
        /// Gets the type of the record.
        /// </summary>
        /// <value>
        /// The type of the record.
        /// </value>
        RecordType RecordType { get; }

        /// <summary>
        /// Gets the step identifier.
        /// </summary>
        /// <value>
        /// The step identifier.
        /// </value>
        short StepId { get; }

        /// <summary>
        /// Gets the type of the step.
        /// </summary>
        /// <value>
        /// The type of the step.
        /// </value>
        StepType StepType { get; }
    }
}