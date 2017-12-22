using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Builder.Base
{
    /// <summary>
    /// This class is a helper base class intended to make the process of 
    /// creating concrete providers a little easier and cleaner. This class
    /// contains a typed reference to an associated builder source, removing
    /// the need for yet another downcast operation whenever a provider needs
    /// access to it's corresponding source.
    /// </summary>
    /// <typeparam name="TSource">A source type to associate with the provider.</typeparam>
    public abstract class TypedProviderBase<TSource> : ProviderBase
        where TSource : SourceBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a typed source reference.
        /// </summary>
        public TSource TypedSource
        {
            get { return ((IBuilderProvider)this).Source as TSource; }
        }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="TypedProviderBase{TSource}"/>
        /// class.
        /// </summary>
        /// <param name="source">A source for the provider.</param>
        protected TypedProviderBase(
            IBuilderSource source
        ) : base(source)
        {

        }

        #endregion        
    }
}
