using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : BaseMovement
{
    private void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var waypoints = pathfinder.GetPath();

        // TODO: generic
        // extract transform list from waypoint list
        List<Transform> path = new List<Transform>();
        foreach (Waypoint waypoint in waypoints)
        {
            path.Add(waypoint.transform);
        }

        StartCoroutine(FollowPath(path));
    }

}