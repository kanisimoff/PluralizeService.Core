using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PluralizationService.Core.Builder.Base
{
    /// <summary>
    /// This class is a helper base class intended to make the process of 
    /// creating concrete products a little easier and cleaner.
    /// </summary>
    public abstract class ProductBase : DisposableObject, IBuilderProduct
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly List<IBuilderProvider> _providers = new List<IBuilderProvider>();

        #endregion

        // *******************************************************************
        // IProduct implementation.
        // *******************************************************************

        #region IProduct implementation

        /// <summary>
        /// This property contains a collection of providers.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IEnumerable<IBuilderProvider> IBuilderProduct.Providers { get { return _providers; } }

        // *******************************************************************

        /// <summary>
        /// This method adds a new provider to the product.
        /// </summary>
        /// <param name="provider">The provider to add.</param>
        void IBuilderProduct.AddProvider(IBuilderProvider provider)
        {
            _providers.Add(provider);
        }

        // *******************************************************************

        /// <summary>
        /// This method initializes the product for use.
        /// </summary>
        void IBuilderProduct.Initialize()
        {
            // Initialize the product.
            OnInitialize();
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is called when the product is initialized by the builder.
        /// </summary>
        protected virtual void OnInitialize()
        {

        }

        #endregion
    }
}
