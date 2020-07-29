using System;
using UnityEngine;

namespace Movement
{
    public abstract class MovingCharacter : MonoBehaviour
    {
        #region Constants

        protected static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");
        protected static readonly float GROUND_DIST = 0.05f;
        protected static readonly float AIR_CONTROL_MOD = 0.1f;

        #endregion


        #region Inspector

        [SerializeField]
        protected float speed = 1f;

        [SerializeField]
        protected float jump_force = 3.5f;

        [Header("Relations")]
        [SerializeField]
        protected Animator animator = null;

        [SerializeField]
        protected Rigidbody physics_body = null;

        [SerializeField]
        protected new CapsuleCollider collider = null;

        [SerializeField]
        protected SpriteRenderer sprite_renderer = null;

        #endregion


        #region Fields

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
