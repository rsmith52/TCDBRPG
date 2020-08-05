using UnityEngine;
using Abilities;
using Utilities;

/*
 * This code defines the stats every player will have. It also includes their 
 * race and class info.
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

        [HideInInspector]
        public Weapon weapon = null;

        #endregion


        #region Stats
        #endregion


        #region MeteredStats
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