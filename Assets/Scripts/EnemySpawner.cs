using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemy;
    Vector3 spawnLocation = new Vector3(0f, 0f, 0f);

    void Start()
    {
        StartCoroutine(SpawnEnemies(spawnLocation));
    }

    IEnumerator SpawnEnemies(Vector3 spawnLocation)
    {
        while(true)
        {
            GameObject newEnemy = Instantiate(enemy, spawnLocation, Quaternion.identity);
            enemy = newEnemy;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }       
    }
}
