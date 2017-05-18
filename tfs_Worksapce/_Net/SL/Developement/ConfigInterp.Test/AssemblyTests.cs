// ----------------------------------------------------------------------
// <copyright file="AssemblyTests.cs" company="CoreLink">
//        Copyright © CoreLink 2017. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// the class
    /// </summary>
    [TestClass]
    public class AssemblyTests
    {
        /// <summary>
        /// Checks the contracts are all attributed.
        /// </summary>
        [TestMethod]
        public void CheckContractsAreAllAttributed()
        {
            var assembly = typeof(IConfigInterpService).Assembly;
            var allTypes = assembly.GetTypes();

            var filter = new[] { typeof(Attribute), typeof(Enum) };

            var exclusions = new[] { typeof(ServiceNamespaces) };

            var filtered = allTypes
                .Where(_ => exclusions.All(exclusion => exclusion != _))
                .Where(_ => !filter.Any(f => f.IsAssignableFrom(_)))
                .ToArray();

            Assert.IsTrue(filtered.Any());

            var classAttributes = new[] { typeof(DataContractAttribute), typeof(MessageContractAttribute), typeof(ServiceContractAttribute) };
            var propAttributes = new[] { typeof(OperationContractAttribute), typeof(MessageHeaderAttribute), typeof(MessageBodyMemberAttribute), typeof(DataMemberAttribute) };
            var list = new List<Tuple<Type, PropertyInfo>>();
            foreach (var type in filtered)
            {
                var currentClassAttributes = type.GetCustomAttributes(false).OfType<Attribute>().ToArray();
                if (!currentClassAttributes.Select(_ => _.GetType()).Any(_ => classAttributes.Any(att => att == _)))
                {
                    list.Add(new Tuple<Type, PropertyInfo>(type, null));
                }

                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    var currentPropAttributes = property.GetCustomAttributes(false).OfType<Attribute>().ToArray();
                    if (!currentPropAttributes.Select(_ => _.GetType()).Any(_ => propAttributes.Any(att => att == _)))
                    {
                        list.Add(new Tuple<Type, PropertyInfo>(type, property));
                    }
                }
            }

            Assert.IsFalse(list.Any(), GenerateMessage(list));
        }

        /// <summary>
        /// Generates the message.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>
        /// the value
        /// </returns>
        private static string GenerateMessage(List<Tuple<Type, PropertyInfo>> list)
        {
            var sb = new StringBuilder(Environment.NewLine);

            foreach (var tuple in list)
            {
                sb.AppendFormat("Class {0} is missing attribute", tuple.Item1.FullName);
                if (tuple.Item2 == null)
                {
                    sb.AppendLine();
                }
                else
                {
                    sb.AppendLine(string.Format(" on Property {0}", tuple.Item2.Name))
                        .AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}