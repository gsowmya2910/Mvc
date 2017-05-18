// ----------------------------------------------------------------------
// <copyright file="EqualityChecker.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.TestUtilities
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Contracts.DataContracts;

    /// <summary>
    /// the class
    /// </summary>
    [SuppressMessage("ReSharper", "CyclomaticComplexity", Justification = "Dev")]
    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse", Justification = "Dev")]
    public static class EqualityChecker
    {
        /// <summary>
        /// Compares the specified objects.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// the value
        /// </returns>
        public static bool Compare(ConfiguredSteps first, ConfiguredSteps second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            if ((first.ConditionalSteps != null && second.ConditionalSteps == null) || (first.ConditionalSteps == null && second.ConditionalSteps != null) ||
                (first.UnconditionalSteps != null && second.UnconditionalSteps == null) || (first.UnconditionalSteps == null && second.UnconditionalSteps != null) ||
                (first.ExceptionSteps != null && second.ExceptionSteps == null) || (first.ExceptionSteps == null && second.ExceptionSteps != null))
            {
                return false;
            }

            if (first.ConditionalSteps != null && second.ConditionalSteps != null)
            {
                if (first.ConditionalSteps.Length == second.ConditionalSteps.Length)
                {
                    var firstOrdered = first.ConditionalSteps.OrderBy(_ => _.Index).ToArray();
                    var secondOrdered = second.ConditionalSteps.OrderBy(_ => _.Index).ToArray();
                    for (int index = 0; index < secondOrdered.Length; index++)
                    {
                        var firstStep = firstOrdered[index];
                        var secondStep = secondOrdered[index];
                        if (!Compare(firstStep, secondStep))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            if (first.UnconditionalSteps != null && second.UnconditionalSteps != null)
            {
                if (first.UnconditionalSteps.Length == second.UnconditionalSteps.Length)
                {
                    var firstOrdered = first.UnconditionalSteps.OrderBy(_ => _.Index).ToArray();
                    var secondOrdered = second.UnconditionalSteps.OrderBy(_ => _.Index).ToArray();
                    for (int index = 0; index < secondOrdered.Length; index++)
                    {
                        var firstStep = firstOrdered[index];
                        var secondStep = secondOrdered[index];
                        if (firstStep == null && secondStep == null)
                        {
                            continue;
                        }

                        if ((firstStep != null && secondStep == null) || (firstStep == null && secondStep != null))
                        {
                            return false;
                        }

                        if (firstStep.Index != secondStep.Index)
                        {
                            return false;
                        }

                        if (!Compare(firstStep.Action, secondStep.Action))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            if (first.ExceptionSteps != null && second.ExceptionSteps != null)
            {
                if (first.ExceptionSteps.Length == second.ExceptionSteps.Length)
                {
                    var firstOrdered = first.ExceptionSteps.OrderBy(_ => _.Index).ToArray();
                    var secondOrdered = second.ExceptionSteps.OrderBy(_ => _.Index).ToArray();
                    for (int index = 0; index < secondOrdered.Length; index++)
                    {
                        var firstStep = firstOrdered[index];
                        var secondStep = secondOrdered[index];
                        if (!CompareExceptionStep(firstStep, secondStep))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Joined the enumerable.
        /// </summary>
        /// <typeparam name="T">type parameter</typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="pairs">The pairs.</param>
        /// <returns>the value</returns>
        internal static bool JoinedEnumerable<T>(IEnumerable<T> first, IEnumerable<T> second, out IEnumerable<Pairs<T>> pairs)
        {
            pairs = Enumerable.Empty<Pairs<T>>();
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            var firstCached = first.ToArray();
            var secondCached = second.ToArray();
            if (firstCached.Length != secondCached.Length)
            {
                return false;
            }

            var list = new List<Pairs<T>>();
            for (int index = 0; index < firstCached.Length; index++)
            {
                var firstObject = firstCached[index];
                var secondObject = secondCached[index];
                list.Add(new Pairs<T>
                {
                    First = firstObject,
                    Second = secondObject
                });
            }

            pairs = list;
            return true;
        }

        /// <summary>
        /// Compares the specified first step.
        /// </summary>
        /// <param name="firstStep">The first step.</param>
        /// <param name="secondStep">The second step.</param>
        /// <returns>the value</returns>
        private static bool Compare(ConditionalStep firstStep, ConditionalStep secondStep)
        {
            if (firstStep == null && secondStep == null)
            {
                return true;
            }

            if ((firstStep != null && secondStep == null) || (firstStep == null && secondStep != null))
            {
                return false;
            }

            if (firstStep.Index != secondStep.Index)
            {
                return false;
            }

            if ((firstStep.Conditions != null && secondStep.Conditions == null) || (firstStep.Conditions == null && secondStep.Conditions != null) ||
                (firstStep.TrueActions != null && secondStep.TrueActions == null) || (firstStep.TrueActions == null && secondStep.TrueActions != null) ||
                (firstStep.FalseActions != null && secondStep.FalseActions == null) || (firstStep.FalseActions == null && secondStep.FalseActions != null))
            {
                return false;
            }

            IEnumerable<Pairs<Condition>> conditionPairs;
            if (JoinedEnumerable(firstStep.Conditions, secondStep.Conditions, out conditionPairs))
            {
                foreach (var pair in conditionPairs)
                {
                    if (!Compare(pair.First, pair.Second))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            IEnumerable<Pairs<StepAction>> trueActionPairs;
            if (JoinedEnumerable(firstStep.TrueActions, firstStep.TrueActions, out trueActionPairs))
            {
                foreach (var actionPair in trueActionPairs)
                {
                    if (!Compare(actionPair.First, actionPair.Second))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            IEnumerable<Pairs<StepAction>> falseActionPairs;
            if (JoinedEnumerable(firstStep.FalseActions, firstStep.FalseActions, out falseActionPairs))
            {
                foreach (var actionPair in falseActionPairs)
                {
                    if (!Compare(actionPair.First, actionPair.Second))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the specified first.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>the value</returns>
        private static bool Compare(Condition first, Condition second)
        {
            if (first == null & second == null)
            {
                return true;
            }

            if (first != null & second == null || first == null & second != null)
            {
                return false;
            }

            if (first.FieldType != second.FieldType)
            {
                return false;
            }

            if (first.CompareType != second.CompareType)
            {
                return false;
            }

            if (first.FieldNumber != second.FieldNumber)
            {
                return false;
            }

            if (first.Operation != second.Operation)
            {
                return false;
            }

            if (first.ParameterType != second.ParameterType)
            {
                return false;
            }

            if (first.Qualifier != second.Qualifier)
            {
                return false;
            }

            if ((first.AlphaParameters != null && second.AlphaParameters == null) || 
                (first.AlphaParameters == null && second.AlphaParameters != null) ||
                (first.NumericParameters != null && second.NumericParameters == null) || 
                (first.NumericParameters == null && second.NumericParameters != null) ||
                (first.DecimalParameters != null && second.DecimalParameters == null) || 
                (first.DecimalParameters == null && second.DecimalParameters != null))
            {
                return false;
            }

            IEnumerable<Pairs<AlphaValueWithThru>> alphaPairs;
            if (JoinedEnumerable((first.AlphaParameters ?? Enumerable.Empty<AlphaValueWithThru>()).OrderBy(_ => _ == null ? string.Empty : _.Value), (second.AlphaParameters ?? Enumerable.Empty<AlphaValueWithThru>()).OrderBy(_ => _ == null ? string.Empty : _.Value), out alphaPairs))
            {
                foreach (var pair in alphaPairs)
                {
                    if (!Compare(pair.First, pair.Second))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            IEnumerable<Pairs<DecimalValueWithThru>> decimalPairs;
            if (JoinedEnumerable(first.DecimalParameters, second.DecimalParameters, out decimalPairs))
            {
                foreach (var pair in decimalPairs)
                {
                    if (!Compare(pair.First, pair.Second))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            IEnumerable<Pairs<NumericValueWithThru>> numericPairs;
            if (JoinedEnumerable(first.NumericParameters, second.NumericParameters, out numericPairs))
            {
                foreach (var pair in numericPairs)
                {
                    if (!Compare(pair.First, pair.Second))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the specified first.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>the value</returns>
        private static bool Compare(NumericValueWithThru first, NumericValueWithThru second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.Value != second.Value)
            {
                return false;
            }

            if (first.ValueThru != second.ValueThru)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the specified first.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>the value</returns>
        private static bool Compare(DecimalValueWithThru first, DecimalValueWithThru second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.Value != second.Value)
            {
                return false;
            }

            if (first.ValueThru != second.ValueThru)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the specified first.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>the value</returns>
        private static bool Compare(AlphaValueWithThru first, AlphaValueWithThru second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.Value != second.Value)
            {
                return false;
            }

            if (first.ValueThru != second.ValueThru)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the specified first action.
        /// </summary>
        /// <param name="first">The first action.</param>
        /// <param name="second">The second action.</param>
        /// <returns>the value</returns>
        private static bool Compare(StepAction first, StepAction second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.ActionId != second.ActionId)
            {
                return false;
            }

            if ((first.AlphaParameters != null && second.AlphaParameters == null) ||
                (first.AlphaParameters == null && second.AlphaParameters != null) ||
               (first.DecimalParameters != null && second.DecimalParameters == null) ||
               (first.DecimalParameters == null && second.DecimalParameters != null) ||
               (first.NumericParameters != null && second.NumericParameters == null) ||
               (first.NumericParameters == null && second.NumericParameters != null))
            {
                return false;
            }

            if (first.AlphaParameters != null && second.AlphaParameters != null)
            {
                if (first.AlphaParameters.Count != second.AlphaParameters.Count)
                {
                    return false;
                }

                var firstOrderedAlpha = (first.AlphaParameters ?? Enumerable.Empty<AlphaValue>()).OrderBy(_ => _ == null ? string.Empty : _.Value).ToArray();
                var secondOrderedAlpha = (second.AlphaParameters ?? Enumerable.Empty<AlphaValue>()).OrderBy(_ => _ == null ? string.Empty : _.Value).ToArray();
                for (int i = 0; i < first.AlphaParameters.Count; i++)
                {
                    var firstValue = firstOrderedAlpha[i];
                    var secondValue = secondOrderedAlpha[i];
                    if (!CompareAlpha(firstValue, secondValue))
                    {
                        return false;
                    }
                }
            }

            if (first.DecimalParameters != null && second.DecimalParameters != null)
            {
                if (first.DecimalParameters.Count != second.DecimalParameters.Count)
                {
                    return false;
                }

                for (int i = 0; i < first.DecimalParameters.Count; i++)
                {
                    var firstValue = first.DecimalParameters[i];
                    var secondValue = second.DecimalParameters[i];
                    if (!CompareDecimal(firstValue, secondValue))
                    {
                        return false;
                    }
                }
            }

            if (first.NumericParameters != null && second.NumericParameters != null)
            {
                IEnumerable<Pairs<NumericValue>> parameters;
                if (!JoinedEnumerable(first.NumericParameters, second.NumericParameters, out parameters))
                {
                    return false;
                }

                foreach (var parameter in parameters)
                {
                    if (!CompareNumeric(parameter.First, parameter.Second))
                    {
                        return false;
                    }
                }

                if (first.NumericParameters.Count != second.NumericParameters.Count)
                {
                    return false;
                }

                for (int i = 0; i < first.NumericParameters.Count; i++)
                {
                    var firstValue = first.NumericParameters[i];
                    var secondValue = second.NumericParameters[i];
                    if (!CompareNumeric(firstValue, secondValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Compares the alpha.
        /// </summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>the value</returns>
        private static bool CompareAlpha(AlphaValue first, AlphaValue second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.Value != second.Value)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the decimal.
        /// </summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>the value</returns>
        private static bool CompareDecimal(DecimalValue first, DecimalValue second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.Value != second.Value)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the exception step.
        /// </summary>
        /// <param name="first">The first step.</param>
        /// <param name="second">The second step.</param>
        /// <returns>the value</returns>
        private static bool CompareExceptionStep(ExceptionStep first, ExceptionStep second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.Index != second.Index)
            {
                return false;
            }

            if (first.ExceptionId != second.ExceptionId)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the numeric.
        /// </summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>the value</returns>
        private static bool CompareNumeric(NumericValue first, NumericValue second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first != null && second == null) || (first == null && second != null))
            {
                return false;
            }

            if (first.Value != second.Value)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// the class
        /// </summary>
        /// <typeparam name="T">the type parameter</typeparam>
        internal class Pairs<T>
        {
            /// <summary>
            /// Gets or sets the first.
            /// </summary>
            /// <value>
            /// The first.
            /// </value>
            public T First { get; set; }

            /// <summary>
            /// Gets or sets the second.
            /// </summary>
            /// <value>
            /// The second.
            /// </value>
            public T Second { get; set; }
        }
    }
}