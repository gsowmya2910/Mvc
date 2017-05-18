// ----------------------------------------------------------------------
// <copyright file="StepDataMapTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Bl.Inquire;
    using Bl.Interfaces;
    using CIPINQ01;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The class
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StepDataMapTests
    {
        /// <summary>
        /// Steps the data map call all properties test.
        /// </summary>
        [TestMethod]
        public void StepDataMapCallAllPropertiesTest()
        {
            var dataMap = new DataMapsOut
            {
                ActionParamsSeq = 1,
                ActionParamsDecimal = 1,
                ActionParamsNumeric = 1,
                ActionActualParamCount = 1,
                ActionParamsAlpha = "alpha",
                ActionFalseCount = 1,
                ActionID = 1,
                ActionSequence = 1,
                ActionTrueCount = 1,
                ActionType = 1,
                AlphaValue = "value",
                AlphaValueThru = "value",
                ConditionCompareToFieldNum = 1,
                ConditionCompareToFieldType = 1,
                ConditionCompareToQualifier = 1,
                ConditionCount = 1,
                ConditionRangeUse = 1,
                DecimalValue = 1,
                DecimalValueThru = 1,
                ExceptionID = 1,
                GenericCompType = 1,
                GenericConditionLevel1 = 1,
                GenericConditionLevel2 = 1,
                GenericFieldNum = 1,
                GenericFieldQualifier = 1,
                GenericFieldType = 1,
                NumericValue = 1,
                NumericValueThru = 1,
                RecordType = 1,
                StepID = 1,
                StepType = 1,
                ValueType = 1
            };
            IStepDataMap stepData = new StepDataMap(dataMap);

            Assert.IsNotNull(stepData);

            var properties = typeof(IStepDataMap).GetProperties(
                           BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            foreach (var property in properties)
            {
                property.GetValue(stepData, null);
            }
        }
    }
}