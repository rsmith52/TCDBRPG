using UnityEngine;
using Utilities;

/*
 * This code defines the stats every character will have, split between
 * regular stats and metered stats. PlayerStats and MonsterStats extend from
 * this. Receiving damage is also handled here.
 */

namespace Stats
{
    public abstract class CharacterStats : MonoBehaviour
    {
        #region General Info

        [Header("General")]
        [SerializeField]
        protected new string name = "Name";

        #endregion


        #region Stats

        [Header("Stats")]
        public Stat speed;

        [HideInInspector]
        public Stat jump_force = new Stat(Settings.BASE_JUMP);

        #endregion


        #region MeteredStats

        [Header("Metered Stats")]
        public MeteredStat health;
        public MeteredStat mana;
        public float mana_time { get; set; }

        #endregion


        #region MonoBehavior

        public void Damage(int damage)
        {
            // Apply damage
            health.ChangeCurValue(-1 * damage);

            // Show damaged animation
            Animator animator = GetComponentInChildren<Animator>();
            animator.SetTrigger(Constants.WAS_HIT_PROPERTY);
        }

        #endregion

    }
}