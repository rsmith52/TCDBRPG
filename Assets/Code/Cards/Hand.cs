/*
 * This code defines the hand, where cards that are currently able to be
 * cast go. It also includes various methods for interacting with the hand.
 */

using System.Collections.Generic;

namespace Cards
{
    [System.Serializable]
    public class Hand
    {
        #region Fields

        protected List<Card> cards;

        #endregion


        #region Constructor

        public Hand()
        {
            cards = new List<Card>();
        }

        #endregion

    }
}