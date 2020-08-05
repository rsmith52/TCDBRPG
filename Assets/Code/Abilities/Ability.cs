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
        Melee,
        Projectile,
        Enemy,
        Ally,
        Line,
        Cone,
        Square,
        None
    };

    #endregion

    public class Ability : MonoBehaviour
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
        public int reach = 0;

        [Header("Relations")]
        [SerializeField]
        public GameObject prefab = null;

        #endregion

    }
}