using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : Weapon
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform fireballHolder,fireballToSpawn;

    [SerializeField] private float timeBetweenSpawn;
    private float _spawnCounter;
    public EnemyDamager damager;

    private void Start()
    {
        SetStats();
        //UIController.Instance.levelUpButtons[0].UpdateButtonDisplayFunc(this);
    }

    void Update()
    {
        fireballHolder.transform.rotation =
            Quaternion.Euler(0f, 0f, fireballHolder.transform.rotation.eulerAngles.z + 
                                     (rotationSpeed * Time.deltaTime * stats[weaponLevel].speed));

        _spawnCounter -= Time.deltaTime;
        if (_spawnCounter <= 0)
        {
            _spawnCounter = timeBetweenSpawn;
            
            Instantiate(fireballToSpawn,fireballToSpawn.position,fireballToSpawn.rotation,fireballHolder).gameObject.SetActive(true);
        }

        if (statsUpdated)
        {
            statsUpdated = false;
            SetStats();
        }
    }

    public void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;
        
        transform.localScale = Vector3.one * stats[weaponLevel].range;
        timeBetweenSpawn = stats[weaponLevel].timeBetweenAttacks;
        damager.lifeTime = stats[weaponLevel].duration;

        _spawnCounter = 0f;
    }
}
