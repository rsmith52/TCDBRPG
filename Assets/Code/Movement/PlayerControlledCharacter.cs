using System;
using System.Collections.Generic;
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
        #region Fields

        private Vector3 facing_dir;

        #endregion


        #region MonoBehavior

        private void Update()
        {
            // Vertical
            float inputY = 0;
            if (Input.GetKey(KeyCode.W))
                inputY = 1;
            else if (Input.GetKey(KeyCode.S))
                inputY = -1;

            // Horizontal
            float inputX = 0;
            if (Input.GetKey(KeyCode.D))
            {
                inputX = 1;
                sprite_renderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                inputX = -1;
                sprite_renderer.flipX = true;
            }

            // Jump
            jump_input = 0;
            if (Input.GetKey(KeyCode.Space))
                jump_input = 1;

            // Normalize
            movement = new Vector3(inputX, 0, inputY).normalized;

            // Check for edges
            if (!Settings.ALLOW_WALK_OFF)
            {
                facing_dir = transform.TransformDirection(Vector3.down);
                if (!Physics.Raycast(transform.position - new Vector3(0f, 0f, 1f), facing_dir, 1))
                    movement.z = movement.z > 0 ? movement.z : 0;
                if (!Physics.Raycast(transform.position - new Vector3(0.75f, 0f, 0f), facing_dir, 1))
                    movement.x = movement.x > 0 ? movement.x : 0;
                if (!Physics.Raycast(transform.position - new Vector3(0f, 0f, -0.1f), facing_dir, 1))
                    movement.z = movement.z < 0 ? movement.z : 0;
                if (!Physics.Raycast(transform.position - new Vector3(-0.75f, 0f, 0f), facing_dir, 1))
                    movement.x = movement.x < 0 ? movement.x : 0;
            }

            // Update Animator
            animator.SetBool(Constants.WALK_PROPERTY,
                             Math.Abs(movement.sqrMagnitude) > Mathf.Epsilon);
        }

        #endregion

    }
}