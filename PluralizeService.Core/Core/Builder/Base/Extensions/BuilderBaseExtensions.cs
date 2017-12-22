using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder.Base.Extensions
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="BuilderBase"/>
    /// type.
    /// </summary>
    /// <remarks>
    /// The idea with this class is to provide a way to sidestep the need for
    /// downcasting everything to an <see cref="IBuilder"/> in order to access
    /// the explicitly implemented interface methods on the <see cref="BuilderBase"/> 
    /// class.
    /// </remarks>
    public static class BuilderBaseExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method exposes the <see cref="IBuilder.Sources"/> method on a
        /// <see cref="BuilderBase"/> object, in order to avoid the need to 
        /// constantly downcast.
        /// </summary>
        /// <param name="builder">A <see cref="BuilderBase"/> reference.</param>
        /// <returns>A collection of configuration sources.</returns>
        public static IEnumerable<IBuilderSource> Sources(
            this BuilderBase builder
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(builder, nameof(builder));

            // Downcast and perform the operation.
            return ((IBuilder)builder).Sources;
        }

        // *******************************************************************

        /// <summary>
        /// This method exposes the <see cref="IBuilder.AddSource(IBuilderSource)"/> 
        /// method on a <see cref="BuilderBase"/> object, in order to avoid the 
        /// need to contantly downcast.
        /// </summary>
        /// <param name="builder">A <see cref="BuilderBase"/> reference.</param>
        /// <param name="source">The source to add.</param>
        public static void AddSource(
            this BuilderBase builder,
            IBuilderSource source
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(builder, nameof(builder))
                .ThrowIfNull(source, nameof(source));

            // Downcast and perform the operation.
            ((IBuilder)builder).AddSource(source);
        }

        // *******************************************************************

        /// <summary>
        /// This method exposes the <see cref="IBuilder.Build{TProduct}"/> 
        /// method on a <see cref="BuilderBase"/> object, in order to avoid the 
        /// need to contantly downcast.
        /// </summary>
        /// <typeparam name="TProduct">The product type associated with the 
        /// builder.</typeparam>
        /// <param name="builder">A <see cref="BuilderBase"/> reference.</param>
        /// <returns>The newly built product instance.</returns>
        public static TProduct Build<TProduct>(
            this BuilderBase builder
        ) where TProduct : IBuilderProduct, new()
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(builder, nameof(builder));

            // Downcast and perform the operation.
            return ((IBuilder)builder).Build<TProduct>();
        }

        #endregion
    }
}
