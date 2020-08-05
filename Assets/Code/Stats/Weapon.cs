using UnityEngine;
using Abilities;

/*
 * This code defines a weapon.
 */

namespace Stats
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/Weapon", order = 5)]
    public class Weapon : ScriptableObject
    {
        #region ScriptableObject

        [Header("General")]
        [SerializeField]
        protected new string name = "Weapon Name";
        [SerializeField]
        [TextArea]
        protected string description = "Weapon Description";
        [SerializeField]
        protected Sprite img = null;

        [Header("Mechanics")]
        [SerializeField]
        protected float range = 1f;
        [SerializeField]
        protected int damage = 1;

        #endregion

    }
}