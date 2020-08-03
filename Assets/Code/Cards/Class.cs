using UnityEngine;

/*
 * This code defines a character class.
 */

namespace Cards
{
    #region Enums

    public enum Role
    {
        Tank,
        Damage,
        Speed,
        Caster,
        Support
    }

    #endregion


    [CreateAssetMenu(fileName = "Class", menuName = "Data/Class", order = 1)]
    public class Class : ScriptableObject
    {
        #region ScriptableObject

        protected new string name = "Class Name";
        protected string description = "Class Description";
        protected Sprite img = null;

        protected Role role = Role.Tank;

        #endregion

    }
}