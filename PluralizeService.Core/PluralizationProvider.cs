using System;
using System.Globalization;
using PluralizationService;
using PluralizationService.English;

namespace PluralizeService.Core
{
    public static class PluralizationProvider
    {
        private static Lazy<IPluralizationApi> lazyPluralApi;
        private static IPluralizationApi pluralization => lazyPluralApi.Value;
        private static readonly CultureInfo culture;

        static PluralizationProvider()
        {
            // Set the culture
            culture = new CultureInfo("en-US");

            // Create the singleton instance
            lazyPluralApi = new Lazy<IPluralizationApi>(() =>
            {
                var builder = new PluralizationApiBuilder();
                builder.AddEnglishProvider();

                return builder.Build();
            });
        }

        /// <summary>
        /// Attempts to pluralize the word, returning the original word if it fails
        /// </summary>
        /// <param name="word">The word to convert</param>
        /// <returns>The converted word, or original</returns>
        public static string Pluralize(string word) =>
            pluralization.Pluralize(word, culture) ?? word;

        /// <summary>
        /// Attempts to de-pluralize the word, returning the original if it fails
        /// </summary>
        /// <param name="word">The word to convert</param>
        /// <returns>The converted word, or original</returns>
        public static string Singularize(string word) =>
            pluralization.Singularize(word, culture) ?? word;

    }
}
