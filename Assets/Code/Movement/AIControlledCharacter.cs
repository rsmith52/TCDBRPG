using System.Collections;
using UnityEngine;
using Pathfinding;

/*
 * This code handles movement for a character not being controlled by the
 * player. Using A* pathfinding the character will move along a set path.
 */

namespace Movement
{
    public class AIControlledCharacter : MovingCharacter
    {
        #region Inspector

        [Header("Path Finding")]
        [SerializeField]
        protected Transform target_pos;

        [SerializeField]
        protected Seeker seeker;

        #endregion


        #region MonoBehavior

        protected override void Start()
        {
            base.Start();
            // Start to calculate a new path to the targetPosition object, return the result to the OnPathComplete method.
            // Path requests are asynchronous, so when the OnPathComplete method is called depends on how long it
            // takes to calculate the path. Usually it is called the next frame.
            seeker.StartPath(transform.position, target_pos.position, OnPathComplete);
        }

        private void OnPathComplete(Path p)
        {
            Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        }

        #endregion

    }
}