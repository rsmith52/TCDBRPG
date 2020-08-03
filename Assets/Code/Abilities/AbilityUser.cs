using UnityEngine;
using Cards;

/*
 * This code contains the basic setup and information for a character that can
 * use abilities.
 */

namespace Abilities
{
    public enum State
    {
        Waiting,
        Targeting,
        Activating
    };

    public abstract class AbilityUser : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected GameObject character = null;

        #endregion


        #region Fields

        public State state; // MAKE PRIVATE
        public Transform target; // MAKE PRIVATE
        protected TargetType target_type;

        #endregion


        #region MonoBehavior

        protected virtual void Start()
        {
            this.target_type = TargetType.None;
            target = null;
            state = State.Waiting;
        }

        public void AimAbility()
        {
            return;
        }

        // These methods must be implemented by classes implementing this
        protected abstract Transform SetTarget();

        public void UseAbility(Ability ability, Transform target)
        {
            state = State.Activating;
            // Show animation on user
            // Wait activation time
            // Remove mana

            state = State.Waiting; // This allows other abilities to be used while the first continues to resolve
            // Perform ability
            // Determine results
            // Show animation on target
            // Apply results
        }

        public void Cancel()
        {
            target_type = TargetType.None;
            target = null;
            state = State.Waiting;
        }

        protected bool DistanceInRange(Vector3 other_pos, float range)
        {
            Vector3 player_pos = transform.position;

            Vector3 offset = other_pos - player_pos;
            float sqlen = offset.sqrMagnitude;

            return sqlen <= range * range;
        }

        #endregion

    }
}