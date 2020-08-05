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

        [Header("General")]
        [SerializeField]
        protected new string name = "Name";

        [SerializeField]
        protected Race character_race = null;

        [SerializeField]
        protected Class character_class = null;

        [SerializeField]
        public Weapon weapon = null;

        #endregion


        #region Stats

        [Header("Stats")]
        public Stat speed;

        [HideInInspector]
        public Stat jump_force = new Stat(Settings.BASE_JUMP);

        #endregion


        #region MeteredStats

        [Header("Metered Stats")]
        public MeteredStat health;
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