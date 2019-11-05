using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code runs even when the games isn't in "play mode"
[ExecuteInEditMode]

//When you click an object with this on it, it will be the selection base
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
   
    Waypoint waypoint;

    //Gets the waypoint connected to the block
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    //Snaps the block to the grid size with editing - useful for developers
    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }

    //Causes the textmesh on each block to be relivant against the block's position
    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>(); //Searches the gameobject and its children for a textmesh
        string spot = waypoint.GetGridPos().x + ", " + waypoint.GetGridPos().y;
        textMesh.text = spot;
        gameObject.name = spot;
    }
}
