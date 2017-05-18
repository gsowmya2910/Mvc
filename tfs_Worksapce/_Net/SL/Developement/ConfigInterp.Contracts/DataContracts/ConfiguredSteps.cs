// ----------------------------------------------------------------------
// <copyright file="ConfiguredSteps.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class ConfiguredSteps
    {
        /// <summary>
        /// Gets or sets the conditional steps.
        /// </summary>
        /// <value>
        /// The conditional steps.
        /// </value>
        [DataMember]
        public ConditionalStep[] ConditionalSteps { get; set; }

        /// <summary>
        /// Gets or sets the exception steps.
        /// </summary>
        /// <value>
        /// The exception steps.
        /// </value>
        [DataMember]
        public ExceptionStep[] ExceptionSteps { get; set; }

        /// <summary>
        /// Gets or sets the unconditional steps.
        /// </summary>
        /// <value>
        /// The unconditional steps.
        /// </value>
        [DataMember]
        public UnconditionalStep[] UnconditionalSteps { get; set; }
    }
}