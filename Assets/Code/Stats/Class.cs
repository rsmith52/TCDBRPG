using UnityEngine;
using Abilities;
using Cards;

/*
 * This code defines a character class.
 */

namespace Stats
{
    #region Enums

    public enum Role
    {
        Tank,
        Damage,
        Speed,
        Caster,
        Support,
        Special
    }

    #endregion


    [CreateAssetMenu(fileName = "Class", menuName = "Data/Class", order = 1)]
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
        [SerializeField]
        protected Role role = Role.Tank;

        [Header("Abilities")]
        [SerializeField]
        protected Ability class_basic = null;
        [SerializeField]
        protected Ability class_special = null;

        #endregion

    }
}