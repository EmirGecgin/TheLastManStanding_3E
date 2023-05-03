using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject enemyToSpawn;
    private float _spawnCounter;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private Transform minSpawn, maxSpawn;

    private Transform _target;
    
    void Awake()
    {
        _spawnCounter = timeToSpawn;
        _target = HealthManager.Instance.transform;

    }
    
    void Update()
    {
        SpawningEnemy();
    }

    public void SpawningEnemy()
    {
        _spawnCounter -= Time.deltaTime;
        if (_spawnCounter <= 0)
        {
            _spawnCounter = timeToSpawn;
            //Instantiate(enemyToSpawn, transform.position, transform.rotation);
            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);
        }

        transform.position = _target.position;
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;
        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }  
        }

        return spawnPoint;
    }
}
