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

        [Header("Attack/Ability Bases")]
        [SerializeField]
        protected GameObject weapon_base = null;
        [SerializeField]
        protected GameObject projectile_base = null;

        #endregion


        #region Fields

        private bool key_pressed;
        private Weapon slotted_weapon;
        private GameObject weapon;
        private SpriteRenderer weapon_renderer;
        private BoxCollider weapon_collider;

        #endregion


        #region MonoBehavior

        private void Update()
        {
            if (!key_pressed && Input.GetKeyDown(Settings.KEY_ATTACK))
            {
                BasicAttack();
                key_pressed = true;
            }
            if (key_pressed && Input.GetKeyUp(Settings.KEY_ATTACK))
                key_pressed = false;
        }

        private void FixedUpdate()
        {
        }

        private void BasicAttack()
        {
            slotted_weapon = stats.weapon;

            if (slotted_weapon.target == TargetType.Melee)
                BasicMelee();
            else if (slotted_weapon.target == TargetType.Projectile)
                BasicProjectile();
        }

        private void BasicMelee()
        {
            // Setup weapon object
            weapon = Instantiate(weapon_base);
            weapon_renderer = weapon.GetComponent<SpriteRenderer>();
            weapon_renderer.sprite = slotted_weapon.sprite;

            // Reset position and location - SET TO THE 30 DEGREE OFF POSITION
            weapon.transform.SetParent(ability_aim.transform);
            weapon.transform.localPosition = new Vector3(0, 0, Constants.WEAPON_DIST_OFFSET);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 180);

            // Setup hitbox
            weapon_collider = weapon.GetComponent<BoxCollider>();
            weapon_collider.size = new Vector3(Constants.MELEE_WEAPON_WIDTH, slotted_weapon.range, 1);

            // Perform attack
            // Rotate weapon 30 degrees - DO ABOVE
            // Rotate weapon 60 degrees opposite checking collisions with enemies along the way
            // ACTUALLY USE Constants.MELEE_WEAPON_SWING_DEGREES
        }

        private void BasicProjectile()
        {
            // Setup weapon object
            slotted_weapon = stats.weapon;
            weapon = Instantiate(weapon_base);
            weapon_renderer = weapon.GetComponent<SpriteRenderer>();
            weapon_renderer.sprite = slotted_weapon.sprite;

            // Reset position and location
            weapon.transform.SetParent(ability_aim.transform);
            weapon.transform.localPosition = new Vector3(0, 0, Constants.WEAPON_DIST_OFFSET);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 180);

            // Setup projectile object

            // Setup projectile hitbox

            // Perform attack
            // Travel range in direction, checking collisions with enemies along the way
        }

        #endregion

    }
}