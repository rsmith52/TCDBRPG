using UnityEngine;
using Utilities;

/*
 * This code handles player input to set targets for and use abilities.
 * Targeting/aim is selected through mouse/touch input.
 */

namespace Abilities
{
    public class PlayerControlledAbility : AbilityUser
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected GameObject square = null;

        #endregion


        #region Fields

        public Vector3 surface_hit;
        private GameObject target_view;
        private RaycastHit hit;

        #endregion


        #region MonoBehavior

        private void Update()
        {
            if (state == State.Targeting)
            {
                // Casts the ray and get the first game object hit
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                surface_hit = hit.point;
            }
        }

        private void FixedUpdate()
        {
            // Nothing to adjust
            float x_pos = surface_hit.x;
            // Round to nearest half and adjust to put off ground a smidge
            float y_pos = Mathf.Round((2 * surface_hit.y)) / 2 + Constants.TARGET_OFF_GROUND_DIST;
            // Adjust to put off ground a smidge
            float z_pos = surface_hit.z + Constants.TARGET_OFF_GROUND_DIST;

            square.transform.localPosition = new Vector3(x_pos, y_pos, z_pos);
        }

        protected override Transform SetTarget(TargetType target_type, bool show_area)
        {
            switch (target_type)
            {
                case TargetType.Square:
                    target_view = square;
                    break;
                default:
                    break;
            }

            while(target == null)
            {
                // Loop forever until a target has been set
            }

            return target;
        }

        #endregion

    }
}