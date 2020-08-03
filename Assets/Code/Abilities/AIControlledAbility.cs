using UnityEngine;

/*
 * This code handles player input to set targets for and use abilities.
 * Targeting/aim is selected through basic AI decisions.
 */

namespace Abilities
{
    public class AIControlledAbility : AbilityUser
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