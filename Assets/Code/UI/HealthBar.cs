﻿using UnityEngine;
using Stats;
using Utilities;

/*
 * This code handles creating and maintaining mini health bars for non-player
 * characters, including enemies and allies.
 */

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected GameObject character;

        #endregion


        #region Fields

        private CharacterStats stats;
        private int max_health;
        private int health;
        private float percent_full;
        private float time_at_full;
        private bool shown;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            // If this is a player, immediately destroy
            if (character.layer == Constants.PLAYER_LAYER)
            {
                GameObject.Destroy(this.gameObject);
            }

            stats = character.GetComponent<CharacterStats>();
            max_health = stats.health.GetValue();

            // Start off not showing the bar
            shown = false;
            transform.localScale = new Vector3(0, 0, 0);
        }

        private void Update()
        {
            health = stats.health.GetCurValue();
        }

        private void FixedUpdate()
        {
            // Only show bar once character has been damaged, then show it indefinitely
            if (health != max_health)
            {
                shown = true;
                time_at_full = 0;
            }
            if (shown)
            {
                percent_full = (float)health / (float)max_health;
                transform.localScale = new Vector3(Constants.HEALTH_BAR_SIZE * percent_full, 0.25f, 1);

                // Hide after some time if health is full
                if (health == max_health)
                {
                    time_at_full += Time.deltaTime;
                    if (time_at_full >= Constants.HEALTH_BAR_HIDE_TIME)
                    {
                        shown = false;
                        transform.localScale = new Vector3(0, 0, 0);
                    }
                }
            }
        }

        #endregion

    }
}