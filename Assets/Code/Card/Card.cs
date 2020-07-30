using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
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

        protected new string name;
        protected string description;
        protected Sprite icon;

        protected int mana_cost;
        protected Rarity rarity;
        protected int value;

        #endregion

    }
}
