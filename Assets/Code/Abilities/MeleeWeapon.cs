using UnityEngine;
using Stats;
using Utilities;

/*
 * This code defines a melee weapon. It handles detecting collisions with
 * enemies as the weapon strikes.
 */

namespace Abilities
{
    public class MeleeWeapon : Weapon
    {
        #region Inspector
        #endregion


        #region Fields

        private float time_existed;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            time_existed = 0;
        }

        private void Update()
        {
            time_existed += Time.deltaTime;
        }

        private void FixedUpdate()
        {
            // Once the attack animation has fully played delete this
            if (time_existed > animation_length)
                GameObject.Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Check if collision is with enemy, and damage them if so
            if (other.gameObject.layer == Constants.ENEMY_LAYER)
                other.GetComponent<CharacterStats>().Damage(damage);
        }

        #endregion

    }
}