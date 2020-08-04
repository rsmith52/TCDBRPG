using UnityEngine;
using Utilities;

/*
 * This code defines a character race.
 */

namespace Stats
{
    #region Enums
    #endregion


    [CreateAssetMenu(fileName = "Race", menuName = "Data/Race", order = 1)]
    public class Race : ScriptableObject
    {
        #region ScriptableObject

        [Header("General")]
        [SerializeField]
        public readonly new string name = "Race Name";
        [SerializeField]
        [TextArea]
        public readonly string description = "Race Description";
        [SerializeField]
        public Sprite icon = null;

        [Header("Stats")]
        [SerializeField]
        public Stat speed = new Stat(Settings.BASE_SPEED);
        [SerializeField]
        public MeteredStat health = new MeteredStat(Settings.BASE_HEALTH, Settings.BASE_HEALTH);
        [SerializeField]
        public MeteredStat mana = new MeteredStat(Settings.BASE_MANA, 0);

        #endregion

    }
}