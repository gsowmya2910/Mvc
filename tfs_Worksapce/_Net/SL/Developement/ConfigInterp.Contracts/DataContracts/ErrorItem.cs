// ----------------------------------------------------------------------
// <copyright file="ErrorItem.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Contracts.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// POCO Object
    /// </summary>
    [DataContract(Namespace = ServiceNamespaces.DataContracts)]
    public class ErrorItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorItem"/> class.
        /// </summary>
        /// <param name="prop">   The property.</param>
        /// <param name="message">The message.</param>
        public ErrorItem(string prop, string message)
        {
            this.Prop = prop;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorItem"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        public ErrorItem(int id, string message)
        {
            this.Prop = string.Format("Error Id : {0}", id);
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        /// <value>The property.</value>
        [DataMember]
        public string Prop { get; set; }
    }
}