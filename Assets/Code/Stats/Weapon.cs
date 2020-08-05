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
        public new string name = "Weapon Name";
        [SerializeField]
        [TextArea]
        public string description = "Weapon Description";
        [SerializeField]
        public Sprite sprite = null;

        [Header("Mechanics")]
        [SerializeField]
        public TargetType target = TargetType.Melee;
        [SerializeField]
        public float range = 1f; // Hitbox size for melee
        [SerializeField]
        public int damage = 1;

        #endregion

    }
}