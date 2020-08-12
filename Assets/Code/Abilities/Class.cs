using System.Collections.Generic;
using UnityEngine;

/*
 * This code defines a character class.
 */

namespace Abilities
{
    #region Enums

    public enum Role
    {
        Striker,
        Tank,
        Controller,
        Support
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
        protected Role suggested_role = Role.Striker;

        [Header("Abilities")]
        [SerializeField]
        public Weapon weapon = null;
        [SerializeField]
        protected Ability class_special = null;

        [Header("Themes")]
        [SerializeField]
        public List<string> themes = new List<string>();

        #endregion

    }
}