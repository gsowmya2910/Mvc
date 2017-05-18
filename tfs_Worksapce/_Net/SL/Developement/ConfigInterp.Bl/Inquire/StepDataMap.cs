// ----------------------------------------------------------------------
// <copyright file="StepDataMap.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl.Inquire
{
    using CIPINQ01;
    using Contracts.DataContracts;
    using Interfaces;

    /// <summary>
    /// The Object
    /// </summary>
    /// <seealso cref="IStepDataMap" />
    internal class StepDataMap : IStepDataMap
    {
        /// <summary>
        /// The data map
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly DataMapsOut _dataMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="StepDataMap" /> class.
        /// </summary>
        /// <param name="dataMap">The data map.</param>
        public StepDataMap(DataMapsOut dataMap)
        {
            this._dataMap = dataMap;
        }

        /// <summary>
        /// Gets the action actual pram count.
        /// </summary>
        /// <value>
        /// The action actual pram count.
        /// </value>
        public short ActionActualParameterCount
        {
            get { return this._dataMap.ActionActualParamCount; }
        }

        /// <summary>
        /// Gets the action false count.
        /// </summary>
        /// <value>
        /// The action false count.
        /// </value>
        public short ActionFalseCount
        {
            get { return this._dataMap.ActionFalseCount; }
        }

        /// <summary>
        /// Gets the action identifier.
        /// </summary>
        /// <value>
        /// The action identifier.
        /// </value>
        public short ActionId
        {
            get { return this._dataMap.ActionID; }
        }

        /// <summary>
        /// Gets the action parameters alpha.
        /// </summary>
        /// <value>
        /// The action parameters alpha.
        /// </value>
        public string ActionParameterAlpha
        {
            get { return this._dataMap.ActionParamsAlpha; }
        }

        /// <summary>
        /// Gets the action parameters decimal.
        /// </summary>
        /// <value>
        /// The action parameters decimal.
        /// </value>
        public decimal ActionParameterDecimal
        {
            get { return this._dataMap.ActionParamsDecimal; }
        }

        /// <summary>
        /// Gets the action parameters numeric.
        /// </summary>
        /// <value>
        /// The action parameters numeric.
        /// </value>
        public long ActionParameterNumeric
        {
            get { return (long)this._dataMap.ActionParamsNumeric; }
        }

        /// <summary>
        /// Gets the action parameters sequence.
        /// </summary>
        /// <value>
        /// The action parameters sequence.
        /// </value>
        public short ActionParameterSequence
        {
            get { return this._dataMap.ActionParamsSeq; }
        }

        /// <summary>
        /// Gets the action sequence.
        /// </summary>
        /// <value>
        /// The action sequence.
        /// </value>
        public short ActionSequence
        {
            get { return this._dataMap.ActionSequence; }
        }

        /// <summary>
        /// Gets the action true count.
        /// </summary>
        /// <value>
        /// The action true count.
        /// </value>
        public short ActionTrueCount
        {
            get { return this._dataMap.ActionTrueCount; }
        }

        /// <summary>
        /// Gets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType ActionType
        {
            get
            {
                if (RecordType == RecordType.Action)
                {
                    return (ActionType)this._dataMap.ActionType;
                }

                return ActionType.NotApplicable;
            }
        }

        /// <summary>
        /// Gets the alpha value.
        /// </summary>
        /// <value>
        /// The alpha value.
        /// </value>
        public string AlphaValue
        {
            get { return this._dataMap.AlphaValue; }
        }

        /// <summary>
        /// Gets the alpha value thru.
        /// </summary>
        /// <value>
        /// The alpha value thru.
        /// </value>
        public string AlphaValueThru
        {
            get { return this._dataMap.AlphaValueThru; }
        }

        /// <summary>
        /// Gets the condition compare to field number.
        /// </summary>
        /// <value>
        /// The condition compare to field number.
        /// </value>
        public int ConditionCompareToFieldNumber
        {
            get { return this._dataMap.ConditionCompareToFieldNum; }
        }

        /// <summary>
        /// Gets the type of the condition compare to field.
        /// </summary>
        /// <value>
        /// The type of the condition compare to field.
        /// </value>
        public short ConditionCompareToFieldType
        {
            get { return this._dataMap.ConditionCompareToFieldType; }
        }

        /// <summary>
        /// Gets the condition compare to qualifier.
        /// </summary>
        /// <value>
        /// The condition compare to qualifier.
        /// </value>
        public short ConditionCompareToQualifier
        {
            get { return this._dataMap.ConditionCompareToQualifier; }
        }

        /// <summary>
        /// Gets the condition count.
        /// </summary>
        /// <value>
        /// The condition count.
        /// </value>
        public short ConditionCount
        {
            get { return this._dataMap.ConditionCount; }
        }

        /// <summary>
        /// Gets the type of the condition parameter value.
        /// </summary>
        /// <value>
        /// The type of the condition parameter value.
        /// </value>
        public RecordValueType ConditionParameterValueType
        {
            get { return (RecordValueType)this._dataMap.ConditionValueType; }
        }

        /// <summary>
        /// Gets the condition range use.
        /// </summary>
        /// <value>
        /// The condition range use.
        /// </value>
        public short ConditionRangeUse
        {
            get { return this._dataMap.ConditionRangeUse; }
        }

        /// <summary>
        /// Gets the decimal value.
        /// </summary>
        /// <value>
        /// The decimal value.
        /// </value>
        public decimal DecimalValue
        {
            get { return this._dataMap.DecimalValue; }
        }

        /// <summary>
        /// Gets the decimal value thru.
        /// </summary>
        /// <value>
        /// The decimal value thru.
        /// </value>
        public decimal DecimalValueThru
        {
            get { return this._dataMap.DecimalValueThru; }
        }

        /// <summary>
        /// Gets the exception identifier.
        /// </summary>
        /// <value>
        /// The exception identifier.
        /// </value>
        public short ExceptionId
        {
            get { return this._dataMap.ExceptionID; }
        }

        /// <summary>
        /// Gets the type of the generic comp.
        /// </summary>
        /// <value>
        /// The type of the generic comp.
        /// </value>
        public CompareType GenericCompareType
        {
            get { return (CompareType)this._dataMap.GenericCompType; }
        }

        /// <summary>
        /// Gets the generic condition level.
        /// </summary>
        /// <value>
        /// The generic condition level.
        /// </value>
        public ConditionOperation GenericConditionOperation
        {
            get { return (ConditionOperation)this._dataMap.GenericConditionLevel1; }
        }

        /// <summary>
        /// Gets the generic condition level2.
        /// </summary>
        /// <value>
        /// The generic condition level2.
        /// </value>
        public short GenericConditionSequence
        {
            get { return this._dataMap.GenericConditionLevel2; }
        }

        /// <summary>
        /// Gets the generic field number.
        /// </summary>
        /// <value>
        /// The generic field number.
        /// </value>
        public int GenericFieldNumber
        {
            get { return this._dataMap.GenericFieldNum; }
        }

        /// <summary>
        /// Gets the generic field qualifier.
        /// </summary>
        /// <value>
        /// The generic field qualifier.
        /// </value>
        public short GenericFieldQualifier
        {
            get { return this._dataMap.GenericFieldQualifier; }
        }

        /// <summary>
        /// Gets the type of the generic field.
        /// </summary>
        /// <value>
        /// The type of the generic field.
        /// </value>
        public FieldType GenericFieldType
        {
            get { return (FieldType)this._dataMap.GenericFieldType; }
        }

        /// <summary>
        /// Gets the numeric value.
        /// </summary>
        /// <value>
        /// The numeric value.
        /// </value>
        public long NumericValue
        {
            get { return (long)this._dataMap.NumericValue; }
        }

        /// <summary>
        /// Gets the numeric value thru.
        /// </summary>
        /// <value>
        /// The numeric value thru.
        /// </value>
        public long NumericValueThru
        {
            get { return (long)this._dataMap.NumericValueThru; }
        }

        /// <summary>
        /// Gets the type of the value.
        /// </summary>
        /// <value>
        /// The type of the value.
        /// </value>
        public RecordValueType ParametersValueType
        {
            get { return (RecordValueType)this._dataMap.ValueType; }
        }

        /// <summary>
        /// Gets the type of the record.
        /// </summary>
        /// <value>
        /// The type of the record.
        /// </value>
        public RecordType RecordType
        {
            get { return (RecordType)this._dataMap.RecordType; }
        }

        /// <summary>
        /// Gets the step identifier.
        /// </summary>
        /// <value>
        /// The step identifier.
        /// </value>
        public short StepId
        {
            get { return this._dataMap.StepID; }
        }

        /// <summary>
        /// Gets the type of the step.
        /// </summary>
        /// <value>
        /// The type of the step.
        /// </value>
        public StepType StepType
        {
            get { return (StepType)this._dataMap.StepType; }
        }
    }
}