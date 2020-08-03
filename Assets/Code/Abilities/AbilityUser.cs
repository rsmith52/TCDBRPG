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

        public void AimAbility(Target target_type)
        {
            state = State.Targeting;
            switch (target_type)
            {
                case Target.Self:
                    target = transform;
                    break;
                case Target.Direction:
                    target = TargetDirection();
                    break;
                case Target.Area:
                    target = TargetArea();
                    break;
                case Target.None:
                    target = null;
                    break;
                default:
                    target = null;
                    break;
            }
        }

        // These methods must be implemented by classes implementing this
        protected abstract Transform TargetDirection();
        protected abstract Transform TargetArea();

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