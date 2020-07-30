using System;
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
    public class MeteredStat: Stat
    {
        #region Fields

        [SerializeField]
        private int cur_value = 1;

        #endregion


        #region Methods

        public new int GetValue()
        {
            // Add all modifiers to base stat
            int ret_val = (int)Math.Round(base_value);
            foreach (Modifier modifier in modifiers)
            {
                ret_val += modifier.GetRoundedValue();
            }
            return ret_val;
        }

        public int GetCurValue()
        {
            return cur_value;
        }

        public void ChangeCurValue(int value)
        {
            if (value != 0)
            {
                cur_value += value;

                // Ensure value doesn't exceed max
                if (cur_value > GetValue())
                {
                    cur_value = GetValue();
                }
            }
        }

        #endregion

    }
}
