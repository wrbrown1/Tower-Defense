using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem damageEffect;
    [SerializeField] ParticleSystem lowHealthEffect;
    [SerializeField] ParticleSystem deathEffect;
    public int health;
    bool lowHealth = false;


    private void Awake()
    {
        EnemySpawner enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
    }

    private void Update()
    {

    }

    private void CheckHealth()
    {
        if(health < 10)
        {
            lowHealth = true;
            StartSparking();
        }
        else
        {
            lowHealth = false;
        }
    }

    private void StartSparking()
    {
        var emissionModule = lowHealthEffect.emission;
        emissionModule.enabled = true;   
    }

    private void OnParticleCollision(GameObject other)
    {
        CheckHealth();
        ShowDamageEffect();
        ProcessHit();
    }

    private void ProcessHit()
    {
        health = health - 1;
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void ShowDamageEffect()
    {
        Instantiate(damageEffect, transform.position + new Vector3(0, 5, 0), Quaternion.identity);
    }
}
