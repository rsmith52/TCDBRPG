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
        #region General Info

        public new string name = "Name";

        #endregion


        #region Stats

        [Header("Stats")]
        public Stat speed = new Stat(Settings.BASE_SPEED);

        [HideInInspector]
        public Stat jump_force = new Stat(Settings.BASE_JUMP);

        #endregion


        #region MeteredStats

        [Header("Metered Stats")]
        public MeteredStat health = new MeteredStat(Settings.BASE_HEALTH, Settings.BASE_HEALTH);
        public MeteredStat mana = new MeteredStat(Settings.BASE_MANA, 0);
        public float mana_time { get; set; }

        #endregion

    }
}