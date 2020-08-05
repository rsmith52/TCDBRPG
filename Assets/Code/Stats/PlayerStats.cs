using UnityEngine;
using Utilities;

/*
 * This code defines the stats every player will have, split between
 * regular stats and metered stats. It includes their race and class info.
 */

namespace Stats
{
    public class PlayerStats : CharacterStats
    {
        #region General Info

        [Header("General")]

        [SerializeField]
        protected Race character_race = null;

        [SerializeField]
        protected Class character_class = null;

        [SerializeField]
        public Weapon weapon = null;

        #endregion


        #region Stats
        #endregion


        #region MeteredStats

        [Header("Metered Stats")]
        public MeteredStat mana;
        public float mana_time { get; set; }

        #endregion


        #region MonoBehavior

        private void Start()
        {
            // Set stats
            speed = character_race.speed;

            health = new MeteredStat(character_race.health.GetValue(), character_race.health.GetCurValue());
            mana = new MeteredStat(character_race.mana.GetValue(), character_race.mana.GetCurValue());

            // Set weapon
            weapon = character_class.weapon;
        }

        #endregion

    }
}