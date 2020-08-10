using UnityEngine;
using UnityEngine.UI;
using Abilities;
using Stats;
using Utilities;

/*
 * This code handles behavior for the ability bar, including the boxes for card
 * abilities and special abilities.
 */

namespace UI
{
    public class AbilityBar : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected PlayerStats player_stats = null;

        [SerializeField]
        protected AbilityUser ability_user = null;

        // Ability Bar Parts
        [SerializeField]
        protected GameObject ability_bg = null;
        [SerializeField]
        protected GameObject first_ability_box = null;
        [SerializeField]
        protected GameObject ability_box = null;

        #endregion


        #region Fields

        private GameObject[] ability_boxes;
        private int selected_index;
        private RectTransform rect_transform;
        private GameObject bg;
        private GameObject box;
        private Button button;

        #endregion


        #region Monobehavior

        private void Start()
        {
            ability_boxes = new GameObject[Settings.HAND_SIZE];
            for (int i = 0; i < Settings.HAND_SIZE; i++)
            {
                if (i == 0)
                    box = Instantiate(first_ability_box);
                else
                    box = Instantiate(ability_box);
                bg = Instantiate(ability_bg);
                bg.transform.SetParent(transform);
                box.transform.SetParent(bg.transform);
                rect_transform = bg.GetComponent<RectTransform>();
                rect_transform.anchoredPosition = new Vector3(
                    -1 * Constants.ABILITY_BAR_X_OFFSET * ((Settings.HAND_SIZE - 1) / 2f) + i * Constants.ABILITY_BAR_X_OFFSET,
                    Constants.ABILITY_BAR_Y_OFFSET, 0);
                ability_boxes[i] = bg;
            }

            // Set first button as selected
            selected_index = 1;
        }

        private void Update()
        {
            // Check input for selected ability
            if (Input.GetKey(KeyCode.Alpha1))
                selected_index = 1;
            else if (Input.GetKey(KeyCode.Alpha2) && Settings.HAND_SIZE >= 2)
                selected_index = 2;
            else if (Input.GetKey(KeyCode.Alpha3) && Settings.HAND_SIZE >= 3)
                selected_index = 3;
            else if (Input.GetKey(KeyCode.Alpha4) && Settings.HAND_SIZE >= 4)
                selected_index = 4;
            else if (Input.GetKey(KeyCode.Alpha5) && Settings.HAND_SIZE >= 5)
                selected_index = 5;
            else if (Input.GetKey(KeyCode.Alpha6) && Settings.HAND_SIZE >= 6)
                selected_index = 6;
            else if (Input.GetKey(KeyCode.Alpha7) && Settings.HAND_SIZE >= 7)
                selected_index = 7;
            else if (Input.GetKey(KeyCode.Alpha8) && Settings.HAND_SIZE >= 8)
                selected_index = 8;
            else if (Input.GetKey(KeyCode.Alpha9) && Settings.HAND_SIZE >= 9)
                selected_index = 9;
            else if (Input.GetKey(KeyCode.Alpha0) && Settings.HAND_SIZE >= 10)
                selected_index = 10;
        }

        private void FixedUpdate()
        {
            bg = ability_boxes[selected_index - 1];
            button = bg.GetComponent<Button>();
            button.Select();
        }

        #endregion

    }
}