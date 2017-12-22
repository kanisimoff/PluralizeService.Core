using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PluralizationService.Properties;
using PluralizationService.Core.Builder.Base.Extensions;

namespace PluralizationService.Core.Builder.Base
{
    /// <summary>
    /// This class is a helper base class intended to make the process of 
    /// creating concrete builders a little easier and cleaner.
    /// </summary>
    public abstract class BuilderBase : IBuilder
    {
        // ******************************************************************* 
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains a list of sources.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IList<IBuilderSource> _sources = new List<IBuilderSource>();

        /// <summary>
        /// This field contains a collection of external providers.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IEnumerable<IBuilderProvider> _externalProviders;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="BuilderBase"/>
        /// class.
        /// </summary>
        protected BuilderBase()
        {

        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="BuilderBase"/>
        /// class, that is embedded inside an existing parent product. 
        /// </summary>
        /// <param name="parentProduct">A parent product reference.</param>
        protected BuilderBase(
            IBuilderProduct parentProduct
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(parentProduct, nameof(parentProduct));

            // Save the collection of providers.
            _externalProviders = parentProduct.Providers;
        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="BuilderBase"/>
        /// class, that is embedded inside an existing parent product. 
        /// </summary>
        /// <param name="parentProvider">A parent provider reference.</param>
        protected BuilderBase(
            IBuilderProvider parentProvider
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(parentProvider, nameof(parentProvider));

            // Save the collection of child providers.
            _externalProviders = parentProvider.Children;
        }

        #endregion

        // ******************************************************************* 
        // IBuilder implementation.
        // *******************************************************************

        #region IBuilder implementation

        /// <summary>
        /// This property contains a collection of sources.
        /// </summary>
        IEnumerable<IBuilderSource> IBuilder.Sources { get { return _sources; } }

        // *******************************************************************

        /// <summary>
        /// This method is used to add a new source to the builder.
        /// </summary>
        /// <param name="source">The source to be added.</param>
        /// <returns>The builder instance.</returns>
        IBuilder IBuilder.AddSource(
            IBuilderSource source
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(source, nameof(source));

            // Add the source.
            _sources.Add(source);

            // Return the builder instance.
            return this;
        }

        // *******************************************************************

        /// <summary>
        /// This method builds the specified product instance.
        /// </summary>
        /// <typeparam name="TProduct">The type of product to build.</typeparam>
        /// <returns>A new product instance.</returns>
        TProduct IBuilder.Build<TProduct>()
        {
            // If there are no external providers then we'll need to insist 
            //   that the builder contains at least one source.
            if (_externalProviders?.Count() == 0)
            {
                // The builder requires at least one source before it can build 
                //   anything.
                if (this.Sources().Count() == 0)
                    throw new BuilderException(
                        Resources.BuilderBase_NoSources
                    );
            }

            // Create a product instance.
            var product = new TProduct();

            // Should we add providers from a parent product?
            if (_externalProviders?.Count() > 0)
            {
                // Add any external providers.
                foreach (var provider in _externalProviders)
                    product.AddProvider(provider);
            }

            // Loop and build providers from the sources.
            foreach (var source in _sources)
            {
                // Build up the provider from the source.
                var provider = source.Build(this);

                // Add the provider to the product.
                product.AddProvider(provider);
            }

            // Initialize the product after building it.
            product.Initialize();

            // Return the product instance.
            return product;
        }

        #endregion
    }
}
