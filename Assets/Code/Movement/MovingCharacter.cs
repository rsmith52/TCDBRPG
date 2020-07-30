﻿using UnityEngine;
using Stats;

/* 
 * This code contains the basic information and setup needed for a character
 * that can move. Player controlled characters extend from this, and AI
 * controlled characters will also extend from this.
 */

namespace Movement
{
    public abstract class MovingCharacter : MonoBehaviour
    {
        #region Constants

        protected static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");
        protected static readonly float GROUND_DIST = 0.05f;
        protected static readonly float AIR_CONTROL_MOD = 0.075f;

        #endregion


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

        protected float speed;
        protected float jump_force;
        protected Vector3 movement;
        protected int jump_input;
        protected float dist_to_ground;

        #endregion


        #region MonoBehavior

        protected void Start()
        {
            dist_to_ground = collider.bounds.extents.y;
        }

        protected bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, dist_to_ground + GROUND_DIST);
        }

        #endregion

    }
}
