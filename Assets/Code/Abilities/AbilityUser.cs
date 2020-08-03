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

        public State state;
        public Transform target;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            state = State.Waiting;
            target = null;
        }

        public void AimAbility(TargetType target_type)
        {
            state = State.Targeting;
            switch (target_type)
            {
                case TargetType.Self:
                    target = transform;
                    break;
                case TargetType.Immediate:
                    target = SetTarget(target_type, false);
                    break;
                case TargetType.Projectile:
                    target = SetTarget(target_type, false);
                    break;
                case TargetType.None:
                    target = null;
                    break;
                default:
                    // Enemy, Ally
                    // Line, Cone, Circle, Square
                    target = SetTarget(target_type, true);
                    break;
            }
        }

        // These methods must be implemented by classes implementing this
        protected abstract Transform SetTarget(TargetType target_type, bool show_area);

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
            target = null;
            state = State.Waiting;
        }

        #endregion

    }
}