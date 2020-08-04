using System;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Extending from normal stat, a metered stat treats the base value as a max
 * and can have anywhere from 0 to that max at a given time for the current
 * value. These stats are used for things like health and mana, and always
 * viewed as integers.
 */

namespace Stats
{
    [System.Serializable]
    public class MeteredStat : Stat
    {
        #region Fields

        [SerializeField]
        private int cur_value;

        #endregion


        #region Constructor

        public MeteredStat()
        {
            base_value = 0f;
            cur_value = (int)base_value;
            modifiers = new List<Modifier>();
        }

        public MeteredStat(float base_value)
        {
            this.base_value = base_value;
            cur_value = (int)base_value;
            modifiers = new List<Modifier>();
        }

        public MeteredStat(float base_value, int cur_value)
        {
            this.base_value = base_value;
            this.cur_value = cur_value;
            modifiers = new List<Modifier>();
        }

        #endregion


        #region Methods

        public new int GetValue()
        {
            // Add all modifiers to base stat
            float ret_val = base_value;
            foreach (Modifier modifier in modifiers)
                ret_val += modifier.GetRoundedValue();
            return (int)ret_val;
        }

        public int GetCurValue()
        {
            return cur_value;
        }

        public void ChangeCurValue(int value)
        {
            cur_value += value;

            // Ensure value doesn't exceed max
            if (cur_value > GetValue())
                cur_value = GetValue();
        }

        #endregion

    }
}