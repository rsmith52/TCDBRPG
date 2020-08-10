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

        [SerializeField]
        protected Transform target;

        #endregion


        #region Fields

        private bool follow_mouse;
        private RaycastHit hit;
        private GameObject object_hit;
        private Vector3 surface_hit;
        private Vector3 character_pos;
        private Vector3 direction;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            // If this is not the player, immediately destroy?
            /*
            if (character.layer != Constants.PLAYER_LAYER)
                GameObject.Destroy(this.gameObject);
            */
            follow_mouse = character.layer == Constants.PLAYER_LAYER;
        }

        private void Update()
        {
            // Get offset character position
            character_pos = character.transform.position + new Vector3(0, Constants.ARROW_DIST_OFFSET, Constants.ARROW_DIST_OFFSET);

            if (follow_mouse)
            {
                // Casts the ray and get the first game object hit
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                // Check if on ground or an object and offset based on this as necessary
                object_hit = hit.collider.gameObject;
                if (object_hit.layer == Constants.GROUND_LAYER)
                    surface_hit = hit.point + new Vector3(0, Constants.ARROW_DIST_OFFSET, Constants.ARROW_DIST_OFFSET);
                else
                    surface_hit = hit.point;
                direction = surface_hit - character_pos;
            }
            else
                direction = target.position - character_pos;
            
            // Normalize direction from character to point
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