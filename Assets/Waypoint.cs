using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public bool isExplored = false;
    public Waypoint exploredFrom;
    //How far appart each grid peice is from one another
    const int gridSize = 10;

    //Grid coordinates
    Vector2Int gridPos;

    //Method allows the grid size to be used but not changed outside of this script
    public int GetGridSize()
    {
        return gridSize;
    }

    //Method allows the coordinates of the block to be used but not changed outside of this script
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / 10f),
            Mathf.RoundToInt(transform.position.z / 10f)
            );
    }

    //Allows waypoint object to change colors
    public void SetSurfaceColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
