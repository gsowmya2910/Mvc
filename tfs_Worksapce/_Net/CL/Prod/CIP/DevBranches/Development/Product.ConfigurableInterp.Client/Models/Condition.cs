//----------------------------------------------------------------
// <copyright file="Condition.cs" company="CoreLink">
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
    /// This class will hold Condition structure
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Condition type collection object
        /// </summary>
        private List<ConditionType> conditionTypesData;

        /// <summary>
        /// Field type collection object
        /// </summary>
        private List<FieldType> fieldTypesData;

        /// <summary>
        /// Field name collection object
        /// </summary>
        private List<Fieldname> fieldNamesData;

        /// <summary>
        /// Compare type collection object
        /// </summary>
        private List<CompareType> compareTypesData;

        /// <summary>
        /// Gets or sets Step Number of the Condition
        /// </summary>
        public int StepNumber { get; set; }

        /// <summary>
        /// Gets or sets parameter type value
        /// </summary>
        public string ParameterType { get; set; }

        /// <summary>
        /// Gets or sets Condition Order Number within the step
        /// </summary>
        public int Order { get; set; }

       /// <summary>
       /// Gets or sets alpha parameters list
       /// </summary>
        public List<AlphaParameters> AlphaParametersList { get; set; }

        /// <summary>
        /// Gets or sets decimal parameters list
        /// </summary>
        public List<DecimalParameters> DecimalParametersList { get; set; }

        /// <summary>
        /// Gets or sets numeric parameters list
        /// </summary>
        public List<NumericParameters> NumericParametersList { get; set; }

        /// <summary>
        /// Gets Condition Type collection property
        /// </summary>
        public ICollection<ConditionType> ConditionTypes 
        { 
            get 
            { 
                return this.conditionTypesData; 
            } 
        }
        
        /// <summary>
        /// Gets Field Type collection property
        /// </summary>
        public ICollection<FieldType> FieldTypes 
        { 
            get 
            { 
                return this.fieldTypesData; 
            } 
        }
        
        /// <summary>
        /// Gets Field Name collection property
        /// </summary>
        public ICollection<Fieldname> Fieldnames 
        { 
            get 
            { 
                return this.fieldNamesData; 
            } 
        }
        
        /// <summary>
        /// Gets Compare Type collection property
        /// </summary>
        public ICollection<CompareType> CompareTypes 
        { 
            get 
            { 
                return this.compareTypesData; 
            } 
        }
        
        /// <summary>
        /// Gets or sets Compare Values property
        /// </summary>
        [Display(Name = "Compare Values")]
        public string CompareValues { get; set; }

        /// <summary>
        /// Gets or sets Selected Condition Type value from Drop down
        /// </summary>
        [Display(Name = "Condition Type")]
        public string SelectedConditionType { get; set; }
        
        /// <summary>
        /// Gets Condition Type MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> ConditionTypesList
        {
            get
            {
                return new SelectList(this.ConditionTypes, "Id", "Name");
            }
        }

        /// <summary>
        /// Gets or sets Selected Field Type value from Drop down
        /// </summary>
        [Display(Name = "Field Type")]
        public string SelectedFieldType { get; set; }
        
        /// <summary>
        /// Gets Field Type MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> FieldTypesList
        {
            get
            {
                return new SelectList(new List<FieldType>(this.FieldTypes), "Id", "Name").OrderBy(x => x.Text);
            }
        }

        /// <summary>
        /// Gets or sets Selected Field Name value from Drop down
        /// </summary>
        [Display(Name = "Field Name")]
        public string SelectedFieldName { get; set; }

        /// <summary>
        /// Gets or sets selected field value from Drop Down List
        /// </summary>
        public int SelectedFieldValue { get; set; }

        /// <summary>
        /// Gets Field Name MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> FieldnamesList
        {
            get
            {
                return new SelectList(new List<Fieldname>(this.Fieldnames), "Id", "Name");
            }
        }

        /// <summary>
        /// Gets or sets Selected Compare Type value from Drop down
        /// </summary>
        [Display(Name = "Compare Type")]
        public string SelectedCompareType { get; set; }
        
        /// <summary>
        /// Gets Compare Type MVC Drop Down List
        /// </summary>
        public IEnumerable<SelectListItem> CompareTypesList
        {
            get
            {
                return new SelectList(new List<CompareType>(this.CompareTypes), "Id", "Name");
            }
        }

        /// <summary>
        /// Set condition type collection object
        /// </summary>
        /// <param name="conditionType">condition type object</param>
        public void SetConditionTypes(ICollection<ConditionType> conditionType)
        {
            this.conditionTypesData = new List<ConditionType>(conditionType);
        }

        /// <summary>
        /// Set field type collection object
        /// </summary>
        /// <param name="fieldType">field type object</param>
        public void SetFieldTypes(ICollection<FieldType> fieldType)
        {
            this.fieldTypesData = new List<FieldType>(fieldType);
        }

        /// <summary>
        /// Set field name collection object
        /// </summary>
        /// <param name="fieldname">field name object</param>
        public void SetFieldnames(ICollection<Fieldname> fieldname)
        {
            this.fieldNamesData = new List<Fieldname>(fieldname);
        }

        /// <summary>
        /// Set field name collection object
        /// </summary>
        /// <param name="compareType">compare type object</param>
        public void SetCompareTypes(ICollection<CompareType> compareType)
        {
            this.compareTypesData = new List<CompareType>(compareType);
        }
    }    
}