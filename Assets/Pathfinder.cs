using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to handle the grid and traversion through it
public class Pathfinder : MonoBehaviour
{

    //The dictionary object allows us to keep track of each grid space via key reference
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    //Allows specification of start and end points in the Unity editor
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    //Queue datastructure filled with waypoints
    Queue<Waypoint> queue = new Queue<Waypoint>();

    //Boolean to determine if the algorithm needs to continue running
    bool isRunning = true;

    //Array of coordinates that can be referenced for the purpose of movement
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        FindAPath();
        //ExploreNeighbours();
    }

    //Algorithm for finding a path from start to finish (Breadth first search)
    private void FindAPath()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            CheckIfArrived(searchCenter);
        }
    }

    //Compare the current search location to the endpoint - if they are the same, stop running
    private void CheckIfArrived(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Pathfinding has finished.");
            isRunning = false;
        }
    }

    //Sets the color of the blocks adjacent to the start position to blue
    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetSurfaceColor(Color.blue);
            }
            catch
            {
                Debug.Log("Cannot explore in all directions.");
            }
        }
    }

    //Simple method to identify the start and end points in the Unity editor
    void ColorStartAndEnd()
    {
        startWaypoint.SetSurfaceColor(Color.green);
        endWaypoint.SetSurfaceColor(Color.red);
    }

    //Populates the dictionary with all blocks currently on the grid
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>(); //Finds EVERY active object of the type specified that is currently loaded
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping block" + waypoint.name);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                waypoint.SetSurfaceColor(Color.black);
            }
        }
    }

}
