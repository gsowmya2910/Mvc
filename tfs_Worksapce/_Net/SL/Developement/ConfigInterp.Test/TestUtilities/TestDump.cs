// ----------------------------------------------------------------------
// <copyright file="TestDump.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Test.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Bl;
    using Bl.Interfaces;
    using Bl.Update;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// the class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TestDump
    {
        /// <summary>
        /// Outputs the data CSV.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="name">The name.</param>
        public static void OutputDataCsv(IEnumerable<IStepDataMap> result, string name)
        {
            var dataTable = new DataTable();
            var properties = typeof(IStepDataMap).GetProperties();
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name);
            }

            foreach (var step in result)
            {
                var row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(step, null);
                }

                dataTable.Rows.Add(row);
            }

            var outputText = DataTableToCsv(dataTable, ',');
            var path = ReadyAndGetTestFilePath();

            var fullPath = Path.Combine(path, name + ".csv");
            File.WriteAllText(fullPath, outputText);
            Assert.IsTrue(File.Exists(fullPath));
        }

        /// <summary>
        /// Outputs the data CSV.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="name">The name.</param>
        public static void OutputDataCsv(IUpdateInterp input, string name)
        {
            var properties = typeof(IUpdateInterp).GetPublicProperties();

            var sb = new StringBuilder();
            var names = new List<string>();
            var values = new List<string>();
            foreach (var property in properties)
            {
                names.Add(property.Name);
                if (property.PropertyType.IsEnum)
                {
                    var obj = property.GetValue(input, null);
                    int val = Convert.ToInt32(obj);
                    values.Add(string.Format("{0}:{1}", obj, val));
                }
                else
                {
                    values.Add(string.Format("{0}", property.GetValue(input, null)));
                }
            }

            sb.AppendLine(string.Join(",", names));
            sb.AppendLine(string.Join(",", values));

            sb.AppendLine();
            sb.AppendLine();

            var stepProperties = typeof(IStepDataMap).GetProperties();
            sb.AppendLine(string.Join(",", stepProperties.Select(_ => _.Name)));
            foreach (var step in input.Steps)
            {
                var stepValues = new List<string>();

                foreach (var property in stepProperties)
                {
                    if (property.PropertyType.IsEnum)
                    {
                        var obj = property.GetValue(step, null);

                        int val = Convert.ToInt32(obj);

                        stepValues.Add(string.Format("{0}:{1}", obj, val));
                    }
                    else
                    {
                        stepValues.Add(string.Format("{0}", property.GetValue(step, null)));
                    }
                }

                sb.AppendLine(string.Join(",", stepValues));
            }

            var path = ReadyAndGetTestFilePath();

            var fullPath = Path.Combine(path, name + ".csv");
            File.WriteAllText(fullPath, sb.ToString());
            Assert.IsTrue(File.Exists(fullPath));
        }

        /// <summary>
        /// Outputs the data objects.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="name">The name.</param>
        public static void OutputDataObjects(IEnumerable<IStepDataMap> result, string name)
        {
            var lines = new List<string>();

            var properties = typeof(IStepDataMap).GetProperties();

            foreach (var step in result)
            {
                var sb = new StringBuilder("new StepConverterTests.TestMap{");
                foreach (var property in properties)
                {
                    if (property.PropertyType.IsEnum)
                    {
                        sb.AppendFormat("{0} = {1}.{2}", property.Name, property.PropertyType.Name, property.GetValue(step, null));
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        sb.AppendFormat("{0} = \"{1}\"", property.Name, property.GetValue(step, null));
                    }
                    else
                    {
                        sb.AppendFormat("{0} = {1}", property.Name, property.GetValue(step, null));
                    }

                    sb.Append(", ");
                }

                sb.Append("},");

                lines.Add(sb.ToString());
            }

            var path = ReadyAndGetTestFilePath();

            var fullPath = Path.Combine(path, name + ".txt");
            File.WriteAllLines(fullPath, lines);
            Assert.IsTrue(File.Exists(fullPath));
        }

        /// <summary>
        /// Data table to CSV.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>
        /// The value
        /// </returns>
        private static string DataTableToCsv(DataTable dataTable, char separator)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                sb.Append(dataTable.Columns[i]);
                if (i < dataTable.Columns.Count - 1)
                {
                    sb.Append(separator);
                }
            }

            sb.AppendLine();
            foreach (DataRow dr in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sb.Append(dr[i]);

                    if (i < dataTable.Columns.Count - 1)
                    {
                        sb.Append(separator);
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Readies the and get test file path.
        /// </summary>
        /// <returns>the value</returns>
        private static string ReadyAndGetTestFilePath()
        {
#if (LOCALDEVBUILD)
            var local = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
#else
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var local = Path.GetDirectoryName(assembly.Location);
#endif

            //// ReSharper disable once AssignNullToNotNullAttribute
            var path = Path.Combine(local, "TestFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}