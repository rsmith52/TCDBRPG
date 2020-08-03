using UnityEngine;
using Abilities;
using Cards;

/*
 * This code defines a character class.
 */

namespace Stats
{
    #region Enums
    #endregion


    [CreateAssetMenu(fileName = "Class", menuName = "Data/Class", order = 2)]
    public class Class : ScriptableObject
    {
        #region ScriptableObject

        [Header("General")]
        [SerializeField]
        protected new string name = "Class Name";
        [SerializeField]
        [TextArea]
        protected string description = "Class Description";
        [SerializeField]
        protected Sprite icon = null;

        [Header("Abilities")]
        [SerializeField]
        protected Ability class_basic = null;
        [SerializeField]
        protected Ability class_special = null;

        #endregion

    }
}