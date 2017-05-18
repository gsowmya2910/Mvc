//----------------------------------------------------------------
// <copyright file="InterpJsonData.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

using System.Collections.Generic;

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "CL Reviewed.")]

namespace Product.ConfigurableInterp.Client.Models
{
    /// <summary>
    /// This class will hold Interp JSON Data
    /// </summary>
    public class InterpJsonData
    {
        /// <summary>
        /// Gets or sets step number
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the step has an error
        /// </summary>
        public bool StepInError { get; set; }

        /// <summary>
        /// Gets or sets Interp Exception Data
        /// </summary>
        public JsonDataDetail ExceptionData { get; set; }

        /// <summary>
        /// Gets or sets Collection of Condition Data
        /// </summary>
        public JsonConditionStep ConditionData { get; set; }

        /// <summary>
        /// Gets or sets Collection of Action Data
        /// </summary>
        public JsonActionStep ActionData { get; set; }
    }

    /// <summary>
    /// Class holds the Json detail data
    /// </summary>
    public class JsonDataDetail
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Class holds the Json actions step
    /// </summary>
    public class JsonActionStep
    {
        /// <summary>
        /// Gets or sets result
        /// </summary>
        public JsonDataDetail Result { get; set; }

        /// <summary>
        /// Gets or sets action type
        /// </summary>
        public JsonDataDetail ActionType { get; set; }

        /// <summary>
        /// Gets or sets action name
        /// </summary>
        public JsonDataDetail ActionName { get; set; }

        /// <summary>
        /// Gets or sets parameter 1
        /// </summary>
        public JsonDataDetail Parameter1 { get; set; }

        /// <summary>
        /// Gets or sets parameter 2
        /// </summary>
        public JsonDataDetail Parameter2 { get; set; }

        /// <summary>
        /// Gets or sets parameter 3
        /// </summary>
        public JsonDataDetail Parameter3 { get; set; }

        /// <summary>
        /// Gets or sets parameter 4
        /// </summary>
        public JsonDataDetail Parameter4 { get; set; }

        /// <summary>
        /// Gets or sets parameter 5
        /// </summary>
        public JsonDataDetail Parameter5 { get; set; }
    }

    /// <summary>
    /// Class holds the Json condition
    /// </summary>
    public class JsonCondition
    {
        /// <summary>
        /// Gets or sets condition type
        /// </summary>
        public JsonDataDetail ConditionType { get; set; }

        /// <summary>
        /// Gets or sets field type
        /// </summary>
        public JsonDataDetail FieldType { get; set; }

        /// <summary>
        /// Gets or sets field name
        /// </summary>
        public JsonDataDetail FieldName { get; set; }

        /// <summary>
        /// Gets or sets compare type
        /// </summary>
        public JsonDataDetail CompareType { get; set; }

        /// <summary>
        /// Gets or sets compare value
        /// </summary>
        public JsonDataDetail CompareValue { get; set; }
    }

    /// <summary>
    /// Class holds the Json condition step
    /// </summary>
    public class JsonConditionStep
    {
        /// <summary>
        /// Gets or sets list of conditions
        /// </summary>
        public List<JsonCondition> Conditions { get; set; }

        /// <summary>
        /// Gets or sets list of actions
        /// </summary>
        public List<JsonActionStep> Actions { get; set; }
    }
}