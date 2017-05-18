// ----------------------------------------------------------------------
// <copyright file="StepConverterTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System.Diagnostics.CodeAnalysis;
    using Bl;
    using Bl.Interfaces;
    using Contracts.DataContracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]

    public class StepConverterTests
    {
        /// <summary>
        /// Converts the steps test.
        /// </summary>
        [TestMethod]
        public void ConvertStepsTest()
        {
            IStepDataMap map = new TestMap { ActionActualParameterCount = 0, ActionFalseCount = 0, ActionId = 0, ActionParameterAlpha = string.Empty, ActionParameterDecimal = 0, ActionParameterNumeric = 0, ActionParameterSequence = 0, ActionSequence = 0, ActionTrueCount = 0, ActionType = 0, AlphaValue = string.Empty, AlphaValueThru = string.Empty, ConditionCompareToFieldNumber = 0, ConditionCompareToFieldType = 0, ConditionCompareToQualifier = 0, ConditionCount = 0, ConditionRangeUse = 0, DecimalValue = 0, DecimalValueThru = 0, ExceptionId = 0, GenericCompareType = CompareType.Equals, GenericConditionOperation = 0, GenericConditionSequence = 0, GenericFieldNumber = 0, GenericFieldQualifier = 0, GenericFieldType = 0, NumericValue = 0, NumericValueThru = 0, StepId = 0, StepType = 0, RecordType = RecordType.Action };
            Assert.IsNotNull(map);
        }
    }
}