using UnityEngine;

/*
 * This code contains some general card metadata, and creates the base Card
 * ScriptableObject that all types of cards will extend from.
 */

namespace Cards
{
    #region Enums

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary
    };

    #endregion


    [CreateAssetMenu(fileName = "Card", menuName = "Data/Card", order = 1)]
    public class Card : ScriptableObject
    {
        #region ScriptableObject

        protected new string name = "Card Name";
        protected string description = "Card Description";
        protected Sprite icon = null;

        protected int mana_cost = 0;
        protected Rarity rarity = Rarity.Common;
        protected int value = 0;

        #endregion

    }
}