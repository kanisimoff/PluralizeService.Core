using PluralizationService.Adapters;

namespace PluralizationService.Providers
{
    /// <summary>
    /// This interface represents a meta-data provider.
    /// </summary>
    public interface IMetaDataProvider
    {
        /// <summary>
        /// This method returns a meta-data adapter.
        /// </summary>
        /// <returns>A <see cref="IMetaDataAdapter"/> instance.</returns>
        IMetaDataAdapter GetMetaDataAdapter();
    }
}
