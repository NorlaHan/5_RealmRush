using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector3Int, Waypoint> grid = new Dictionary<Vector3Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; 

    Vector3Int[] directions = {
        new Vector3Int(0,0,1) ,
        new Vector3Int(1,0,0),
        new Vector3Int(0,0,-1),
        new Vector3Int(-1,0,0)
    };

    // Start is called before the first frame update
    void Start()
    {
        //if (startWaypoint == endWaypoint)
        //{
        //    Debug.LogWarning("Start and End are the same, process terminated");
        //    return;
        //}

        LoadBlocks();
        ColorStartAndEnd();
        //ExploreNeighbor();
        PathFinding();
    }

    private void PathFinding()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from " + searchCenter);    // TODO remove log
            HaltIfEndFound(searchCenter);
            ExploreNeighbor(searchCenter);
        }
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (startWaypoint == endWaypoint)
        {
            Debug.LogWarning("Start and End are the same, process terminated"); // TODO remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbor(Waypoint from)
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector3Int direction in directions)
        {
            //print(direction);

            Vector3Int neighborCoordinates = from.GetGridPos() + direction;

            try
            {
                print("Exploring" + neighborCoordinates);
                Waypoint neighbor = grid[neighborCoordinates];
                neighbor.SetTopColor(Color.blue);       //TODO move later
                queue.Enqueue(neighbor);
                print("Queueing " + neighbor);
            }
            catch
            {
                //Do nothing
            }            
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
            var gridPos = waypoint.GetGridPos();
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
