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

    private float _despawnDistance;

    private List<GameObject> _spawnedEnemies = new List<GameObject>();

    public int checkPerFrame;
    private int _enemyToCheck;

    public List<WaveInfo> waves;

    private int _currentWave;
    private float _waveCounter;

    void Start()
    {
        _spawnCounter = timeToSpawn;
        _target = HealthManager.Instance.transform;

        _despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;

        _currentWave = -1;
        GoToNextWave();
    }
    
    void Update()
    {
        SpawningEnemy();
    }

    public void SpawningEnemy()
    {
        /*_spawnCounter -= Time.deltaTime;
        if (_spawnCounter <= 0)
        {
            _spawnCounter = timeToSpawn;
            //Instantiate(enemyToSpawn, transform.position, transform.rotation);
            GameObject newEnemy = Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);
            _spawnedEnemies.Add(newEnemy);
        }*/
        if (HealthManager.Instance.gameObject.activeSelf)
        {
            if (_currentWave < waves.Count)
            {
                _waveCounter -= Time.deltaTime;
                if (_waveCounter <= 0)
                {
                    GoToNextWave();
                }

                _spawnCounter -= Time.deltaTime;
                if (_spawnCounter <= 0)
                {
                    _spawnCounter = waves[_currentWave].timeBetweenSpawn;
                    GameObject newEnemy = Instantiate(waves[_currentWave].enemyToSpawn, SelectSpawnPoint(),
                        Quaternion.identity);
                    _spawnedEnemies.Add(newEnemy);
                }
            }
        }

        transform.position = _target.position;

        int checkTarget = _enemyToCheck + checkPerFrame;
        while (_enemyToCheck < checkTarget)
        {
            if (_enemyToCheck < _spawnedEnemies.Count)
            {
                if (_spawnedEnemies[_enemyToCheck] != null)
                {
                    if (Vector3.Distance(transform.position, _spawnedEnemies[_enemyToCheck].transform.position) >
                        _despawnDistance)
                    {
                        Destroy(_spawnedEnemies[_enemyToCheck]);
                        _spawnedEnemies.RemoveAt(_enemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        _enemyToCheck++;
                    }
                }
                else
                {
                    _spawnedEnemies.RemoveAt(_enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                _enemyToCheck = 0;
                checkTarget = 0;
            }
        }
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

    public void GoToNextWave()
    {
        _currentWave++;
        if (_currentWave >= waves.Count)
        {
            _currentWave = waves.Count - 1;
            
        }

        _waveCounter = waves[_currentWave].waveLength;
        _spawnCounter = waves[_currentWave].timeBetweenSpawn;
    }
}
[System.Serializable]
public class WaveInfo
{
    public GameObject enemyToSpawn;
    public float waveLength= 10f;
    public float timeBetweenSpawn = 1f;
}
