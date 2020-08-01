using UnityEngine;
using Utilities;

/*
 * This code defines the stats every character will have, split between
 * regular stats and metered stats.
 */

namespace Stats
{
    public class CharacterStats : MonoBehaviour
    {
        #region Stats

        [Header("Stats")]
        public Stat speed = new Stat(Settings.BASE_SPEED);

        [HideInInspector]
        public Stat jump_force = new Stat(Settings.BASE_JUMP);

        #endregion


        #region MeteredStats
        /*
        [Header("Metered Stats")]
        public MeteredStat health;
        public MeteredStat mana;
        */
        #endregion

    }
}