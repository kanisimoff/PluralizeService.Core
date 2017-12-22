using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder
{
    /// <summary>
    /// This interface represents a reusable, extensible builder.
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// This property contains a collection of configuration sources.
        /// </summary>
        IEnumerable<IBuilderSource> Sources { get; }

        /// <summary>
        /// This method is used to add a new configuration source to the builder.
        /// </summary>
        /// <param name="source">The source to be added.</param>
        /// <returns>The builder instance.</returns>
        IBuilder AddSource(IBuilderSource source);

        /// <summary>
        /// This method builds the specified product instance.
        /// </summary>
        /// <typeparam name="TProduct">The type of product to build.</typeparam>
        /// <returns>A new product instance.</returns>
        TProduct Build<TProduct>() where TProduct : IBuilderProduct, new();
    }
}
