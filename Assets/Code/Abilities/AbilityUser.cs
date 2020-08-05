using UnityEngine;
using Stats;
using Utilities;

/* 
 * This code contains the basic information and setup needed for a character
 * that can move. Player controlled characters and AI controlled characters
 * extend from this.
 */

namespace Abilities
{
    public abstract class AbilityUser : MonoBehaviour
    {
        #region Inspector
        #endregion


        #region Fields
        #endregion


        #region MonoBehavior

        protected virtual void Start()
        {
        }

        private void FixedUpdate()
        {
        }

        #endregion

    }
}