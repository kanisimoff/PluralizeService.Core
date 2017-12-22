using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PluralizationService.Adapters;
using PluralizationService.Core;
using PluralizationService.Core.Builder.Base;
using PluralizationService.Properties;
using PluralizationService.Providers;
using PluralizationService.Core.Builder.Base.Extensions;

namespace PluralizationService
{
    /// <summary>
    /// This class is a default implementation of <see cref="IPluralizationApi"/>
    /// </summary>
    internal class DefaultPluralizationApi : ProductBase, IPluralizationApi
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a list of meta-data adapters.
        /// </summary>
        protected List<IMetaDataAdapter> Adapters { get; private set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="DefaultPluralizationApi"/>
        /// class.
        /// </summary>
        public DefaultPluralizationApi()
        {
            Adapters = new List<IMetaDataAdapter>();
        }

        #endregion

        // *******************************************************************
        // IPluralizationApi implementation.
        // *******************************************************************

        #region IPluralizationApi implementation

        /// <summary>
        /// This method determines if the specified word is plural in the 
        /// language associated with the current culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is plural; otherwise, false.</returns>
        public virtual bool IsPlural(
            string word
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word));

            // Get the current culture.
            var culture = CultureInfo.CurrentCulture;

            // Return the results for that culture.
            return IsPlural(
                word,
                culture
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method determines if the specified word is plural in the 
        /// language associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>True if the word is plural; otherwise, false.</returns>
        public virtual bool IsPlural(
            string word,
            CultureInfo culture
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word))
                .ThrowIfNull(culture, nameof(culture));

            // Look for the adapter for the current culture.
            var adapter = Adapters.FirstOrDefault(
                x => x.Culture.Name == culture.Name
            );

            // Did we fail to find one?
            if (adapter == null)
                throw new PluralizationException(
                    string.Format(
                        Resources.DefaultPluralizationApi_AdapterNotFound,
                        culture.Name
                    )
                );

