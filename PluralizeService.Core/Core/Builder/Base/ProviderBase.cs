using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PluralizationService.Core.Builder.Base
{
    /// <summary>
    /// This class is a helper base class intended to make the process of 
    /// creating concrete providers a little easier and cleaner.
    /// </summary>
    public abstract class ProviderBase : IBuilderProvider
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field contains the source for this provider.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IBuilderSource _source;

        /// <summary>
        /// This field contains a list of child providers.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IList<IBuilderProvider> _children = new List<IBuilderProvider>();

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="ProviderBase"/>
        /// class.
        /// </summary>
        /// <param name="source">A source for the provider.</param>
        protected ProviderBase(
            IBuilderSource source
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(source, nameof(source));

            // Save the reference.
            _source = source;
        }

        #endregion        

        // *******************************************************************
        // IBuilderProvider implementation.
        // *******************************************************************

        #region IBuilderProvider implementation

        /// <summary>
        /// This property contains an assoicated source.
        /// </summary>
        IBuilderSource IBuilderProvider.Source { get { return _source; } }

        // *******************************************************************

        /// <summary>
        /// This property contains a collection of child providers.
        /// </summary>
        IEnumerable<IBuilderProvider> IBuilderProvider.Children { get { return _children; } }

        // *******************************************************************

        /// <summary>
        /// This method adds a child to the provider.
        /// </summary>
        /// <param name="provider">The provider to add.</param>
        void IBuilderProvider.AddChild(
            IBuilderProvider provider
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(provider, nameof(provider));

            // Add the child provider.
            _children.Add(provider);
        }

        #endregion
    }
}
