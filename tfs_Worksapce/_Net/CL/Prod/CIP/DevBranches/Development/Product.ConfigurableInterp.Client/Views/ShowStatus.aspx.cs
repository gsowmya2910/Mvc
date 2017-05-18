// ----------------------------------------------------------------------
// <copyright file="ShowStatus.aspx.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace Product.ConfigurableInterp.Client.Views
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ShowStatus : Page
    {
        /// <summary>
        /// Logic to execute when the page loads
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var currentUser = Membership.GetUser();
                this.currentUserDisplay.InnerText = string.Format(CultureInfo.CurrentCulture, "Welcome: {0}", currentUser != null ? currentUser.UserName : string.Empty);
                this.RolesBulletedList.DataSource = Roles.GetRolesForUser();
                this.RolesBulletedList.DataBind();
            }
            catch (Exception ex)
            {
                this.Response.Write(string.Format(CultureInfo.CurrentCulture, "<h1>Membership Error: {0}</h1>", ex.Message));
            }

            this.SetGridViewDataStorce(this.ApplicationGridView, this.Application);
            this.SetGridViewDataStorce(this.SessionGridView, this.Session);
            this.SetGridViewDataStorce(this.ServerVariablesGridView, this.Request.ServerVariables);
            this.SetGridViewDataStorce(this.RequestFormGridView, this.Request.Form);
            this.SetGridViewDataStorce(this.RequestQueryStringGridView, this.Request.QueryString);
        }

        /// <summary>
        /// Binds a GridView object to a HttpApplicationState
        /// </summary>
        /// <param name="gridView">The GridView object to bind.</param>
        /// <param name="application">The HttpApplicationState for the DataSource</param>
        private void SetGridViewDataStorce(GridView gridView, HttpApplicationState application)
        {
            var dictionary = this.ToDictionary(application);
            this.SetGridViewDataStorce(gridView, dictionary);
        }

        /// <summary>
        /// Binds a GridView object to a HttpSessionState
        /// </summary>
        /// <param name="gridView">The GridView object to bind.</param>
        /// <param name="session">The HttpSessionState for the DataSource</param>
        private void SetGridViewDataStorce(GridView gridView, HttpSessionState session)
        {
            var dictionary = this.ToDictionary(session);
            this.SetGridViewDataStorce(gridView, dictionary);
        }

        /// <summary>
        /// Binds a GridView object to a NameValueCollection
        /// </summary>
        /// <param name="gridView">The GridView object to bind.</param>
        /// <param name="collection">The NameValueCollection for the DataSource</param>
        private void SetGridViewDataStorce(GridView gridView, NameValueCollection collection)
        {
            var dictionary = this.ToDictionary(collection);
            this.SetGridViewDataStorce(gridView, dictionary);
        }

        /// <summary>
        /// Binds a GridView object to a dictionary
        /// </summary>
        /// <param name="gridView">The GridView object to bind.</param>
        /// <param name="dictionary">The Dictionary for the DataSource</param>
        private void SetGridViewDataStorce(GridView gridView, Dictionary<string, string> dictionary)
        {
            if (dictionary != null)
            {
                gridView.DataSource = from item in dictionary
                                      select new { item.Key, item.Value };
                gridView.DataBind();
            }
        }

        /// <summary>
        /// Builds a Dictionary object from HttpSessionState
        /// </summary>
        /// <param name="session">The HttpSessionState.</param>
        /// <returns>Dictionary object created from HttpSessionState</returns>
        private Dictionary<string, string> ToDictionary(HttpSessionState session)
        {
            var temp = new Dictionary<string, string>();
            temp.Add("SessionID", session.SessionID);
            temp.Add("LCID", Convert.ToString(session.LCID, CultureInfo.CurrentCulture));
            temp.Add("Count", Convert.ToString(session.Count, CultureInfo.CurrentCulture));
            temp.Add("Mode", session.Mode.ToString());
            temp.Add("IsCookieless", session.IsCookieless.ToString());
            temp.Add("Timeout", Convert.ToString(session.Timeout, CultureInfo.CurrentCulture));
            foreach (string key in session.Keys)
            {
                temp.Add(key, session[key] == null ? " " : session[key].ToString());
            }

            return temp;
        }

        /// <summary>
        /// Builds a Dictionary object from HttpApplicationState
        /// </summary>
        /// <param name="application">The HttpApplicationState.</param>
        /// <returns>Dictionary object created from HttpApplicationState</returns>
        private Dictionary<string, string> ToDictionary(HttpApplicationState application)
        {
            var temp = new Dictionary<string, string>();
            temp.Add("Count", Convert.ToString(application.Count, CultureInfo.CurrentCulture));
            foreach (string key in application.Keys)
            {
                temp.Add(key, application[key] == null ? " " : application[key].ToString());
            }

            return temp;
        }

        /// <summary>
        /// Builds a Dictionary object from NameValueCollection
        /// </summary>
        /// <param name="collection">The NameValueCollection.</param>
        /// <returns>Dictionary object created from NameValueCollection</returns>
        private Dictionary<string, string> ToDictionary(NameValueCollection collection)
        {
            var temp = new Dictionary<string, string>();
            foreach (string key in collection)
            {
                try
                {
                    temp.Add(key ?? "n/a", collection[key] ?? " ");
                }
                catch (Exception ex)
                {
                    temp.Add(key ?? "n/a", ex.Message);
                }
            }

            return temp;
        }
    }
}