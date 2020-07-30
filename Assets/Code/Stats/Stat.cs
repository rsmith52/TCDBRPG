using System.Collections.Generic;
using UnityEngine;

/* 
 * This code defines all stats used by various aspects of the game. A stat has
 * both a base value, and a "real value", where the real value takes into
 * account any modifiers affecting the stat. This is the value that is visible
 * in game, so GetValue() should always be used.
 */

namespace Stats
{
    [System.Serializable]
    public class Stat
    {
        #region Fields

        [SerializeField]
        protected float base_value = 1f;

        // Can be negative or positive
        protected List<Modifier> modifiers = new List<Modifier>();

        #endregion


        #region Methods

        public float GetValue()
        {
            // Add all modifiers to base stat
            float ret_val = base_value;
            foreach (Modifier modifier in modifiers)
            {
                ret_val += modifier.GetValue();
            }
            return ret_val;
        }

        public void ChangeBaseValue(float value)
        {
            {
                base_value += value;
            }
        }

        public void AddModifier(Modifier modifier)
        {
            {
                modifiers.Add(modifier);
            }
        }

        public void RemoveModifier(Modifier modifier)
        {
            {
                modifiers.Remove(modifier);
            }
        }

        #endregion

    }
}
