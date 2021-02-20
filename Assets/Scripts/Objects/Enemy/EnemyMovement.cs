using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float waypointDwellTime = 1f;

    private void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();

        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            // wait until enemy moves to next waypoint
            yield return StartCoroutine(MoveTowardsWaypoint(waypoint));
            // dwell on a waypoint for a little while
            yield return new WaitForSeconds(waypointDwellTime);
        }
    }

    private IEnumerator MoveTowardsWaypoint(Waypoint waypoint)
    {
        while (transform.position != waypoint.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, speed * Time.timeScale);

            // wait until next frame
            yield return null;
        }
    }
}