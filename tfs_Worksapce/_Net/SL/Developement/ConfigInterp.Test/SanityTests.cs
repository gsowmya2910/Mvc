// ----------------------------------------------------------------------
// <copyright file="SanityTests.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using Bl;
    using Bl.Inquire;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The Object
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SanityTests
    {
        /// <summary>
        /// the enum
        /// </summary>
        private enum DirtyEnum
        {
            /// <summary>
            /// The no value
            /// </summary>
            NoValue = 0,

            /// <summary>
            /// The has value
            /// </summary>
            HasValue = 1
        }

        /// <summary>
        /// Behaviors the of linked lists are interesting tests.
        /// </summary>
        [TestMethod]
        public void BehaviorsOfLinkedListsAreInterestingTests()
        {
            var list = new LinkedList<DirtyClass>();
            list.AddLast(new DirtyClass { IntValue = 2 });
            list.AddLast(new DirtyClass { IntValue = 3 });
            list.AddLast(new DirtyClass { IntValue = 3 });
            var found = false;
            foreach (var node in list.GetNodes())
            {
                if (node.Next != null && node.Value.IntValue == node.Next.Value.IntValue)
                {
                    found = true;
                }
            }

            Assert.IsTrue(found);
        }

        /// <summary>
        /// Checks date format requirements
        /// </summary>
        [TestMethod]
        public void CheckDateConversionFormatTest()
        {
            var text = "20160930151515";
            var format = "yyyyMMddHHmmss";

            DateTime parse;
            var success = DateTime.TryParseExact(text, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out parse);
            Assert.IsTrue(success);

            Assert.AreEqual(format, InquireDataResultBase.DateTimeFormat);
        }

        /// <summary>
        /// Data the type compatibility test.
        /// </summary>
        [TestMethod]
        public void DataTypeCompatibilityTest()
        {
            long value = 111111111111;

            decimal asDecimal = value;

            long backToLong = (long)asDecimal;

            Assert.AreEqual(value, backToLong);
        }

        /// <summary>
        /// Checks null-able compatibility
        /// </summary>
        [TestMethod]
        public void DateTimeNullableCanCastNull()
        {
            DateTime? val = DateTime.Now;
            Assert.IsTrue(val.HasValue);
            // ReSharper disable once RedundantCast
            val = (DateTime?)null;
            Assert.IsFalse(val.HasValue);
        }

        /// <summary>
        /// Enum the properties through reflection are convertible to underlying value.
        /// </summary>
        [TestMethod]
        public void EnumPropertiesThroughReflectionAreConvertibleToUnderlyingValue()
        {
            var obj1 = new HasEnumPropery { Enum = DirtyEnum.HasValue };
            var obj2 = new HasEnumPropery { Enum = DirtyEnum.NoValue };
            var prop = typeof(HasEnumPropery).GetProperties().First();

            var value1 = prop.GetValue(obj1, null);
            var value2 = prop.GetValue(obj2, null);

            int converted1 = (int)value1;
            int converted2 = (int)value2;
            Assert.AreNotEqual(converted2, converted1);
            Assert.AreEqual(obj1.Enum, DirtyEnum.HasValue);
        }

        /// <summary>
        /// Implementation the still matters test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ImplementationStillMattersTest()
        {
            IList list = new List<string>();
            list.Add(1);
            Assert.IsFalse(list.OfType<string>().Any());
        }

        /// <summary>
        /// Reflections the types assignable direction test.
        /// </summary>
        [TestMethod]
        public void ReflectionTypesAssignableDirectionTest()
        {
            var objType = typeof(object);
            var stringType = typeof(string);

            Assert.IsTrue(objType.IsAssignableFrom(stringType));
            Assert.IsFalse(stringType.IsAssignableFrom(objType));
        }

        /// <summary>
        /// Structs the are safe copies test.
        /// </summary>
        [TestMethod]
        public void StructsAreSafeCopiesTest()
        {
            var source = new DirtyStruct();

            var target = source;
            target.IntValue = 5;
            Assert.AreEqual(source.IntValue, 0);
        }

        /// <summary>
        /// the class
        /// </summary>
        private struct DirtyStruct
        {
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>
            /// The value.
            /// </value>
            public int IntValue { get; set; }
        }

        /// <summary>
        /// the class
        /// </summary>
        private class DirtyClass
        {
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>
            /// The value.
            /// </value>
            public int IntValue { get; set; }
        }

        /// <summary>
        /// the class
        /// </summary>
        private class HasEnumPropery
        {
            /// <summary>
            /// Gets or sets the enum.
            /// </summary>
            /// <value>
            /// The enum.
            /// </value>
            public DirtyEnum Enum { get; set; }
        }
    }
}