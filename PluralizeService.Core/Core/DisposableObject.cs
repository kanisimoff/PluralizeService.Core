using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PluralizationService.Core
{
    /// <summary>
    /// This class is a helper base class for creating disposable objects 
    /// without having to manually implement the .NET disposable pattern 
    /// everywhere.
    /// </summary>
    public abstract class DisposableObject : IDisposable
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property indicates whether the object has ever been disposed.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected bool IsDisposed { get; private set; }

        #endregion

        // *******************************************************************
        // IDisposable implementation.
        // *******************************************************************

        #region IDisposable implementation

        /// <summary>
        /// This method performs application-defined tasks associated with 
        /// freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            // Only dispose ther object once.
            if (!IsDisposed)
                OnDispose();

            // We're now disposed!
            IsDisposed = true;
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is called when the object is disposed.
        /// </summary>
        protected virtual void OnDispose()
        {

        }

        #endregion
    }
}
