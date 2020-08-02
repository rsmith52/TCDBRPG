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

        #endregion


        #region Stat Settings

        public static int BASE_HEALTH = 10;
        public static int BASE_MANA = 10;
        public static readonly float BASE_SPEED = 3f;
        public static readonly float BASE_JUMP = 6.5f;

        #endregion


        #region World Settings

        public static float MANA_GAIN_RATE = 1f; // seconds / 1 mana

        #endregion

    }
}