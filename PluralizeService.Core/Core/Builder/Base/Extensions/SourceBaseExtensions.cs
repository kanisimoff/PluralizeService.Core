using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder.Base.Extensions
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="SourceBase"/>
    /// type.
    /// </summary>
    /// <remarks>
    /// The idea with this class is to provide a way to sidestep the need for
    /// downcasting everything to an <see cref="IBuilderSource"/> in order to access
    /// the explicitly implemented interface methods on the <see cref="SourceBase"/> 
    /// class.
    /// </remarks>
    public static class SourceBaseExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method exposes the <see cref="IBuilderSource.Build(IBuilder)"/> method on a
        /// <see cref="SourceBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="source">A <see cref="SourceBase"/> reference.</param>
        /// <param name="builder">The builder to use for the operation.</param>
        /// <returns></returns>
        public static IBuilderProvider Build(
            this SourceBase source,
            IBuilder builder
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(source, nameof(source))
                .ThrowIfNull(builder, nameof(builder));

            // Downcast and perform the operation.
            return ((IBuilderSource)source).Build(builder);
        }

        // *******************************************************************

        /// <summary>
        /// This method exposes the <see cref="IBuilderSource.Children"/> property on a
        /// <see cref="SourceBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="source">A <see cref="SourceBase"/> reference.</param>
        /// <returns>A collection of child <see cref="IBuilderSource"/> references.</returns>
        public static IEnumerable<IBuilderSource> Children(
            this SourceBase source
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(source, nameof(source));

            // Downcast and perform the operation.
            return ((IBuilderSource)source).Children;
        }

        // *******************************************************************

        /// <summary>
        /// This method exposes the <see cref="IBuilderSource.AddChild(IBuilderSource)"/> method
        /// on a <see cref="SourceBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="source">A <see cref="SourceBase"/> reference.</param>
        /// <param name="child">The source to add as a child.</param>
        public static void AddChild(
            this SourceBase source,
            IBuilderSource child
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(source, nameof(source))
                .ThrowIfNull(child, nameof(child));

            // Downcast and perform the operation.
            ((IBuilderSource)source).AddChild(child);
        }

        #endregion
    }
}
