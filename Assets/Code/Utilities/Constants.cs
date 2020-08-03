using UnityEngine;

/*
 * This code stores constant values used throughout the game.
 */

namespace Utilities
{
    public class Constants
    {
        #region AI

        public static readonly float WAYPOINT_DISTANCE = 1f;
        public static readonly float REPATH_RATE = 0.5f;

        #endregion


        #region Layers

        public static readonly int PLAYER_LAYER = 8;
        public static readonly int ENEMY_LAYER = 9;
        public static readonly int ALLY_LAYER = 13;

        #endregion


        #region Movement

        public static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");
        public static readonly float GROUND_DIST = 0.1f;
        public static readonly float AIR_CONTROL_MOD = 0.035f;

        #endregion


        #region Scenes

        public static readonly int PVE_SCENE = 1;

        #endregion


        #region UI

        // HUD
        public static readonly int HUD_X_OFFSET = 75;
        public static readonly int HP_Y_OFFSET = -75;
        public static readonly int HP_SPACING = 60;
        public static readonly int MANA_Y_OFFSET = -150;
        public static readonly int MANA_SPACING = 50;

        // Health Bars
        public static readonly float HEALTH_BAR_SIZE = 1.5f;
        public static readonly float HEALTH_BAR_HIDE_TIME = 2.5f; // seconds

        #endregion


        #region World

        public static readonly string MANA_RING_NAME = "Mana Ring(Clone)";
        public static readonly float MANA_RING_SIZE = 12f;

        #endregion

    }
}