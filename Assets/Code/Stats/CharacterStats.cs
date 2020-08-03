using UnityEngine;
using Utilities;
using Cards;

/*
 * This code defines the stats every character will have, split between
 * regular stats and metered stats.
 */

namespace Stats
{
    public class CharacterStats : MonoBehaviour
    {
        #region General Info

        [Header("General")]
        [SerializeField]
        protected new string name = "Name";

        [SerializeField]
        protected Class character_class = null;

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