using UnityEngine;
using Stats;
using Utilities;

/* 
 * This code contains the basic information and setup needed for a character
 * that can move. Player controlled characters and AI controlled characters
 * extend from this.
 */

namespace Movement
{
    public abstract class MovingCharacter : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected CharacterStats character_stats = null;

        [SerializeField]
        protected Rigidbody physics_body = null;

        [SerializeField]
        protected new Collider collider = null;

        [SerializeField]
        protected SpriteRenderer sprite_renderer = null;

        [SerializeField]
        protected Animator animator = null;

        #endregion


        #region Fields

        protected float speed; // movement speed
        protected float jump_force;
        protected Vector3 movement; // movement direction
        protected int jump_input;
        protected float dist_to_ground;

        #endregion


        #region MonoBehavior

        protected virtual void Start()
        {
            dist_to_ground = collider.bounds.extents.y;
        }

        private void FixedUpdate()
        {
            speed = character_stats.speed.GetValue();
            jump_force = character_stats.jump_force.GetValue();

            if (IsGrounded())
            {
                physics_body.velocity = movement * speed;

                if (jump_input == 1 && Settings.ALLOW_JUMP)
                    physics_body.velocity = new Vector3(0, jump_input, 0) * jump_force;
            }
            // While in the air, provide less control
            else
                physics_body.velocity += (movement * Constants.AIR_CONTROL_MOD * speed);
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, dist_to_ground + Constants.GROUND_DIST);
        }

        #endregion

    }
}