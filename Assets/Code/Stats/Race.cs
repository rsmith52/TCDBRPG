using UnityEngine;
using Utilities;

/*
 * This code defines a character race.
 */

namespace Stats
{
    [CreateAssetMenu(fileName = "Race", menuName = "Data/Race", order = 4)]
    public class Race : ScriptableObject
    {
        #region ScriptableObject

        [Header("General")]
        [SerializeField]
        public new string name = "Race Name";
        [SerializeField]
        [TextArea]
        public string description = "Race Description";
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