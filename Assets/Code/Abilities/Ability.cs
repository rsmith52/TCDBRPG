using UnityEngine;

/*
 * This code defines the base class for all abilities, including those activated
 * by cards, class ability, and enemies.
 */

namespace Abilities
{
    public abstract class Ability : ScriptableObject
    {
        #region ScriptableObject

        protected new string name = "Ability Name";
        protected string description = "Ability Description";
        protected Sprite icon = null;

        #endregion

    }
}