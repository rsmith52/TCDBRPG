using UnityEngine;
using Movement;
using Stats;
using Utilities;

/*
 * This code defines a weapon. It also handles applying damage to struck 
 * creatures.
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

        [Header("Animation")]
        [SerializeField]
        public float animation_length = 1f;

        [Header("Mechanics")]
        [SerializeField]
        public TargetType target = TargetType.Melee;

        [SerializeField]
        public int damage = 1;

        #endregion


        #region MonoBehavior

        protected void Damage(GameObject other)
        {
            // Apply damage
            CharacterStats stats = other.GetComponent<CharacterStats>();
            stats.health.ChangeCurValue(-1 * damage);

            // Show damaged animation
            Animator animator = other.GetComponentInChildren<Animator>();
            animator.SetTrigger(Constants.WAS_HIT_PROPERTY);
        }

        #endregion

    }
}