// ----------------------------------------------------------------------
// <copyright file="UnconditionalStep.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Contracts.DataContracts.ConfiguredStep" />
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class UnconditionalStep : ConfiguredStep
    {
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [DataMember]
        public StepAction Action { get; set; }
    }
}