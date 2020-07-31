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
        protected Seeker seeker;

        [SerializeField]
        protected Transform target_pos;

        [SerializeField]
        protected float next_waypoint_distance = 0.3f;

        #endregion


        #region Fields

        private Path path;
        private int current_waypoint = 0;
        private bool reached_end_of_path;

        #endregion


        #region MonoBehavior

        protected override void Start()
        {
            base.Start();

            // OnPathComplete will be called every time a path is returned to
            // this seeker
            seeker.pathCallback += OnPathComplete;

            // Start to calculate a new path to the targetPosition object, return
            // the result to the OnPathComplete method.
            // Path requests are asynchronous, so when the OnPathComplete method
            // is called depends on how long it takes to calculate the path.
            // Usually it is called the next frame.
            seeker.StartPath(transform.position, target_pos.position);
        }

        public void Update()
        {
            if (path == null)
            {
                // We have no path to follow yet, so don't do anything
                return;
            }

            // Check in a loop if we are close enough to the current waypoint to switch to the next one.
            // We do this in a loop because many waypoints might be close to each other and we may reach
            // several of them in the same frame.
            reached_end_of_path = false;
            // The distance to the next waypoint in the path
            float distance_to_waypoint;
            while (true)
            {

                // If you want maximum performance you can check the squared distance instead to get rid of a
                // square root calculation. But that is outside the scope of this tutorial.
                distance_to_waypoint = Vector3.Distance(transform.position, path.vectorPath[current_waypoint]);
                if (distance_to_waypoint < next_waypoint_distance)
                {
                    // Check if there is another waypoint or if we have reached the end of the path
                    if (current_waypoint + 1 < path.vectorPath.Count)
                    {
                        current_waypoint++;
                    }
                    else
                    {
                        // Set a status variable to indicate that the agent has reached the end of the path.
                        // You can use this to trigger some special code if your game requires that.
                        reached_end_of_path = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            // Slow down smoothly upon approaching the end of the path
            // This value will smoothly go from 1 to 0 as the agent approaches the last waypoint in the path.
            var speedFactor = reached_end_of_path ? Mathf.Sqrt(distance_to_waypoint / next_waypoint_distance) : 1f;

            // Direction to the next waypoint
            // Normalize it so that it has a length of 1 world unit
            Vector3 dir = (path.vectorPath[current_waypoint] - transform.position).normalized;
            // Multiply the direction by our desired speed to get a velocity
            movement = dir * speed * speedFactor;
        }

        private void OnPathComplete(Path p)
        {
            if (!p.error)
            {
                path = p;
                // Reset the waypoint counter so that we start to move towards the first point in the path
                current_waypoint = 0;
            }
        }

        private void OnDisable()
        {
            seeker.pathCallback -= OnPathComplete;
        }

        #endregion

    }
}