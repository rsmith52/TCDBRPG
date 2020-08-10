using System.Collections.Generic;
using UnityEngine;
using Stats;
using UI;
using Utilities;

/* 
 * This code contains the basic information and setup needed for a character
 * that can use abilities.
 */

namespace Abilities
{
    public class AbilityUser : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected AbilityAim ability_aim = null;

        [SerializeField]
        protected PlayerStats stats = null;

        [SerializeField]
        protected Ability slotted_ability = null;

        #endregion


        #region Fields

        private bool mouse_pressed;
        private Weapon slotted_weapon;
        private GameObject weapon;
        private GameObject projectile;
        private float cool_down;
        private float cool_down_period;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            cool_down_period = 0;
        }

        private void Update()
        {
            if (!mouse_pressed && Input.GetMouseButtonDown(0) &&
                cool_down >= cool_down_period)
            {
                BasicAttack();
                mouse_pressed = true;
            }
            if (mouse_pressed && Input.GetMouseButtonUp(0))
                mouse_pressed = false;
            cool_down += Time.deltaTime;
        }

        private void FixedUpdate()
        {
        }

        private void BasicAttack()
        {
            // Get equipped weapon
            slotted_weapon = stats.weapon;
            cool_down_period = slotted_weapon.animation_length;
            cool_down = 0;

            if (weapon == null && slotted_weapon.target == TargetType.Melee)
                BasicMelee();
            else if (slotted_weapon.target == TargetType.Projectile)
                BasicRanged();
        }

        private void BasicMelee()
        {
            // Setup weapon object
            weapon = Instantiate(slotted_weapon.gameObject);

            // Set position and location based on ability aim
            weapon.transform.SetParent(ability_aim.transform);
            weapon.transform.localPosition = new Vector3(0,
                slotted_weapon.offset_from_character_mod, Constants.WEAPON_DIST_OFFSET);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 180);

            // Perform attack in place, don't rotate further
            weapon.transform.SetParent(ability_aim.transform.parent);
        }

        private void BasicRanged()
        {
            // Setup weapon object
            weapon = Instantiate(slotted_weapon.gameObject);
            projectile = Instantiate(slotted_weapon.projectile);

            // Set position and location
            weapon.transform.SetParent(ability_aim.transform);
            projectile.transform.SetParent(ability_aim.transform);
            weapon.transform.localPosition = new Vector3(0,
                slotted_weapon.offset_from_character_mod, Constants.WEAPON_DIST_OFFSET);
            projectile.transform.localPosition = new Vector3(0,
                slotted_weapon.offset_from_character_mod, Constants.WEAPON_DIST_OFFSET);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 180);
            projectile.transform.localEulerAngles = new Vector3(0, 0, 180);

            // Perform attack in place, don't rotate further
            weapon.transform.SetParent(ability_aim.transform.parent);
            projectile.transform.SetParent(ability_aim.transform.parent);

            // Perform attack
            Projectile projectile_code = projectile.GetComponent<Projectile>();
            projectile_code.Fire(ability_aim.GetAimDirection(), slotted_weapon.range,
                slotted_weapon.speed, slotted_weapon.damage);
        }

        private void UseAbility() { }

        #endregion

    }
}