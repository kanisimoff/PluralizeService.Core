using System;
using System.Collections.Generic;
using System.Text;
using PluralizationService.Core.Builder;
using PluralizationService.Core.Builder.Base;
using PluralizationService.Core.Builder.Base.Extensions;

namespace PluralizationService
{
    /// <summary>
    /// This class builds instances of <see cref="IPluralizationApi"/>
    /// </summary>
    public class PluralizationApiBuilder : BuilderBase
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="PluralizationApiBuilder"/>
        /// class.
        /// </summary>
        public PluralizationApiBuilder() { }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="PluralizationApiBuilder"/>
        /// class.
        /// </summary>
        /// <param name="parentProvider">A parent provider reference, for constructing
        /// a <see cref="IBuilderProvider"/> reference as part of a larger object graph.</param>
        public PluralizationApiBuilder(
            IBuilderProvider parentProvider
        ) : base(parentProvider)
        {

        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method builds up an instance of <see cref="IPluralizationApi"/>
        /// </summary>
        /// <returns>An instance of <see cref="IPluralizationApi"/></returns>
        public virtual IPluralizationApi Build()
        {
            // Build the API instance.
            return this.Build<DefaultPluralizationApi>();
        }

        #endregion
    }
}
