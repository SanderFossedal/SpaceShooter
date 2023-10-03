using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy_Spawn : MonoBehaviour
{
    //public GameObject enemyPrefab; // The enemy prefab to spawn
    //public GameObject bossPrefab; // The boss prefab to spawn
    public int enemyCount;
    private int randomInt;
    public float spawnInterval = 1f; // The interval between enemy spawns
    public float initialDelay = 0f; // The initial delay before spawning starts
    public String enemyName;

    public static event Action enemySpawnFinished;

    private void Start()
    {
        // Invoke the SpawnEnemy function repeatedly at the specified interval, with an initial delay
        randomInt = Random.Range(20, 25);
        InvokeRepeating("SpawnEnemy", initialDelay, spawnInterval);
        Debug.Log(randomInt);
    }

    private void SpawnEnemy()
    {
        // Calculate the spawn position at the top of the screen
        Vector2 spawnPosition = new Vector2(Random.Range(-3f, 3f), 5.6f);

        // Instantiate the enemy prefab at the spawn position
        //Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Instantiate(Resources.Load(enemyName) as GameObject, spawnPosition, Quaternion.identity);
    }

    //private void spawnBoss()
    //{
    //    if (isSpawned == false)
    //    {
    //        isSpawned = true;
    //        Instantiate(bossPrefab, new Vector2(0, 0), Quaternion.identity);
    //    }
        
    //}

    private void Update()
    {
        endSpawning();
    }

    private void endSpawning()
    {
        if (enemyCount >= randomInt)
        {
            CancelInvoke();
            //spawnBoss();
            enemySpawnFinished?.Invoke();
        }
    }

    private void OnEnable()
    {
        EnemyHandler.onDeath += addCount;
    }

    private void OnDisable()
    {
        EnemyHandler.onDeath -= addCount;
    }

    public void addCount()
    {
        enemyCount++;
        
    }
}
