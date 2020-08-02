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


        #region Scenes

        public static readonly int PVE_SCENE = 1;

        #endregion


        #region UI

        public static readonly int HUD_X_OFFSET = 75;
        public static readonly int HP_Y_OFFSET = -75;
        public static readonly int HP_SPACING = 60;
        public static readonly int MANA_Y_OFFSET = -150;
        public static readonly int MANA_SPACING = 50;

        #endregion


        #region World

        public static readonly string MANA_RING_NAME = "Mana Ring(Clone)";

        #endregion

    }
}