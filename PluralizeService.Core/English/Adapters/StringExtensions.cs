using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using PluralizationService.Core;

namespace PluralizationService.English.Adapters
{
    /// <summary>
    /// This class contains extension methods related to the string 
    /// type.
    /// </summary>
    internal static class StringExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method indicates whether a string ends with a specific value.
        /// </summary>
        /// <param name="pThis">The string to be tested.</param>
        /// <param name="value">The value to test for.</param>
        /// <param name="ignoreCase">True to ignore case; false otherwise.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>True if the string ends in the specific value; false 
        /// otherwise.</returns>
        public static bool EndsWith(
            this string pThis,
            string value,
            bool ignoreCase,
            CultureInfo culture
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(pThis, nameof(pThis))
                .ThrowIfNull(value, nameof(value));

            // Do the object references match?
            if ((object)pThis == (object)value)
                return true;

            // Get the cultureInfo
            var cultureInfo = (culture != null ? culture : CultureInfo.CurrentCulture);

            // Perform the operation.
            return cultureInfo.CompareInfo
                .IsSuffix(
                    pThis,
                    value,
                    (ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None)
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method converts a string to lower case using the specified culture.
        /// </summary>
        /// <param name="pThis">The string to be converted.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns></returns>
        public static string ToLower(
            this string pThis,
            CultureInfo culture
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(pThis, nameof(pThis))
                .ThrowIfNull(culture, nameof(culture));

            // Perform the operation.
            return culture.TextInfo.ToLower(pThis);
        }

        #endregion
    }
}
