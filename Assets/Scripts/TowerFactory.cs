using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    public int maxTowers = 3;
    Waypoint waypoint;
    public int towersPlaced = 0;
    [SerializeField] Tower towerPrefab;

    public Tower CreateTower(Vector3 location)
    {
        Tower newTower = Instantiate(towerPrefab, location, Quaternion.identity);
        return newTower;
    }

}