            // Defer to the adapter.
            return adapter.IsPlural(word);
        }

        // *******************************************************************

        /// <summary>
        /// This method determines if the specified word is singular in the 
        /// language associated with the current culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is singular; otherwise, false.</returns>
        public virtual bool IsSingular(
            string word
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word));

            // Get the current culture.
            var culture = CultureInfo.CurrentCulture;

            // Return the results for that culture.
            return IsSingular(
                word,
                culture
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method determines if the specified word is singular in the 
        /// language associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>True if the word is singular; otherwise, false.</returns>
        public virtual bool IsSingular(
            string word,
            CultureInfo culture
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word))
                .ThrowIfNull(culture, nameof(culture));

            // Look for the adapter for the current culture.
            var adapter = Adapters.FirstOrDefault(
                x => x.Culture.Name == culture.Name
            );

            // Did we fail to find one?
            if (adapter == null)
                throw new PluralizationException(
                    string.Format(
                        Resources.DefaultPluralizationApi_AdapterNotFound,
                        culture.Name
                    )
                );

            // Defer to the adapter.
            return adapter.IsSingular(word);
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the plural form of the specified word using
        /// the lanauge associated with the current culture.
        /// </summary>
        /// <param name="word">The word to be made plural.</param>
        /// <returns>The plural form of the specified word.</returns>
        public virtual string Pluralize(
            string word
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word));

            // Get the current culture.
            var culture = CultureInfo.CurrentCulture;

            // Return the results for that culture.
            return Pluralize(
                word,
                culture
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the plural form of the specified word using
        /// the lanauge associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to be made plural.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>The plural form of the specified word.</returns>
        public virtual string Pluralize(
            string word,
            CultureInfo culture
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word))
                .ThrowIfNull(culture, nameof(culture));

            // Look for the adapter for the current culture.
            var adapter = Adapters.FirstOrDefault(
                x => x.Culture.Name == culture.Name
            );

            // Did we fail to find one?
            if (adapter == null)
                throw new PluralizationException(
                    string.Format(
                        Resources.DefaultPluralizationApi_AdapterNotFound,
                        culture.Name
                    )
                );

            // Defer to the adapter.
            return adapter.Pluralize(word);
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the singular form of the specified word using
        /// the lanauge associated with the current culture.
        /// </summary>
        /// <param name="word">The word to be made singular.</param>
        /// <returns>The singular form of the specified word.</returns>
        public virtual string Singularize(
            string word
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word));

            // Get the current culture.
            var culture = CultureInfo.CurrentCulture;

            // Return the results for that culture.
            return Singularize(
                word,
                culture
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the singular form of the specified word using
        /// the lanauge associated with the specified culture.
        /// </summary>
        /// <param name="word">The word to be made singular.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        /// <returns>The singular form of the specified word.</returns>
        public virtual string Singularize(
            string word,
            CultureInfo culture
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNullOrEmpty(word, nameof(word))
                .ThrowIfNull(culture, nameof(culture));

            // Look for the adapter for the current culture.
            var adapter = Adapters.FirstOrDefault(
                x => x.Culture.Name == culture.Name
            );

            // Did we fail to find one?
            if (adapter == null)
                throw new PluralizationException(
                    string.Format(
                        Resources.DefaultPluralizationApi_AdapterNotFound,
                        culture.Name
                    )
                );

            // Defer to the adapter.
            return adapter.Singularize(word);
        }

        // *******************************************************************

        /// <summary>
        /// This method adds a custom word to the adapter.
        /// </summary>
        /// <param name="singular">The singular version of the word.</param>
        /// <param name="plural">The plural version of the word.</param>
        public virtual void AddWord(
            string singular,
            string plural
        )
        {

            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNullOrEmpty(singular, nameof(singular))
                .ThrowIfNullOrEmpty(plural, nameof(plural));

            // Get the current culture.
            var culture = CultureInfo.CurrentCulture;

            // Defer to the adapter.
            AddWord(
                singular,
                plural,
                culture
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method adds a custom word to the adapter.
        /// </summary>
        /// <param name="singular">The singular version of the word.</param>
        /// <param name="plural">The plural version of the word.</param>
        /// <param name="culture">The culture to use for the operation.</param>
        public virtual void AddWord(
            string singular,
            string plural,
            CultureInfo culture
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNullOrEmpty(singular, nameof(singular))
                .ThrowIfNullOrEmpty(plural, nameof(plural))
                .ThrowIfNull(culture, nameof(culture));

            // Look for the adapter for the current culture.
            var adapter = Adapters.FirstOrDefault(
                x => x.Culture.Name == culture.Name
            );

            // Did we fail to find one?
            if (adapter == null)
                throw new PluralizationException(
                    string.Format(
                        Resources.DefaultPluralizationApi_AdapterNotFound,
                        culture.Name
                    )
                );

            // Defer to the adapter.
            adapter.AddWord(
                singular,
                plural
            );
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is overriden in order to initialize the product.
        /// </summary>
        protected override void OnInitialize()
        {
            // Look for meta-data providers.
            var metaDataProviders = this.Providers()
                .Where(x => x is IMetaDataProvider)
                .Select(x => x as IMetaDataProvider)
                .ToList();

            // Verify there was at least one provider configured.
            if (metaDataProviders == null || metaDataProviders.Count == 0)
                throw new PluralizationException(
                    Resources.DefaultPluralizationApi_NoMetaDataSources
                );

            // Create the adapters and store them.
            foreach (var provider in metaDataProviders)
                Adapters.Add(provider.GetMetaDataAdapter());
        }

        // *******************************************************************

        /// <summary>
        /// This method is overriden in order to dispose of any internal 
        /// unmanaged resources.
        /// </summary>
        protected override void OnDispose()
        {
            // Cleanup the meta-data adapters.
            foreach (var adapter in Adapters)
                adapter.Dispose();

            // Empty the list.
            Adapters.Clear();
        }

        #endregion
    }
}
