using System;
using UnityEngine;
using Utilities;

/* 
 * This code handles player input to control a character. Input is checked with
 * every update but movement is only applied every fixed update to remain
 * consistent through frame rates.
 */

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
                sprite_renderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputX = -1;
                sprite_renderer.flipX = true;
            }

            // Jump
            jump_input = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                jump_input = 1;
            }

            // Normalize
            movement = new Vector3(inputX, 0, inputY).normalized;

            // Update Animator
            animator.SetBool(Constants.WALK_PROPERTY,
                             Math.Abs(movement.sqrMagnitude) > Mathf.Epsilon);
        }

        #endregion

    }
}