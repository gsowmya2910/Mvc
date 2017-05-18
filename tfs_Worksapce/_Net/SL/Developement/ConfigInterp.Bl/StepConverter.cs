// ----------------------------------------------------------------------
// <copyright file="StepConverter.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.DataContracts;
    using Interfaces;
    using Update;

    /// <summary>
    /// the class
    /// </summary>
    public class StepConverter : IStepConverter
    {
        /// <summary>
        /// Complexities the count.
        /// </summary>
        /// <param name="configuredStep">The configured step.</param>
        /// <returns>
        /// the value
        /// </returns>
        public static int ComplexityCount(ConfiguredStep configuredStep)
        {
            var list = new List<IStepDataMap>();
            HandleEachStep(configuredStep, list);
            return list.Count;
        }

        /// <summary>
        /// Converts the steps.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// the value
        /// </returns>
        public ConfiguredSteps ConvertSteps(IEnumerable<IStepDataMap> source)
        {
            if (source == null)
            {
                return null;
            }

            var steps = new ConfiguredSteps();
            var stepDatas = source.ToList();
            var actualSteps = new List<ConfiguredStep>();
            foreach (var stepParts in stepDatas.GroupBy(_ => _.StepId))
            {
                var step = MergeData(stepParts);
                actualSteps.Add(step);
            }

            var ordered = actualSteps.OrderBy(_ => _.Index).ToArray();
            steps.ConditionalSteps = ordered.OfType<ConditionalStep>().ToArray();
            steps.UnconditionalSteps = ordered.OfType<UnconditionalStep>().ToArray();
            steps.ExceptionSteps = ordered.OfType<ExceptionStep>().ToArray();
            return steps;
        }

        /// <summary>
        /// Converts to flat data.
        /// </summary>
        /// <param name="configuredSteps">The configured steps.</param>
        /// <returns>
        /// the value
        /// </returns>
        public IEnumerable<IStepDataMap> ConvertToFlatData(ConfiguredSteps configuredSteps)
        {
            if (configuredSteps != null)
            {
                var allList = new List<IStepDataMap>();

                var orderedSteps = MergeAndOrderSteps(configuredSteps).ToList();
                foreach (var configuredStep in orderedSteps)
                {
                    HandleEachStep(configuredStep, allList);
                }

                return allList;
            }

            return Enumerable.Empty<IStepDataMap>();
        }

        /// <summary>
        /// Converts the actions.
        /// </summary>
        /// <param name="actionsFalse">The actions false.</param>
        /// <param name="actionsTrue">The actions true.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="conditionCount">The condition count.</param>
        /// <param name="stepType">Type of the step.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="action">The action.</param>
        /// <param name="actionIndex">Index of the action.</param>
        /// <param name="list">The list.</param>
        internal static void ConvertActions(short actionsFalse, short actionsTrue, short stepId, short conditionCount, StepType stepType, ActionType actionType, StepAction action, short actionIndex, IList<IStepDataMap> list)
        {
            if (action != null)
            {
                var parameterCount = (short)
                    ((action.NumericParameters == null ? 0 : action.NumericParameters.Count) +
                     (action.DecimalParameters == null ? 0 : action.DecimalParameters.Count) +
                     (action.AlphaParameters == null ? 0 : action.AlphaParameters.Count));

                var actionRecord = new RecordInDataMap
                {
                    ActionActualParameterCount = parameterCount,
                    ActionFalseCount = actionsFalse,
                    ActionId = action.ActionId,
                    ActionSequence = actionIndex,
                    ActionTrueCount = actionsTrue,
                    ActionType = actionType,
                    ConditionCount = conditionCount,
                    RecordType = RecordType.Action,
                    StepId = stepId,
                    StepType = stepType
                };
                list.Add(actionRecord);

                if (parameterCount > 0)
                {
                    short paramIndex = 1;
                    if (action.AlphaParameters != null)
                    {
                        foreach (var alphaParameter in action.AlphaParameters.Where(_ => _ != null))
                        {
                            var paramRecord = GetBaseActionParameterRecord(actionsFalse, actionsTrue, stepId, conditionCount, stepType, parameterCount, paramIndex);
                            paramRecord.ActionParameterAlpha = alphaParameter.Value;
                            paramRecord.ParametersValueType = RecordValueType.Alpha;
                            list.Add(paramRecord);
                            paramIndex++;
                        }
                    }

                    if (action.DecimalParameters != null)
                    {
                        foreach (var decimalParameter in action.DecimalParameters.Where(_ => _ != null))
                        {
                            var paramRecord = GetBaseActionParameterRecord(actionsFalse, actionsTrue, stepId, conditionCount, stepType, parameterCount, paramIndex);
                            paramRecord.ActionParameterDecimal = decimalParameter.Value;
                            paramRecord.ParametersValueType = RecordValueType.Decimal;
                            list.Add(paramRecord);
                            paramIndex++;
                        }
                    }

                    if (action.NumericParameters != null)
                    {
                        foreach (var numericParameter in action.NumericParameters.Where(_ => _ != null))
                        {
                            var paramRecord = GetBaseActionParameterRecord(actionsFalse, actionsTrue, stepId, conditionCount, stepType, parameterCount, paramIndex);
                            paramRecord.ActionParameterNumeric = numericParameter.Value;
                            paramRecord.ParametersValueType = RecordValueType.Numeric;
                            list.Add(paramRecord);
                            paramIndex++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Converts the alpha.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static AlphaValueWithThru ConvertAlpha(IStepDataMap map)
        {
            var value = new AlphaValueWithThru
            {
                Value = map.AlphaValue,
                ValueThru = map.AlphaValueThru
            };
            return value;
        }

        /// <summary>
        /// Converts the condition.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static Condition ConvertCondition(IStepDataMap map)
        {
            var value = new Condition
            {
                CompareType = map.GenericCompareType,
                FieldNumber = map.GenericFieldNumber,
                Qualifier = map.GenericFieldQualifier,
                Operation = map.GenericConditionOperation,
                FieldType = map.GenericFieldType
            };
            return value;
        }

        /// <summary>
        /// Converts the actions.
        /// </summary>
        /// <param name="stepList">The step list.</param>
        /// <param name="actionsFalse">The actions false.</param>
        /// <param name="actionsTrue">The actions true.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="conditionCount">The condition count.</param>
        /// <param name="stepType">Type of the step.</param>
        /// <param name="actions">The actions.</param>
        /// <param name="actionType">Type of the action.</param>
        internal static void ConvertConditionalActions(List<IStepDataMap> stepList, short actionsFalse, short actionsTrue, short stepId, short conditionCount, StepType stepType, List<StepAction> actions, ActionType actionType)
        {
            var list = new List<IStepDataMap>();
            short actionIndex = 1;
            foreach (var action in actions.Where(_ => _ != null))
            {
                ConvertActions(actionsFalse, actionsTrue, stepId, conditionCount, stepType, actionType, action, actionIndex, list);
                actionIndex++;
            }

            stepList.AddRange(list);
        }

        /// <summary>
        /// Converts the conditions.
        /// </summary>
        /// <param name="stepList">The step list.</param>
        /// <param name="actionsFalse">The actions false.</param>
        /// <param name="actionsTrue">The actions true.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="conditionCount">The condition count.</param>
        /// <param name="stepType">Type of the step.</param>
        /// <param name="conditions">The conditions.</param>
        internal static void ConvertConditions(List<IStepDataMap> stepList, short actionsFalse, short actionsTrue, short stepId, short conditionCount, StepType stepType, List<Condition> conditions)
        {
            var list = new List<RecordInDataMap>();
            var linkedConditions = new List<RecordInDataMap>();

            foreach (var condition in conditions.Where(_ => _ != null))
            {
                var conditionRecord = new RecordInDataMap
                {
                    ActionFalseCount = actionsFalse,
                    ActionTrueCount = actionsTrue,
                    ConditionCount = conditionCount,
                    GenericCompareType = condition.CompareType,
                    GenericConditionOperation = condition.Operation,
                    GenericConditionSequence = 1,
                    GenericFieldNumber = condition.FieldNumber,
                    GenericFieldQualifier = condition.Qualifier,
                    GenericFieldType = condition.FieldType,
                    RecordType = RecordType.Conditions,
                    StepId = stepId,
                    StepType = stepType,
                    ConditionParameterValueType = condition.ParameterType
                };
                list.Add(conditionRecord);
                linkedConditions.Add(conditionRecord);

                if (condition.AlphaParameters != null)
                {
                    conditionRecord.ConditionParameterValueType = RecordValueType.Alpha;
                    foreach (var parameter in condition.AlphaParameters.Where(_ => _ != null))
                    {
                        var parameterRecord = GetBaseConditionParameterRecord(actionsFalse, actionsTrue, stepId, conditionCount, stepType, conditionRecord);
                        parameterRecord.AlphaValue = parameter.Value;
                        parameterRecord.AlphaValueThru = parameter.ValueThru;
                        parameterRecord.RecordType = RecordType.Alpha;
                        list.Add(parameterRecord);
                    }

                    continue;
                }

                if (condition.DecimalParameters != null)
                {
                    conditionRecord.ConditionParameterValueType = RecordValueType.Decimal;
                    foreach (var parameter in condition.DecimalParameters.Where(_ => _ != null))
                    {
                        var parameterRecord = GetBaseConditionParameterRecord(actionsFalse, actionsTrue, stepId, conditionCount, stepType, conditionRecord);
                        parameterRecord.DecimalValue = parameter.Value;
                        parameterRecord.DecimalValueThru = parameter.ValueThru;
                        parameterRecord.RecordType = RecordType.Decimal;
                        list.Add(parameterRecord);
                    }

                    continue;
                }

                if (condition.NumericParameters != null)
                {
                    conditionRecord.ConditionParameterValueType = RecordValueType.Numeric;
                    foreach (var parameter in condition.NumericParameters.Where(_ => _ != null))
                    {
                        var parameterRecord = GetBaseConditionParameterRecord(actionsFalse, actionsTrue, stepId, conditionCount, stepType, conditionRecord);
                        parameterRecord.NumericValue = parameter.Value;
                        parameterRecord.NumericValueThru = parameter.ValueThru;
                        parameterRecord.RecordType = RecordType.Integer;
                        list.Add(parameterRecord);
                    }

                    //// ReSharper disable once RedundantJumpStatement
                    continue;
                }
            }

            short offset = 1;
            for (int index = offset; index < linkedConditions.Count; index++)
            {
                var previous = linkedConditions[index - offset];
                var current = linkedConditions[index];
                if (previous.GenericConditionOperation == ConditionOperation.AndIf && current.GenericConditionOperation == ConditionOperation.AndIf)
                {
                    current.GenericConditionSequence = (short)(previous.GenericConditionSequence + offset);
                }
            }

            stepList.AddRange(list);
        }

        /// <summary>
        /// Converts the decimal.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static DecimalValueWithThru ConvertDecimal(IStepDataMap map)
        {
            var value = new DecimalValueWithThru
            {
                Value = map.DecimalValue,
                ValueThru = map.DecimalValueThru
            };
            return value;
        }

        /// <summary>
        /// Converts the false actions.
        /// </summary>
        /// <param name="stepList">The step list.</param>
        /// <param name="actionsFalse">The actions false.</param>
        /// <param name="actionsTrue">The actions true.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="conditionCount">The condition count.</param>
        /// <param name="stepType">Type of the step.</param>
        /// <param name="falseActions">The false actions.</param>
        internal static void ConvertFalseActions(List<IStepDataMap> stepList, short actionsFalse, short actionsTrue, short stepId, short conditionCount, StepType stepType, List<StepAction> falseActions)
        {
            ConvertConditionalActions(stepList, actionsFalse, actionsTrue, stepId, conditionCount, stepType, falseActions, ActionType.ConditionalFalse);
        }

        /// <summary>
        /// Converts the numeric.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static NumericValueWithThru ConvertNumeric(IStepDataMap map)
        {
            var value = new NumericValueWithThru
            {
                Value = map.NumericValue,
                ValueThru = map.NumericValueThru
            };
            return value;
        }

        /// <summary>
        /// Converts the step action.
        /// </summary>
        /// <param name="narrative">The narrative.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static StepAction ConvertStepAction(IStepDataMap narrative)
        {
            var action = new StepAction
            {
                ActionId = narrative.ActionId
            };
            return action;
        }

        /// <summary>
        /// Converts the true actions.
        /// </summary>
        /// <param name="stepList">The step list.</param>
        /// <param name="actionsFalse">The actions false.</param>
        /// <param name="actionsTrue">The actions true.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="conditionCount">The condition count.</param>
        /// <param name="stepType">Type of the step.</param>
        /// <param name="trueActions">The true actions.</param>
        internal static void ConvertTrueActions(List<IStepDataMap> stepList, short actionsFalse, short actionsTrue, short stepId, short conditionCount, StepType stepType, List<StepAction> trueActions)
        {
            ConvertConditionalActions(stepList, actionsFalse, actionsTrue, stepId, conditionCount, stepType, trueActions, ActionType.ConditionalTrue);
        }

        /// <summary>
        /// Gets the base action parameter record.
        /// </summary>
        /// <param name="actionsFalse">The actions false.</param>
        /// <param name="actionsTrue">The actions true.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="conditionCount">The condition count.</param>
        /// <param name="stepType">Type of the step.</param>
        /// <param name="parameterCount">The parameter count.</param>
        /// <param name="paramIndex">Index of the parameter.</param>
        /// <returns>the value</returns>
        internal static RecordInDataMap GetBaseActionParameterRecord(short actionsFalse, short actionsTrue, short stepId, short conditionCount, StepType stepType, short parameterCount, short paramIndex)
        {
            return new RecordInDataMap
            {
                ActionActualParameterCount = parameterCount,
                ActionFalseCount = actionsFalse,
                ActionParameterSequence = paramIndex,
                ActionTrueCount = actionsTrue,
                ConditionCount = conditionCount,
                RecordType = RecordType.Parameters,
                StepId = stepId,
                StepType = stepType
            };
        }

        /// <summary>
        /// Gets the base parameter record.
        /// </summary>
        /// <param name="actionsFalse">The actions false.</param>
        /// <param name="actionsTrue">The actions true.</param>
        /// <param name="stepId">The step identifier.</param>
        /// <param name="conditionCount">The condition count.</param>
        /// <param name="stepType">Type of the step.</param>
        /// <param name="conditionRecord">The condition record.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static RecordInDataMap GetBaseConditionParameterRecord(short actionsFalse, short actionsTrue, short stepId, short conditionCount, StepType stepType, RecordInDataMap conditionRecord)
        {
            return new RecordInDataMap
            {
                ActionFalseCount = actionsFalse,
                ActionTrueCount = actionsTrue,
                ConditionCount = conditionCount,
                StepId = stepId,
                StepType = stepType,
                GenericFieldQualifier = conditionRecord.GenericFieldQualifier,
                GenericFieldNumber = conditionRecord.GenericFieldNumber,
                GenericFieldType = conditionRecord.GenericFieldType,
                GenericCompareType = conditionRecord.GenericCompareType,
                GenericConditionOperation = conditionRecord.GenericConditionOperation,
                GenericConditionSequence = conditionRecord.GenericConditionSequence
            };
        }

        /// <summary>
        /// Gets the conditional step.
        /// </summary>
        /// <param name="stepParts">The step parts.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static ConditionalStep GetConditionalStep(IGrouping<short, IStepDataMap> stepParts)
        {
            var step = new ConditionalStep { Index = stepParts.Key };
            Condition condition = null;
            StepAction action = null;
            foreach (var map in stepParts)
            {
                if (map.RecordType == RecordType.Action)
                {
                    action = ConvertStepAction(map);
                    if (map.ActionType == ActionType.ConditionalTrue)
                    {
                        if (step.TrueActions == null)
                        {
                            step.TrueActions = new List<StepAction>();
                        }

                        step.TrueActions.Add(action);
                    }
                    else if (map.ActionType == ActionType.ConditionalFalse)
                    {
                        if (step.FalseActions == null)
                        {
                            step.FalseActions = new List<StepAction>();
                        }

                        step.FalseActions.Add(action);
                    }
                }
                else if (map.RecordType == RecordType.Conditions)
                {
                    condition = ConvertCondition(map);
                    if (step.Conditions == null)
                    {
                        step.Conditions = new List<Condition>();
                    }

                    step.Conditions.Add(condition);
                }
                else if (map.RecordType == RecordType.Alpha)
                {
                    HandleAlphaRecordType(map, condition);
                }
                else if (map.RecordType == RecordType.Decimal)
                {
                    HandleDecimalRecordType(map, condition);
                }
                else if (map.RecordType == RecordType.Integer)
                {
                    HandleIntegerRecordType(map, condition);
                }
                else if (map.RecordType == RecordType.Parameters)
                {
                    HandleParameterRecordType(action, map);
                }
            }

            return step;
        }

        /// <summary>
        /// Gets the exception step.
        /// </summary>
        /// <param name="stepParts">The step parts.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static ExceptionStep GetExceptionStep(IGrouping<short, IStepDataMap> stepParts)
        {
            var step = new ExceptionStep { Index = stepParts.Key };
            var data = stepParts.FirstOrDefault();

            if (data != null)
            {
                step.ExceptionId = data.ExceptionId;
            }

            return step;
        }

        /// <summary>
        /// Gets the unconditional step.
        /// </summary>
        /// <param name="stepParts">The step parts.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static UnconditionalStep GetUnconditionalStep(IGrouping<short, IStepDataMap> stepParts)
        {
            var step = new UnconditionalStep { Index = stepParts.Key };
            StepAction action = null;

            foreach (var map in stepParts)
            {
                if (map.RecordType == RecordType.Action)
                {
                    step.Action = action = ConvertStepAction(map);
                }
                else if (map.RecordType == RecordType.Parameters)
                {
                    HandleParameterRecordType(action, map);
                }
            }

            return step;
        }

        /// <summary>
        /// Handles the type of the alpha record.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="condition">The condition.</param>
        internal static void HandleAlphaRecordType(IStepDataMap map, Condition condition)
        {
            AlphaValueWithThru alphaValue = ConvertAlpha(map);
            if (condition != null)
            {
                if (condition.AlphaParameters == null)
                {
                    condition.AlphaParameters = new List<AlphaValueWithThru>();
                }

                condition.AlphaParameters.Add(alphaValue);
            }
        }

        /// <summary>
        /// Handles the conditional step.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="allList">All list.</param>
        internal static void HandleConditionalStep(ConditionalStep step, List<IStepDataMap> allList)
        {
            var list = new List<IStepDataMap>();

            short actionsFalse = step.FalseActions == null ? (short)0 : (short)step.FalseActions.Count;
            short actionsTrue = step.TrueActions == null ? (short)0 : (short)step.TrueActions.Count;
            short conditionCount = step.Conditions == null ? (short)0 : (short)step.Conditions.Count;

            short stepId = step.Index;
            var stepType = StepType.Conditional;
            if (step.Conditions != null)
            {
                ConvertConditions(list, actionsFalse, actionsTrue, stepId, conditionCount, stepType, step.Conditions);
            }

            if (step.TrueActions != null)
            {
                ConvertTrueActions(list, actionsFalse, actionsTrue, stepId, conditionCount, stepType, step.TrueActions);
            }

            if (step.FalseActions != null)
            {
                ConvertFalseActions(list, actionsFalse, actionsTrue, stepId, conditionCount, stepType, step.FalseActions);
            }

            allList.AddRange(list);
        }

        /// <summary>
        /// Handles the type of the decimal record.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="condition">The condition.</param>
        internal static void HandleDecimalRecordType(IStepDataMap map, Condition condition)
        {
            DecimalValueWithThru decimalValue = ConvertDecimal(map);
            if (condition != null)
            {
                if (condition.DecimalParameters == null)
                {
                    condition.DecimalParameters = new List<DecimalValueWithThru>();
                }

                condition.DecimalParameters.Add(decimalValue);
            }
        }

        /// <summary>
        /// Handles the each step.
        /// </summary>
        /// <param name="configuredStep">The configured step.</param>
        /// <param name="allList">All list.</param>
        internal static void HandleEachStep(ConfiguredStep configuredStep, List<IStepDataMap> allList)
        {
            var conditionalStep = configuredStep as ConditionalStep;
            if (conditionalStep != null)
            {
                HandleConditionalStep(conditionalStep, allList);
                return;
            }

            var unconditionalStep = configuredStep as UnconditionalStep;
            if (unconditionalStep != null)
            {
                HandleUnconditionalStep(unconditionalStep, allList);
                return;
            }

            var exceptionStep = configuredStep as ExceptionStep;
            if (exceptionStep != null)
            {
                HandleExceptionStep(exceptionStep, allList);
                //// ReSharper disable once RedundantJumpStatement
                return;
            }
        }

        /// <summary>
        /// Handles the exception step.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="allList">All list.</param>
        internal static void HandleExceptionStep(ExceptionStep step, IList<IStepDataMap> allList)
        {
            var stepData = new RecordInDataMap
            {
                StepType = StepType.Exception,
                RecordType = RecordType.Exceptions,
                ExceptionId = step.ExceptionId,
                StepId = step.Index
            };
            allList.Add(stepData);
        }

        /// <summary>
        /// Handles the type of the integer record.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="condition">The condition.</param>
        internal static void HandleIntegerRecordType(IStepDataMap map, Condition condition)
        {
            NumericValueWithThru numericValue = ConvertNumeric(map);
            if (condition != null)
            {
                if (condition.NumericParameters == null)
                {
                    condition.NumericParameters = new List<NumericValueWithThru>();
                }

                condition.NumericParameters.Add(numericValue);
            }
        }

        /// <summary>
        /// Handles the type of the parameter record.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="map">The map.</param>
        internal static void HandleParameterRecordType(StepAction action, IStepDataMap map)
        {
            if (action != null)
            {
                if (map.ParametersValueType == RecordValueType.Alpha)
                {
                    if (action.AlphaParameters == null)
                    {
                        action.AlphaParameters = new List<AlphaValue>();
                    }

                    action.AlphaParameters.Add(new AlphaValue { Value = map.ActionParameterAlpha });
                }
                else if (map.ParametersValueType == RecordValueType.Decimal)
                {
                    if (action.DecimalParameters == null)
                    {
                        action.DecimalParameters = new List<DecimalValue>();
                    }

                    action.DecimalParameters.Add(new DecimalValue { Value = map.ActionParameterDecimal });
                }
                else if (map.ParametersValueType == RecordValueType.Numeric)
                {
                    if (action.NumericParameters == null)
                    {
                        action.NumericParameters = new List<NumericValue>();
                    }

                    action.NumericParameters.Add(new NumericValue { Value = map.ActionParameterNumeric });
                }
            }
        }

        /// <summary>
        /// Handles the unconditional step.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="allList">All list.</param>
        internal static void HandleUnconditionalStep(UnconditionalStep step, IList<IStepDataMap> allList)
        {
            if (step.Action != null)
            {
                ConvertActions(0, 0, step.Index, 0, StepType.Unconditional, ActionType.Unconditional, step.Action, 0, allList);
            }
        }

        /// <summary>
        /// Merges the and order steps.
        /// </summary>
        /// <param name="configuredSteps">The configured steps.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static IEnumerable<ConfiguredStep> MergeAndOrderSteps(ConfiguredSteps configuredSteps)
        {
            var rawSteps = new List<ConfiguredStep>();
            if (configuredSteps.ConditionalSteps != null)
            {
                rawSteps.AddRange(configuredSteps.ConditionalSteps);
            }

            if (configuredSteps.UnconditionalSteps != null)
            {
                rawSteps.AddRange(configuredSteps.UnconditionalSteps);
            }

            if (configuredSteps.ExceptionSteps != null)
            {
                rawSteps.AddRange(configuredSteps.ExceptionSteps);
            }

            var orderedSteps = rawSteps.OrderBy(_ => _.Index).ToList();
            return orderedSteps;
        }

        /// <summary>
        /// Merges the data.
        /// </summary>
        /// <param name="stepParts">The step parts.</param>
        /// <returns>
        /// the value
        /// </returns>
        internal static ConfiguredStep MergeData(IGrouping<short, IStepDataMap> stepParts)
        {
            var stepType = stepParts.First().StepType;

            switch (stepType)
            {
                case StepType.Conditional:
                    return GetConditionalStep(stepParts);

                case StepType.Exception:
                    return GetExceptionStep(stepParts);

                case StepType.Unconditional:
                    return GetUnconditionalStep(stepParts);

                default:
                    return null;
            }
        }
    }
}