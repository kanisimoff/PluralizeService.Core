using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder
{
    /// <summary>
    /// This interface represents a builder provider, which is an object 
    /// that creates instances of any internal abstractions required
    /// by a given product.
    /// </summary>
    public interface IBuilderProvider
    {
        /// <summary>
        /// This property contains the provider's corresponding source.
        /// </summary>
        IBuilderSource Source { get; }

        /// <summary>
        /// This property contains a collection of child providers.
        /// </summary>
        IEnumerable<IBuilderProvider> Children { get; }

        /// <summary>
        /// This method adds a child to the provider.
        /// </summary>
        /// <param name="provider">The provider to add.</param>
        void AddChild(IBuilderProvider provider);
    }
}
