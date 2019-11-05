using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to handle the grid and traversion through it
public class Pathfinder : MonoBehaviour
{

    List<Waypoint> path = new List<Waypoint>();
    Waypoint searchCenter;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

        //Array of coordinates that can be referenced for the purpose of movement
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while(previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    //Algorithm for finding a path from start to finish (Breadth first search)
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            CheckIfArrived();
            ExploreNeighbours();
        }
    }

        //Compare the current search location to the endpoint - if they are the same, stop running
    private void CheckIfArrived()
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
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbors(explorationCoordinates);
            }
        }
    }

        //Method to queue neighbours that haven't been explored
    private void QueueNewNeighbors(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        { 
            //do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
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
