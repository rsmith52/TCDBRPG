using UnityEngine;
using Abilities;
using Stats;

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


    [CreateAssetMenu(fileName = "Card", menuName = "Data/Card", order = 3)]
    public class Card : ScriptableObject
    {
        #region ScriptableObject

        [Header("General")]
        [SerializeField]
        protected new string name = "Card Name";
        [SerializeField]
        [TextArea]
        protected string description = "Card Description";
        [SerializeField]
        protected Rarity rarity = Rarity.Common;
        [SerializeField]
        protected Class card_class = null;
        [SerializeField]
        protected Sprite icon = null;

        [Header("Mechanics")]
        [SerializeField]
        protected int mana_cost = 0;
        [SerializeField]
        protected Ability ability = null;

        #endregion

    }
}