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
        protected new string name = "Name";

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
            // Set weapon
            weapon = character_class.weapon;
        }

        #endregion

    }
}