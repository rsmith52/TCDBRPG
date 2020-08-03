using UnityEngine;
using System.Collections.Generic;
using Stats;
using Utilities;
using UnityEngine.UI;

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
        private int cur_health;
        private List<GameObject> mana_segments;
        private int mana_total;
        private int cur_mana;
        private RectTransform rect_transform;

        #endregion


        #region MonoBehavior

        public void Start()
        {
            // Setup health bar
            health_segments = new List<GameObject>();
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
                health_segments.Add(fill);
            }

            // Setup mana bar
            mana_segments = new List<GameObject>();
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
                mana_segments.Add(fill);
            }
        }

        private void Update()
        {
            cur_health = character_stats.health.GetCurValue();
            cur_mana = character_stats.mana.GetCurValue();

            // Redraw bars if total amounts change
            if (health_total != character_stats.health.GetValue())
            {
                RedrawHealth();
            }
            if (mana_total != character_stats.mana.GetValue())
            {
                RedrawMana();
            }
        }

        private void FixedUpdate()
        {
            // Update health bar
            for (int i = 0; i < health_segments.Count; i++)
            {
                Image img;
                img = health_segments[i].GetComponent<Image>();
                Color temp_color = img.color;
                if (i < cur_health)
                {
                    temp_color.a = 1f;
                }
                else
                {
                    temp_color.a = 0f;
                }
                img.color = temp_color;
            }

            // Update mana bar
            for (int i = 0; i < mana_segments.Count; i++)
            {
                Image img;
                img = mana_segments[i].GetComponent<Image>();
                Color temp_color = img.color;
                if (i < cur_mana)
                {
                    temp_color.a = 1f;
                }
                else
                {
                    temp_color.a = 0f;
                }
                img.color = temp_color;
            }
        }

        private void RedrawHealth()
        {
            // Destroy existing health bar
            for (int i = 0; i < health_segments.Count; i++)
            {
                GameObject.Destroy(health_segments[i]);
            }

            // Setup health bar
            health_segments = new List<GameObject>();
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
                health_segments.Add(fill);
            }
        }

        private void RedrawMana()
        {
            // Destroy existing mana bar
            for (int i = 0; i < mana_segments.Count; i++)
            {
                GameObject.Destroy(mana_segments[i]);
            }

            // Setup mana bar
            mana_segments = new List<GameObject>();
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
                mana_segments.Add(fill);
            }
        }

        #endregion

    }
}