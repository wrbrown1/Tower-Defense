using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 50f;
    [SerializeField] ParticleSystem projectileParticle;
    bool inRange = false;

    private void Start()
    {
        
    }
    void Update()
    {
        if (targetEnemy)
        {
            objectPan.LookAt(targetEnemy);
            CheckDistance();
            FireAtEnemy(inRange);
        }
        else
        {
            FireAtEnemy(false);
        }
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        if (distance <= attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    private void FireAtEnemy(bool inRange)
    {
        var emissionModule = projectileParticle.emission;
        if (inRange)
        {
            emissionModule.enabled = true;
        }
        else
        {
            emissionModule.enabled = false;
        }
    }
}
