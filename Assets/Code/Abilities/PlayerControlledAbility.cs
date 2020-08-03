using UnityEngine;

/*
 * This code handles player input to set targets for and use abilities.
 * Targeting/aim is selected through mouse/touch input.
 */

namespace Abilities
{
    public class PlayerControlledAbility : AbilityUser
    {
        #region MonoBehavior

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            
        }

        protected override Transform SetTarget(TargetType target_type, bool show_area)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}