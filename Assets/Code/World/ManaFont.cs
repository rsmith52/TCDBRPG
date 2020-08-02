using System.Collections.Generic;
using UnityEngine;
using Stats;
using Utilities;

/*
 * This code defines a mana font, a location in which players regain mana.
 */

namespace World
{
    public class ManaFont : MonoBehaviour
    {
        #region Inspector

        [Header("Relations")]
        [SerializeField]
        protected new Collider collider;

        [SerializeField]
        protected GameObject mana_ring;

        #endregion


        #region Fields

        protected List<Collider> characters;
        protected float ring_size;

        #endregion


        #region MonoBehavior

        private void Start()
        {
            characters = new List<Collider>();
        }

        void Update()
        {
            foreach (Collider character in characters)
            {
                GameObject obj = character.gameObject;
                CharacterStats stats = obj.GetComponent<CharacterStats>();
                GameObject ring = obj.transform.Find(Constants.MANA_RING_NAME).gameObject;

                // Update mana ring size
                if (stats.mana.GetCurValue() != stats.mana.GetValue())
                {
                    ring_size = (Settings.MANA_GAIN_RATE - (Time.time - stats.mana_time)) * Constants.MANA_RING_SIZE / Settings.MANA_GAIN_RATE;
                }
                else
                {
                    ring_size = 0f;
                }
                ring.transform.localScale = new Vector3(ring_size, ring_size, 0);

                // Add mana if enough time has passed
                if (Time.time - stats.mana_time >= Settings.MANA_GAIN_RATE)
                {
                    stats.mana.ChangeCurValue(1);
                    stats.mana_time = Time.time;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject obj = other.gameObject;
            CharacterStats stats = obj.GetComponent<CharacterStats>();
            if (stats != null && !characters.Contains(other) && obj.layer == Constants.PLAYER_LAYER)
            {
                characters.Add(other);
                stats.mana_time = Time.time;
                GameObject ring = Instantiate(mana_ring, obj.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            GameObject obj = other.gameObject;
            CharacterStats stats = obj.GetComponent<CharacterStats>();
            if (stats != null && obj.layer == Constants.PLAYER_LAYER)
            {
                characters.Remove(other);
                stats.mana_time = 0f;
                GameObject ring = obj.transform.Find(Constants.MANA_RING_NAME).gameObject;
                GameObject.Destroy(ring);
            }
        }

        #endregion

    }
}
