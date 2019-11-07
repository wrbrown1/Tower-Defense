using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] Collider collisionMesh;
    [SerializeField] int health;
    

    private void Awake()
    {
        
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        Vector3 distance;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        health = health - 10;
        if (health <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
}
