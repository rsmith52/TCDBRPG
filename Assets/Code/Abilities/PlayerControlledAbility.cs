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

        protected override Transform TargetArea()
        {
            throw new System.NotImplementedException();
        }

        protected override Transform TargetDirection()
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}