using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public enum SpawnerState { Start,Hold,Spawn}
    public SpawnerState spawnerState;

    public GameObject[] normalEnemy;
    public GameObject[] specialEnemy;
    public Transform playerposition;

    public int waveCount = 1;
    public int countEnemy = 5;
    public int enemyCount;
    public float radius;
    public List<GameObject> listEnemy = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        playerposition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            startSpawn();

        CheckEnemyCount();
    }

    void CheckState()
    {
        switch (spawnerState)
        {
            case SpawnerState.Start: break;
            case SpawnerState.Hold: Invoke(nameof(nextWave), 10f); break;
            case SpawnerState.Spawn: SpawnEnemy(); break;
        }
    }

    void CheckEnemyCount()
    {
        if(listEnemy.Count <= 0 && spawnerState == SpawnerState.Spawn)
        {
            spawnerState = SpawnerState.Hold;
            CheckState();
        }
    }

    void nextWave()
    {
        waveCount++;
        startSpawn();
    }

    public void startSpawn()
    {
        spawnerState = SpawnerState.Spawn;
        CheckState();
    }

    public void SpawnEnemy()
    {
        int AllEnemy = countEnemy * waveCount;

        for(int i = 0; i < AllEnemy; i++)
        {
            float angle = (i + Random.Range(-10 , 10)) * 360f / AllEnemy;
            radius = Random.Range(30, 100);
            Vector3 spawnPosition = playerposition.position + Quaternion.Euler(0, angle, 0) * (Vector3.forward * radius);
            GameObject Enemy = Instantiate((i % 5 == 0) ? specialEnemy[Random.Range(0, specialEnemy.Length)] : normalEnemy[Random.Range(0, normalEnemy.Length)], spawnPosition, Quaternion.identity);
            listEnemy.Add(Enemy);
        }
    }

    public void EnemyDead(GameObject enemy)
    {
        if (!listEnemy.Contains(enemy))
            return;

        listEnemy.Remove(enemy);
    }
}
