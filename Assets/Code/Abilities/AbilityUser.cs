using System.Collections;
using System.Collections.Generic;
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
        Targeting,
        Activating,
        Occuring,
        Finished
    }

    public abstract class AbilityUser : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected GameObject character = null;

        #endregion


        #region Fields

        private State state;

        #endregion


        #region MonoBehavior

        protected virtual Transform SetTarget()
        {
            return transform;
        }

        protected virtual GameObject SetTargetCharacter()
        {
            return gameObject;
        }

        public void UseAbility()
        {
            // Get Target (targeting)

            // Show animation on user (Activating)

            // Perform ability (Occuring)

            // Show animation on target (Finished)
        }

        #endregion

    }
}