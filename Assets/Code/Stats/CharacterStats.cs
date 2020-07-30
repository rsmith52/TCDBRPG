using UnityEngine;

namespace Stats
{
    public class CharacterStats : MonoBehaviour
    {
        #region Stats

        [Header("Stats")]
        public Stat speed;

        #endregion


        #region MeteredStats

        [Header("Metered Stats")]
        public MeteredStat health;
        public MeteredStat mana;

        #endregion

    }
}