using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector3Int, Waypoint> grid = new Dictionary<Vector3Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true; // For stopping pathfing. when the end is reached.

    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    // Prevent infinity loop
    [SerializeField] int exploreCount = 1;
    public int exploreLimit = 3;

    Vector3Int[] directions = {
        new Vector3Int(0,0,1) ,     // up
        new Vector3Int(1,0,0),      // right
        new Vector3Int(0,0,-1),     // down
        new Vector3Int(-1,0,0)      // left
    };


    void Awake()        // TODO maybe happens when the path is asked?
    {
        LoadBlocks();       // Count all the blocks into the distionary.
        ColorStartAndEnd(); // Mark out the start and End.
    }

    public List<Waypoint> GetPath() {
        BreadFirstSearch();
        CreatPath();
        return path;
    }

    private void CreatPath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint) {
            // Add intermediate waypoints
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        // Add startWaypoint
        path.Add(startWaypoint);

        // Reverse the list
        path.Reverse();
    }

    private void BreadFirstSearch()
    {
        queue.Enqueue(startWaypoint);   // put startWaypoint in queue.
        while (queue.Count > 0 && isRunning && exploreCount <= exploreLimit)
        {
            Debug.LogWarning("Exploration " + exploreCount + ". (Max explaration is " + exploreLimit + ")");
            exploreCount++;     // prevent infinity loop.

            print(queue.Count + " waiting in queue.");
            searchCenter = queue.Dequeue();         // remove from queue and start explore.
            searchCenter.isExplored = true;
            
            print("===== Searching from " + searchCenter.name + searchCenter.GetGridPos() + " =====");    // TODO remove log
            //HaltIfEndFound();
            ExploreNeighbor();
        }

        // TODO Work out path.
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            Debug.LogWarning("End point found, process terminated"); // TODO remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbor()
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector3Int direction in directions)
        {
            //print(direction);

            Vector3Int neighborKey = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighborKey))
            {
                QueueNewNeighbor(neighborKey);
            }
            else
            {
                Debug.LogWarning("Neighbor with key " + neighborKey + " do not exit.");
            }
        }
    }

    private void QueueNewNeighbor(Vector3Int neighborKey)
    {

        print("Exploring" + grid[neighborKey].name + neighborKey);

        Waypoint neighbor = grid[neighborKey];

        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            Debug.LogWarning(neighbor + " has been explored or already in queue.");
        }
        else
        {
            neighbor.exploredFrom = searchCenter;

            if (neighbor == endWaypoint)
            {
                neighbor.SetTopColor(Color.yellow);
                Debug.LogWarning("End point found, process terminated"); // TODO remove log
                isRunning = false;
                return;
            }
            neighbor.SetTopColor(Color.blue);       //TODO move later
            queue.Enqueue(neighbor);                // put found neighbor in queue.
            
            print("Queueing " + neighbor);
        }
    }
    

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            //Is there any overlapping Blocks?
            var gridPos = waypoint.GetGridPos();    // the key is the compressed vector3
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else
            {
                //Add to dictionary
                grid.Add(gridPos, waypoint);    
                waypoint.SetTopColor(Color.gray);
            }
        }
        //print("Loaded " + grid.Count + " block(s)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
