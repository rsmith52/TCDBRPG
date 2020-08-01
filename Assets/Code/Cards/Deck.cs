using System.Collections.Generic;
using UnityEngine;

/* 
 * This code defines what a deck is, including the list of cards.
 * It also holds various methods for interacting with the deck.
 */

namespace Cards
{
    [System.Serializable]
    public class Deck : CardZone
    {
        #region Fields

        protected List<Card> cards;

        #endregion


        #region Constructor

        public Deck()
        {
            cards = new List<Card>();
        }

        #endregion


        #region Methods

        public bool AddCard(Card card)
        {
            return true;
        }

        public bool RemoveCard(Card card)
        {
            return true;
        }

        public void Shuffle()
        {
            return;
        }

        public Card Draw()
        {
            return ScriptableObject.CreateInstance<Card>();
        }

        #endregion

    }
}