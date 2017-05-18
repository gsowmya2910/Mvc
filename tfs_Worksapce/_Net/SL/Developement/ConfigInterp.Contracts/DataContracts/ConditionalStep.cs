// ----------------------------------------------------------------------
// <copyright file="ConditionalStep.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.ConfiguredStep" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class ConditionalStep : ConfiguredStep
    {
        /// <summary>
        /// Gets or sets the conditions.
        /// </summary>
        /// <value>
        /// The conditions.
        /// </value>
        [DataMember]
        public List<Condition> Conditions { get; set; }

        /// <summary>
        /// Gets or sets the false actions.
        /// </summary>
        /// <value>
        /// The false actions.
        /// </value>
        [DataMember]
        public List<StepAction> FalseActions { get; set; }

        /// <summary>
        /// Gets or sets the true actions.
        /// </summary>
        /// <value>
        /// The true actions.
        /// </value>
        [DataMember]
        public List<StepAction> TrueActions { get; set; }
    }
}