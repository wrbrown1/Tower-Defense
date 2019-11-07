using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] Collider collisionMesh;
    public int health;

    private void Awake()
    {
        EnemySpawner enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
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
        health = health - 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
