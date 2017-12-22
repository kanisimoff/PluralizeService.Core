using System;
using System.Collections.Generic;
using System.Text;
using PluralizationService.Adapters;
using PluralizationService.Core.Builder.Base;
using PluralizationService.English.Adapters;
using PluralizationService.English.Sources;
using PluralizationService.Providers;

namespace PluralizationService.English.Providers
{
    /// <summary>
    /// This class is an implementation of <see cref="IMetaDataProvider"/>
    /// </summary>
    internal class EnglishMetaDataProvider : ProviderBase, IMetaDataProvider
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="EnglishMetaDataProvider"/>
        /// class.
        /// </summary>
        /// <param name="source">The parent builder source.</param>
        public EnglishMetaDataProvider(
            EnglishMetaDataSource source
        ) : base(source)
        {

        }

        #endregion

        // *******************************************************************
        // IMetaDataProvider implementation.
        // *******************************************************************

        #region IMetaDataProvider implementation

        /// <summary>
        /// This method returns a meta-data adapter.
        /// </summary>
        /// <returns>A <see cref="IMetaDataAdapter"/> instance.</returns>
        IMetaDataAdapter IMetaDataProvider.GetMetaDataAdapter()
        {
            return new EnglishMetaDataAdapter(this);
        }

        #endregion
    }
}
