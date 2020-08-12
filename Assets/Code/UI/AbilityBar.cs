using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
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
        protected AbilityUser ability_user = null;

        // Ability Bar Parts
        [SerializeField]
        protected GameObject ability_bg = null;
        [SerializeField]
        protected GameObject first_ability_box = null;
        [SerializeField]
        protected GameObject ability_box = null;
        [SerializeField]
        protected GameObject special_bg = null;
        [SerializeField]
        protected GameObject special_box = null;
        [SerializeField]
        protected GameObject control_text = null;

        #endregion


        #region Fields

        private EventSystem event_system;
        private GameObject[] ability_boxes;
        private int selected_index;
        private RectTransform rect_transform;
        private GameObject special;
        private GameObject next_card;
        private GameObject bg;
        private GameObject box;
        private GameObject text_obj;
        private TextMeshProUGUI text;
        private Button button;

        #endregion


        #region Monobehavior

        private void Start()
        {
            // Get event system
            event_system = GameObject.Find("EventSystem").GetComponent<EventSystem>();

            // Setup Ability Boxes
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
                text_obj = Instantiate(control_text);
                text_obj.transform.SetParent(bg.transform);
                text = text_obj.GetComponent<TextMeshProUGUI>();
                text.SetText(Constants.TEXT_ABILITIES[i]);
                rect_transform = bg.GetComponent<RectTransform>();
                rect_transform.anchoredPosition = new Vector3(
                    -1 * Constants.ABILITY_BAR_X_OFFSET * ((Settings.HAND_SIZE - 1) / 2f) + i * Constants.ABILITY_BAR_X_SPACER,
                    Constants.ABILITY_BAR_Y_OFFSET, 0);
                ability_boxes[i] = bg;
            }

            // Setup Special Box
            box = Instantiate(special_box);
            bg = Instantiate(special_bg);
            bg.transform.SetParent(transform);
            box.transform.SetParent(bg.transform);
            text_obj = Instantiate(control_text);
            text_obj.transform.SetParent(bg.transform);
            text = text_obj.GetComponent<TextMeshProUGUI>();
            text.SetText(Constants.TEXT_SPECIAL_ABILITY);
            rect_transform = bg.GetComponent<RectTransform>();
            rect_transform.anchoredPosition = new Vector3(
                -1 * Constants.ABILITY_BAR_X_OFFSET * ((Settings.HAND_SIZE - 1) / 2f) - (1.5f * Constants.ABILITY_BAR_X_OFFSET), Constants.ABILITY_BAR_Y_OFFSET, 0);
            special = bg;

            // Setup Next Card Box
            box = Instantiate(first_ability_box);
            bg = Instantiate(ability_bg);
            bg.transform.SetParent(transform);
            box.transform.SetParent(bg.transform);
            text_obj = Instantiate(control_text);
            text_obj.transform.SetParent(bg.transform);
            text = text_obj.GetComponent<TextMeshProUGUI>();
            text.SetText(Constants.TEXT_ABILITY_BAR_NEXT);
            rect_transform = bg.GetComponent<RectTransform>();
            rect_transform.anchoredPosition = new Vector3(
                Constants.ABILITY_BAR_X_OFFSET * ((Settings.HAND_SIZE - 1) / 2f) + (1.5f * Constants.ABILITY_BAR_X_OFFSET), Constants.ABILITY_BAR_Y_OFFSET, 0);
            next_card = bg;

            // Set no ability as selected - may change to set first as selected
            selected_index = -1;
        }

        private void Update()
        {
            // Check input for selected ability
            if (Input.GetKey(Settings.KEY_ABILITY_CANCEL))
                selected_index = -1; // None selected
            else if (Input.GetKey(Settings.KEY_SPECIAL_ABILITY))
                selected_index = 0; // Special selected
            else if (Input.GetKey(Settings.KEYS_ABILITIES[0]) && Settings.HAND_SIZE >= 1)
                selected_index = 1;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[1]) && Settings.HAND_SIZE >= 2)
                selected_index = 2;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[2]) && Settings.HAND_SIZE >= 3)
                selected_index = 3;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[3]) && Settings.HAND_SIZE >= 4)
                selected_index = 4;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[4]) && Settings.HAND_SIZE >= 5)
                selected_index = 5;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[5]) && Settings.HAND_SIZE >= 6)
                selected_index = 6;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[6]) && Settings.HAND_SIZE >= 7)
                selected_index = 7;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[7]) && Settings.HAND_SIZE >= 8)
                selected_index = 8;
            else if (Input.GetKey(Settings.KEYS_ABILITIES[8]) && Settings.HAND_SIZE >= 9)
                selected_index = 9;
        }

        private void FixedUpdate()
        {
            if (selected_index > 0)
            {
                bg = ability_boxes[selected_index - 1];
                button = bg.GetComponent<Button>();
                button.Select();
            }
            else if (selected_index == 0)
            {
                // Set to class special
                button = special.GetComponent<Button>();
                button.Select();
            }
            else if (selected_index == -1)
                // Set to basic, no active ability
                event_system.SetSelectedGameObject(null);
            
        }

        #endregion

    }
}