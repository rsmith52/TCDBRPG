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

        #endregion


        #region MonoBehavior

        private void Update()
        {
            if (!mouse_pressed && Input.GetMouseButtonDown(0))
            {
                BasicAttack();
                mouse_pressed = true;
            }
            if (mouse_pressed && Input.GetMouseButtonUp(0))
                mouse_pressed = false;
        }

        private void FixedUpdate()
        {
        }

        private void BasicAttack()
        {
            // Get equipped weapon
            slotted_weapon = stats.weapon;

            if (weapon == null && slotted_weapon.target == TargetType.Melee)
                BasicMelee();
            else if (slotted_weapon.target == TargetType.Projectile)
                BasicProjectile();
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

        private void BasicProjectile()
        {
            // Setup weapon object

            // Reset position and location

            // Setup projectile object

            // Setup projectile hitbox

            // Perform attack
            // Travel range in direction, checking collisions with enemies along the way
        }

        private void UseAbility() { }

        #endregion

    }
}