using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder.Base.Extensions
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="ProductBase"/>
    /// type.
    /// </summary>
    /// <remarks>
    /// The idea with this class is to provide a way to sidestep the need for
    /// downcasting everything to an <see cref="IBuilderProduct"/> in order to access
    /// the explicitly implemented interface methods on the <see cref="ProductBase"/> 
    /// class.
    /// </remarks>
    public static class ProductBaseExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method exposes the <see cref="IBuilderProduct.Providers"/> method on a
        /// <see cref="ProductBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="product">A <see cref="ProductBase"/> reference.</param>
        /// <returns>A collection of providers.</returns>
        public static IEnumerable<IBuilderProvider> Providers(
            this ProductBase product
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(product, nameof(product));

            // Downcast and perform the operation.
            return ((IBuilderProduct)product).Providers;
        }

        // *******************************************************************

        /// <summary>
        /// This method exposes the <see cref="IBuilderProduct.AddProvider"/> method on a
        /// <see cref="ProductBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="product">A <see cref="ProductBase"/> reference.</param>
        /// <param name="provider">The provider to add.</param>
        public static void AddProvider(
            this ProductBase product,
            IBuilderProvider provider
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(product, nameof(product))
                .ThrowIfNull(provider, nameof(provider));

            // Downcast and perform the operation.
            ((IBuilderProduct)product).AddProvider(provider);
        }

        #endregion
    }
}
