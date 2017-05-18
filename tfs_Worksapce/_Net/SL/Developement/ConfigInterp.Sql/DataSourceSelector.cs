// ----------------------------------------------------------------------
// <copyright file="DataSourceSelector.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    /// <summary>
    /// the class
    /// </summary>
    internal class DataSourceSelector
    {
        /// <summary>
        /// Keywords, type 5, get data from a different table
        /// </summary>
        public const int FieldTypeKeyword = 5;

        /// <summary>
        /// Uses the common database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the value</returns>
        public static bool UseCommonDatabase(int id)
        {
            return id == FieldTypeKeyword;
        }
    }
}