//----------------------------------------------------------------
// <copyright file="Action.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Models
{
    #region references
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// This class will hold Action structure
    /// </summary>
    public class Action
    {
        /// <summary>
        /// Result Data collection object
        /// </summary>
        private List<Result> resultsData;

        /// <summary>
        /// Action Types Data collection object
        /// </summary>
        private List<ActionType> actionTypesData;

        /// <summary>
        /// Action Name Data collection object
        /// </summary>
        private List<ActionName> actionNameData;

        /// <summary>
        /// Gets or sets Step Number of the Action
        /// </summary>
        public int StepNumber { get; set; }

        /// <summary>
        /// Gets or sets Action Order Number within the step
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets selected action id within the step
        /// </summary>
        public int SelectedActionId { get; set; }

        /// <summary>
        /// Gets Result Collection property
        /// </summary>
        public ICollection<Result> Results 
        { 
            get 
            { 
                return this.resultsData; 
            } 
        }
        
        /// <summary>
        /// Gets Action Type collection property
        /// </summary>
        public ICollection<ActionType> ActionTypes 
        { 
            get 
            { 
                return this.actionTypesData; 
            } 
        }
        
        /// <summary>
        /// Gets Action Name collection property
        /// </summary>
        public ICollection<ActionName> ActionNames 
        { 
            get 
            { 
                return this.actionNameData; 
            } 
        }
        
        /// <summary>
        /// Gets or sets Parameter 1 Property
        /// </summary>
         [Display(Name = "[Param 1 label]")]
        public string Parameter1 { get; set; }
        
        /// <summary>
         /// Gets or sets Parameter 2 Property
        /// </summary>
        [Display(Name = "[Param 2 label]")]
        public string Parameter2 { get; set; }
        
        /// <summary>
        /// Gets or sets Parameter 3 Property
        /// </summary>
        [Display(Name = "[Param 3 label]")]
        public string Parameter3 { get; set; }
        
        /// <summary>
        /// Gets or sets Parameter 4 Property
        /// </summary>
        [Display(Name = "[Param 4 label]")]
        public string Parameter4 { get; set; }
        
        /// <summary>
        /// Gets or sets Parameter 5 Property
        /// </summary>
        [Display(Name = "[Param 5 label]")]
        public string Parameter5 { get; set; }

        /// <summary>
        /// Gets or sets Selected Result value from Drop down
        /// </summary>
        [Display(Name = "Result")]
        public string SelectedResult { get; set; }

        /// <summary>
        /// Gets Result MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> ResultsList
        {
            get
            {
                return new SelectList(this.Results, "Id", "Name");
            }
        }

        /// <summary>
        /// Gets or sets Selected Action Type value from Drop down
        /// </summary>
        [Display(Name = "Action Type")]
        public string SelectedActionType { get; set; }

        /// <summary>
        /// Gets Action Type MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> ActionTypesList
        {
            get
            {
                return new SelectList(this.ActionTypes, "Id", "Name");
            }
        }

        /// <summary>
        /// Gets or sets Selected Action Name value from Drop down
        /// </summary>
        [Display(Name = "Action Name")]
        public string SelectedActionName { get; set; }

        /// <summary>
        /// Gets Action Name MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> ActionNamesList
        {
            get
            {
                return new SelectList(this.ActionNames, "Id", "Name");
            }
        }

        /// <summary>
        /// Set Result collection object
        /// </summary>
        /// <param name="results">Result collection object</param>
        public void SetResults(ICollection<Result> results)
        {
            this.resultsData = new List<Result>(results);
        }

        /// <summary>
        /// Set Action Type collection object
        /// </summary>
        /// <param name="actionType">Action Type collection object</param>
        public void SetActionType(ICollection<ActionType> actionType)
        {
            this.actionTypesData = new List<ActionType>(actionType);
        }

        /// <summary>
        /// Set Action Name collection object
        /// </summary>
        /// <param name="actionName">Action Name collection object</param>
        public void SetActionNames(ICollection<ActionName> actionName)
        {
            this.actionNameData = new List<ActionName>(actionName);
        }
    } 
}