using System;
using System.Collections.Generic;
using System.Text;
using PluralizationService.Core;

namespace PluralizationService.English.Adapters
{
    /// <summary>
    /// This class is a 2-way dictionary.
    /// </summary>
    /// <typeparam name="TFirst">The type associated with the 1st type.</typeparam>
    /// <typeparam name="TSecond">The type associated with the 2nd type.</typeparam>
    internal class BidirectionalDictionary<TFirst, TSecond>
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a dictionary of 1st to 2nd relations.
        /// </summary>
        protected Dictionary<TFirst, TSecond> FirstToSecondDictionary { get; set; }

        // *******************************************************************

        /// <summary>
        /// This property contains a dictionary of 2nd to 1st relations.
        /// </summary>
        protected Dictionary<TSecond, TFirst> SecondToFirstDictionary { get; set; }

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="BidirectionalDictionary{TFirst, TSecond}"/>
        /// class.
        /// </summary>
        public BidirectionalDictionary()
        {
            FirstToSecondDictionary = new Dictionary<TFirst, TSecond>();
            SecondToFirstDictionary = new Dictionary<TSecond, TFirst>();
        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="BidirectionalDictionary{TFirst, TSecond}"/>
        /// class.
        /// </summary>
        /// <param name="firstToSecondDictionary">A dictionary of 1st to 2nd relations.</param>
        public BidirectionalDictionary(
            Dictionary<TFirst, TSecond> firstToSecondDictionary
        ) : this()
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(firstToSecondDictionary, nameof(firstToSecondDictionary));

            // Loop and add the keys.
            foreach (var key in firstToSecondDictionary.Keys)
                AddValue(key, firstToSecondDictionary[key]);
        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method adds a new relationship to the dictionary.
        /// </summary>
        /// <param name="firstValue">The 1st value in the relationship.</param>
        /// <param name="secondValue">The 2nd value in the realtionship.</param>
        public void AddValue(
            TFirst firstValue,
            TSecond secondValue
        )
        {
            // Validate the parameters before attempting to use them.
            new Guard().ThrowIfNull(firstValue, nameof(firstValue))
                .ThrowIfNull(secondValue, nameof(secondValue));

            // Add the relationship to the first dictionary.
            FirstToSecondDictionary.Add(
                firstValue,
                secondValue
            );

            // Should we add the relationship to the second dictionary?
            if (!SecondToFirstDictionary.ContainsKey(secondValue))
                SecondToFirstDictionary.Add(
                    secondValue,
                    firstValue
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates wether a value exists as a 1st relation.
        /// </summary>
        /// <param name="value">The value to use for the operation.</param>
        /// <returns>true if the value exists; false otherwise.</returns>
        public virtual bool ExistsInFirst(
            TFirst value
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(value, nameof(value));

            // Does the value exist in the internal dictionary?
            if (FirstToSecondDictionary.ContainsKey(value))
                return true;

            // Not there.
            return false;
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates wether a value exists as a 2nd relation.
        /// </summary>
        /// <param name="value">The 2nd value to use for the operation.</param>
        /// <returns>true if the value exists; false otherwise.</returns>
        public virtual bool ExistsInSecond(
            TSecond value
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(value, nameof(value));

            // Does the value exist in the internal dictionary?
            if (SecondToFirstDictionary.ContainsKey(value))
                return true;

            // Not there.
            return false;
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the value 1st related to the specified 2nd value.
        /// </summary>
        /// <param name="value">The 1st value to use for the operation.</param>
        /// <returns>The related 2nd value (if one exists).</returns>
        public virtual TFirst GetFirstValue(
            TSecond value
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(value, nameof(value));

            // Does the value exist in the internal dictionary?
            if (!ExistsInSecond(value))
                return default(TFirst);

            // Return the related value.
            return SecondToFirstDictionary[value];
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the value 2nd related to the specified 1st value.
        /// </summary>
        /// <param name="value">The 2nd value to use for the operation.</param>
        /// <returns>The related 1st value (if one exists).</returns>
        public virtual TSecond GetSecondValue(
            TFirst value
        )
        {
            // Validate the parameter before attempting to use it.
            new Guard().ThrowIfNull(value, nameof(value));

            // Does the value exist in the internal dictionary?
            if (!ExistsInFirst(value))
                return default(TSecond);

            // Return the related value.
            return FirstToSecondDictionary[value];
        }

        #endregion
    }
}
