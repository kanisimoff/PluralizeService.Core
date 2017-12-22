using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder
{
    /// <summary>
    /// This interface represents a builder source, which is an object
    /// that contains all the configuration details required by a provider
    /// at runtime.
    /// </summary>
    public interface IBuilderSource
    {
        /// <summary>
        /// This method builds the source into a provider instance.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <returns>A provider instance.</returns>
        IBuilderProvider Build(IBuilder builder);

        /// <summary>
        /// This property contains a collection of child sources.
        /// </summary>
        IEnumerable<IBuilderSource> Children { get; }

        /// <summary>
        /// This method adds a child to the source.
        /// </summary>
        /// <param name="source">The source to add.</param>
        void AddChild(IBuilderSource source);
    }
}
