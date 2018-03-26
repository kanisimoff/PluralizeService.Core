using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PluralizationService
{
    /// <summary>
    /// This interface represents a public API for converting words to and
    /// from singular to plural.
    /// </summary>
    public interface IPluralizationApi : IDisposable
    {
        /// <summary>
        /// This method determines if the specified word is plural in the 
        /// language associated with the current culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is plural; otherwise, false.</returns>
        bool IsPlural(
            string word
        );

        /// <summary>
        /// This method determines if the specified word is plural in the 
        /// language associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>True if the word is plural; otherwise, false.</returns>
        bool IsPlural(
            string word,
            CultureInfo culture
        ); 

        /// <summary>
        /// This method determines if the specified word is singular in the 
        /// language associated with the current culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is singular; otherwise, false.</returns>
        bool IsSingular(
            string word
        );

        /// <summary>
        /// This method determines if the specified word is singular in the 
        /// language associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>True if the word is singular; otherwise, false.</returns>
        bool IsSingular(
            string word,
            CultureInfo culture
        );

        /// <summary>
        /// This method returns the plural form of the specified word using
        /// the lanauge associated with the current culture.
        /// </summary>
        /// <param name="word">The word to be made plural.</param>
        /// <returns>The plural form of the specified word.</returns>
        string Pluralize(
            string word
        );

        /// <summary>
        /// This method returns the plural form of the specified word using
        /// the lanauge associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to be made plural.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>The plural form of the specified word.</returns>
        string Pluralize(
            string word,
            CultureInfo culture
        );

        /// <summary>
        /// This method returns the singular form of the specified word using
        /// the lanauge associated with the current culture.
        /// </summary>
        /// <param name="word">The word to be made singular.</param>
        /// <returns>The singular form of the specified word.</returns>
        string Singularize(
            string word
        );

        /// <summary>
        /// This method returns the singular form of the specified word using
        /// the lanauge associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to be made singular.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>The singular form of the specified word.</returns>
        string Singularize(
            string word,
            CultureInfo culture
        );

        /// <summary>
        /// This method adds a custom word to the adapter.
        /// </summary>
        /// <param name="singular">The singular version of the word.</param>
        /// <param name="plural">The plural version of the word.</param>
        void AddWord(
            string singular,
            string plural
        );

        /// <summary>
        /// This method adds a custom word to the adapter.
        /// </summary>
        /// <param name="singular">The singular version of the word.</param>
        /// <param name="plural">The plural version of the word.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        void AddWord(
            string singular,
            string plural,
            CultureInfo culture
        );
    }
}
