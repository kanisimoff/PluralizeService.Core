using System;
using System.Collections.Generic;
using System.Text;
using PluralizationService.Core.Builder;
using PluralizationService.Core.Builder.Base;
using PluralizationService.English.Providers;
using PluralizationService.Sources;

namespace PluralizationService.English.Sources
{
    internal class EnglishMetaDataSource : SourceBase, IPluralizationSource
    {
        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        protected override IBuilderProvider OnBuild(IBuilder builder)
        {
            return new EnglishMetaDataProvider(this);
        }


        #endregion
    }
}
