using UnityEngine;
using Stats;
using UI;
using Utilities;

/* 
 * This code contains the basic information and setup needed for a character
 * that can use abilities.
 */

namespace Abilities
{
    public class AbilityUser : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected AbilityAim ability_aim;

        [SerializeField]
        protected Ability slotted_ability;

        #endregion


        #region Fields
        #endregion


        #region MonoBehavior

        private void Start()
        {
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
        }

        #endregion

    }
}