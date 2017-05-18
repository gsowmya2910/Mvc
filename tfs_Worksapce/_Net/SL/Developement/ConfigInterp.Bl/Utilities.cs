// ----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------

namespace ConfigInterp.Bl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Contracts.DataContracts;

    /// <summary>
    /// The class
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Batches the specified size.
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="size">The size.</param>
        /// <returns>the value</returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
        {
            T[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                {
                    bucket = new T[size];
                }

                bucket[count++] = item;

                if (count != size)
                {
                    continue;
                }

                yield return bucket.Select(x => x);

                bucket = null;
                count = 0;
            }

            // Return the last bucket with all remaining elements
            if (bucket != null && count > 0)
            {
                yield return bucket.Take(count);
            }
        }

        /// <summary>
        /// enum to array of explicit values.
        /// </summary>
        /// <typeparam name="T">type of enum</typeparam>
        /// <returns>
        /// The value
        /// </returns>
        /// <exception cref="System.ArgumentException">When <see cref="T" /> is not an enum</exception>
        public static T[] ExplicitValues<T>() where T : IComparable, IFormattable, IConvertible
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("Type is not an enum. Type provided {0}", type.AssemblyQualifiedName));
            }

            var result = Enum.GetValues(type).OfType<T>().ToArray();
            return result;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>the value</returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        /// <summary>
        /// Gets the description value.
        /// </summary>
        /// <param name="value">The input enum value.</param>
        /// <returns>the value</returns>
        public static string GetDescriptionValue(this Enum value)
        {
            var att = value.GetAttribute<DescriptionAttribute>();
            if (att != null)
            {
                return att.Description;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <typeparam name="T">the collection type</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>the value</returns>
        public static IEnumerable<LinkedListNode<T>> GetNodes<T>(this LinkedList<T> source)
        {
            var current = source.First;

            if (current != null)
            {
                do
                {
                    yield return current;
                    current = current.Next;
                }
                while (current != null);
            }
        }

        /// <summary>
        /// Gets the only number.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the value</returns>
        public static short GetOnlyNumber(string value)
        {
            var cleaned = Regex.Replace(value, "[^0-9]", string.Empty);
            short retValue;
            if (short.TryParse(cleaned, out retValue))
            {
                return retValue;
            }

            return 0;
        }

        /// <summary>
        /// Gets the public properties.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>the value</returns>
        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var propertyInfos = new List<PropertyInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface))
                        {
                            continue;
                        }

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var typeProperties = subType.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);

                    var newPropertyInfos = typeProperties.Where(x => !propertyInfos.Contains(x)).ToArray();

                    propertyInfos.AddRange(newPropertyInfos);
                }

                return propertyInfos.ToArray();
            }

            return type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Narratives the type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the value</returns>
        public static short NarrativeType(this LineOfBusiness value)
        {
            var attribute = value.GetAttribute<NarrativeTypeAttribute>();
            return attribute == null ? (short)0 : attribute.Narrative;
        }
    }
}