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

    public enum TargetType
    {
        Self,
        Immediate,
        Projectile,
        Enemy,
        Ally,
        Line,
        Cone,
        Circle,
        Square,
        None
    };

    public enum TargetArea
    {
        Small,
        Medium,
        Large,
        None
    }

    public enum Weapon
    {
        Sword,
        Bow,
        Dagger,
        Staff
    };

    #endregion


    [CreateAssetMenu(fileName = "Ability", menuName = "Data/Ability", order = 4)]
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
        protected TargetType target_type = TargetType.Self;
        [SerializeField]
        protected TargetArea target_area = TargetArea.Medium;
        [SerializeField]
        protected float activation_time = 0;
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