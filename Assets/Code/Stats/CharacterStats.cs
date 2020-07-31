using UnityEngine;

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
        public Stat speed;

        [HideInInspector]
        public Stat jump_force;

        #endregion


        #region MeteredStats

        [Header("Metered Stats")]
        public MeteredStat health;
        public MeteredStat mana;

        #endregion

    }
}