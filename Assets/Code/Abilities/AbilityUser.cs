using System.Collections.Generic;
using UnityEngine;
using Stats;

/*
 * This code contains the basic setup and information for a character that can
 * use abilities.
 */

namespace Abilities
{
    public enum State
    {
        Waiting,
        Targeting,
        Activating
    };

    public abstract class AbilityUser : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected GameObject character = null;

        [SerializeField]
        protected CharacterStats stats = null;

        [SerializeField]
        protected Ability ability = null;

        #endregion


        #region Structs

        protected struct SetAbility
        {
            public Ability ability;
            public GameObject target_view;
            public List<GameObject> squares;
        }

        #endregion


        #region Fields

        protected State state;
        protected TargetType target_type;
        protected float activation_time_waited;
        protected SetAbility ability_in_activation;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            target_type = TargetType.None;
            state = State.Waiting;
        }

        protected virtual void Update()
        {
            if (state == State.Activating)
                activation_time_waited += Time.deltaTime;
        }

        protected virtual void FixedUpdate()
        {
            if (state == State.Activating && activation_time_waited >= ability.activation_time)
            {
                state = State.Waiting;
                UseAbility(ability_in_activation);
            }
        }

        protected void StartAbility(SetAbility set_ability)
        {
            Debug.Log("Ability started " + set_ability.ability.name);
            // Show animation on user
        }

        private void UseAbility(SetAbility set_ability)
        {
            // Remove mana
            stats.mana.ChangeCurValue(-1 * set_ability.ability.mana_cost);

            // Perform ability
            Debug.Log("Used ability " + set_ability.ability.name);

            // Show animation on target

            // Cleanup targeting
            foreach (GameObject square in set_ability.squares)
            {
                GameObject.Destroy(square);
            }
            GameObject.Destroy(set_ability.target_view);
        }

        protected void CancelAbility()
        {
            // Cleanup targeting
            foreach (GameObject square in ability_in_activation.squares)
            {
                GameObject.Destroy(square);
            }
            GameObject.Destroy(ability_in_activation.target_view);
            state = State.Waiting;
        }

        protected bool DistanceInRange(Vector3 other_pos, float range)
        {
            // Ignore y component so height on map doesn't get taken into account
            Vector3 player_pos = new Vector3(transform.position.x, 0, transform.position.z);
            other_pos = new Vector3(other_pos.x, 0, other_pos.z);

            Vector3 offset = other_pos - player_pos;
            float sqlen = offset.sqrMagnitude;

            return sqlen <= range * range;
        }

        #endregion

    }
}