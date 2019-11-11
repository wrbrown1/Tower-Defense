using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectPan;
    [SerializeField] float attackRange = 50f;
    [SerializeField] ParticleSystem projectileParticle;
    bool inRange = false;
    public Waypoint towerWaypoint;

    //State of each tower
    Transform targetEnemy;

    public void SetWaypoint(Waypoint waypoint)
    {
        towerWaypoint = waypoint;
    }
    void Update()
    {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        EnemyDamage[] sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform closestEnemy, Transform testEnemy)
    {
        float closestDistance = Vector3.Distance(closestEnemy.position, gameObject.transform.position);
        float otherDistance = Vector3.Distance(testEnemy.position, gameObject.transform.position);
        if (closestDistance > otherDistance){
            return testEnemy;
        }
        else
        {
            return closestEnemy;
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
