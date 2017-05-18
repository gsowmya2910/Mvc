//----------------------------------------------------------------
// <copyright file="InterpActionData.cs" company="CoreLink">
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
    /// This class will hold Interp Action Data
    /// </summary>
    public class InterpActionData
    {
        /// <summary>
        /// Collection of Result data objects
        /// </summary>
        private List<InterpResultData> resultData;

        /// <summary>
        /// Collection of Action Type data objects
        /// </summary>
        private List<InterpActionTypeData> actionTypeData;

        /// <summary>
        /// Collection of Parameter 1 data objects
        /// </summary>
        private List<InterpParameterValueData> parameter1Data;

        /// <summary>
        /// Collection of Parameter 2 data objects
        /// </summary>
        private List<InterpParameterValueData> parameter2Data;

        /// <summary>
        /// Collection of Parameter 3 data objects
        /// </summary>
        private List<InterpParameterValueData> parameter3Data;

        /// <summary>
        /// Collection of Parameter 4 data objects
        /// </summary>
        private List<InterpParameterValueData> parameter4Data;

        /// <summary>
        /// Collection of Parameter 5 data objects
        /// </summary>
        private List<InterpParameterValueData> parameter5Data;

        /// <summary>
        /// Gets Collection of Result Data objects
        /// </summary>
        public ICollection<InterpResultData> ResultData 
        { 
            get 
            { 
                return this.resultData; 
            } 
        }

        /// <summary>
        /// Gets Collection of Action Type Data objects
        /// </summary>
        public ICollection<InterpActionTypeData> ActionTypeData 
        { 
            get 
            { 
                return this.actionTypeData; 
            } 
        }

        /// <summary>
        /// Gets Collection of Parameter Value Data Objects
        /// </summary>
        public ICollection<InterpParameterValueData> Parameter1Data 
        { 
            get 
            { 
                return this.parameter1Data; 
            } 
        }

        /// <summary>
        /// Gets Collection of Parameter Value Data Objects
        /// </summary>
        public ICollection<InterpParameterValueData> Parameter2Data 
        { 
            get 
            { 
                return this.parameter2Data; 
            } 
        }

        /// <summary>
        /// Gets Collection of Parameter Value Data Objects
        /// </summary>
        public ICollection<InterpParameterValueData> Parameter3Data 
        { 
            get 
            { 
                return this.parameter3Data; 
            } 
        }

        /// <summary>
        /// Gets Collection of Parameter Value Data Objects
        /// </summary>
        public ICollection<InterpParameterValueData> Parameter4Data 
        { 
            get 
            { 
                return this.parameter4Data; 
            } 
        }

        /// <summary>
        /// Gets Collection of Parameter Value Data Objects
        /// </summary>
        public ICollection<InterpParameterValueData> Parameter5Data 
        { 
            get 
            { 
                return this.parameter5Data; 
            } 
        }

        /// <summary>
        /// Initialize Result data collection object
        /// </summary>
        /// <param name="resultData">Result data collection object</param>
        public void SetResultData(ICollection<InterpResultData> resultData)
        {
            this.resultData = new List<InterpResultData>(resultData);
        }

        /// <summary>
        /// Initialize Action type data collection object
        /// </summary>
        /// <param name="actionTypeData">Action type data collection object</param>
        public void SetActionTypeData(ICollection<InterpActionTypeData> actionTypeData)
        {
            this.actionTypeData = new List<InterpActionTypeData>(actionTypeData);
        }

        /// <summary>
        /// Initialize Parameter 1 data collection object
        /// </summary>
        /// <param name="parameterData">Parameter data collection object</param>
        public void SetParameter1Data(ICollection<InterpParameterValueData> parameterData)
        {
            this.parameter1Data = new List<InterpParameterValueData>(parameterData);
        }

        /// <summary>
        /// Initialize Parameter 2 data collection object
        /// </summary>
        /// <param name="parameterData">Parameter data collection object</param>
        public void SetParameter2Data(ICollection<InterpParameterValueData> parameterData)
        {
            this.parameter2Data = new List<InterpParameterValueData>(parameterData);
        }

        /// <summary>
        /// Initialize Parameter 3 data collection object
        /// </summary>
        /// <param name="parameterData">Parameter data collection object</param>
        public void SetParameter3Data(ICollection<InterpParameterValueData> parameterData)
        {
            this.parameter3Data = new List<InterpParameterValueData>(parameterData);
        }

        /// <summary>
        /// Initialize Parameter 4 data collection object
        /// </summary>
        /// <param name="parameterData">Parameter data collection object</param>
        public void SetParameter4Data(ICollection<InterpParameterValueData> parameterData)
        {
            this.parameter4Data = new List<InterpParameterValueData>(parameterData);
        }

        /// <summary>
        /// Initialize Parameter 5 data collection object
        /// </summary>
        /// <param name="parameterData">Parameter data collection object</param>
        public void SetParameter5Data(ICollection<InterpParameterValueData> parameterData)
        {
            this.parameter5Data = new List<InterpParameterValueData>(parameterData);
        }
    }
}