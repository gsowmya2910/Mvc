// ----------------------------------------------------------------------
// <copyright file="ObjectExtensions.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    using System;

    /// <summary>
    /// the class
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// To the int16.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the value</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public static short ToInt16(this object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }

            return Convert.ToInt16(value);
        }
    }
}