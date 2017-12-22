using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PluralizationService.Core.Builder.Base
{
    /// <summary>
    /// This class is a helper base class intended to make the process of 
    /// creating concrete sources a little easier and cleaner.
    /// </summary>
    public abstract class SourceBase : IBuilderSource
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a list of child sources.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IList<IBuilderSource> _children = new List<IBuilderSource>();

        #endregion

        // *******************************************************************
        // IBuilderSource implementation.
        // *******************************************************************

        #region IBuilderSource implementation

        /// <summary>
        /// This method builds the source into a provider instance.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <returns>A provider instance.</returns>
        IBuilderProvider IBuilderSource.Build(
            IBuilder builder
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(builder, nameof(builder));

            // Build the provider.
            var provider = OnBuild(builder);

            // Loop through any children.
            foreach (var child in _children)
            {
                // Build and add any child providers.
                provider.AddChild(
                    child.Build(builder)
                );
            }

            // Return the provider.
            return provider;
        }

        // *******************************************************************

        /// <summary>
        /// This property contains a collection of child sources.
        /// </summary>
        IEnumerable<IBuilderSource> IBuilderSource.Children { get { return _children; } }

        // *******************************************************************

        /// <summary>
        /// This method adds a child to the source.
        /// </summary>
        /// <param name="source">The source to add.</param>
        void IBuilderSource.AddChild(
            IBuilderSource source
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(source, nameof(source));

            // Add the child source.
            _children.Add(source);
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is called when a source should build it's corresponding 
        /// provider. The method is called once per source, including any child
        /// sources, so each source should only attempt to create it's own provider
        /// and trust any children to create their own providers.
        /// </summary>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <returns>A provider instance.</returns>
        protected abstract IBuilderProvider OnBuild(
            IBuilder builder
        );

        #endregion
    }
}
