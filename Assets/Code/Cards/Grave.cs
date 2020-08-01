/*
 * This code defines the grave zone, where cards go after being cast.
 * It includes the list of cards, as well as various methods for interacting
 * with the grave.
 */

using System.Collections.Generic;

namespace Cards
{
    [System.Serializable]
    public class Grave
    {
        #region Fields

        protected List<Card> cards;

        #endregion


        #region Constructor

        public Grave()
        {
            cards = new List<Card>();
        }

        #endregion

    }
}