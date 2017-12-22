using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.English.Adapters
{
    /// <summary>
    /// This class is a 2-way dictionary for strings.
    /// </summary>
    internal class StringBidirectionalDictionary : BidirectionalDictionary<string, string>
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="StringBidirectionalDictionary"/>
        /// class.
        /// </summary>
        public StringBidirectionalDictionary()
        {

        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="StringBidirectionalDictionary"/>
        /// class.
        /// </summary>
        /// <param name="firstToSecondDictionary">A dictionary of 1st to 2nd relations.</param>
        public StringBidirectionalDictionary(
            Dictionary<string, string> firstToSecondDictionary
        ) : base(firstToSecondDictionary)
        {

        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method indicates wether a value exists as a 1st relation.
        /// </summary>
        /// <param name="value">The value to use for the operation.</param>
        /// <returns>true if the value exists; false otherwise.</returns>
        public override bool ExistsInFirst(
            string value
        )
        {
            return base.ExistsInFirst(
                value.ToLowerInvariant()
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method indicates wether a value exists as a 2nd relation.
        /// </summary>
        /// <param name="value">The 2nd value to use for the operation.</param>
        /// <returns>true if the value exists; false otherwise.</returns>
        public override bool ExistsInSecond(string value)
        {
            return base.ExistsInSecond(
                value.ToLowerInvariant()
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the value 1st related to the specified 2nd value.
        /// </summary>
        /// <param name="value">The 1st value to use for the operation.</param>
        /// <returns>The related 2nd value (if one exists).</returns>
        public override string GetFirstValue(string value)
        {
            return base.GetFirstValue(
                value.ToLowerInvariant()
            );
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the value 2nd related to the specified 1st value.
        /// </summary>
        /// <param name="value">The 2nd value to use for the operation.</param>
        /// <returns>The related 1st value (if one exists).</returns>
        public override string GetSecondValue(
            string value
        )
        {
            return base.GetSecondValue(
                value.ToLowerInvariant()
            );
        }

        #endregion
    }
}
