using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

/*
 * This code contains the basic setup and information for a character that can
 * use abilities.
 */

namespace Abilities
{
    public class AbilityUser : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected GameObject character = null;

        #endregion


        #region Fields
        #endregion


        #region MonoBehavior

        public void UseAbility()
        {

        }

        #endregion

    }
}