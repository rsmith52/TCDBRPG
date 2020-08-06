using UnityEngine;
using Movement;
using Stats;
using Utilities;

/*
 * This code defines a weapon.
 */

namespace Abilities
{
    public abstract class Weapon : MonoBehaviour
    {
        #region Inspector

        [Header("General")]
        [SerializeField]
        public new string name = "Weapon Name";

        [SerializeField]
        [TextArea]
        public string description = "Weapon Description";

        [Header("Visuals")]
        [SerializeField]
        public float animation_length = 1f;

        [SerializeField]
        public float offset_from_character_mod = 0; // higher is closer to character

        [Header("Mechanics")]
        [SerializeField]
        public TargetType target = TargetType.Melee;

        [SerializeField]
        public int damage = 1;

        [Header("Ranged Extras")]
        [SerializeField]
        public GameObject projectile = null;

        [SerializeField]
        public float range = 0;

        [SerializeField]
        public float speed = 0;

        #endregion


        #region MonoBehavior
        #endregion

    }
}