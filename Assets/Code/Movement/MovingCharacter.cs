using System;
using UnityEngine;

namespace Movement
{
    public abstract class MovingCharacter : MonoBehaviour
    {
        #region Constants

        protected static readonly int WALK_PROPERTY = Animator.StringToHash("Walk");
        protected static readonly float GROUND_MARGIN = 0.1f;

        #endregion


        #region Inspector

        [SerializeField]
        protected float speed = 1f;

        [Header("Relations")]
        [SerializeField]
        protected Animator animator = null;

        [SerializeField]
        protected Rigidbody physicsBody = null;

        [SerializeField]
        protected CapsuleCollider collider = null;

        [SerializeField]
        protected SpriteRenderer spriteRenderer = null;

        #endregion


        #region Fields

        protected Vector3 _movement;

        #endregion

    }
}
