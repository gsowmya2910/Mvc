//----------------------------------------------------------------
// <copyright file="DashboardModel.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    #region references   
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using schemas.cri.corelinksolutions.com.product.schema.configurableinterp.v1;
    #endregion

    /// <summary>
    /// This class is used to hold Model data for Interp Dashboard
    /// </summary>
    public class DashboardModel
    {
        /// <summary>
        /// Interp Collection
        /// </summary>
        private List<Interp> interpId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardModel" /> class.
        /// </summary>
        public DashboardModel()
        {
            var interpIds = new List<string>() 
                                        { 
                                            "34-600-040-0995-23",
                                            "34-080-001-0007-23",
                                            "34-100-000-0146-23",
                                            "34-120-012-0100-23",
                                            "34-180-001-0014-23",
                                            "34-240-015-0001-23",
                                            "34-560-004-0007-23"
                                        };
            this.interpId = new List<Interp>();
            foreach (var item in interpIds)
            {
                this.interpId.Add(new Interp() { InterpId = item });
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardModel" /> class.
        /// </summary>
        /// <param name="data">Interp Data collection</param>
        public DashboardModel(InterpData[] data)
        {
            this.interpId = new List<Interp>();
            foreach (InterpData item in data)
            {
                this.interpId.Add(new Interp() { InterpId = item.InterpId, Status = item.Status, Username = item.EmployeeId });
            }
        }

        /// <summary>
        /// Gets New Interp object
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Method being claeed from View")]
        public NewInterpModel NewInterp 
        {
            get
            {
                return new NewInterpModel();
            }
        }

        /// <summary>
        /// Gets or sets Selected Interp Id
        /// </summary>
        [Display(Name = "Interp Number")]
        public string SelectedInterpId { get; set; }

        /// <summary>
        /// Gets Interp Ids
        /// </summary>
        public IEnumerable<SelectListItem> InterpIds 
        {
            get 
            {
                return new SelectList(this.interpId, "InterpId", "InterpId");
            }         
        }
    }    
}