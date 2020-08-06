using UnityEngine;
using Stats;
using Utilities;

/*
 * This code defines a ranged weapon.
 */

namespace Abilities
{
    public class RangedWeapon : Weapon
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

        #endregion

    }
}