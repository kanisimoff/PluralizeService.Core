using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PluralizationService.English.Adapters
{
    /// <summary>
    /// This class utility contains misc utility methods.
    /// </summary>
    internal static class PluralizationServiceUtil
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method indicates whether a word contains a specific suffix.
        /// </summary>
        /// <param name="word">The word to use for the operation.</param>
        /// <param name="suffixes">A list of suffixes to check for.</param>
        /// <param name="culture">A culture to use for the operation.</param>
        /// <returns>True if the word contains one or more of the specified 
        /// suffixes; false otherwise.</returns>
        public static bool DoesWordContainSuffix(
            string word,
            IEnumerable<string> suffixes,
            CultureInfo culture
        )
        {
            return suffixes.Any<string>(
                (string s) => word.EndsWith(s, true, culture)
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method performs an action if a word contains a specific suffix.
        /// </summary>
        /// <param name="word">The word to use for the operation.</param>
        /// <param name="suffixes">A list of suffixes to check for.</param>
        /// <param name="operationOnWord">The action to be performed.</param>
        /// <param name="culture">A culture to use for the operation.</param>
        /// <param name="newWord">The results of the operation.</param>
        /// <returns>True if the operation succeeded; false otherwise.</returns>
        public static bool TryInflectOnSuffixInWord(
            string word,
            IEnumerable<string> suffixes,
            Func<string, string> operationOnWord,
            CultureInfo culture,
            out string newWord
        )
        {
            newWord = null;
            if (!PluralizationServiceUtil.DoesWordContainSuffix(word, suffixes, culture))
            {
                return false;
            }
            newWord = operationOnWord(word);
            return true;
        }

        #endregion
    }
}
