// ----------------------------------------------------------------------
// <copyright file="NumberInterpreter.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    /// <summary>
    /// the class
    /// </summary>
    public static class NumberInterpreter
    {
        /// <summary>
        /// Defaults the specified argument.
        /// </summary>
        /// <param name="input">The argument.</param>
        /// <returns>the value</returns>
        public static bool Default(DataResultBase input)
        {
            return input.MessageNumber == 0;
        }

        /// <summary>
        /// Specific Not Zero Message Number.
        /// </summary>
        /// <param name="input">The argument.</param>
        /// <param name="compareValue">The Compare Value</param>
        /// <returns>the value</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public static bool SpecificNotZeroMessageNumber(DataResultBase input, int compareValue)
        {
            return input.MessageNumber == compareValue;
        }
    }
}