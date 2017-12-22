using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PluralizationService.Properties;

namespace PluralizationService.Core
{
    /// <summary>
    /// This class represents a "fluent style" API for containing commonly used 
    /// parameter validations. 
    /// </summary>
    public class Guard
    {
        // ******************************************************************
        // Public methods.
        // ******************************************************************

        #region Public methods

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains a FALSE value.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a FALSE value.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfFalse(bool, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = false;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfFalse(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfFalse(
            bool argValue,
            string argName
        )
        {
            if (!argValue)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgIsFalse
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains a TRUE value.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a FALSE value.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfTrue(bool, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = true;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfTrue(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfTrue(
            bool argValue,
            string argName
        )
        {
            if (argValue)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgIsTrue
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains a value that is not a writable stream.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a stream that 
        /// is not writable.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNotWritable(Stream, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = new FileStream("test.doc", FileMode.Open, FileAccess.Read);
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNotWritable(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNotWritable(
            Stream argValue,
            string argName
        )
        {
            if (!argValue.CanWrite)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgNotWritable
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains a value that is not a readable stream.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a stream that 
        /// is not readable.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNotReadable(Stream, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = new FileStream("test.doc", FileMode.Open, FileAccess.Write);
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNotReadable(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNotReadable(
            Stream argValue,
            string argName
        )
        {
            if (!argValue.CanRead)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgNotReadable
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains a value that is less than or equal to zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// less than or equal to zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfLessThanOrEqualZero(int, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 0;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfLessThanOrEqualZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfLessThanOrEqualZero(
            int argValue,
            string argName
        )
        {
            if (argValue <= 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgLessThanEqualZero
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the '<paramref name="argValue"/>
        /// argument contains a value that is less than or equal to zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// less than or equal to zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfLessThanOrEqualZero(long, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 0;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfLessThanOrEqualZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfLessThanOrEqualZero(
            long argValue,
            string argName
        )
        {
            if (argValue <= 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgLessThanEqualZero
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains a value that is less than zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// less than zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfLessThanZero(long, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = -1;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfLessThanZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfLessThanZero(
            int argValue,
            string argName
        )
        {
            if (argValue < 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgLessThanZero
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains a value that is less than zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// less than zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfLessThanZero(long, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = -1;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfLessThanZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfLessThanZero(
            long argValue,
            string argName
        )
        {
            if (argValue < 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgLessThanZero
                );

            return this;
        }

        // *******************************************************************

        /// <summary>
        /// This method will throw an exception if the <paramref name="argValue"/>
        /// argument is less than the <paramref name="amount"/> argument.
        /// </summary>
        /// <param name="argValue">The argument to be validated.</param>
        /// <param name="amount">The amount to be used for validation.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// less than the <paramref name="amount"/> argument.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfLessThan(int, int, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 1;
        /// 
        ///         // make the value to compare it against.
        ///         var amount = 2; 
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfLessThan(arg, amount, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfLessThan(
            int argValue,
            int amount,
            string argName
        )
        {
            if (argValue < amount)
                throw new ArgumentException(
                    argName,
                    string.Format(
                        Resources.Guard_ArgLessThan,
                        amount
                    )
                );
            return this;
        }

        // *******************************************************************

        /// <summary>
        /// This method will throw an exception if the <paramref name="argValue"/>
        /// argument is less than the <paramref name="amount"/> argument.
        /// </summary>
        /// <param name="argValue">The argument to be validated.</param>
        /// <param name="amount">The amount to be used for validation.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// less than the <paramref name="amount"/> argument.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfLessThan(long, long, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 1;
        /// 
        ///         // make the value to compare it against.
        ///         var amount = 2; 
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfLessThan(arg, amount, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfLessThan(
            long argValue,
            long amount,
            string argName
        )
        {
            if (argValue < amount)
                throw new ArgumentException(
                    argName,
                    string.Format(
                        Resources.Guard_ArgLessThan,
                        amount
                    )
                );
            return this;
        }

        // *******************************************************************

        /// <summary>
        /// This method will throw an exception if the <paramref name="argValue"/> 
        /// argument is greater than the <paramref name="amount"/> argument. 
        /// </summary>
        /// <param name="argValue">The argument to be validated.</param>
        /// <param name="amount">The amount to be used for validation.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// greater than the <paramref name="amount"/> argument.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfGreaterThan(int, int, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 2;
        /// 
        ///         // make the value to compare it against.
        ///         var amount = 1; 
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfGreaterThan(arg, amount, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfGreaterThan(
            int argValue,
            int amount,
            string argName
        )
        {
            if (argValue > amount)
                throw new ArgumentException(
                    argName,
                    string.Format(
                        Resources.Guard_ArgGreaterThan,
                        amount
                    )
                );
            return this;
        }

        // *******************************************************************

        /// <summary>
        /// This method will throw an exception if the <paramref name="argValue"/> 
        /// argument is greater than the <paramref name="amount"/> argument. 
        /// </summary>
        /// <param name="argValue">The argument to be validated.</param>
        /// <param name="amount">The amount to be used for validation.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// greater than the <paramref name="amount"/> argument.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfGreaterThan(long, long, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 2;
        /// 
        ///         // make the value to compare it against.
        ///         var amount = 1; 
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfGreaterThan(arg, amount, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfGreaterThan(
            long argValue,
            long amount,
            string argName
        )
        {
            if (argValue > amount)
                throw new ArgumentException(
                    string.Format(
                        argName,
                        Resources.Guard_ArgGreaterThan,
                        amount
                    )
                );
            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains a zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfZero(int, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 0;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfZero(
            int argValue,
            string argName
        )
        {
            if (argValue == 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgZero
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains a zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfZero(long, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 0;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfZero(
            long argValue,
            string argName
        )
        {
            if (argValue == 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgZero
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains something other than zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// something other than zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNotZero(long, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 1;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNotZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNotZero(
            long argValue,
            string argName
        )
        {
            if (argValue != 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgNotZero
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains something other than zero.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a value that is
        /// something other than zero.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNotZero(int, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = 1;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNotZero(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNotZero(
            int argValue,
            string argName
        )
        {
            if (argValue != 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgNotZero
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains a null reference.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a null value.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNull(object, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = null;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNullOrEmpty(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNull(
            object argValue,
            string argName
        )
        {
            if (argValue == null)
                throw new ArgumentNullException(
                    argName,
                    Resources.Guard_ArgNullOrEmpty
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains a null reference or an empty string.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains an empty or null 
        /// string value.</exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNullOrEmpty(string, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = string.Empty;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNullOrEmpty(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNullOrEmpty(
            string argValue,
            string argName
        )
        {
            if (string.IsNullOrEmpty(argValue))
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgNullOrEmpty
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument does not contain a null reference or an empty string.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument does not contain an empty 
        /// or null string value.</exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNotNullOrEmpty(string, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = "testing, 1, 2, 3";
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNotNullOrEmpty(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNotNullOrEmpty(
            string argValue,
            string argName
        )
        {
            if (!string.IsNullOrEmpty(argValue))
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgNotNullOrEmpty
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains an empty collection reference.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains an empty 
        /// collection reference.</exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfEmptyCollection(ICollection, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = new ArrayList();
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfEmptyCollection(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfEmptyCollection(
            ICollection argValue,
            string argName
        )
        {
            if (argValue?.Count == 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgEmptyCollection
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains does not contain an empty collection reference.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument does not contain an 
        /// empty collection reference.</exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNotEmptyCollection(ICollection, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = new ArrayList();
        ///         arg.Add("1");
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowNotIfEmptyCollection(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNotEmptyCollection(
            ICollection argValue,
            string argName
        )
        {
            if (argValue?.Count > 0)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_ArgNotEmptyCollection
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains an empty GUID instance.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains an empty GUID.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfEmptyGuid(Guid, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = Guid.Empty;
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfEmptyGuid(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfEmptyGuid(
            Guid argValue,
            string argName
        )
        {
            if (argValue == Guid.Empty)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_EmptyGuid
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument does not contain an empty GUID instance.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument does not contain an 
        /// empty GUID.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfNotEmptyGuid(Guid, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = Guid.Parse("some guid value");
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfNotEmptyGuid(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfNotEmptyGuid(
            Guid argValue,
            string argName
        )
        {
            if (argValue != Guid.Empty)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_NotEmptyGuid
                );

            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains an invalid file path.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains an invalid file
        /// path.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfInvalidFilePath(string, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = "*";
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfInvalidFilePath(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfInvalidFilePath(
            string argValue,
            string argName
        )
        {
            if (string.IsNullOrEmpty(argValue) ||
                Path.GetFileName(argValue).IndexOfAny(Path.GetInvalidFileNameChars(), 0) != -1 ||
                Path.GetDirectoryName(argValue).IndexOfAny(Path.GetInvalidPathChars(), 0) != -1)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_InvalidFilePath
                );
            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/> 
        /// argument contains an invalid folder path.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains an invalid folder
        /// path.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfInvalidFolderPath(string, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = "*";
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfInvalidFolderPath(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfInvalidFolderPath(
            string argValue,
            string argName
        )
        {
            if (string.IsNullOrEmpty(argValue) ||
                Path.GetDirectoryName(argValue).IndexOfAny(Path.GetInvalidPathChars(), 0) != -1)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_InvalidFolderPath
                );
            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the <paramref name="argValue"/>
        /// argument contains an invalid file extension.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains an invalid file
        /// extension.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfInvalidFileExtension(string, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = "*";
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfInvalidFolderPath(arg, nameof(arg));
        ///    }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfInvalidFileExtension(
            string argValue,
            string argName
        )
        {
            if (string.IsNullOrEmpty(argValue) ||
                !argValue.StartsWith(".") ||
                argValue.Trim().Length <= 1 ||
                Path.GetExtension(argValue).IndexOfAny(Path.GetInvalidFileNameChars(), 0) != -1)
                throw new ArgumentException(
                    argName,
                    Resources.Guard_InvalidExtension
                );
            return this;
        }

        // ******************************************************************

        /// <summary>
        /// This method throws an exception if the "argValue" argument 
        /// contains a malformed URI.
        /// </summary>
        /// <param name="argValue">The argument to test.</param>
        /// <param name="argName">The name of the argument.</param>
        /// <returns>The object instance.</returns>
        /// <exception cref="ArgumentException">This exception is thrown when
        /// the <paramref name="argValue"/> argument contains a malformed uri.
        /// </exception>
        /// <example>
        /// This example shows how to call the <see cref="ThrowIfMalformedUri(string, string)"/>
        /// method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         // make an invalid argument.
        ///         var arg = "*";
        /// 
        ///         // throws an exception, since the argument is invalid.
        ///         new Guard().ThrowIfMalformedUri(arg, nameof(arg));
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual Guard ThrowIfMalformedUri(
            string argValue,
            string argName
        )
        {
            if (!Uri.IsWellFormedUriString(argValue, UriKind.RelativeOrAbsolute))
                throw new ArgumentException(
                    argName,
                    Resources.Guard_MalformedUri
                );
            return this;
        }

        #endregion
    }
}
