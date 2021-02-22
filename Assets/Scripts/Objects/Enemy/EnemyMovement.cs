using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : BaseMovement
{
    [SerializeField] int damage = 1; // state?
    [SerializeField] ParticleSystem attackVfx;
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

        StartCoroutine(FollowPath(path, Attack));
    }

    private void Attack()
    {
        ParticleSystem vfx = Instantiate(attackVfx, transform.position, Quaternion.identity);
        Destroy(vfx.gameObject, 2f);
        Destroy(gameObject);
        GameManager.Instance.UpdateHealth(-damage);
    }

}