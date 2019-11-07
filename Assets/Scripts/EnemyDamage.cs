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
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        health = health - 5;
        if (health <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
}
