using UnityEngine;

namespace Cards
{
    #region Enums

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        VeryRare,
        Legendary
    };

    #endregion


    public abstract class Card : ScriptableObject
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
