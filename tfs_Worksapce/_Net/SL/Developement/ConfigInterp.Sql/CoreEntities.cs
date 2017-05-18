// ----------------------------------------------------------------------
// <copyright file="CoreEntities.cs" company="CoreLink">
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
    public partial class CoreEntities
    { 
        /// <summary>
        /// Initializes static members of the <see cref="CoreEntities"/> class.
        /// </summary>
        /// <exception cref="System.Exception">Do not remove, ensures static reference to System.Data.Entity.SqlServer</exception>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        static CoreEntities()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
            {
                //// ReSharper disable once UnthrowableException
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreEntities"/> class.
        /// </summary>
        /// <param name="connectionString">connection string</param>
        public CoreEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}