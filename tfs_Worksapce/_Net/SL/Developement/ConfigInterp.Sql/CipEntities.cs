// ----------------------------------------------------------------------
// <copyright file="CipEntities.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Sql
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    [ExcludeFromCodeCoverage]
    public partial class CipEntities
    {
        /// <summary>
        /// Initializes static members of the <see cref="CipEntities"/> class.
        /// </summary>
        /// <exception cref="System.Exception">Do not remove, ensures static reference to System.Data.Entity.SqlServer</exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        static CipEntities()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
            {
                //// ReSharper disable once UnthrowableException
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CipEntities"/> class.
        /// </summary>
        /// <param name="connectionString">connection string</param>
        public CipEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}