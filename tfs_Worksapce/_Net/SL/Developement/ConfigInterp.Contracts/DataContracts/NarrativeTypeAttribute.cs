// ----------------------------------------------------------------------
// <copyright file="NarrativeTypeAttribute.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System;

    /// <summary>
    /// the attribute
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class NarrativeTypeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NarrativeTypeAttribute"/> class.
        /// </summary>
        /// <param name="narrative">The narrative.</param>
        public NarrativeTypeAttribute(short narrative)
        {
            this.Narrative = narrative;
        }

        /// <summary>
        /// Gets the narrative.
        /// </summary>
        /// <value>
        /// The narrative.
        /// </value>
        public short Narrative { get; private set; }
    }
}