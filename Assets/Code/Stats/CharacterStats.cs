using System.Collections.Generic;
using UnityEngine;
using Utilities;

/*
 * This code defines the stats every character will have, split between
 * regular stats and metered stats. PlayerStats and MonsterStats extend from
 * this. Receiving damage is also handled here.
 */

namespace Stats
{
    public abstract class CharacterStats : MonoBehaviour
    {
        #region General Info
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


        #region MonoBehavior

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            if (health.GetCurValue() <= 0)
                Die();
        }

        public void Damage(int damage)
        {
            // Apply damage
            health.ChangeCurValue(-1 * damage);

            // Show damaged animation
            Animator animator = GetComponentInChildren<Animator>();
            animator.SetTrigger(Constants.WAS_HIT_PROPERTY);
        }

        private void Die()
        {
            GameObject.Destroy(gameObject);
        }

        #endregion

    }
}