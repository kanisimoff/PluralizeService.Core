using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder
{
    /// <summary>
    /// This interface represents a builder product, which is the thing
    /// the builder creates an instance of when the <see cref="IBuilder.Build{TProduct}"/>
    /// method is called.
    /// </summary>
    public interface IBuilderProduct
    {
        /// <summary>
        /// This property contains a collection of providers.
        /// </summary>
        IEnumerable<IBuilderProvider> Providers { get; }

        /// <summary>
        /// This method adds a new provider to the product.
        /// </summary>
        /// <param name="provider">The provider to add.</param>
        void AddProvider(IBuilderProvider provider);

        /// <summary>
        /// This method initializes the product for use.
        /// </summary>
        void Initialize();
    }
}
