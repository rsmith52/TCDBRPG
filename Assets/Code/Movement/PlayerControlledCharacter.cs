using System;
using UnityEngine;

namespace Movement
{
    public class PlayerControlledCharacter : MovingCharacter
    {
        #region MonoBehavior

        private void Update()
        {
            // Vertical
            float inputY = 0;
            if (Input.GetKey(KeyCode.UpArrow))
                inputY = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                inputY = -1;

            // Horizontal
            float inputX = 0;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                inputX = 1;
                spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputX = -1;
                spriteRenderer.flipX = true;
            }

            // Normalize
            _movement = new Vector3(inputX, 0, inputY).normalized;

            // Update Animator
            animator.SetBool(WALK_PROPERTY,
                             Math.Abs(_movement.sqrMagnitude) > Mathf.Epsilon);
        }

        private void FixedUpdate()
        {
            physicsBody.velocity = _movement * speed;
        }

        #endregion
    }
}