using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    [System.Serializable]
    public class Stat
    {
        #region Fields

        [SerializeField]
        protected int base_value = 0;

        // Can be negative or positive
        protected List<int> modifiers = new List<int>();

        #endregion


        #region Methods

        public int GetValue()
        {
            // Add all modifiers to base stat
            int ret_val = base_value;
            foreach (int i in modifiers)
            {
                ret_val += i;
            }
            return ret_val;
        }

        public void ChangeValue(int value)
        {
            if (value != 0)
            {
                base_value += value;
            }
        }

        public void AddModifier(int modifier)
        {
            if (modifier != 0)
            {
                modifiers.Add(modifier);
            }
        }

        public void RemoveModifier(int modifier)
        {
            if (modifier != 0)
            {
                modifiers.Remove(modifier);
            }
        }

        #endregion

    }
}
