using UnityEngine;
using System.Collections.Generic;
using Stats;
using Utilities;

/*
 * This code handles behavior for the heads up display, including player
 * health and mana bars.
 */

namespace UI
{
    public class HUD : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected CharacterStats character_stats;

        // Health Bar Parts
        [SerializeField]
        protected GameObject health_bar_segment;
        [SerializeField]
        protected GameObject health_bar_cap;
        [SerializeField]
        protected GameObject health_bar_fill;
        [SerializeField]
        protected GameObject health_bar_cap_fill;

        // Mana Bar Parts
        [SerializeField]
        protected GameObject mana_bar_segment;
        [SerializeField]
        protected GameObject mana_bar_cap;
        [SerializeField]
        protected GameObject mana_bar_fill;
        [SerializeField]
        protected GameObject mana_bar_cap_fill;

        #endregion


        #region Fields

        private List<GameObject> health_segments;
        private int health_total;
        private List<GameObject> mana_segments;
        private int mana_total;
        private RectTransform rect_transform;

        #endregion


        #region MonoBehavior

        protected void Start()
        {
            // Setup health bar
            health_total = character_stats.health.GetValue();
            for (int i = 0; i < health_total; i++)
            {
                GameObject segment;
                GameObject fill;
                if (i == health_total - 1)
                {
                    segment = Instantiate(health_bar_cap);
                    fill = Instantiate(health_bar_cap_fill);
                }
                else
                {
                    segment = Instantiate(health_bar_segment);
                    fill = Instantiate(health_bar_fill);
                }
                fill.transform.SetParent(transform);
                segment.transform.SetParent(fill.transform);
                rect_transform = fill.GetComponent<RectTransform>();
                rect_transform.anchoredPosition = new Vector3(Constants.HUD_X_OFFSET + i * Constants.HP_SPACING, Constants.HP_Y_OFFSET, 0);
            }

            // Setup mana bar
            mana_total = character_stats.mana.GetValue();
            for (int i = 0; i < mana_total; i++)
            {
                GameObject segment;
                GameObject fill;
                if (i == mana_total - 1)
                {
                    segment = Instantiate(mana_bar_cap);
                    fill = Instantiate(mana_bar_cap_fill);
                }
                else
                {
                    segment = Instantiate(mana_bar_segment);
                    fill = Instantiate(mana_bar_fill);
                }
                fill.transform.SetParent(transform);
                segment.transform.SetParent(fill.transform);
                fill.transform.SetParent(transform);
                segment.transform.SetParent(fill.transform);
                rect_transform = fill.GetComponent<RectTransform>();
                rect_transform.anchoredPosition = new Vector3(Constants.HUD_X_OFFSET + i * Constants.MANA_SPACING, Constants.MANA_Y_OFFSET, 0);
            }
        }

        protected void Update()
        {
            
        }

        #endregion

    }
}