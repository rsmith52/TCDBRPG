using UnityEngine;

/*
 * This code stores constant values used throughout the game.
 */

namespace Utilities
{
    public class Constants
    {
        #region Movement

        public static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");
        public static readonly float GROUND_DIST = 0.1f;
        public static readonly float AIR_CONTROL_MOD = 0.035f;

        #endregion

    }
}
