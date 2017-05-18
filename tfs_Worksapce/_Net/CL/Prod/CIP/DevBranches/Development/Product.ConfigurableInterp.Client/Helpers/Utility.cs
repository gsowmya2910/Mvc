//----------------------------------------------------------------
// <copyright file="Utility.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 

namespace Product.ConfigurableInterp.Client.Helpers
{
    using System;
    using System.Web.Script.Serialization;

    /// <summary>
    /// Class used to hold common utility functions.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Used to just do console logging for debugging purposes.
        /// </summary>
        /// <param name="message">The message string to be logged.</param>
        public static void ConsoleLogger(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <summary>
        /// Used to just do console logging for debugging purposes.
        /// </summary>
        /// <param name="value">The object to be converted to a string and logged.</param>
        public static void ConsoleLogger(object value)
        {
            System.Diagnostics.Debug.WriteLine(new JavaScriptSerializer().Serialize(value));
        }

        /// <summary>
        /// Used to just do console logging for debugging purposes.
        /// </summary>
        /// <param name="message">The prefix string to be displayed before the object.</param>
        /// <param name="value">The object to be converted to a string and logged.</param>
        public static void ConsoleLogger(string message, object value)
        {
            System.Diagnostics.Debug.WriteLine(message + new JavaScriptSerializer().Serialize(value));
        }
    }
}