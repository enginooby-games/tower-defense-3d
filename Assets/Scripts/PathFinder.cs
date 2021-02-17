using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
    bool isRunning = true;
    // Waypoint currentSearchPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            BFS();
            CreatePath();
        }
        return path;
    }

    private void BFS()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            Waypoint searchCenter = queue.Dequeue();
            if (searchCenter == endWaypoint)
            {
                print("Finish BFS");
                isRunning = false;
            }
            else
            {
                ExploreNeighbours(searchCenter);
            }
        }
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previousWaypoint = endWaypoint.exploreFrom;
        while (previousWaypoint != startWaypoint)
        {
            path.Add(previousWaypoint);
            previousWaypoint = previousWaypoint.exploreFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
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
        waypoint.isExplored = true;
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoord = waypoint.GetCoord() + direction;
            if (grid.ContainsKey(neighbourCoord))
            {
                Waypoint neighbour = grid[neighbourCoord];
                neighbour.SetColor(Color.gray);
                if (!neighbour.isExplored && !queue.Contains(neighbour))
                {
                    queue.Enqueue(neighbour);
                    neighbour.exploreFrom = waypoint;
                }
            }

        }
    }
}
