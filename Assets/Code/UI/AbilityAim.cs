using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

/* This code defines the behavior for a aim marker that circles the character,
 * showing where they are aiming, and tracks where the mouse is on the ground.
 */

namespace UI
{
    public class AbilityAim : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected GameObject character;

        [SerializeField]
        protected SpriteRenderer sprite_renderer;

        #endregion


        #region Fields

        private RaycastHit hit;
        private Vector3 surface_hit;
        private Vector3 player_pos;
        private Vector3 direction;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            // If this is not the player, immediately destroy?
            if (character.layer != Constants.PLAYER_LAYER)
                GameObject.Destroy(this.gameObject);
        }

        private void Update()
        {
            // Get offset player position
            player_pos = character.transform.position + new Vector3(0, Constants.ARROW_DIST_OFFSET, Constants.ARROW_DIST_OFFSET);

            // Casts the ray and get the first game object hit
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            surface_hit = hit.point;

            // Calculate direction from player to point
            direction = (surface_hit - player_pos);
            direction = new Vector3(direction.x, 0, direction.z).normalized;
        }

        private void FixedUpdate()
        {
            // Set position about character
            transform.localPosition = new Vector3(
                Constants.ARROW_DIST_FROM_CHARACTER * direction.x,
                Constants.ARROW_DIST_OFFSET,
                Constants.ARROW_DIST_FROM_CHARACTER * direction.z + Constants.ARROW_DIST_OFFSET);

            // Set rotation of pointer and
            // Flip character based on the direction fac
            if (direction.x == 0)
                direction.x = 0.001f; // Account for divide by 0 errors
            if (direction.x <= 0)
            {
                transform.eulerAngles = new Vector3(90, 0,
                    -1 * (90 + (-1 * Mathf.Rad2Deg * Mathf.Atan(direction.z / direction.x))));
                sprite_renderer.flipX = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(90, 0,
                     90 + Mathf.Rad2Deg * Mathf.Atan(direction.z / direction.x));
                sprite_renderer.flipX = false;
            }
        }

        public Vector3 GetAimDirection()
        {
            return direction;
        }

        #endregion

    }
}