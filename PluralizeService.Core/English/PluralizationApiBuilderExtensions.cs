using System;
using System.Collections.Generic;
using System.Text;
using PluralizationService.English.Sources;
using PluralizationService.Sources;
using PluralizationService.Core.Builder.Base.Extensions;

namespace PluralizationService.English
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="PluralizationApiBuilder"/>
    /// class. 
    /// </summary>
    public static partial class PluralizationApiBuilderExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method configures a <see cref="PluralizationApiBuilder"/> to use 
        /// an english meta-data provider at runtime.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <returns>An <see cref="IPluralizationSource"/> for configuration 
        /// purposes.</returns>
        public static IPluralizationSource AddEnglishProvider(
            this PluralizationApiBuilder builder
        )
        {
            // Create the source instance.
            var source = new EnglishMetaDataSource();

            // Add the source to the builder.
            builder.AddSource(source);

            // Return the source instance for configuration purposes.
            return source;
        }

        #endregion
    }
}
