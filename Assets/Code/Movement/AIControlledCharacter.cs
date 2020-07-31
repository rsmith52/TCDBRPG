using UnityEngine;
using Pathfinding;
using System;
using Utilities;

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
        protected Transform target;

        [SerializeField]
        protected float next_waypoint_distance = 1.5f;

        [SerializeField]
        protected float repath_rate = 0.5f;

        [SerializeField]
        protected float wait_before_start = 0;
        
        #endregion


        #region Fields

        private Path path = null; // current path to follow
        private int current_waypoint = 0; // current waypoint index
        private bool reached_end_of_path;
        private float last_repath = float.NegativeInfinity;
        private float time_started = 0;
        private float speed_factor;

        #endregion


        #region MonoBehavior

        public void Update()
        {
            if (Time.time > last_repath + repath_rate && seeker.IsDone())
            {
                last_repath = Time.time;

                // Start a new path to the targetPosition, call the the OnPathComplete function
                // when the path has been calculated (which may take a few frames depending on the complexity)
                seeker.StartPath(transform.position, target.position);
            }

            if (path == null || Time.time < time_started + wait_before_start)
            {
                // We have no path to follow yet, so we do nothing
                // or we wait a certain amount of time before starting the movement
                // or the total path distance is shorter than the set min path distance
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
            speed_factor = reached_end_of_path ? 0f : 1f;

            // Direction to the next waypoint
            // Normalize it so that it has a length of 1 world unit
            movement = ((path.vectorPath[current_waypoint] - transform.position).normalized) * speed_factor;

            // Update Animator
            animator.SetBool(Constants.WALK_PROPERTY,
                             Math.Abs(movement.sqrMagnitude) > Mathf.Epsilon);
        }

        private void OnPathComplete(Path p)
        {
            Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

            // Path pooling. To avoid unnecessary allocations paths are reference counted.
            // Calling Claim will increase the reference count by 1 and Release will reduce
            // it by one, when it reaches zero the path will be pooled and then it may be used
            // by other scripts. The ABPath.Construct and Seeker.StartPath methods will
            // take a path from the pool if possible. See also the documentation page about path pooling.
            p.Claim(this);
            if (!p.error)
            {
                if (path != null) path.Release(this);
                path = p;
                // Reset the waypoint counter so that we start to move towards the first point in the path
                current_waypoint = 0;
            }
            else
            {
                p.Release(this);
            }
        }

        private void OnDisable()
        {
            seeker.pathCallback -= OnPathComplete;
            // Update Animator
            movement = new Vector3(0, 0, 0);
            animator.SetBool(Constants.WALK_PROPERTY,
                             Math.Abs(movement.sqrMagnitude) > Mathf.Epsilon);
        }

        private void OnEnable()
        {
            // Reset fields
            path = null;
            current_waypoint = 0;
            reached_end_of_path = false;
            last_repath = float.NegativeInfinity;
            time_started = Time.time;

            // OnPathComplete will be called every time a path is returned to
            // this seeker
            seeker.pathCallback += OnPathComplete;
        }

        #endregion

    }
}