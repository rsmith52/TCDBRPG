﻿using UnityEngine;

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


        #region Combat

        public static readonly float WEAPON_DIST_OFFSET = -0.5f;

        #endregion


        #region Layers

        public static readonly int PLAYER_LAYER = 8;
        public static readonly int ENEMY_LAYER = 9;
        public static readonly int ALLY_LAYER = 13;
        public static readonly int GROUND_LAYER = 10;
        public static readonly int OBJECT_LAYER = 11;

        #endregion


        #region Movement

        public static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");
        public static readonly float GROUND_DIST = 0.1f;
        public static readonly float AIR_CONTROL_MOD = 0.035f;
        public static readonly int WAS_HIT_PROPERTY = Animator.StringToHash("WasHit");
        public static readonly float ON_HIT_BOUNCE_FORCE = 10f;

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

        // Ability Bar
        public static readonly float ABILITY_BAR_X_OFFSET = 112.5f;
        public static readonly float ABILITY_BAR_X_SPACER = 106.25f;
        public static readonly int ABILITY_BAR_Y_OFFSET = 100;
        public static readonly string TEXT_ABILITY_BAR_NEXT = "Next";
        public static readonly string TEXT_SPECIAL_ABILITY = "1";
        public static readonly string[] TEXT_ABILITIES = new string[] {"2", "3",
            "4", "5", "6", "7", "8", "9", "0" };

        // Health Bars
        public static readonly float HEALTH_BAR_SIZE = 1.5f;
        public static readonly float HEALTH_BAR_HIDE_TIME = 2.5f; // seconds

        // Targetting
        public static readonly float ARROW_DIST_OFFSET = -0.49f;
        public static readonly float ARROW_DIST_FROM_CHARACTER = 1.25f;

        #endregion


        #region World

        public static readonly string MANA_RING_NAME = "Mana Ring(Clone)";
        public static readonly float MANA_RING_SIZE = 12f;
        public static readonly float MANA_RING_OFFSET = -0.5f;

        #endregion

    }
}