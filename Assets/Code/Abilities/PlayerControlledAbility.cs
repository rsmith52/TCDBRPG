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
        protected GameObject line = null;

        [SerializeField]
        protected GameObject cone = null;

        [SerializeField]
        protected GameObject circle = null;

        [SerializeField]
        protected GameObject square = null;

        #endregion


        #region Fields

        public Vector3 surface_hit;
        private GameObject target_view;
        private SpriteRenderer target_view_renderer;
        private RaycastHit hit;
        private float range;
        private bool in_range;
        private bool show_area;

        #endregion


        #region MonoBehavior

        protected override void Start()
        {
            base.Start();

            range = 5f;
            show_area = true;
            target_view = square;
            target_view_renderer = target_view.GetComponent<SpriteRenderer>();
            show_area = true;
        }

        private void Update()
        {
            if (state == State.Targeting)
            {
                // Casts the ray and get the first game object hit
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                surface_hit = hit.point;

                // Check if in range of character
                in_range = DistanceInRange(surface_hit, range);
            }
        }

        private void FixedUpdate()
        {
            if (state == State.Targeting && show_area)
            {
                // Set target view position
                float x_pos = surface_hit.x;
                float y_pos = Mathf.Round((2 * surface_hit.y)) / 2 + Constants.TARGET_OFF_GROUND_DIST; // Round to nearest half and adjust to put off ground a smidge
                float z_pos = surface_hit.z + Constants.TARGET_OFF_GROUND_DIST; // Adjust to put off ground a smidge
                target_view.transform.localPosition = new Vector3(x_pos, y_pos, z_pos);

                // Set target view color
                target_view_renderer.color = in_range ? Constants.TARGET_VALID_COLOR : Constants.TARGET_INVALID_COLOR;

                // Set scale
                if (target_type == TargetType.Circle)
                {
                    target_view.transform.localScale = new Vector3();
                }
                else if (target_type == TargetType.Square)
                {
                    target_view.transform.localScale = new Vector3();
                }
            }
        }

        protected override Transform SetTarget(TargetType target_type, float range, bool show_area)
        {
            this.range = range;
            this.show_area = show_area;

            switch (target_type)
            {
                case TargetType.Circle:
                    target_view = circle;
                    break;
                case TargetType.Square:
                    target_view = square;
                    break;
                default:
                    break;
            }
            target_view_renderer = target_view.GetComponent<SpriteRenderer>();

            while (target == null)
            {
                // Loop forever until a target has been set
            }

            return target;
        }

        #endregion

    }
}