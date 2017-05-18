//----------------------------------------------------------------
// <copyright file="Interp.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 
namespace Product.ConfigurableInterp.Client.Models
{
    #region references
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    #endregion references

    /// <summary>
    /// This Class represents Interp Structure
    /// </summary>
    public class Interp
    {
        /// <summary>
        /// Index counter for Action collection
        /// </summary>
        private int actionCounter = 0;

        /// <summary>
        /// Index counter for Condition collection
        /// </summary>
        private int conditionCounter = 0;

        /// <summary>
        /// Index counter for error collection
        /// </summary>
        private int errorCounter = 0;

        /// <summary>
        /// Condition data collection object
        /// </summary>
        private List<Condition> conditionsData;

        /// <summary>
        /// Action data collection object
        /// </summary>
        private List<Action> actionsData;

        /// <summary>
        /// Exception data collection object
        /// </summary>
        private List<InterpError> exceptionsData;

        /// <summary>
        /// Gets or sets Interp Id
        /// </summary>
        [Display(Name = "Interp Number")]
        public string InterpId { get; set; }

        /// <summary>
        /// Gets or sets Interp Status
        /// </summary>
        [Display(Name = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Interp Created User Name
        /// </summary>
        [Display(Name = "Owner")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Interp Created User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Created Date property
        /// </summary>
        [Display(Name = "Activated")]
        public string ActivatedDate { get; set; }

        /// <summary>
        /// Gets or sets Last Modified Date property
        /// </summary>
        [Display(Name = "Last Maintained")]
        public string MaintenanceDate { get; set; }

        /// <summary>
        /// Gets or sets Other Date property
        /// </summary>
        [Display(Name = "Other Timestamp")]
        public string OtherDate { get; set; }

        /// <summary>
        /// Gets or sets Outline
        /// </summary>
        [Display(Name = "Outline")]
        public string Outline { get; set; }

        /// <summary>
        /// Gets or sets Category
        /// </summary>
        [Display(Name = "Category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets Sub Category
        /// </summary>
        [Display(Name = "Sub Category")]
        public string Subcategory { get; set; }

        /// <summary>
        /// Gets or sets Level
        /// </summary>
        [Display(Name = "Level")]
        public string Level { get; set; }

        /// <summary>
        /// Gets Condition collection property
        /// </summary>        
        public ICollection<Condition> Conditions
        {
            get
            {
                return this.conditionsData;
            }
        }

        /// <summary>
        /// Gets Action collection property
        /// </summary>
        public ICollection<Action> Actions
        {
            get
            {
                return this.actionsData;
            }
        }

        /// <summary>
        /// Gets Interp Exception collection property
        /// </summary>
        public ICollection<InterpError> Exceptions
        {
            get
            {
                return this.exceptionsData;
            }
        }

        /// <summary>
        /// Gets Action object
        /// </summary>
        public Action ActionObject
        {
            get
            {
                List<Action> actions;
                if (this.Actions != null && this.Actions.Count > 0)
                {
                    actions = new List<Action>(this.Actions);
                    ActionType action =
                      actions.SelectMany(a => a.ActionTypes).FirstOrDefault(n => n.Name.ToLower() == "undefined");
                    if (action != null)
                    {
                        actions = actions.Where(a => a.ActionTypes.Remove(action)).ToList();
                    }
                }
                else
                {
                    actions = new List<Action>();
                }

                Action value = null;
                if (actions.Count > this.actionCounter)
                {
                    value = actions[this.actionCounter];
                }
                else
                {
                    value = new Action();
                }

                return value;
            }
        }

        /// <summary>
        /// Gets Condition object
        /// </summary>
        public Condition ConditionObject
        {
            get
            {
                List<Condition> conditions;
                if (this.Conditions != null && this.Conditions.Count > 0)
                {
                    conditions = new List<Condition>(this.Conditions);
                }
                else
                {
                    conditions = new List<Condition>();
                }

                Condition value = null;
                if (conditions.Count > this.conditionCounter)
                {
                    value = conditions[this.conditionCounter];
                }
                else
                {
                    value = new Condition();
                }

                return value;
            }
        }

        /// <summary>
        /// Gets Interp Error object
        /// </summary>
        public InterpError ErrorObject
        {
            get
            {
                List<InterpError> errors;
                if (this.Exceptions != null && this.Exceptions.Count > 0)
                {
                    errors = new List<InterpError>(this.Exceptions);
                }
                else
                {
                    errors = new List<InterpError>();
                }
                
                InterpError value = null;
                if (errors.Count > this.errorCounter)
                {
                    value = errors[this.errorCounter];
                }
                else
                {
                    value = new InterpError();
                }

                return value;
            }
        }

        /// <summary>
        /// Gets or sets Selected Result value from Drop down
        /// </summary>
        [Display(Name = "Exception Name")]
        public string SelectedException { get; set; }

        /// <summary>
        /// Gets MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> ExceptionsList
        {
            get
            {
                return new SelectList(this.Exceptions, "Id", "Name");
            }
        }

        /// <summary>
        /// Initialize Conditions collection object
        /// </summary>
        /// <param name="conditions">Condition collection object</param>
        public void SetConditions(ICollection<Condition> conditions)
        {
            this.conditionsData = new List<Condition>(conditions);
        }

        /// <summary>
        /// Initialize Actions collection object
        /// </summary>
        /// <param name="actions">Action collection object</param>
        public void SetActions(ICollection<Action> actions)
        {
            this.actionsData = new List<Action>(actions);
        }

        /// <summary>
        /// Initialize Exceptions collection object
        /// </summary>
        /// <param name="exceptions">Exception collection object</param>
        public void SetExceptions(ICollection<InterpError> exceptions)
        {
            this.exceptionsData = new List<InterpError>(exceptions);
        }

        /// <summary>
        /// Initialize the display sections of the Interp
        /// </summary>
        /// <param name="sections">The Interp Sections data</param>
        public void SetSections(InterpSections sections)
        {
            this.Outline = sections.OutlineDisplay;
            this.Category = sections.CategoryDisplay;
            this.Subcategory = sections.SubcategoryDisplay;
            this.Level = sections.LevelDisplay;
        }
    }
}