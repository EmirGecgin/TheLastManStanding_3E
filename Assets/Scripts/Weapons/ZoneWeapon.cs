using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWeapon : Weapon
{
    private float _spawnTime;
    private float _spawnCounter;
    public EnemyDamager damager;

    private void Start()
    {
        SetStats();
    }

    private void Update()
    {
        if (statsUpdated)
        {
            statsUpdated = false;
            SetStats();
        }

        _spawnCounter -= Time.deltaTime;
        if (_spawnCounter <= 0f)
        {
            _spawnCounter = _spawnTime;
            Instantiate(damager,damager.transform.position,Quaternion.identity,transform).gameObject.SetActive(true);
            SFXManager.instance.PlaySfxPitched(10);
        }
    }

    public void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;
        damager.lifeTime = stats[weaponLevel].duration;
        damager.timeBetweenDamage = stats[weaponLevel].speed;
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;
        _spawnTime = stats[weaponLevel].timeBetweenAttacks;

        _spawnCounter = 0f;
    }
}
