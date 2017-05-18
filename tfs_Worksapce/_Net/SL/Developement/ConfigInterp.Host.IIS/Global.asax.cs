// ----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Host.IIS
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Practices.Unity;
    using Unity;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// The lazy container
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Legacy code")]
        private static readonly Lazy<IUnityContainer> _lazyContainer = new Lazy<IUnityContainer>(CreateContainer);

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IUnityContainer Container
        {
            get { return _lazyContainer.Value; }
        }

        /// <summary>
        /// Handles the End event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_End(object sender, EventArgs e)
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            if (Container != null)
            {
            }
        }

        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <returns>the value</returns>
        private static IUnityContainer CreateContainer()
        {
            var con = new UnityContainer();
            Bootstrapper.Configure(con);
            return con;
        }
    }
}