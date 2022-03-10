using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;


    public bool enemyAlife = false;

    private int counter = 0;

    void FixedUpdate()
    {
        if (!enemyAlife)
        {
            enemyAlife = true;
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {

        Debug.Log("COUNTER SPAWN: " + counter);

            GameObject spawnedEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        spawnedEnemy.GetComponent<VliegEnemyScript>().SpawnerReference = this;
              enemyAlife = true;

        counter++;
    }
}
