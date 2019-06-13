using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    bool bIsSpawning = false;
    public bool enemyAlife = false;

    void FixedUpdate()
    {
        if (bIsSpawning == false && enemyAlife == false && VerwijderScript.alife == true)
        {
            bIsSpawning = true;
            enemyAlife = true;
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position,Quaternion.identity);
        bIsSpawning = false;
        VerwijderScript.alife = true;

        if (VerwijderScript.alife == true)
        {
            VerwijderScript.alife = false;
            enemyAlife = false;

        }
    }
}
