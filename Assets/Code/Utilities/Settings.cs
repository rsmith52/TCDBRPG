/*
 * This code stores settings used throughout the game.
 */

namespace Utilities
{
    public class Settings
    {
        #region Control Settings

        public static readonly bool ALLOW_JUMP = false; // requires ALLOW_WALK_OFF
        public static readonly bool ALLOW_WALK_OFF = false;

        #endregion


        #region Deck Settings

        public static readonly int DECK_SIZE = 30;
        public static readonly int HAND_SIZE = 6;
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