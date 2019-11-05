using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
    }

    void ColorStartAndEnd()
    {
        startWaypoint.SetSurfaceColor(Color.green);
        endWaypoint.SetSurfaceColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
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
        print("Loaded" + grid.Count + "blocks");
    }

    void Update()
    {
        
    }
}
