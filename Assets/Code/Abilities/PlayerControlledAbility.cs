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

        [SerializeField]
        protected GameObject target_view_prefab;

        [SerializeField]
        protected GameObject target_square;

        #endregion


        #region Fields

        private Vector3 surface_hit;
        private RaycastHit hit;
        private float range;
        private bool in_range;
        private bool show_area;
        private GameObject target_view;
        private List<GameObject> target_squares;
        private bool mouse_down;

        #endregion


        #region MonoBehavior

        protected override void Update()
        {
            base.Update();

            if (state == State.Waiting && Input.GetKeyDown(KeyCode.Space))
            {
                state = State.Targeting;
                SetupTargetView(ability.target_type, ability.area_size);
            }

            if (state == State.Targeting)
            {
                // Casts the ray and get the first game object hit
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                    surface_hit = hit.point;

                // Check if in range of character
                in_range = DistanceInRange(surface_hit, range);

                // Determine if mouse clicked
                mouse_down = Input.GetMouseButton(0);
            }

            if (state == State.Activating && Input.GetKeyDown(KeyCode.C))
                CancelAbility();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (state == State.Targeting)
            {
                // Set target view position
                float x_pos = surface_hit.x;
                float y_pos = Mathf.Floor(surface_hit.y / 1.5f) * 1.5f + Constants.TARGET_OFF_GROUND_DIST; // Round to nearest 1.5 and adjust to put off ground a smidge
                float z_pos = surface_hit.z + Constants.TARGET_OFF_GROUND_DIST; // Adjust to put off ground a smidge
                target_view.transform.localPosition = new Vector3(x_pos, y_pos, z_pos);

                // Set target view color
                foreach (GameObject square in target_squares)
                {
                    SpriteRenderer renderer = square.GetComponent<SpriteRenderer>();
                    renderer.color = in_range ? Constants.TARGET_VALID_COLOR : Constants.TARGET_INVALID_COLOR;
                }

                // Set target if mouse down and in range
                if (in_range && mouse_down)
                {
                    // Check if enough mana
                    if (stats.mana.GetCurValue() >= ability.mana_cost)
                    {
                        // Store target until activation completed
                        SetAbility set_ability = new SetAbility();
                        set_ability.ability = ability;
                        set_ability.target_view = target_view;
                        set_ability.squares = target_squares;

                        // Move to ability activation
                        state = State.Activating;
                        ability_in_activation = set_ability;
                        StartAbility(set_ability);
                        activation_time_waited = 0;
                    }
                    // Not enough mana
                    else {
                        // Do something to show not enough mana
                    }
                }
            }
        }

        private void SetupTargetView(TargetType target_type, int size)
        {
            target_view = Instantiate(target_view_prefab);
            target_view.transform.position = new Vector3(0, 0, 0);
            target_squares = new List<GameObject>();

            switch (target_type)
            {
                case TargetType.Square:
                    BuildSquareTarget(size);
                    break;
                default:
                    break;
            }

            range = ability.range;
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