using System;
using UnityEngine;

/*
 * This code defines modifiers that are used to alter stats. A modifier simply
 * has 2 parts: a name and a value. When stats are calculated, all set modifiers
 * are added to the base stat value. Modifiers to metered stats should be
 * integer values.
 */

namespace Stats
{
    [System.Serializable]
    public class Modifier
    {
        #region Fields

        [SerializeField]
        protected string name = "Modifier Name";

        [SerializeField]
        protected float value = 0f;

        #endregion


        #region Constructor

        public Modifier(string name, float value)
        {
            this.name = name;
            this.value = value;
        }

        #endregion


        #region Methods

        public float GetValue()
        {
            return value;
        }

        // Used for metered stats
        public int GetRoundedValue()
        {
            return (int)Math.Round(value);
        }

        #endregion

    }
}