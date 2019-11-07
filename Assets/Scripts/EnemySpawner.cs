using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyDamage enemy;
    [SerializeField] Transform enemyParentTransform;
    Vector3 spawnLocation = new Vector3(0f, 0f, 0f);
    public List<EnemyDamage> enemies = new List<EnemyDamage>();

    void Start()
    {
        StartCoroutine(SpawnEnemies(spawnLocation));
    }

    IEnumerator SpawnEnemies(Vector3 spawnLocation)
    {
        while(true)
        {
            EnemyDamage newEnemy = Instantiate(enemy, spawnLocation, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            enemies.Add(newEnemy);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }       
    }
}
