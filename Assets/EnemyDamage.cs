using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] Collider collisionMesh;
    [SerializeField] int health;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Collision detected");
        health = health - 10;
        if(health <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }

}
