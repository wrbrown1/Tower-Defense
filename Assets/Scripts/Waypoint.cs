using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isPlaceable = true;
    bool hasTower = false;
    TowerFactory towerFactory;

    private void Start()
    {
        towerFactory = GameObject.FindObjectOfType<TowerFactory>();
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / 10f),
            Mathf.RoundToInt(transform.position.z / 10f)
            );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable && !hasTower)
        {
            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        if (towerFactory.towersPlaced < towerFactory.maxTowers)
        {
            hasTower = true;
            Tower newTower = towerFactory.CreateTower(transform.position);
            newTower.SetWaypoint(this);
            towerFactory.towersPlaced++;
        }
        else
        {
            print("Max towers placed.");
        }
    }
}
