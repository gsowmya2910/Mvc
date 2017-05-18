// ----------------------------------------------------------------------
// <copyright file="UsesConnectionStringsBase.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// the class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class UsesConnectionStringsBase
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="name">connection name</param>
        /// <returns>Connection String</returns>
        /// <exception cref="ConfigurationErrorsException">when Connection String is not found</exception>
        internal static string GetConnectionString(string name)
        {
            var setting = ConfigurationManager.ConnectionStrings[name];
            if (setting == null)
            {
                //// ReSharper disable once UnthrowableException
                throw new ConfigurationErrorsException(string.Format("The Connection String '{0}' Cannot Be Found", name));
            }

            return setting.ConnectionString;
        }
    }
}