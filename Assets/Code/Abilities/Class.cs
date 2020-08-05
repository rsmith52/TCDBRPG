using UnityEngine;

/*
 * This code defines a character class.
 */

namespace Abilities
{
    [CreateAssetMenu(fileName = "Class", menuName = "Data/Class", order = 3)]
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
        public Weapon weapon = null;
        [SerializeField]
        protected Ability class_special = null;

        #endregion

    }
}