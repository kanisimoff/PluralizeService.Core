using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder.Base.Extensions
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="ProviderBase"/>
    /// type.
    /// </summary>
    /// <remarks>
    /// The idea with this class is to provide a way to sidestep the need for
    /// downcasting everything to an <see cref="IBuilderProvider"/> in order to access
    /// the explicitly implemented interface methods on the <see cref="ProviderBase"/> 
    /// class.
    /// </remarks>
    public static class ProviderBaseExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method exposes the <see cref="IBuilderProvider.Source"/> method on a
        /// <see cref="ProviderBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="provider">A <see cref="ProviderBase"/> reference.</param>
        /// <returns>A source reference.</returns>
        public static IBuilderSource Source(
            this ProviderBase provider
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(provider, nameof(provider));

            // Downcast and perform the operation.
            return ((IBuilderProvider)provider).Source;
        }

        // *******************************************************************

        /// <summary>
        /// This method exposes the <see cref="IBuilderProvider.Children"/> property on a
        /// <see cref="ProviderBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="provider">A <see cref="ProviderBase"/> reference.</param>
        /// <returns>A collection of child <see cref="IBuilderProvider"/> references.</returns>
        public static IEnumerable<IBuilderProvider> Children(
            this ProviderBase provider
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(provider, nameof(provider));

            // Downcast and perform the operation.
            return ((IBuilderProvider)provider).Children;
        }

        // *******************************************************************

        /// <summary>
        /// This method exposes the <see cref="IBuilderProvider.AddChild(IBuilderProvider)"/> method
        /// on a <see cref="ProviderBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="provider">A <see cref="ProviderBase"/> reference.</param>
        /// <param name="child">The provider to add as a child.</param>
        public static void AddChild(
            this ProviderBase provider,
            IBuilderProvider child
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(provider, nameof(provider))
                .ThrowIfNull(child, nameof(child));

            // Downcast and perform the operation.
            ((IBuilderProvider)provider).AddChild(child);
        }

        #endregion
    }
}
