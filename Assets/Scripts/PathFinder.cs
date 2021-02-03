using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        startWaypoint.SetColor(Color.black);
        endWaypoint.SetColor(Color.magenta);
        ExploreNeighbours(startWaypoint);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int pointCoord = waypoint.GetCoord();
            if (grid.ContainsKey(pointCoord))
            {
                print("Overlapped block at coord: " + pointCoord);
            }
            else
            {
                grid.Add(pointCoord, waypoint);
            }
        }

        print(grid.Count + " blocks loaded");
    }

    private void ExploreNeighbours(Waypoint waypoint)
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoord = waypoint.GetCoord() + direction;
            try
            {
                grid[neighbourCoord].SetColor(Color.gray);
            }
            catch (System.Exception)
            {
            }
        }
    }
}
