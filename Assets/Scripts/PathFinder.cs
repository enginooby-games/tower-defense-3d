using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
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
}
