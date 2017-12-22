using System;
using System.Globalization;

namespace PluralizationService.Adapters
{
    /// <summary>
    /// This interface represents a meta-data adapter for a specific culture.
    /// </summary>
    public interface IMetaDataAdapter : IDisposable
    {
        /// <summary>
        /// This property indicates which language the adapter supports.
        /// </summary>
        CultureInfo Culture { get; }

        /// <summary>
        /// This method determines if the specified word is plural.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is plural; otherwise, false.</returns>
        bool IsPlural(
            string word
        );

        /// <summary>
        /// This method determines if the specified word is singular.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is singular; otherwise, false.</returns>
        bool IsSingular(
            string word
        );

        /// <summary>
        /// This method returns the plural form of the specified word
        /// </summary>
        /// <param name="word">The word to be made plural.</param>
        /// <returns>The plural form of the specified word.</returns>
        string Pluralize(
            string word
        );

        /// <summary>
        /// This method returns the singular form of the specified word
        /// </summary>
        /// <param name="word">The word to be made singular.</param>
        /// <returns>The singular form of the specified word.</returns>
        string Singularize(
            string word
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
    }
}
