// ----------------------------------------------------------------------
// <copyright file="KillSession.aspx.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace Product.ConfigurableInterp.Client.Views
{
    using System;
    using System.Globalization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class KillSession : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                short regionCode = short.Parse(this.Session["RegionCode"] == null ? "0" : this.Session["RegionCode"].ToString(), CultureInfo.CurrentCulture);
                this.RegionCode.Value = regionCode.ToString(CultureInfo.CurrentCulture);
                this.Session.Abandon();
            }
        }
    }
}