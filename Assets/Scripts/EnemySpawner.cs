using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyPrefab2;
    [SerializeField] private Transform enemySpawnPointLeft;
    [SerializeField] private Transform enemySpawnPointRight;
    private int enemyPosition;
    private float spawnDelay;
    private int enemyCounter = 0;
    public static int numOfEnemies = 20;
    void Start()
    {
        WaitForNextSpawn();
    }

    void Update()
    {
        enemyPosition = Random.Range(0, 2);
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0 && enemyCounter < numOfEnemies)
        {
            if (enemyPosition == 0)
            {
                Instantiate(enemyPrefab, enemySpawnPointLeft.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefab2, enemySpawnPointRight.position, Quaternion.Euler(0, 180, 0));
            }
            enemyCounter++;
            WaitForNextSpawn();
        }
    }
    private void WaitForNextSpawn()
    {
        spawnDelay = 0.7f;
    }
}
