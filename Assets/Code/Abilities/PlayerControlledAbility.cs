using System.Collections.Generic;
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
        protected GameObject target_view_prefab;

        [SerializeField]
        protected GameObject target_square;

        #endregion


        #region Temporary Settings

        [Header("Temp Settings")]
        public TargetType ability_target_type = TargetType.Square;
        public float ability_range = 5f;
        public bool ability_show_area = true;
        public int ability_size = 3;

        #endregion


        #region Fields

        private Vector3 surface_hit;
        private RaycastHit hit;
        private float range;
        private bool in_range;
        private bool show_area;
        private GameObject target_view;
        private List<GameObject> target_squares;

        #endregion


        #region MonoBehavior

        protected override void Start()
        {
            base.Start();

            SetupTargetView(ability_target_type, ability_size);
            range = ability_range;
            show_area = ability_show_area;
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
                // target_view_renderer.color = in_range ? Constants.TARGET_VALID_COLOR : Constants.TARGET_INVALID_COLOR;

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

        protected override Transform SetTarget()
        {
            // Setup target view
            // Loop until target selected
            // Return transform of that target

            return transform;
        }

        private void SetupTargetView(TargetType target_type, int size)
        {
            target_view = Instantiate(target_view_prefab);
            target_squares = new List<GameObject>();

            switch (target_type)
            {
                case TargetType.Square:
                    BuildSquareTarget(size);
                    break;
                case TargetType.Circle:
                    break;
            }
        }

        private void BuildSquareTarget(int size)
        {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++)
                {
                    GameObject square = Instantiate(target_square);
                    square.transform.SetParent(target_view.transform);
                    square.transform.localRotation = new Quaternion(0, 0, 0, 0);
                    square.transform.localScale = new Vector3(1, 1, 1);
                    if (size %2 == 1)
                    {
                        square.transform.localPosition = new Vector3(i - (size / 2), j - (size / 2), 0);
                    }
                    else
                    {
                        square.transform.localPosition = new Vector3(i - (size / 2 - 0.5f), j - (size / 2 - 0.5f), 0);
                    }
                    target_squares.Add(square);
                }
            }

        }

        #endregion

    }
}