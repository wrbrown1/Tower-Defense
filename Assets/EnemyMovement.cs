using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //Specify a path in the Unity editor
    [SerializeField] List<Waypoint> path;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    //IEnumerator will be covered later - makes the enemy follow the path specified in the Unity editor
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

}
