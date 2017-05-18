//----------------------------------------------------------------
// <copyright file="InterpConditionData.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//----------------------------------------------------------------

namespace Product.ConfigurableInterp.Client.Models
{
    #region references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    #endregion

    /// <summary>
    /// This class will hold Interp Condition Data
    /// </summary>
    public class InterpConditionData
    {
        /// <summary>
        /// Interp Condition Type Data collection object
        /// </summary>
        private List<InterpConditionTypeData> conditionTypeData;

        /// <summary>
        /// Interp Field Type Data object collection
        /// </summary>
        private List<InterpFieldTypeData> fieldTypeData;

        /// <summary>
        /// Interp Field name data object collection
        /// </summary>
        private List<InterpFieldnameData> fieldNameData;

        /// <summary>
        /// Interp Compare Type data object collection
        /// </summary>
        private List<InterpCompareTypeData> compareTypeData;

        /// <summary>
        /// Interp Compare Value data object collection
        /// </summary>
        private List<InterpCompareValueData> compareValueData;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterpConditionData" /> class
        /// </summary>
        public InterpConditionData()
        {
            this.conditionTypeData = new List<InterpConditionTypeData>();
            this.fieldTypeData = new List<InterpFieldTypeData>();
            this.fieldNameData = new List<InterpFieldnameData>();
            this.compareTypeData = new List<InterpCompareTypeData>();
            this.compareValueData = new List<InterpCompareValueData>();
        }

        /// <summary>
        /// Gets Collection of Condition Type Data objects
        /// </summary>
        public ICollection<InterpConditionTypeData> ConditionTypeData 
        { 
            get 
            { 
                return this.conditionTypeData; 
            } 
        }

        /// <summary>
        /// Gets Collection of Field Type Data objects
        /// </summary>
        public ICollection<InterpFieldTypeData> FieldTypeData 
        { 
            get 
            { 
                return this.fieldTypeData; 
            } 
        }

        /// <summary>
        /// Gets Collection of Field Name Data objects
        /// </summary>
        public ICollection<InterpFieldnameData> FieldnameData 
        { 
            get 
            { 
                return this.fieldNameData; 
            } 
        }

        /// <summary>
        /// Gets Collection of Compare Type Data objects
        /// </summary>
        public ICollection<InterpCompareTypeData> CompareTypeData 
        { 
            get 
            { 
                return this.compareTypeData; 
            } 
        }

        /// <summary>
        /// Gets Collection of Compare Value Data objects
        /// </summary>
        public ICollection<InterpCompareValueData> CompareValueData 
        { 
            get 
            { 
                return this.compareValueData; 
            } 
        }

        /// <summary>
        /// Set Condition type collection data
        /// </summary>
        /// <param name="condition">Condition collection object</param>
        public void SetConditionType(ICollection<InterpConditionTypeData> condition)
        {
            this.conditionTypeData = new List<InterpConditionTypeData>(condition);
        }

        /// <summary>
        /// Set Field type collection data
        /// </summary>
        /// <param name="fieldType">Field type collection object</param>
        public void SetFieldType(ICollection<InterpFieldTypeData> fieldType)
        {
            this.fieldTypeData = new List<InterpFieldTypeData>(fieldType); 
        }

        /// <summary>
        /// Set Field name collection data
        /// </summary>
        /// <param name="fieldname">Field name collection object</param>
        public void SetFieldname(ICollection<InterpFieldnameData> fieldname)
        {
            this.fieldNameData = new List<InterpFieldnameData>(fieldname);
        }

        /// <summary>
        /// Set compare type collection data
        /// </summary>
        /// <param name="compareType">Compare type collection</param>
        public void SetCompareType(ICollection<InterpCompareTypeData> compareType)
        {
            this.compareTypeData = new List<InterpCompareTypeData>(compareType);
        }

        /// <summary>
        /// Set compare value collection data
        /// </summary>
        /// <param name="compareValue">Compare value collection object</param>
        public void SetCompareValue(ICollection<InterpCompareValueData> compareValue)
        {
            this.compareValueData = new List<InterpCompareValueData>(compareValue);
        }
    }
}