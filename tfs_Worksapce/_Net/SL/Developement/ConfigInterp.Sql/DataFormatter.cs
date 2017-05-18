// ----------------------------------------------------------------------
// <copyright file="DataFormatter.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    /// <summary>
    /// the class
    /// </summary>
    internal class DataFormatter
    {
        /// <summary>
        /// Constant used in building pseudo code
        /// </summary>
        private const string KeywordPrefix = "KWD";

        /// <summary>
        /// This routine formats the Pseudo code from the query return
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>the value</returns>
        public static string CreatePseudoCode(string description, string id)
        {
            if (id.Length == 11)
            {
                var returnValue = string.Format("({0}{1}/{2})", KeywordPrefix, description, id.Substring(id.Length - 2, 2));
                return returnValue;
            }

            if (id.Length == 10)
            {
                var returnValue = string.Format("({0}{1}/0{2})", KeywordPrefix, description, id.Substring(id.Length - 1, 1));
                return returnValue;
            }

            if (id.Length > 9)
            {
                var returnValue = string.Format("({0}{1}/{2})", KeywordPrefix, description, id.Substring(9, id.Length - 9));
                return returnValue;
            }

            var defaultValue = "error";
            return defaultValue;
        }

        /// <summary>
        /// This routine formats the Field ID
        /// </summary>
        /// <param name="fieldId">the query version of a field ID</param>
        /// <returns>correctly formatted Field ID</returns>
        public static string FormatFieldId(string fieldId)
        {
            var tempString = fieldId.Remove(0, 6);
            var tempSubCategory = string.Format("0{0}", tempString.Substring(0, 3));
            if (tempString.Length == 4)
            {
                var tempVersion = string.Format("000{0}", tempString.Substring(3, 1));
                var returnValue = tempSubCategory + tempVersion;
                return returnValue;
            }

            if (tempString.Length == 5)
            {
                var tempVersion = string.Format("00{0}", tempString.Substring(3, 2));
                var returnValue = tempSubCategory + tempVersion;
                return returnValue;
            }

            if (tempString.Length == 6)
            {
                var tempVersion = string.Format("0{0}", tempString.Substring(3, 3));
                var returnValue = tempSubCategory + tempVersion;
                return returnValue;
            }

            var defaultReturnValue = tempSubCategory + tempString;
            return defaultReturnValue;
        }
    }
}