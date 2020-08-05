using UnityEngine;
using System.Collections.Generic;
using Stats;
using Utilities;
using UnityEngine.UI;

/*
 * This code handles behavior for the minimap.
 */

namespace UI
{
    public class Minimap : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected Image border = null;

        [SerializeField]
        protected Image mask_image = null;

        [SerializeField]
        protected Mask mask = null;

        [SerializeField]
        protected RawImage map = null;

        #endregion


        #region Fields

        private bool show_map;
        private bool key_pressed;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            show_map = Settings.MINIMAP_START_VISIBLE;
            if (!show_map)
                HideMap();
            key_pressed = false;
        }

        private void Update()
        {
            if (!key_pressed && Input.GetKeyDown(Settings.KEY_MAP_TOGGLE))
            {
                ToggleMapVisibility();
                key_pressed = true;
            }
            if (key_pressed && Input.GetKeyUp(Settings.KEY_MAP_TOGGLE))
                key_pressed = false;
        }

        private void ToggleMapVisibility()
        {
            if (show_map)
                HideMap();
            else
                ShowMap();
        }

        private void HideMap()
        {
            border.enabled = false;
            mask_image.enabled = false;
            mask.enabled = false;
            map.enabled = false;
            show_map = false;
        }

        private void ShowMap()
        {
            border.enabled = true;
            mask_image.enabled = true;
            mask.enabled = true;
            map.enabled = true;
            show_map = true;
        }

        #endregion

    }
}