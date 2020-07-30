using UnityEngine;

namespace Stats
{
    [System.Serializable]
    public class MeteredStat : Stat
    {
        #region Fields

        [SerializeField]
        private int cur_value;

        #endregion


        #region Methods

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
                if (cur_value > base_value)
                {
                    cur_value = base_value;
                }
            }
        }

        #endregion

    }
}
