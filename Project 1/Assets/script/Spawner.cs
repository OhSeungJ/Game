using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Wave[] waves;
    public Enemy enemy;
    Wave currentWave;
    int currentWaveNumber;
    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if(enemiesRemainingToSpawn>0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath; // Enemy가 죽으면 실행되는 것 그래서 event문 사용 Spawner가 event를 계속 구독하고 있다고 생각하면 됨.
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;
        
        if(enemiesRemainingAlive==0)
        {
            NextWave();
        }
    }
    
    void NextWave()
    {
        currentWaveNumber++;
        print("Wave: " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
