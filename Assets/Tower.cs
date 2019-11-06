using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectPan;
    [SerializeField] Transform targetEnemy;

    private void Start()
    {
        
    }
    void Update()
    {
        objectPan.LookAt(targetEnemy);
    }
}
