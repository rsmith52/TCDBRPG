using UnityEngine;

/*
 * This code stores settings used throughout the game.
 */

namespace Utilities
{

    #region Enums

    public enum MouseButton
    {
        Left,
        Right,
        Middle
    }

    #endregion

    public class Settings
    {
        #region Control Settings

        public static readonly bool ALLOW_JUMP = false; // requires ALLOW_WALK_OFF
        public static readonly bool ALLOW_WALK_OFF = false;

        // Controls
        public static readonly KeyCode KEY_UP = KeyCode.W;
        public static readonly KeyCode KEY_LEFT = KeyCode.A;
        public static readonly KeyCode KEY_DOWN = KeyCode.S;
        public static readonly KeyCode KEY_RIGHT = KeyCode.D;
        public static readonly MouseButton MOUSE_BASIC_ATTACK = MouseButton.Left;
        public static readonly KeyCode KEY_ABILITY_CANCEL = KeyCode.Q;
        public static readonly KeyCode KEY_SPECIAL_ABILITY = KeyCode.Alpha1;
        public static readonly KeyCode[] KEYS_ABILITIES = new KeyCode[] { KeyCode.Alpha2,
            KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7,
            KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0 };
        public static readonly KeyCode KEY_MAP_TOGGLE = KeyCode.M;

        #endregion


        #region Deck Settings

        public static readonly int DECK_SIZE = 10;
        public static readonly int HAND_SIZE = 5; // Current code supports up to 9
        public static readonly float SHUFFLE_TIME = 1f; // seconds

        #endregion


        #region Stat Settings

        public static readonly int BASE_HEALTH = 10;
        public static readonly int BASE_MANA = 10;
        public static readonly float BASE_SPEED = 3f;
        public static readonly float BASE_JUMP = 6.5f;

        #endregion


        #region UI

        public static readonly bool MINIMAP_START_VISIBLE = false;

        #endregion


        #region World Settings

        public static readonly float MANA_GAIN_RATE = 2.5f; // seconds per 1 mana

        #endregion

    }
}