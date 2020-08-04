using UnityEngine;
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
        Square,
        None
    };

    #endregion


    [CreateAssetMenu(fileName = "Ability", menuName = "Data/Ability", order = 4)]
    public class Ability : ScriptableObject
    {
        #region ScriptableObject

        [Header("General")]
        [SerializeField]
        public new string name = "Ability Name";
        [SerializeField]
        [TextArea]
        public string description = "Ability Description";
        [SerializeField]
        public Sprite icon = null;
        [SerializeField]
        public Class ability_class = null;

        [Header("Mechanics")]
        [SerializeField]
        public int mana_cost = 0;
        [SerializeField]
        public TargetType target_type = TargetType.Self;
        [SerializeField]
        public int area_size = 0;
        [SerializeField]
        public float activation_time = 0;
        [SerializeField]
        public float damage = 0;
        [SerializeField]
        public float range = 0;

        [Header("Relations")]
        [SerializeField]
        public GameObject prefab = null;

        [Header("Visuals")]
        [SerializeField]
        public Weapon weapon = Weapon.Sword;
        [SerializeField]
        public Animation self_animation = null;
        [SerializeField]
        public Animation target_animation = null;

        #endregion

    }
}