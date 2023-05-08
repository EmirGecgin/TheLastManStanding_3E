using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform fireballHolder,fireballToSpawn;

    [SerializeField] private float timeBetweenSpawn;
    private float _spawnCounter;
    

    
    void Update()
    {
        fireballHolder.transform.rotation =
            Quaternion.Euler(0f, 0f, fireballHolder.transform.rotation.eulerAngles.z + (rotationSpeed * Time.deltaTime));

        _spawnCounter -= Time.deltaTime;
        if (_spawnCounter <= 0)
        {
            _spawnCounter = timeBetweenSpawn;
            
            Instantiate(fireballToSpawn,fireballToSpawn.position,fireballToSpawn.rotation,fireballHolder).gameObject.SetActive(true);
        }
    }
}
