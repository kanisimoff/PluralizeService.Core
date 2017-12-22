using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService
{
    /// <summary>
    /// This class represents a pluralization related exception.
    /// </summary>
    public class PluralizationException : Exception
    {
        // ******************************************************************
        // Constructors.
        // ******************************************************************

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PluralizationException"/> class.
        /// </summary>
        public PluralizationException()
        {

        }

        // ******************************************************************

        /// <summary>
        /// Creates a new instance of the <see cref="PluralizationException"/> 
        /// class with a specified error message and a reference to the inner 
        /// exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason 
        /// for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the 
        /// current exception. If the innerException parameter is not a null 
        /// reference (Nothing in Visual Basic), the current exception is raised 
        /// in a catch block that handles the inner exception.</param>
        public PluralizationException(
            string message,
            Exception innerException
        ) : base(message, innerException)
        {

        }

        // ******************************************************************

        /// <summary>
        /// Creates a new instance of the <see cref="PluralizationException"/> 
        /// class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason 
        /// for the exception.</param>
        public PluralizationException(string message)
            : base(message)
        {

        }

        #endregion
    }
}
