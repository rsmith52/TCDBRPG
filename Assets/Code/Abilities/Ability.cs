using UnityEngine;
using Cards;
using Stats;

/*
 * This code defines abilities, including those activated
 * by cards, class ability, and monsters.
 */

namespace Abilities
{
    #region Enums

    public enum Target
    {
        Self,
        Direction,
        Area,
        Single_Ally,
        Single_Enemy
    }

    public enum Weapon
    {
        Sword,
        Bow,
        Dagger,
        Staff
    }

    #endregion


    [CreateAssetMenu(fileName = "Ability", menuName = "Data/Ability", order = 3)]
    public class Ability : ScriptableObject
    {
        #region ScriptableObject

        [Header("General")]
        [SerializeField]
        protected new string name = "Ability Name";
        [SerializeField]
        [TextArea]
        protected string description = "Ability Description";
        [SerializeField]
        protected Sprite icon = null;
        [SerializeField]
        protected Class ability_class = null;

        [Header("Mechanics")]
        [SerializeField]
        protected int mana_cost = 0;
        [SerializeField]
        protected Target target = Target.Self;
        [SerializeField]
        protected float damage = 0;
        [SerializeField]
        protected float range = 0;

        [Header("Relations")]
        [SerializeField]
        protected GameObject prefab = null;

        [Header("Visuals")]
        [SerializeField]
        protected Weapon weapon = Weapon.Sword;
        [SerializeField]
        protected Animation self_animation = null;
        [SerializeField]
        protected Animation target_animation = null;

        #endregion

    }
}